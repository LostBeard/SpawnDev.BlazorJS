using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JSObjects.WebRTC;
using SpawnDev.BlazorJS.Reflection;
using System.Reflection;
using System.Text.Json;

namespace SpawnDev.BlazorJS.WebWorkers
{
    internal class WebWorkerCallMessageTask
    {
        public Type? ReturnValueType { get; set; }
        public string RequestId => webWorkerCallMessageOutgoing.RequestId;
        public Action<IJSInProcessObjectReference>? OnComplete { get; set; }
        public CancellationToken? CancellationToken { get; set; }
        public WebWorkerMessageOut webWorkerCallMessageOutgoing { get; set; }
        public WebWorkerCallMessageTask(Action<IJSInProcessObjectReference>? onComplete)
        {
            OnComplete = onComplete;
        }
    }
    public class ServiceCallDispatcherInfo
    {
        public string InstanceId { get; init; }
        public string GlobalThisTypeName { get; init; }
    }
    public class ServiceCallDispatcher : CallDispatcher, IDisposable
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
        public IMessagePort? _port { get; set; }
        public bool LocalInvoker { get; private set; }
        public ServiceCallDispatcherInfo? RemoteInfo { get; private set; } = null;
        public ServiceCallDispatcherInfo LocalInfo { get; }
        public bool WaitingForResponse => _waiting.Count > 0;
        Dictionary<string, WebWorkerCallMessageTask> _waiting = new Dictionary<string, WebWorkerCallMessageTask>();
        protected IServiceProvider _serviceProvider;
        protected IServiceCollection ServiceDescriptors;
        public ServiceCallDispatcher(IServiceProvider serviceProvider, IServiceCollection serviceDescriptors, IMessagePort port)
        {
            _serviceProvider = serviceProvider;
            ServiceDescriptors = serviceDescriptors;
            _port = port;
            _port.OnMessage += _worker_OnMessage;
            _port.OnMessageError += _port_OnError;
            additionalCallArgs.Add(new CallSideParameter("caller", () => this, typeof(ServiceCallDispatcher)));
            LocalInfo = new ServiceCallDispatcherInfo { InstanceId = JS.InstanceId, GlobalThisTypeName = JS.GlobalThisTypeName };
        }
        public ServiceCallDispatcher(IServiceProvider serviceProvider, IServiceCollection serviceDescriptors)
        {
            LocalInvoker = true;
            _serviceProvider = serviceProvider;
            ServiceDescriptors = serviceDescriptors;
            additionalCallArgs.Add(new CallSideParameter("caller", () => this, typeof(ServiceCallDispatcher)));
            LocalInfo = new ServiceCallDispatcherInfo { InstanceId = JS.InstanceId, GlobalThisTypeName = JS.GlobalThisTypeName };
            RemoteInfo = LocalInfo;
            _oninit.SetResult(0);
        }
        protected static BlazorJSRuntime JS = BlazorJSRuntime.JS;
        private void _port_OnError()
        {
            JS.Log("_port_OnError");
        }
        private TaskCompletionSource<int> _oninit = new TaskCompletionSource<int>();
        public Task WhenReady => _oninit.Task;
        bool ReadyFlagSent = false;
        public void SendReadyFlag()
        {
            if (_port == null) return;
            ReadyFlagSent = true;
            _port.PostMessage(new WebWorkerMessageBase { TargetType = "__init", TargetName = JsonSerializer.Serialize(LocalInfo) });
        }
        //public delegate void OnMessageDelegate(ServiceCallDispatcher sender, WebWorkerMessageIn msg);
        public event Action<ServiceCallDispatcher, WebWorkerMessageIn> OnMessage;
        public delegate void BusyStateChangedDelegate(ServiceCallDispatcher sender, bool busy);
        public event BusyStateChangedDelegate OnBusyStateChanged;
        private bool _busy = false;
        void CheckBusyStateChanged(bool fire = false)
        {
            if (_busy && _waiting.Count == 0)
            {
                _busy = false;
                OnBusyStateChanged?.Invoke(this, _busy);
            }
            else if (!_busy && _waiting.Count > 0)
            {
                _busy = true;
                OnBusyStateChanged?.Invoke(this, _busy);
            }
            else if (fire)
            {
                OnBusyStateChanged?.Invoke(this, _busy);
            }
        }
        protected async void _worker_OnMessage(MessageEvent e)
        {
            IJSInProcessObjectReference? args = null;
            try
            {
                var msgBase = e.GetData<WebWorkerMessageIn>();
                msgBase._msg = e;
                if (msgBase.TargetType == "__")
                {
                    Console.WriteLine("ping --__--");
                }
                else if (msgBase.TargetType == "__init" && !string.IsNullOrEmpty(msgBase.TargetName))
                {
                    if (RemoteInfo == null)
                    {
                        RemoteInfo = JsonSerializer.Deserialize<ServiceCallDispatcherInfo>(msgBase.TargetName);
                        if (RemoteInfo != null)
                        {
#if DEBUG
                            Console.WriteLine($"ReceivedInit {ReadyFlagSent} {LocalInfo.GlobalThisTypeName}: {RemoteInfo.GlobalThisTypeName}");
#endif
                            if (!ReadyFlagSent)
                            {
                                SendReadyFlag();
                            }
                            _oninit.TrySetResult(0);
                            CheckBusyStateChanged(true);
                        }
                    }
                }
                else if (msgBase.TargetType == "__action" && !string.IsNullOrEmpty(msgBase.RequestId))
                {
                    if (_waiting.TryGetValue(msgBase.RequestId, out var req))
                    {
                        var actionId = msgBase.TargetName;
                        if (_actionHandles.TryGetValue(actionId, out var actionHandle))
                        {
                            var actionArgs = new object[actionHandle.ParameterTypes.Length];
                            if (actionArgs.Length > 0)
                            {
                                // Does not handle multiple args at the moment due to the added complexity with reflection
                                args = msgBase.GetData<IJSInProcessObjectReference>();
                                // JS.Log("msgBasemsgBasemsgBase", msgBase);
                                var argsLength = args != null ? args.Get<int>("length") : 0;
                                if (actionArgs.Length != argsLength)
                                {
                                    Console.WriteLine("Action parameter count does not match invoking");
                                }
                                for (var n = 0; n < actionArgs.Length; n++)
                                {
                                    actionArgs[n] = args.Get(actionHandle.ParameterTypes[n], n);
                                }
                            }
                            actionHandle.Target.DynamicInvoke(actionArgs);
                        }
                    }
                }
                else if (msgBase.TargetType == "__callback" && !string.IsNullOrEmpty(msgBase.RequestId))
                {
                    if (_waiting.TryGetValue(msgBase.RequestId, out var req))
                    {
                        _waiting.Remove(msgBase.RequestId);
                        try
                        {
                            args = msgBase.GetData<IJSInProcessObjectReference>();
                        }
                        catch { }
                        if (args != null)
                        {
                            req.OnComplete?.Invoke(args);
                        }
                        else
                        {
                            var checkThis = true;
                        }
                        CheckBusyStateChanged();
                    }
                }
                else if (msgBase.TargetType == "event" && !string.IsNullOrEmpty(msgBase.TargetName))
                {
                    OnMessage?.Invoke(this, msgBase);
                }
                else if (!string.IsNullOrEmpty(msgBase.TargetType) && !string.IsNullOrEmpty(msgBase.TargetName))
                {
                    // TODO - handle exceptions better.
                    // Currently some caused by bad calls throw exceptions here which leaves the caller in the other context waiting with no reason
                    // Also, try to implementing code to allow calling generic methods
                    object? retValue = null;
                    string? err = null;
                    object?[]? callArgs0 = null;
                    var finalReturnTypeAllowTransfer = true;
                    var finalReturnType = typeof(void);
                    try
                    {
                        args = msgBase.GetData<IJSInProcessObjectReference>();
                    }
                    catch { }
                    var argsLength = args != null ? args.Get<int>("length") : 0;
                    var serviceType = TypeExtensions.GetType(msgBase.TargetType);
                    var methodInfo = GetBestInstanceMethod(serviceType, msgBase.TargetName, argsLength);
                    if (methodInfo == null)
                    {
                        err = $"Method signature not found: {msgBase.TargetName}";
                    }
                    else
                    {
                        if (methodInfo.ReflectedType != null)
                        {
                            serviceType = methodInfo.ReflectedType;
                        }
                        object? service = null;
                        if (!methodInfo.IsStatic)
                        {
                            // non-static methods calls must point at a registered service
                            service = await _serviceProvider.FindServiceAsync(serviceType);
                            if (service == null)
                            {
                                err = $"Service type not found: {serviceType.Name}";
                            }
                        }
                        if (string.IsNullOrEmpty(err))
                        {
                            callArgs0 = PostDeserializeArgs(msgBase.RequestId, methodInfo, argsLength, args.Get);
                            try
                            {
                                retValue = await methodInfo.InvokeAsync(service, callArgs0);
                            }
                            catch (Exception ex)
                            {
                                err = ex.Message;
                            }
                        }
                    }
                    var autoDisposeArgs = true;
                    if (autoDisposeArgs && callArgs0 != null)
                    {
                        foreach (var ca in callArgs0)
                        {
                            if (ca != null && ca is IDisposable disposable)
                            {
                                disposable.Dispose();
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(msgBase.RequestId))
                    {
                        // send notification of completion is there is a requestid
                        var callbackMsg = new WebWorkerMessageOut { TargetType = "__callback", RequestId = msgBase.RequestId };
                        object[] transfer = new object?[0];
                        if (retValue != null)
                        {
                            if (finalReturnTypeAllowTransfer)
                            {
                                if (retValue is byte[] bytes)
                                {
                                    // same as when sending a byte[] as an arg... change it to a Uint8Array reference so it is not serialized using Base64 and we can transfer its array buffer
                                    var uint8Array = new Uint8Array(bytes);
                                    retValue = uint8Array;
                                    transfer = new object[] { uint8Array.Buffer };
                                }
                                else
                                {
                                    var conversionInfo = TypeConversionInfo.GetTypeConversionInfo(finalReturnType);
                                    transfer = conversionInfo.GetTransferablePropertyValues(retValue);
                                }
                            }
                        }
                        callbackMsg.Data = new object?[] { err, retValue };
                        _port.PostMessage(callbackMsg, transfer);
                        // dispose the return value if it is IJSInProcessObjectReference or JSObject
                        if (retValue is IDisposable disposable)
                        {
                            disposable.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BlazorJSRuntime.JS.Log("ERROR: ", e);
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.WriteLine($"ERROR stacktrace: {ex.StackTrace}");
            }
            finally
            {
                args?.Dispose();
                e?.Dispose();
            }
        }

        public void SendEvent(string eventName, object? data = null)
        {
            _port.PostMessage(new WebWorkerMessageOut { TargetType = "event", TargetName = eventName, Data = data });
        }
        private async Task<object?> LocalCallAsync(MethodInfo methodInfo, object?[]? args = null)
        {
            if (methodInfo == null)
            {
                throw new NullReferenceException(nameof(methodInfo));
            }
            object? service = null;
            if (!methodInfo.IsStatic)
            {
                // non-static methods calls must point at a registered service
                service = await _serviceProvider.FindServiceAsync(methodInfo.ReflectedType);
                if (service == null)
                {
                    throw new NullReferenceException(nameof(service));
                }
            }
            return await methodInfo.InvokeAsync(service, args);
        }
        /// <summary>
        /// Calls the MethodInfo on remote context
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<object?> DispatchCall(MethodInfo methodInfo, object?[]? args = null)
        {
            if (LocalInvoker)
            {
                return LocalCallAsync(methodInfo, args);
            }
            var serviceType = methodInfo.ReflectedType;
            if (serviceType == null)
            {
                throw new Exception("ServiceCallDispatcher.CallAsync: method does not have a reflected type.");
            }
            var methodName = SerializableMethodInfo.SerializeMethodInfo(methodInfo);
            var argsLength = args != null ? args.Length : 0;
            Type returnType = methodInfo.ReturnType;
            var finalReturnType = returnType.AsyncReturnType() ?? returnType;
            var finalReturnTypeIsVoid = finalReturnType == typeof(void);
            var requestId = Guid.NewGuid().ToString();
            var msgData = PreSerializeArgs(requestId, methodInfo, args, out var transferable);
            var workerMsg = new WebWorkerMessageOut
            {
                RequestId = requestId,
                TargetName = methodName,
                TargetType = serviceType.GetBestName(),
                Data = msgData,
            };
            var t = new TaskCompletionSource<object?>();
            var workerTask = new WebWorkerCallMessageTask((args) =>
            {
                // remove any callbacks
                var keysToRemove = _actionHandles.Values.Where(o => o.RequestId == requestId).Select(o => o.Id).ToArray();
                foreach (var key in keysToRemove) _actionHandles.Remove(key);
                // get result or exception and fire results handlers
                var argsLength = args != null ? args.Get<int>("length") : 0;
                object? retVal = null;
                string? err = null;
                if (argsLength > 0)
                {
                    err = args.Get<string?>(0);
                    if (string.IsNullOrEmpty(err) && !finalReturnTypeIsVoid)
                    {
                        retVal = args.Get(finalReturnType, 1);
                    }
                }
                if (!string.IsNullOrEmpty(err))
                    t.TrySetException(new Exception(err));
                else
                    t.TrySetResult(retVal);
            });
            workerTask.ReturnValueType = finalReturnType;
            workerTask.webWorkerCallMessageOutgoing = workerMsg;
            _waiting.Add(workerTask.RequestId, workerTask);
            _port.PostMessage(workerMsg, transferable);
            CheckBusyStateChanged();
            return t.Task;
        }
        //public Task<object?> CallAsync(Type serviceType, string methodName, object?[]? args = null)
        //{
        //    var argsLength = args != null ? args.Length : 0;
        //    var methodInfo = GetBestInstanceMethod(serviceType, methodName, argsLength);
        //    return CallAsync(methodInfo, args);
        //}
        //public Task<TResult> InvokeAsync<TService, TResult>(string methodName, params object?[]? args) => CallAsync<TService, TResult>(methodName, args ?? new object[0]);
        //public async Task<TResult> CallAsync<TService, TResult>(string methodName, object?[]? args = null)
        //{
        //    var argsLength = args != null ? args.Length : 0;
        //    var serviceType = typeof(TService);
        //    var methodInfo = GetBestInstanceMethod(serviceType, methodName, argsLength);
        //    return (TResult)await CallAsync(methodInfo, args);
        //    //            var returnType = methodInfo.ReturnType;
        //    //            var isAwaitable = returnType.IsAsync();
        //    //            var finalReturnType = isAwaitable ? returnType.AsyncReturnType() : returnType;
        //    //            var finalReturnTypeIsVoid = finalReturnType == typeof(void);
        //    //            var requestId = Guid.NewGuid().ToString();
        //    //            var msgData = PreSerializeArgs(requestId, methodInfo, args, out var transferable);
        //    //            var workerMsg = new WebWorkerMessageOut
        //    //            {
        //    //                RequestId = requestId,
        //    //                TargetName = methodName,
        //    //                TargetType = serviceType.FullName ?? serviceType.Name,
        //    //                Data = msgData,
        //    //            };
        //    //            var t = new TaskCompletionSource<TResult>();
        //    //            if (typeof(TResult) != finalReturnType)
        //    //            {
        //    //#if DEBUG
        //    //                Console.WriteLine($"WARNING: Worker service {serviceType.Name} method {methodName} has a different return type {finalReturnType.Name} then the callee requested type {finalReturnType.Name}");
        //    //#endif
        //    //            }
        //    //            var workerTask = new WebWorkerCallMessageTask((args) =>
        //    //            {
        //    //                // remove any callbacks
        //    //                var keysToRemove = _actionHandles.Values.Where(o => o.RequestId == requestId).Select(o => o.Id).ToArray();
        //    //                foreach (var key in keysToRemove) _actionHandles.Remove(key);
        //    //                //var finalReturnTypeName = finalReturnType.Name;
        //    //                var argsLength = args == null ? 0 : args.Get<int>("length");
        //    //                if (args == null || argsLength != 2)
        //    //                {
        //    //                    Console.WriteLine($"ServiceCallDispatcher Invalid return args for workerTask");
        //    //                    t.TrySetException(new Exception("Invalid return args for workerTask"));
        //    //                    return;
        //    //                }
        //    //                var err = args.Get<string?>(0);
        //    //                if (!string.IsNullOrEmpty(err))
        //    //                {
        //    //                    t.TrySetException(new Exception(err));
        //    //                    return;
        //    //                }
        //    //                try
        //    //                {
        //    //                    var ret = args.Get<TResult>(1);
        //    //                    t.TrySetResult(ret);
        //    //                    return;
        //    //                }
        //    //                catch
        //    //                {
        //    //#if DEBUG && false
        //    //                            Console.WriteLine($"ServiceCallDispatcher 'retVal = args.Get<TResult?>(1);'");
        //    //#endif
        //    //                    t.TrySetResult(default);
        //    //                }
        //    //            });
        //    //            workerTask.ReturnValueType = finalReturnType;
        //    //            workerTask.webWorkerCallMessageOutgoing = workerMsg;
        //    //            _waiting.Add(workerTask.RequestId, workerTask);
        //    //            _port.PostMessage(workerMsg, transferable);
        //    //            CheckBusyStateChanged();
        //    //            return t.Task;
        //}

        //public void Call<TService>(string methodName, object?[]? args, Action<Exception?, object?> callback) where TService : class => Call(typeof(TService), methodName, args, callback);
        //public void Call(Type serviceType, string methodName, object?[]? args, Action<Exception?, object?> callback)
        //{
        //    var argsLength = args != null ? args.Length : 0;
        //    var methodInfo = GetBestInstanceMethod(serviceType, methodName, argsLength);
        //    Call(methodInfo, args, callback);
        //    //var returnType = methodInfo.ReturnType;
        //    //var isAwaitable = returnType.IsAsync();
        //    //var finalReturnType = isAwaitable ? returnType.AsyncReturnType() : returnType;
        //    //var finalReturnTypeIsVoid = finalReturnType == typeof(void);
        //    //var requestId = Guid.NewGuid().ToString();
        //    //var msgData = PreSerializeArgs(requestId, methodInfo, args, out var transferable);
        //    //var workerMsg = new WebWorkerMessageOut
        //    //{
        //    //    RequestId = requestId,
        //    //    TargetName = methodName,
        //    //    TargetType = serviceType.FullName ?? serviceType.Name,
        //    //    Data = msgData,
        //    //};
        //    //var workerTask = new WebWorkerCallMessageTask((args) =>
        //    //{
        //    //    Exception? retExc = null;
        //    //    object? retVal = null;
        //    //    // remove any callbacks
        //    //    var keysToRemove = _actionHandles.Values.Where(o => o.RequestId == requestId).Select(o => o.Id).ToArray();
        //    //    foreach (var key in keysToRemove) _actionHandles.Remove(key);
        //    //    //var finalReturnTypeName = finalReturnType.Name;
        //    //    var argsLength = args == null ? 0 : args.Get<int>("length");
        //    //    if (args == null || argsLength != 2)
        //    //    {
        //    //        Console.WriteLine($"ServiceCallDispatcher Invalid return args for workerTask");
        //    //        retExc = new Exception("Invalid return args for workerTask");
        //    //    }
        //    //    else
        //    //    {
        //    //        var err = args.Get<string?>(0);
        //    //        if (!string.IsNullOrEmpty(err))
        //    //        {
        //    //            retExc = new Exception(err);
        //    //        }
        //    //        else if (!finalReturnTypeIsVoid)
        //    //        {
        //    //            try
        //    //            {
        //    //                retVal = args.Get(finalReturnType, 1);
        //    //            }
        //    //            catch (Exception ex)
        //    //            {
        //    //                retExc = ex;
        //    //            }
        //    //        }
        //    //    }
        //    //    callback?.Invoke(retExc, retVal);
        //    //});
        //    //workerTask.ReturnValueType = finalReturnType;
        //    //workerTask.webWorkerCallMessageOutgoing = workerMsg;
        //    //_waiting.Add(workerTask.RequestId, workerTask);
        //    //_port.PostMessage(workerMsg, transferable);
        //    //CheckBusyStateChanged();
        //}
        //public void Call(Delegate methodDelegate, object?[]? args, Action<Exception?, object?> callback) => Call(methodDelegate.Method, args, callback);
        //public void Call(MethodInfo methodInfo, object?[]? args, Action<Exception?, object?> callback)
        //{

        //    _ = CallAsync(methodInfo, args).ContinueWith(t => callback(t.Exception, t.Result));
        //    return;


        //    var serviceType = methodInfo.ReflectedType;
        //    var argsLength = args != null ? args.Length : 0;
        //    var methodName = SerializableMethodInfo.SerializeMethodInfo(methodInfo);
        //    var returnType = methodInfo.ReturnType;
        //    var isAwaitable = returnType.IsAsync();
        //    var finalReturnType = isAwaitable ? returnType.AsyncReturnType() : returnType;
        //    var finalReturnTypeIsVoid = finalReturnType == typeof(void);
        //    var requestId = Guid.NewGuid().ToString();
        //    var msgData = PreSerializeArgs(requestId, methodInfo, args, out var transferable);
        //    var workerMsg = new WebWorkerMessageOut
        //    {
        //        RequestId = requestId,
        //        TargetName = methodName,
        //        TargetType = serviceType.FullName ?? serviceType.Name,
        //        Data = msgData,
        //    };
        //    var workerTask = new WebWorkerCallMessageTask((args) =>
        //    {
        //        Exception? retExc = null;
        //        object? retVal = null;
        //        // remove any callbacks
        //        var keysToRemove = _actionHandles.Values.Where(o => o.RequestId == requestId).Select(o => o.Id).ToArray();
        //        foreach (var key in keysToRemove) _actionHandles.Remove(key);
        //        //var finalReturnTypeName = finalReturnType.Name;
        //        var argsLength = args == null ? 0 : args.Get<int>("length");
        //        if (args == null || argsLength != 2)
        //        {
        //            Console.WriteLine($"ServiceCallDispatcher Invalid return args for workerTask");
        //            retExc = new Exception("Invalid return args for workerTask");
        //        }
        //        else
        //        {
        //            var err = args.Get<string?>(0);
        //            if (!string.IsNullOrEmpty(err))
        //            {
        //                retExc = new Exception(err);
        //            }
        //            else if (!finalReturnTypeIsVoid)
        //            {
        //                try
        //                {
        //                    retVal = args.Get(finalReturnType, 1);
        //                }
        //                catch (Exception ex)
        //                {
        //                    retExc = ex;
        //                }
        //            }
        //        }
        //        callback?.Invoke(retExc, retVal);
        //    });
        //    workerTask.ReturnValueType = finalReturnType;
        //    workerTask.webWorkerCallMessageOutgoing = workerMsg;
        //    _waiting.Add(workerTask.RequestId, workerTask);
        //    _port.PostMessage(workerMsg, transferable);
        //    CheckBusyStateChanged();
        //}
        public static object? GetDefault(Type type) => type.IsValueType ? Activator.CreateInstance(type) : null;
        Dictionary<string, CallbackAction> _actionHandles = new Dictionary<string, CallbackAction>();
        class CallbackAction
        {
            public Delegate Target { get; set; }
            public MethodInfo Method { get; set; }
            public string Id { get; set; } = Guid.NewGuid().ToString();
            public string RequestId { get; set; } = "";
            public Type[] ParameterTypes { get; set; }
        }
        object?[]? PreSerializeArgs(string requestId, MethodInfo methodInfo, object?[]? args, out object[] transferable)
        {
            var trasnferableList = new List<object>();
            var methodsParamTypes = methodInfo.GetParameters();
            object?[]? ret = null;
            if (args != null)
            {
                ret = new object?[args.Length];
                for (var i = 0; i < methodsParamTypes.Length; i++)
                {
                    var value = args[i];
                    if (value == null) continue;
                    var methodParam = methodsParamTypes[i];
                    var methodParamType = methodParam.ParameterType;
                    var methodParamTypeIsTransferable = IsTransferable(methodParamType);
                    var allowTransferable = methodParamType.IsClass;
                    if (allowTransferable)
                    {
                        var transferAttr = (WorkerTransferAttribute?)methodParam.GetCustomAttribute(typeof(WorkerTransferAttribute), false);
                        if (transferAttr != null && !transferAttr.Transfer)
                        {
                            // this property has been marked as non-transferable
                            allowTransferable = false;
                        }
                    }
                    var methodParamTypeName = methodParam.ParameterType.Name;
                    var genericTypes = methodParamType.GenericTypeArguments;
                    var genericTypeNames = methodParamType.GenericTypeArguments.Select(o => o.Name).ToArray();
                    var callSideArg = GetCallSideParameter(methodParam);
                    if (callSideArg != null)
                    {
                        // skip... it will be handles on the other side
                    }
                    else if (value is Delegate valueDelegate)
                    {
                        var cb = new CallbackAction
                        {
                            Method = methodInfo,
                            RequestId = requestId,
                            ParameterTypes = genericTypes,
                            Target = valueDelegate,
                        };
                        _actionHandles[cb.Id] = cb;
                        ret[i] = cb.Id;
                    }
                    else if (value is byte[] bytes)
                    {
                        // to try and good performance sending byte arrays we convert it to a Uint8Array reference first, and add its array buffer to the transferables list.
                        // it will still be read in on the other side as a byte array
                        var uint8Array = new Uint8Array(bytes);
                        if (allowTransferable)
                        {
                            trasnferableList.Add(uint8Array.Buffer);
                        }
                        ret[i] = uint8Array;
                    }
                    else
                    {
                        if (allowTransferable)
                        {
                            var covnersionInfo = TypeConversionInfo.GetTypeConversionInfo(methodParamType);
                            var propTransferable = covnersionInfo.GetTransferablePropertyValues(value);
                            trasnferableList.AddRange(propTransferable);
                        }
                        ret[i] = value;
                    }
                }
            }
            transferable = trasnferableList.ToArray();
            return ret;
        }
        object?[]? PostDeserializeArgs(string requestId, MethodInfo methodInfo, int argsLength, Func<Type, object, object?> getArg)
        {
            var methodsParamTypes = methodInfo.GetParameters();
            var ret = new object?[argsLength];
            var argI = 0;
            for (var i = 0; i < methodsParamTypes.Length; i++)
            {
                var methodParam = methodsParamTypes[i];
                var methodParamType = methodParam.ParameterType;
                var methodParamTypeName = methodParam.ParameterType.Name;
                var genericTypes = methodParamType.GenericTypeArguments;
                var genericTypeNames = methodParamType.GenericTypeArguments.Select(o => o.Name).ToArray();
                var callSideArg = GetCallSideParameter(methodParam);
                if (callSideArg != null)
                {
                    ret[i] = callSideArg.GetValue();
                    continue;
                }
                else if (typeof(Delegate).IsAssignableFrom(methodParamType))
                {
                    var actionId = (string)getArg(typeof(string), argI);
                    argI++;
                    var hasParams = methodParam.ParameterType.IsGenericType;
                    if (genericTypes.Length == 0)
                    {
                        ret[i] = new Action(() =>
                        {
                            //JS.Log($"Action called: {actionId}");
                            var callbackMsg = new WebWorkerMessageOut { TargetType = "__action", RequestId = requestId, TargetName = actionId };
                            _port.PostMessage(callbackMsg);
                        });
                    }
                    else
                    {
                        ret[i] = CreateTypedAction(genericTypes, new Action<object?[]>((args) =>
                        {
                            //JS.Log($"Action called: {actionId} {o}");
                            var callbackMsg = new WebWorkerMessageOut { TargetType = "__action", RequestId = requestId, TargetName = actionId };
                            callbackMsg.Data = args;
                            _port.PostMessage(callbackMsg);
                        }));
                    }
                }
                else if (argI < argsLength)
                {
                    ret[i] = getArg(methodParamType, argI);
                    argI++;
                }
            }
            return ret;
        }
        public static Action<T0> CreateTypedActionT1<T0>(Action<object?[]> arg) => new Action<T0>((t0) => arg(new object[] { t0 }));
        public static Action<T0, T1> CreateTypedActionT2<T0, T1>(Action<object?[]> arg) => new Action<T0, T1>((t0, t1) => arg(new object[] { t0, t1 }));
        public static Action<T0, T1, T2> CreateTypedActionT3<T0, T1, T2>(Action<object?[]> arg) => new Action<T0, T1, T2>((t0, t1, t2) => arg(new object[] { t0, t1 }));
        public static Action<T0, T1, T2, T3> CreateTypedActionT4<T0, T1, T2, T3>(Action<object?[]> arg) => new Action<T0, T1, T2, T3>((t0, t1, t2, t3) => arg(new object[] { t0, t1, t2, t3 }));
        public static Action<T0, T1, T2, T3, T4> CreateTypedActionT4<T0, T1, T2, T3, T4>(Action<object?[]> arg) => new Action<T0, T1, T2, T3, T4>((t0, t1, t2, t3, t4) => arg(new object[] { t0, t1, t2, t3, t4 }));
        public object CreateTypedAction(Type[] typ1, Action<object?[]> arg)
        {
            var meth = typeof(ServiceCallDispatcher).GetMethod($"CreateTypedActionT{typ1.Length}", BindingFlags.Public | BindingFlags.Static);
            var gmeth = meth.MakeGenericMethod(typ1);
            var genericAction = gmeth.Invoke(null, new object[] { arg });
            return genericAction;
        }
        //public Task InvokeVoidAsync<TService>(string methodName, params object?[]? args) => CallVoidAsync<TService>(methodName, args ?? new object[0]);
        //        public async Task CallVoidAsync<TService>(string methodName, object?[]? args = null)
        //        {
        //            await CallAsync(typeof(TService), methodName, args);
        //            return;
        ////            var argsLength = args != null ? args.Length : 0;
        ////            var serviceType = typeof(TService);
        ////            var methodInfo = GetBestInstanceMethod(serviceType, methodName, argsLength);
        ////            var returnType = methodInfo.ReturnType;
        ////            var isAwaitable = returnType.IsAsync();
        ////            var finalReturnType = isAwaitable ? returnType.AsyncReturnType() : returnType;
        ////            var finalReturnTypeIsVoid = finalReturnType == typeof(void);
        ////            var requestId = Guid.NewGuid().ToString();
        ////            var msgData = PreSerializeArgs(requestId, methodInfo, args, out var transferable);
        ////            var workerMsg = new WebWorkerMessageOut
        ////            {
        ////                RequestId = requestId,
        ////                TargetName = methodName,
        ////                TargetType = serviceType.FullName ?? serviceType.Name,
        ////                Data = msgData,
        ////            };
        ////            var t = new TaskCompletionSource<int>();
        ////            if (typeof(void) != finalReturnType)
        ////            {
        ////#if DEBUG
        ////                Console.WriteLine($"WARNING: Worker service {serviceType.Name} method {methodName} has a different return type {typeof(void).Name} then the callee requested type {finalReturnType.Name}");
        ////#endif
        ////            }
        ////            var workerTask = new WebWorkerCallMessageTask((args) =>
        ////            {
        ////                // remove any callbacks
        ////                var keysToRemove = _actionHandles.Values.Where(o => o.RequestId == requestId).Select(o => o.Id).ToArray();
        ////                foreach (var key in keysToRemove) _actionHandles.Remove(key);
        ////                //
        ////                var argsLength = args != null ? args.Get<int>("length") : 0;
        ////                string? err = null;
        ////                if (argsLength > 0)
        ////                {
        ////                    err = args.Get<string?>(0);
        ////                }
        ////                if (!string.IsNullOrEmpty(err))
        ////                    t.TrySetException(new Exception(err));
        ////                else
        ////                    t.TrySetResult(0);
        ////            });
        ////            workerTask.ReturnValueType = finalReturnType;
        ////            workerTask.webWorkerCallMessageOutgoing = workerMsg;
        ////            _waiting.Add(workerTask.RequestId, workerTask);
        ////            _port.PostMessage(workerMsg, transferable);
        ////            CheckBusyStateChanged();
        ////            return t.Task;
        //        }
        List<CallSideParameter> additionalCallArgs { get; } = new List<CallSideParameter>();
        class CallSideParameter
        {
            public string Name { get; }
            public Type Type { get; }
            public Func<object?> GetValue;
            public CallSideParameter(string name, Func<object?> getter, Type type)
            {
                Name = name;
                GetValue = getter;
                Type = type;
            }
        }
        CallSideParameter? GetCallSideParameter(ParameterInfo p)
        {
            return additionalCallArgs.Where(o => o.Name == p.Name && o.Type == p.ParameterType).FirstOrDefault();
        }
        private MethodInfo? GetBestInstanceMethod<T>(string identifier, int paramCount) => GetBestInstanceMethod(typeof(T), identifier, paramCount);
        private MethodInfo? GetBestInstanceMethod(Type classType, string identifier, int paramCount)
        {
            if (identifier.StartsWith("{"))
            {
                // serialized SerializableMethodInfo full method signature (supports generic types)
                var best = SerializableMethodInfo.DeserializeMethodInfo(identifier);
                return best;
            }
            else
            {
                // name of Method only
                var instanceMethods = classType
                .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static)
                .Where(m => m.Name == identifier)
                .Where(m => !m.IsGenericMethod)
                .Where(m => m.GetParameters().Count() == paramCount)
                .ToList();
                var best = instanceMethods.FirstOrDefault();
                return best;
            }
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
