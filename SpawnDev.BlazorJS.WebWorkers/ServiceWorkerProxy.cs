using System.Reflection;

// https://devblogs.microsoft.com/dotnet/migrating-realproxy-usage-to-dispatchproxy/
namespace SpawnDev.BlazorJS.WebWorkers {
    public class ServiceWorkerProxy<TServiceInterface> : DispatchProxy where TServiceInterface : class // T must be an interface
    {

        public ServiceCallDispatcher Worker { get; private set; }
        internal Type _proxyType;
        internal MethodInfo _InvokeTaskInfo;
        internal MethodInfo _InvokeValueTaskInfo;
        public ServiceWorkerProxy() : base() {
            _proxyType = this.GetType();
            _InvokeTaskInfo = typeof(ServiceWorkerProxy<TServiceInterface>).GetMethod(nameof(InvokeTask), BindingFlags.NonPublic | BindingFlags.Instance);
            _InvokeValueTaskInfo = typeof(ServiceWorkerProxy<TServiceInterface>).GetMethod(nameof(InvokeValueTask), BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public static TServiceInterface GetWorkerService(ServiceCallDispatcher worker) {
            var proxy = Create<TServiceInterface, ServiceWorkerProxy<TServiceInterface>>() as ServiceWorkerProxy<TServiceInterface>;
            proxy.Worker = worker;
            var ret = proxy as TServiceInterface;
            if (ret == null) throw new Exception("Failed to create interface proxy");
            return ret;
        }

        internal Task<TReturnType> InvokeTask<TReturnType>(MethodInfo? targetMethod, object?[]? args) {
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

        internal ValueTask<TReturnType> InvokeValueTask<TReturnType>(MethodInfo? targetMethod, object?[]? args) {
            var t = InvokeTask<TReturnType>(targetMethod, args);
            return new ValueTask<TReturnType>(t);
        }

        internal Task InvokeTaskVoid(MethodInfo? targetMethod, object?[]? args) {
            var ttcs = new TaskCompletionSource();
            Worker.CallAsync<TServiceInterface>(targetMethod.Name, args, (retExc, retVal) => {
                if (retExc != null) {
                    ttcs.TrySetException(retExc);
                }
                else {
                    ttcs.TrySetResult();
                }
            });
            return ttcs.Task;
        }

        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args) {
            var returnType = targetMethod.ReturnType;
            var isTask = typeof(Task).IsAssignableFrom(targetMethod.ReturnType);
            var isValueTask = typeof(ValueTask).IsAssignableFrom(targetMethod.ReturnType);
            Type returnTypeOfTheTask = (isTask || isValueTask) && returnType.GetGenericArguments().Any() ? returnType.GetGenericArguments().First() : typeof(void);
            //var returnTypeOfTheTaskIsVoid = typeof(void) == returnTypeOfTheTask;
            var finalReturnType = isTask || isValueTask ? returnTypeOfTheTask : returnType;
            var finalReturnTypeIsVoid = finalReturnType == typeof(void);
            //
            if (isTask) {
                if (finalReturnTypeIsVoid) {
                    return InvokeTaskVoid(targetMethod, args);
                }
                else {
                    var InvokeTaskTypedG = _InvokeTaskInfo.MakeGenericMethod(finalReturnType);
                    var ret = InvokeTaskTypedG.Invoke(this, new object[] { targetMethod, args });
                    return ret;
                }
            }
            else if (isValueTask) {
                if (finalReturnTypeIsVoid) {
                    return new ValueTask(InvokeTaskVoid(targetMethod, args));
                }
                else {
                    var InvokeTaskTypedG = _InvokeValueTaskInfo.MakeGenericMethod(finalReturnType);
                    var ret = InvokeTaskTypedG.Invoke(this, new object[] { targetMethod, args });
                    return ret;
                }
            }
            throw new Exception("Worker service interface calls must return Task or ValueTask");
        }
    }
    //public class TaskCompletionSourceTyped {
    //    static Type TCSTypedType = typeof(TaskCompletionSource<>);
    //    static Dictionary<Type, Type> _ttcsCache = new Dictionary<Type, Type>();
    //    static Type GetTypedTaskCompletionSource(Type returnType) {
    //        if (_ttcsCache.TryGetValue(returnType, out var result)) return result;
    //        var ret = TCSTypedType.MakeGenericType(returnType);
    //        _ttcsCache[returnType] = ret;
    //        return ret;
    //    }
    //    public static dynamic CreateTaskCompletionSourceTyped(Type returnType) {
    //        var TaskCompletionSourceType = GetTypedTaskCompletionSource(returnType);
    //        var ret = Activator.CreateInstance(TaskCompletionSourceType);
    //        return ret;
    //    }
    //}
    //public static class TaskCompletionSourceExtensions {
    //    public static void ttt<T>(this TaskCompletionSource<T> tcs) {
    //    }
    //}
}
