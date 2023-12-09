using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JSObjects.WebRTC;
using SpawnDev.BlazorJS.Reflection;
using System.Reflection;
using System.Text.Json;
using Array = SpawnDev.BlazorJS.JSObjects.Array;

namespace SpawnDev.BlazorJS.WebWorkers
{
    internal class WebWorkerCallMessageTask
    {
        public string RequestId => webWorkerCallMessageOutgoing.RequestId;
        public Action<Array>? OnComplete { get; set; }
        public CancellationToken? CancellationToken { get; set; }
        public WebWorkerMessageOut webWorkerCallMessageOutgoing { get; set; }
        public WebWorkerCallMessageTask(Action<Array>? onComplete)
        {
            OnComplete = onComplete;
        }
    }
    public class ServiceCallDispatcherInfo
    {
        public string InstanceId { get; init; }
        public string GlobalThisTypeName { get; init; }
    }
    public class ServiceCallDispatcher : AsyncCallDispatcher, IDisposable
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
        /// <summary>
        /// Completes when connection has been established
        /// </summary>
        public Task WhenReady => _oninit.Task;
        private bool ReadyFlagSent = false;
        public void SendReadyFlag()
        {
            if (_port == null) return;
            ReadyFlagSent = true;
            _port.PostMessage(new WebWorkerMessageBase { TargetType = "__init", TargetName = JsonSerializer.Serialize(LocalInfo) });
        }
        public event Action<ServiceCallDispatcher, WebWorkerMessageIn> OnMessage;
        public delegate void BusyStateChangedDelegate(ServiceCallDispatcher sender, bool busy);
        public event BusyStateChangedDelegate OnBusyStateChanged;
        private bool _busy = false;
        private void CheckBusyStateChanged(bool fire = false)
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
            try
            {
                var msgBase = e.GetData<WebWorkerMessageIn>();
                msgBase._msg = e;
                if (msgBase.TargetType == "__init" && !string.IsNullOrEmpty(msgBase.TargetName))
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
                            var actionArgs = new object?[actionHandle.ParameterTypes.Length];
                            if (actionArgs.Length > 0)
                            {
                                // Does not handle multiple args at the moment due to the added complexity with reflection
                                using var args = msgBase.GetData<Array>();
                                var argsLength = args == null ? 0 : args.Length;
                                if (actionArgs.Length != argsLength)
                                {
                                    throw new Exception("Invalid argument count on Action callback");
                                }
                                if (args != null)
                                {
                                    for (var n = 0; n < actionArgs.Length; n++)
                                    {
                                        actionArgs[n] = args.GetItem(actionHandle.ParameterTypes[n], n);
                                    }
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
                        using var args = msgBase.GetData<Array>();
                        req.OnComplete?.Invoke(args);
                        CheckBusyStateChanged();
                    }
                }
                else if (msgBase.TargetType == "event" && !string.IsNullOrEmpty(msgBase.TargetName))
                {
                    OnMessage?.Invoke(this, msgBase);
                }
                else if (!string.IsNullOrEmpty(msgBase.TargetType) && !string.IsNullOrEmpty(msgBase.TargetName))
                {
                    // Method call request
                    object? retValue = null;
                    string? err = null;
                    object?[]? callArgs0 = null;
                    var finalReturnTypeAllowTransfer = true;
                    var finalReturnType = typeof(void);
                    var methodInfo = SerializableMethodInfo.DeserializeMethodInfo(msgBase.TargetName);
                    if (methodInfo == null)
                    {
                        err = $"Method signature not found: {msgBase.TargetName}";
                    }
                    else
                    {
                        var serviceType = methodInfo.ReflectedType;
                        object? service = null;
                        if (!methodInfo.IsStatic)
                        {
                            // non-static methods calls must point at a registered service
                            service = await _serviceProvider.FindServiceAsync(serviceType);
                            if (service == null)
                            {
                                err = $"Service type not found: {(serviceType == null ? "" : serviceType.Name)}";
                            }
                        }
                        if (string.IsNullOrEmpty(err))
                        {
                            using var args = msgBase.GetData<Array>();
                            callArgs0 = PostDeserializeArgs(msgBase.RequestId, methodInfo, args);
                            try
                            {
                                retValue = await methodInfo.InvokeAsync(service, callArgs0!);
                            }
                            catch (Exception ex)
                            {
                                err = ex.Message;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(msgBase.RequestId))
                    {
                        // Send notification of completion because there is a requestId
                        var callbackMsg = new WebWorkerMessageOut { TargetType = "__callback", RequestId = msgBase.RequestId };
                        object[] transfer = System.Array.Empty<object>();
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
                e?.Dispose();
            }
        }
        public void SendEvent(string eventName, object? data = null)
        {
            _port.PostMessage(new WebWorkerMessageOut { TargetType = "event", TargetName = eventName, Data = data });
        }
        private async Task<object?> LocalCall(MethodInfo methodInfo, object?[]? args = null)
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
        public override Task<object?> Call(MethodInfo methodInfo, object?[]? args = null)
        {
            if (LocalInvoker)
            {
                return LocalCall(methodInfo, args);
            }
            var serviceType = methodInfo.ReflectedType;
            if (serviceType == null)
            {
                throw new Exception("ServiceCallDispatcher.Call: method does not have a reflected type.");
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
                var argsLength = args.Length;
                object? retVal = null;
                string? err = null;
                if (argsLength > 0)
                {
                    err = args.GetItem<string?>(0);
                    if (string.IsNullOrEmpty(err) && !finalReturnTypeIsVoid)
                    {
                        retVal = args.GetItem(finalReturnType, 1);
                    }
                }
                if (!string.IsNullOrEmpty(err))
                    t.TrySetException(new Exception(err));
                else
                    t.TrySetResult(retVal);
            });
            workerTask.webWorkerCallMessageOutgoing = workerMsg;
            _waiting.Add(workerTask.RequestId, workerTask);
            _port.PostMessage(workerMsg, transferable);
            CheckBusyStateChanged();
            return t.Task;
        }
        static object? GetDefault(Type type) => type.IsValueType ? Activator.CreateInstance(type) : null;
        private Dictionary<string, CallbackAction> _actionHandles = new Dictionary<string, CallbackAction>();
        class CallbackAction
        {
            public Delegate Target { get; set; }
            public MethodInfo Method { get; set; }
            public string Id { get; set; } = Guid.NewGuid().ToString();
            public string RequestId { get; set; } = "";
            public Type[] ParameterTypes { get; set; }
        }
        /// <summary>
        /// Pre-serialization that prepares call arguments before they are send to the remote endpoint via a postMessage call<br />
        /// Any transferables objects are found in this stage as well and returned in an out param "transferable"
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="methodInfo"></param>
        /// <param name="args"></param>
        /// <param name="transferable"></param>
        /// <returns></returns>
        private object?[]? PreSerializeArgs(string requestId, MethodInfo methodInfo, object?[]? args, out object[] transferable)
        {
            var transferableList = new List<object>();
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
                        // to try and get good performance sending byte arrays we convert it to a Uint8Array reference first, and add its array buffer to the transferables list.
                        // it will still be read in on the other side as a byte array. this prevents 1 copying stage.
                        var uint8Array = new Uint8Array(bytes);
                        if (allowTransferable)
                        {
                            transferableList.Add(uint8Array.Buffer);
                        }
                        ret[i] = uint8Array;
                    }
                    else
                    {
                        if (allowTransferable)
                        {
                            var conversionInfo = TypeConversionInfo.GetTypeConversionInfo(methodParamType);
                            var propTransferable = conversionInfo.GetTransferablePropertyValues(value);
                            transferableList.AddRange(propTransferable);
                        }
                        ret[i] = value;
                    }
                }
            }
            transferable = transferableList.ToArray();
            return ret;
        }
        /// <summary>
        /// Imports method call arguments from Javascript and finishes deserializing them<br />
        /// Returns teh exact number of arguments the methodInfo uses, including default values if there was not enough passed in arguments<br />
        /// CallSide arguments will also be resolved if any.
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="methodInfo"></param>
        /// <param name="callArgs"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private object?[]? PostDeserializeArgs(string requestId, MethodInfo methodInfo, Array callArgs)
        {
            if (callArgs == null) return null;
            var callArgsLength = callArgs == null ? 0 : callArgs.Length;
            var methodsParamTypes = methodInfo.GetParameters();
            if (callArgsLength > methodsParamTypes.Count())
            {
                throw new Exception("PostDeserializeArgs argument count mismatch. Too many arguments.");
            }
            var ret = new object?[methodsParamTypes.Length];
            for (var i = 0; i < ret.Length; i++)
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
                }
                else if (typeof(Delegate).IsAssignableFrom(methodParamType))
                {
                    // Create a local action that can be called to relay the call to the remote endpoint
                    var actionId = callArgs.GetItem<string>(i);
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
                else if (i < callArgsLength)
                {
                    ret[i] = callArgs.GetItem(methodParamType, i);
                }
                else if (methodParam.HasDefaultValue)
                {
                    ret[i] = methodParam.DefaultValue;
                }
                else
                {
                    throw new Exception("PostDeserializeArgs argument count mismatch. Not enough arguments.");
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
