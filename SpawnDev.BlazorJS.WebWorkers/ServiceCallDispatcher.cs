using Microsoft.Extensions.DependencyInjection;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JSObjects.WebRTC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.WebWorkers
{
    //public class MethodCallParams : BaseMessage
    //{
    //    public interface IExpressionSerializer
    //    {
    //        string Serialize(Expression expr);

    //        Expression Deserialize(string exprString);
    //    }
    //    public class WebWorkerOptions
    //    {
    //        private ISerializer messageSerializer;
    //        private IExpressionSerializer expressionSerializer;

    //        public ISerializer MessageSerializer
    //        {
    //            get => messageSerializer ?? (messageSerializer = new DefaultMessageSerializer());
    //            set => messageSerializer = value;
    //        }

    //        public IExpressionSerializer ExpressionSerializer
    //        {
    //            get => expressionSerializer ?? (expressionSerializer = new SerializeLinqExpressionSerializer());
    //            set => expressionSerializer = value;
    //        }
    //    }
    //    public MethodCallParams()
    //    {
    //        MessageType = nameof(MethodCallParams);
    //    }
    //    private readonly WebWorkerOptions options;

    //    public bool AwaitResult { get; set; }
    //    public long InstanceId { get; set; }
    //    public string SerializedExpression { get; set; }
    //    public long WorkerId { get; set; }
    //    public long CallId { get; set; }
    //}
    //private class InvokeOptions
    //{
    //    public static readonly InvokeOptions Default = new InvokeOptions();

    //    public bool AwaitResult { get; set; }
    //}

    //private async Task<TResult> InvokeAsyncInternal<TResult>(Expression action, InvokeOptions invokeOptions)
    //{
    //    // If Blazor ever gets multithreaded this would need to be locked for race conditions
    //    // However, when/if that happens, most of this project is obsolete anyway
    //    var (id, taskCompletionSource) = this.messageRegister.CreateAndAdd();

    //    var expression = this.options.ExpressionSerializer.Serialize(action);
    //    var methodCallParams = new MethodCallParams
    //    {
    //        AwaitResult = invokeOptions.AwaitResult,
    //        WorkerId = this.worker.Identifier,
    //        InstanceId = instanceId,
    //        SerializedExpression = expression,
    //        CallId = id
    //    };

    //    var methodCall = this.options.MessageSerializer.Serialize(methodCallParams);

    //    await this.worker.PostMessageAsync(methodCall);

    //    var returnMessage = await taskCompletionSource.Task;
    //    if (returnMessage.IsException)
    //    {
    //        throw new AggregateException($"Worker exception: {returnMessage.Exception.Message}", returnMessage.Exception);
    //    }
    //    if (string.IsNullOrEmpty(returnMessage.ResultPayload))
    //    {
    //        return default;
    //    }

    //    return this.options.MessageSerializer.Deserialize<TResult>(returnMessage.ResultPayload);
    //}
    internal class WebWorkerCallMessageTask
    {
        public Type? ReturnValueType { get; set; }
        public string RequestId => webWorkerCallMessageOutgoing.RequestId;
        public Action<JSObject?>? OnComplete { get; set; }
        public CancellationToken? CancellationToken { get; set; }
        public WebWorkerCallMessageOutgoing webWorkerCallMessageOutgoing { get; set; }
        public WebWorkerCallMessageTask(Action<JSObject?>? onComplete)
        {
            OnComplete = onComplete;
        }
    }
    public class ServiceCallDispatcher
    {
        public static List<Type> _transferableTypes { get; } = new List<Type> {
            typeof(ArrayBuffer),
            typeof(MessagePort),
            typeof(ReadableStream),
            typeof(WritableStream),
            typeof(TransformStream),
            typeof(AudioData),
            typeof(ImageBitmap),
            typeof(VideoFrame),
            typeof(OffscreenCanvas),
            typeof(RTCDataChannel),
        };
        public static bool IsTransferable(Type type) => _transferableTypes.Contains(type);
        public static bool IsTransferable<T>() => _transferableTypes.Contains(typeof(T));
        public static bool IsTransferable<T>(T obj) => _transferableTypes.Contains(typeof(T));
        public MessagePort _port { get; set; }
        Dictionary<string, WebWorkerCallMessageTask> _waiting = new Dictionary<string, WebWorkerCallMessageTask>();
        protected IServiceProvider _serviceProvider;

        public ServiceCallDispatcher(IServiceProvider serviceProvider, MessagePort port)
        {
            _serviceProvider = serviceProvider;
            _port = port;
            _port.OnMessage += _worker_OnMessage;
            _port.OnError += _port_OnError;
        }

        private void _port_OnError()
        {
            JS.Log("_port_OnError");
        }

        public bool RecevdInit { get; private set; }
        private TaskCompletionSource<int> _oninit = new TaskCompletionSource<int>();
        public Task WhenReady => _oninit.Task;
        public void SendReadyFlag()
        {
            _port.PostMessaage(new WebWorkerCallMessageBase { MethodName = "__init" });
        }
        protected async void _worker_OnMessage(MessageEvent e)
        {
            JSObject? args = null;
            try
            {
                var msgBase = e.GetData<WebWorkerCallMessageBase>();
                if (msgBase.MethodName == "__")
                {
                    Console.WriteLine("ping --__--");
                }
                else if (msgBase.MethodName == "__init")
                {
                    if (!RecevdInit)
                    {
                        RecevdInit = true;
                        _oninit.TrySetResult(0);
                    }
                }
                else if (msgBase.MethodName == "__callback" && !string.IsNullOrEmpty(msgBase.RequestId))
                {
                    if (_waiting.TryGetValue(msgBase.RequestId, out var req))
                    {
                        _waiting.Remove(msgBase.RequestId);
                        try
                        {
                            args = e.JSRef.Get<JSObject?>("data.args");
                        }
                        catch { }
                        req.OnComplete(args);
                    }
                }
                else if (!string.IsNullOrEmpty(msgBase.ServiceTypeFullName) && !string.IsNullOrEmpty(msgBase.MethodName))
                {
                    //Console.WriteLine($"msgBase.MethodName: {msgBase.ServiceTypeFullName}::{msgBase.MethodName}");
                    try
                    {
                        args = e.JSRef.Get<JSObject?>("data.args");
                    }
                    catch { }
                    var argsLength = args != null ? args.JSRef.Get<int>("length") : 0;
                    var serviceType = Type.GetType(msgBase.ServiceTypeFullName);
                    var service = _serviceProvider.GetService(serviceType);
                    var methodInfo = GetBestInstanceMethod(serviceType, msgBase.MethodName, argsLength);
                    var methodsParamTypes = methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
                    var returnType = methodInfo.ReturnType;
                    var returnTypeIsVoid = typeof(void) == returnType;
                    var returnTypeName = returnType.Name;
                    var isTask = typeof(Task).IsAssignableFrom(methodInfo.ReturnType);
                    var isValueTask = typeof(ValueTask).IsAssignableFrom(methodInfo.ReturnType);
                    var isAwaitable = isTask || isValueTask;
                    Type? returnTypeOfTheTask = isTask || isValueTask ? returnType.GetGenericArguments().FirstOrDefault() : typeof(void);
                    var returnTypeOfTheTaskIsVoid = typeof(void) == returnTypeOfTheTask;
                    var returnTypeOfTheTaskName = returnTypeOfTheTask.Name;
                    var finalReturnType = isTask || isValueTask ? returnTypeOfTheTask : returnType;
                    var finalReturnTypeIsVoid = finalReturnType == typeof(void);
                    var callArgs = new object?[argsLength];
                    for (var i = 0; i < argsLength; i++)
                    {
                        var argtype = methodsParamTypes[i];
                        var argv = args.JSRef.Get(argtype, i);
                        callArgs[i] = argv;
                    }
                    var retv = methodInfo.Invoke(service, callArgs);
                    object? retValue = null;
                    var hasReturnValue = (isValueTask && !returnTypeOfTheTaskIsVoid) || (isTask && !returnTypeOfTheTaskIsVoid) || (!returnTypeIsVoid && !isTask && !isValueTask);
                    if (retv is Task t)
                    {
                        await t;
                        if (returnTypeOfTheTask != typeof(void))
                        {
                            retValue = returnType.GetProperty("Result").GetValue(retv, null);
                        }
                    }
                    else if (retv is ValueTask vt)
                    {
                        await vt;
                        if (returnTypeOfTheTask != typeof(void))
                        {
                            retValue = returnType.GetProperty("Result").GetValue(retv, null);
                        }
                    }
                    else if (!returnTypeIsVoid)
                    {
                        retValue = retv;
                    }
                    if (!string.IsNullOrEmpty(msgBase.RequestId))
                    {
                        // send notification of completeion is there is a requestid
                        var callbackMsg = new WebWorkerCallMessageOutgoing { MethodName = "__callback", RequestId = msgBase.RequestId };
                        if (hasReturnValue) callbackMsg.Args = new object[] { retValue };
                        // TODO - use attributes on the methodinfo to determine what, if any, should be transferred  (vs copied)
                        _port.PostMessaage(callbackMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                JS.Log("ERROR: ", e);
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            finally
            {
                args?.Dispose();
            }
        }
        //
        public Task<object?> InvokeAsync(Type serviceType, string methodName, params object?[]? args) => CallAsync(serviceType, methodName, args ?? new object[0]);
        public Task<object?> CallAsync(Type serviceType, string methodName, object?[]? args = null)
        {
            var argsLength = args != null ? args.Length : 0;
            var methodInfo = GetBestInstanceMethod(serviceType, methodName, argsLength);
            var methodsParamTypes = methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
            var returnType = methodInfo.ReturnType;
            var returnTypeIsVoid = typeof(void) == returnType;
            var returnTypeName = returnType.Name;
            var isTask = typeof(Task).IsAssignableFrom(methodInfo.ReturnType);
            var isValueTask = typeof(ValueTask).IsAssignableFrom(methodInfo.ReturnType);
            var isAwaitable = isTask || isValueTask;
            Type? returnTypeOfTheTask = isTask || isValueTask ? returnType.GetGenericArguments().FirstOrDefault() : typeof(void);
            var returnTypeOfTheTaskIsVoid = typeof(void) == returnTypeOfTheTask;
            var returnTypeOfTheTaskName = returnTypeOfTheTask.Name;
            var finalReturnType = isTask || isValueTask ? returnTypeOfTheTask : returnType;
            var finalReturnTypeIsVoid = finalReturnType == typeof(void);
            var workerMsg = new WebWorkerCallMessageOutgoing
            {
                RequestId = Guid.NewGuid().ToString(),
                MethodName = methodName,
                ServiceTypeFullName = serviceType.FullName,
                Args = args,
            };
            //var reqTypeName = typeof(TResult).Name;
            var fnRetTypeName = finalReturnType.Name;
            var t = new TaskCompletionSource<object?>();
            var workerTask = new WebWorkerCallMessageTask((args) =>
            {
                var argsLength = args != null ? args.JSRef.Get<int>("length") : 0;
                object? arg0 = argsLength == 1 ? (object?)args.JSRef.Get(finalReturnType, 0) : null;
                t.TrySetResult(arg0);
            });
            workerTask.ReturnValueType = finalReturnType;
            workerTask.webWorkerCallMessageOutgoing = workerMsg;
            _waiting.Add(workerTask.RequestId, workerTask);
            _port.PostMessaage(workerMsg);
            return t.Task;
        }
        public Task<TResult> InvokeAsync<TService, TResult>(string methodName, params object?[]? args) => CallAsync<TService, TResult>(methodName, args ?? new object[0]);
        public Task<TResult> CallAsync<TService, TResult>(string methodName, object?[]? args = null)
        {
            var argsLength = args != null ? args.Length : 0;
            var serviceType = typeof(TService);
            var methodInfo = GetBestInstanceMethod(serviceType, methodName, argsLength);
            var methodsParamTypes = methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
            var returnType = methodInfo.ReturnType;
            var returnTypeIsVoid = typeof(void) == returnType;
            var returnTypeName = returnType.Name;
            var isTask = typeof(Task).IsAssignableFrom(methodInfo.ReturnType);
            var isValueTask = typeof(ValueTask).IsAssignableFrom(methodInfo.ReturnType);
            var isAwaitable = isTask || isValueTask;
            Type? returnTypeOfTheTask = isTask || isValueTask ? returnType.GetGenericArguments().FirstOrDefault() : typeof(void);
            var returnTypeOfTheTaskIsVoid = typeof(void) == returnTypeOfTheTask;
            var returnTypeOfTheTaskName = returnTypeOfTheTask.Name;
            var finalReturnType = isTask || isValueTask ? returnTypeOfTheTask : returnType;
            var finalReturnTypeIsVoid = finalReturnType == typeof(void);
            var workerMsg = new WebWorkerCallMessageOutgoing
            {
                RequestId = Guid.NewGuid().ToString(),
                MethodName = methodName,
                ServiceTypeFullName = typeof(TService).FullName,
                Args = args,
            };
            var reqTypeName = typeof(TResult).Name;
            var fnRetTypeName = finalReturnType.Name;
            var t = new TaskCompletionSource<TResult>();
            if (typeof(TResult) != finalReturnType)
            {
#if DEBUG
                Console.WriteLine($"WARNING: Worker service {serviceType.Name} method {methodName} has a different return type {finalReturnType.Name} then the callee requested type {finalReturnType.Name}");
#endif
            }
            var workerTask = new WebWorkerCallMessageTask((args) =>
            {
                var argsLength = args != null ? args.JSRef.Get<int>("length") : 0;
                var arg0 = argsLength == 1 ? args.JSRef.Get<TResult>(0) : default(TResult);
                t.TrySetResult(arg0);
            });
            workerTask.ReturnValueType = finalReturnType;
            workerTask.webWorkerCallMessageOutgoing = workerMsg;
            _waiting.Add(workerTask.RequestId, workerTask);
            _port.PostMessaage(workerMsg);
            return t.Task;
        }
        public Task InvokeVoidAsync<TService>(string methodName, params object?[]? args) => CallVoidAsync<TService>(methodName, args ?? new object[0]);
        public Task CallVoidAsync<TService>(string methodName, object?[]? args = null)
        {
            var argsLength = args != null ? args.Length : 0;
            var serviceType = typeof(TService);
            var methodInfo = GetBestInstanceMethod(serviceType, methodName, argsLength);
            var methodsParamTypes = methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
            var returnType = methodInfo.ReturnType;
            var returnTypeIsVoid = typeof(void) == returnType;
            var returnTypeName = returnType.Name;
            var isTask = typeof(Task).IsAssignableFrom(methodInfo.ReturnType);
            var isValueTask = typeof(ValueTask).IsAssignableFrom(methodInfo.ReturnType);
            var isAwaitable = isTask || isValueTask;
            Type? returnTypeOfTheTask = isTask || isValueTask ? returnType.GetGenericArguments().FirstOrDefault() : typeof(void);
            var returnTypeOfTheTaskIsVoid = typeof(void) == returnTypeOfTheTask;
            var returnTypeOfTheTaskName = returnTypeOfTheTask.Name;
            var finalReturnType = isTask || isValueTask ? returnTypeOfTheTask : returnType;
            var finalReturnTypeIsVoid = finalReturnType == typeof(void);
            var workerMsg = new WebWorkerCallMessageOutgoing
            {
                RequestId = Guid.NewGuid().ToString(),
                MethodName = methodName,
                ServiceTypeFullName = typeof(TService).FullName,
                Args = args,
            };
            var reqTypeName = typeof(void).Name;
            var fnRetTypeName = finalReturnType.Name;
            var t = new TaskCompletionSource<int>();
            if (typeof(void) != finalReturnType)
            {
#if DEBUG
                Console.WriteLine($"WARNING: Worker service {serviceType.Name} method {methodName} has a different return type {typeof(void).Name} then the callee requested type {finalReturnType.Name}");
#endif
            }
            var workerTask = new WebWorkerCallMessageTask((args) =>
            {
                t.TrySetResult(0);
            });
            workerTask.ReturnValueType = finalReturnType;
            workerTask.webWorkerCallMessageOutgoing = workerMsg;
            _waiting.Add(workerTask.RequestId, workerTask);
            _port.PostMessaage(workerMsg);
            return t.Task;
        }
        private static Type AsyncStateMachineAttributeType = typeof(AsyncStateMachineAttribute);
        private static bool IsAsyncMethod(MethodInfo method) => method.GetCustomAttribute(AsyncStateMachineAttributeType) != null;
        private static MethodInfo? GetBestInstanceMethod<T>(string identifier, int paramCount, int genericsCount = 0, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance) => GetBestInstanceMethod(typeof(T), identifier, paramCount, genericsCount, bindingFlags);
        private static MethodInfo? GetBestInstanceMethod(Type classType, string identifier, int paramCount, int genericsCount = 0, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            MethodInfo? best = null;
            var instanceMethods = classType
            .GetMethods(bindingFlags)
            .Where(m => m.Name == identifier)
            .Where(m => (!m.IsGenericMethod && genericsCount == 0) || (m.IsGenericMethod && m.GetGenericArguments().Length == genericsCount))
            .Where(m => m.GetParameters().Length == paramCount)
            .ToList();
            if (instanceMethods.Count > 0)
            {
                best = instanceMethods[0];
            }
            return best;
        }
    }
}
