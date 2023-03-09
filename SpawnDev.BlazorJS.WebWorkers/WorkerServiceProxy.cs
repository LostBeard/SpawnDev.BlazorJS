using System.Reflection;

// https://devblogs.microsoft.com/dotnet/migrating-realproxy-usage-to-dispatchproxy/
namespace SpawnDev.BlazorJS.WebWorkers {
    public class WorkerServiceProxy<TServiceInterface> : DispatchProxy where TServiceInterface : class
    {
        internal ServiceCallDispatcher Worker { get; private set; }
        internal MethodInfo _InvokeTaskInfo;
        internal MethodInfo _InvokeValueTaskInfo;
        public WorkerServiceProxy() : base() {
            _InvokeTaskInfo = typeof(WorkerServiceProxy<TServiceInterface>).GetMethod(nameof(InvokeTask), BindingFlags.NonPublic | BindingFlags.Instance) ?? throw new Exception($"WorkerServiceProxy static constructor error");
            _InvokeValueTaskInfo = typeof(WorkerServiceProxy<TServiceInterface>).GetMethod(nameof(InvokeValueTask), BindingFlags.NonPublic | BindingFlags.Instance) ?? throw new Exception($"WorkerServiceProxy static constructor error");
        }

        public static TServiceInterface GetWorkerService(ServiceCallDispatcher worker) {
            var proxy = Create<TServiceInterface, WorkerServiceProxy<TServiceInterface>>() as WorkerServiceProxy<TServiceInterface>;
            proxy.Worker = worker;
            var ret = proxy as TServiceInterface;
            if (ret == null) throw new Exception("Failed to create interface proxy");
            return ret;
        }

        internal Task<TReturnType> InvokeTask<TReturnType>(MethodInfo targetMethod, object?[]? args) {
            var ttcs = new TaskCompletionSource<TReturnType>();
            Worker.CallAsync<TServiceInterface>(targetMethod.Name, args, (retExc, retVal) => {
                if (retExc != null) {
                    ttcs.TrySetException(retExc);
                }
                else {
                    var retValT = default(TReturnType);
                    if (retVal != null) retValT = (TReturnType)retVal;
                    ttcs.TrySetResult(retValT);
                }
            });
            return ttcs.Task;
        }

        internal ValueTask<TReturnType> InvokeValueTask<TReturnType>(MethodInfo targetMethod, object?[]? args) {
            return new ValueTask<TReturnType>(InvokeTask<TReturnType>(targetMethod, args));
        }

        internal Task InvokeTaskVoid(MethodInfo targetMethod, object?[]? args) {
            var taskSource = new TaskCompletionSource();
            Worker.CallAsync<TServiceInterface>(targetMethod.Name, args, (retExc, retVal) => {
                if (retExc != null) {
                    taskSource.TrySetException(retExc);
                }
                else {
                    taskSource.TrySetResult();
                }
            });
            return taskSource.Task;
        }

        internal ValueTask InvokeValueTaskVoid(MethodInfo targetMethod, object?[]? args) {
            return new ValueTask(InvokeTaskVoid(targetMethod, args));
        }

        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args) {
            if (targetMethod == null) return null;
            var returnType = targetMethod.ReturnType;
            var isTask = typeof(Task).IsAssignableFrom(targetMethod.ReturnType);
            var isValueTask = !isTask && typeof(ValueTask).IsAssignableFrom(targetMethod.ReturnType);
            Type finalReturnType;
            if (isTask || isValueTask) {
                finalReturnType = returnType.GetGenericArguments().FirstOrDefault() ?? typeof(void);
            }
            else {
                finalReturnType = returnType;
            }
            if (isTask) {
                if (finalReturnType == typeof(void)) {
                    return InvokeTaskVoid(targetMethod, args);
                }
                else {
                    return InvokeTaskTyped(finalReturnType, targetMethod, args);
                }
            }
            else if (isValueTask) {
                if (finalReturnType == typeof(void)) {
                    return InvokeValueTaskVoid(targetMethod, args);
                }
                else {
                    return InvokeValueTaskTyped(finalReturnType, targetMethod, args);
                }
            }
            throw new Exception("Worker service interface calls must return Task or ValueTask");
        }

        static Dictionary<Type, MethodInfo> InvokeValueTaskCache = new Dictionary<Type, MethodInfo>();
        MethodInfo? GetInvokeValueTaskGeneric(Type finalReturnType) {
            if (InvokeValueTaskCache.TryGetValue(finalReturnType, out var methodInfo)) return methodInfo;
            var InvokeTaskTypedG = _InvokeValueTaskInfo.MakeGenericMethod(finalReturnType);
            InvokeValueTaskCache[finalReturnType] = InvokeTaskTypedG;
            return InvokeTaskTypedG;
        }

        static Dictionary<Type, MethodInfo?> InvokeTaskCache = new Dictionary<Type, MethodInfo?>();
        MethodInfo? GetInvokeTaskGeneric(Type finalReturnType) {
            if (InvokeTaskCache.TryGetValue(finalReturnType, out var methodInfo)) return methodInfo;
            var InvokeTaskTypedG = _InvokeTaskInfo.MakeGenericMethod(finalReturnType);
            InvokeTaskCache[finalReturnType] = InvokeTaskTypedG;
            return InvokeTaskTypedG;
        }

        internal object? InvokeTaskTyped(Type type, MethodInfo targetMethod, object?[]? args) {
            var mi = GetInvokeTaskGeneric(type);
            return mi.Invoke(this, new object[] { targetMethod, args });
        }

        internal object? InvokeValueTaskTyped(Type type, MethodInfo targetMethod, object?[]? args) {
            var mi = GetInvokeValueTaskGeneric(type);
            return mi.Invoke(this, new object[] { targetMethod, args });
        }
    }
}
