using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
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
using static SpawnDev.BlazorJS.WebWorkers.ServiceCallDispatcher;

namespace SpawnDev.BlazorJS.WebWorkers
{
    internal class WebWorkerCallMessageTask
    {
        public Type? ReturnValueType { get; set; }
        public string RequestId => webWorkerCallMessageOutgoing.RequestId;
        public Action<JSObject?>? OnComplete { get; set; }
        public CancellationToken? CancellationToken { get; set; }
        public WebWorkerMessageOut webWorkerCallMessageOutgoing { get; set; }
        public WebWorkerCallMessageTask(Action<JSObject?>? onComplete)
        {
            OnComplete = onComplete;
        }
    }
    public class ServiceCallDispatcher : IDisposable
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
            _port.PostMessaage(new WebWorkerMessageBase { TargetName = "__init" });
        }

        public delegate void OnMessageDelegate(ServiceCallDispatcher sender, WebWorkerMessageIn msg);
        public event OnMessageDelegate OnMessage;

        static Dictionary<string, Type?> typeCache = new Dictionary<string, Type>();

        /// <summary>
        /// For whatever reason Type.GetType was failing when trying to find a Type in the same assembly as this class... no idea why. Below code worked when it failed
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Type? GetType(string typeName)
        {
            Type? t = null;
            lock (typeCache)
            {
                if (!typeCache.TryGetValue(typeName, out t))
                {
                    foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        t = a.GetType(typeName);
                        if (t != null) break;
                    }
                    typeCache[typeName] = t;
                }
            }
            return t;
        }

        protected async void _worker_OnMessage(MessageEvent e)
        {
            JSObject? args = null;
            try
            {
                var msgBase = e.GetData<WebWorkerMessageIn>();
                msgBase._msg = e;
                if (msgBase.TargetName == "__")
                {
                    Console.WriteLine("ping --__--");
                }
                else if (msgBase.TargetName == "__init")
                {
                    if (!RecevdInit)
                    {
                        RecevdInit = true;
                        _oninit.TrySetResult(0);
                    }
                }
                else if (msgBase.TargetName == "__callback" && !string.IsNullOrEmpty(msgBase.RequestId))
                {
                    if (_waiting.TryGetValue(msgBase.RequestId, out var req))
                    {
                        _waiting.Remove(msgBase.RequestId);
                        try
                        {
                            args = msgBase.GetData<JSObject>();
                            //args = e.JSRef.Get<JSObject?>("data.args");
                        }
                        catch { }
                        req.OnComplete(args);
                    }
                }
                else if (msgBase.TargetType == "event" && !string.IsNullOrEmpty(msgBase.TargetName))
                {
                    OnMessage?.Invoke(this, msgBase);
                }
                else if (!string.IsNullOrEmpty(msgBase.TargetType) && !string.IsNullOrEmpty(msgBase.TargetName))
                {
                    //Console.WriteLine($"msgBase.MethodName: {msgBase.ServiceTypeFullName}::{msgBase.MethodName}");
                    try
                    {
                        args = msgBase.GetData<JSObject>();
                        //args = e.JSRef.Get<JSObject?>("data.args");
                    }
                    catch { }
                    var argsLength = args != null ? args.JSRef.Get<int>("length") : 0;
                    var serviceType = GetType(msgBase.TargetType);
                    if (serviceType == null)
                    {
                        throw new Exception($"ERROR: {nameof(ServiceCallDispatcher)} OnMessage - Service type not found {msgBase.TargetType}");// TODO - catch all errors and send to caller on other thread
                    }
                    object? service = null;
                    try
                    {
                        service = _serviceProvider.GetService(serviceType);
                    }
                    catch
                    {
                        throw new Exception($"ERROR: {nameof(ServiceCallDispatcher)} OnMessage - Service not registered {serviceType.FullName}");
                    }
                    var methodInfo = GetBestInstanceMethod(serviceType, msgBase.TargetName, argsLength);
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
                        var callbackMsg = new WebWorkerMessageOut { TargetName = "__callback", RequestId = msgBase.RequestId };
                        if (hasReturnValue) callbackMsg.Data = new object[] { retValue };
                        // TODO - use attributes on the methodinfo to determine what, if any, should be transferred  (vs copied)
                        _port.PostMessaage(callbackMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                JS.Log("ERROR: ", e);
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.WriteLine($"ERROR stacktrace: {ex.StackTrace}");
            }
            finally
            {
                args?.Dispose();
            }
        }

        public void SendEvent(string eventName, object? data = null)
        {
            _port.PostMessaage(new WebWorkerMessageOut { TargetType = "event", TargetName = eventName, Data = data });
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
            var workerMsg = new WebWorkerMessageOut
            {
                RequestId = Guid.NewGuid().ToString(),
                TargetName = methodName,
                TargetType = serviceType.FullName,
                Data = args,
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
            var workerMsg = new WebWorkerMessageOut
            {
                RequestId = Guid.NewGuid().ToString(),
                TargetName = methodName,
                TargetType = typeof(TService).FullName,
                Data = args,
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
            var workerMsg = new WebWorkerMessageOut
            {
                RequestId = Guid.NewGuid().ToString(),
                TargetName = methodName,
                TargetType = typeof(TService).FullName,
                Data = args,
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

        public bool IsDisposed { get; private set; } = false;
        public virtual void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            IsDisposed = true;
            if (disposing)
            {

            }
        }
        public virtual void Dispose()
        {
            Dispose(true);
        }
        ~ServiceCallDispatcher()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }
    }
}
