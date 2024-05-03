using Microsoft.Extensions.DependencyInjection;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JSObjects.WebRTC;
using SpawnDev.BlazorJS.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using Array = SpawnDev.BlazorJS.JSObjects.Array;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public class ServiceCallDispatcher : AsyncCallDispatcher, IDisposable
    {
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
        class CallbackAction
        {
            public Delegate Target { get; set; }
            public string Id { get; set; } = Guid.NewGuid().ToString();
            public string RequestId { get; set; } = "";
            public Type[] ParameterTypes { get; set; }
        }
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
        Dictionary<string, TaskCompletionSource<Array>> _waiting = new Dictionary<string, TaskCompletionSource<Array>>();
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
        protected static BlazorJSRuntime JS => BlazorJSRuntime.JS;
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
            _port.PostMessage(new object?[] { "init", LocalInfo });
        }
        public event Action<ServiceCallDispatcher, Array> OnMessage;
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
                var args = e.GetData<Array>();
                e.Dispose();
                var argsLength = args.Length;
                var msgType = args.Shift<string>(); // 0
                switch (msgType)
                {
                    case "cancelToken":
                        var tokenId = args.Shift<string>(); // 1
                        if (RemoteCancellationTokens.TryGetValue(tokenId, out var remoteTokenSource))
                        {
                            RemoteCancellationTokens.Remove(tokenId);
                            remoteTokenSource.TokenSource.Cancel();
                            remoteTokenSource.Dispose();
                        }
                        break;
                    case "init":
                        {
                            if (RemoteInfo == null)
                            {
                                RemoteInfo = args.Shift<ServiceCallDispatcherInfo>(); // 1
                                if (RemoteInfo != null)
                                {
                                    if (!ReadyFlagSent)
                                    {
                                        SendReadyFlag();
                                    }
                                    _oninit.TrySetResult(0);
                                    CheckBusyStateChanged(true);
                                }
                            }
                        }
                        break;
                    case "action":
                        {
                            var requestId = args.Shift<string>(); // 1
                            if (_waiting.TryGetValue(requestId, out var req))
                            {
                                var actionId = args.Shift<string>(); // 2
                                if (_actionHandles.TryGetValue(actionId, out var actionHandle))
                                {
                                    var actionArgs = new object?[actionHandle.ParameterTypes.Length];
                                    if (actionArgs.Length > 0)
                                    {
                                        argsLength = args.Length;
                                        if (actionArgs.Length != argsLength)
                                        {
                                            throw new Exception("Invalid argument count on Action callback");
                                        }
                                        for (var n = 0; n < actionArgs.Length; n++)
                                        {
                                            actionArgs[n] = args.GetItem(actionHandle.ParameterTypes[n], n);
                                        }
                                    }
                                    actionHandle.Target.DynamicInvoke(actionArgs);
                                }
                            }
                        }
                        break;
                    case "event":
                        {
                            OnMessage?.Invoke(this, args);
                        }
                        break;
                    case "callback":
                        {
                            var requestId = args.Shift<string>(); // 1
                            if (_waiting.TryGetValue(requestId, out var req))
                            {
                                _waiting.Remove(requestId);
                                if (!req.Task.IsCompleted && req.TrySetResult(args)) return;
                                CheckBusyStateChanged();
                            }
                        }
                        break;
                    case "call":
                        {
                            await HandleCallMessage(args);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                BlazorJSRuntime.JS.Log("ERROR: ", e);
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.WriteLine($"ERROR stack trace: {ex.StackTrace}");
            }
        }

        async Task HandleCallMessage(Array args)
        {
            string requestId = "";
            object? retValue = null;
            string? err = null;
            MethodInfo? methodInfo = null;
            try
            {
                requestId = args.Shift<string>(); // 1
                var serializedMethodInfo = args.Shift<string>(); // 2
                object?[]? callArgs0 = null;
                methodInfo = SerializableMethodInfo.DeserializeMethodInfo(serializedMethodInfo);
                if (methodInfo == null)
                {
                    throw new Exception($"Method signature not found.");
                }
                else if (methodInfo.ReflectedType == null)
                {
                    throw new Exception($"Invalid method signature not found. Invalid ReflectedType.");
                }
                var serviceType = methodInfo.ReflectedType;
                object? service = null;
                if (!methodInfo.IsStatic)
                {
                    // non-static methods calls must point at a registered service
                    service = await _serviceProvider.FindServiceAsync(serviceType);
                    if (service == null)
                    {
                        throw new Exception($"Service type not found: {(serviceType == null ? "" : serviceType.Name)}");
                    }
                }
                callArgs0 = await PostDeserializeArgs(requestId, methodInfo, args);
                retValue = await methodInfo.InvokeAsync(service, callArgs0!);
            }
            catch (Exception ex)
            {
                // the call failed
                err = ex.Message;
            }
            // Post call cleanup
            // remove any uncancelled remote CancellationTokens for this request
            var tokensToRemove = RemoteCancellationTokens.Values.Where(o => o.RequestId == requestId).ToArray();
            foreach (var remoteTokenSource in tokensToRemove)
            {
                RemoteCancellationTokens.Remove(remoteTokenSource.TokenId);
                remoteTokenSource.Dispose();
            }
            try
            {
                if (!string.IsNullOrEmpty(requestId))
                {
                    // Send notification of completion because there is a requestId
                    //var callbackMsg = new WebWorkerMessageOut { TargetType = "callback", RequestId = requestId };
                    var callbackMsg = new List<object?> { "callback", requestId, };
                    object[] transfer = System.Array.Empty<object>();
                    if (retValue != null)
                    {
                        if (retValue is byte[] bytes)
                        {
                            // same as when sending a byte[] as an arg... change it to a Uint8Array reference so it is not serialized using Base64 and we can transfer its array buffer
                            var uint8Array = new Uint8Array(bytes);
                            retValue = uint8Array;
                            transfer = new object[] { uint8Array.Buffer };
                        }
                        else if (methodInfo != null)
                        {
                            var finalReturnType = methodInfo.GetFinalReturnType();
                            var conversionInfo = TypeConversionInfo.GetTypeConversionInfo(finalReturnType);
                            transfer = conversionInfo.GetTransferablePropertyValues(retValue);
                        }
                    }
                    callbackMsg.Add(err);
                    callbackMsg.Add(retValue);
                    _port?.PostMessage(callbackMsg, transfer);
                }
            }
            catch (Exception ex)
            {
                // failed to notify remote endpoint of result
                Console.WriteLine($"Failed to notify remote endpoint of result: {ex.Message}");
            }
        }

        public void SendEvent(string eventName, object?[]? data = null)
        {
            var outMsg = new List<object?> { "event", eventName };
            if (data != null) outMsg.AddRange(data);
            _port?.PostMessage(outMsg);
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
        public override async Task<object?> Call(MethodInfo methodInfo, object?[]? args = null)
        {
            if (LocalInvoker)
            {
                return LocalCall(methodInfo, args);
            }
            var serviceType = methodInfo.ReflectedType;
            if (_port == null)
            {
                throw new Exception("ServiceCallDispatcher.Call: port is null.");
            }
            if (serviceType == null)
            {
                throw new Exception("ServiceCallDispatcher.Call: method does not have a reflected type.");
            }
            var requestId = Guid.NewGuid().ToString();
            var targetMethod = SerializableMethodInfo.SerializeMethodInfo(methodInfo);
            var msgData = PreSerializeArgs(requestId, methodInfo, args, out var transferable);
            var msgOut = new List<object?> { "call", requestId, targetMethod };
            msgOut.AddRange(msgData);
            var workerTask = new TaskCompletionSource<Array>();
            _port.PostMessage(msgOut, transferable);
            _waiting.Add(requestId, workerTask);
            CheckBusyStateChanged();
            try
            {
                var returnArray = await workerTask.Task;
                // remove any request callbacks (currently only Action)
                var keysToRemove = _actionHandles.Values.Where(o => o.RequestId == requestId).Select(o => o.Id).ToArray();
                foreach (var key in keysToRemove) _actionHandles.Remove(key);
                // get result or exception
                string? err = returnArray.GetItem<string?>(0);
                if (!string.IsNullOrEmpty(err)) throw new Exception(err);
                var finalReturnType = methodInfo.GetFinalReturnType();
                if (finalReturnType.IsVoid()) return null;
                return returnArray.GetItem(finalReturnType, 1);
            }
            finally
            {
                CheckBusyStateChanged();
            }
        }
        static List<Type> GenericActions = new List<Type> {
            typeof(Action),
            typeof(Action<>),
            typeof(Action<,>),
            typeof(Action<,,>),
            typeof(Action<,,,>),
            typeof(Action<,,,,>),
            typeof(Action<,,,,,>),
            typeof(Action<,,,,,,>),
            typeof(Action<,,,,,,,>),
            typeof(Action<,,,,,,,,>),
            typeof(Action<,,,,,,,,,>),
            typeof(Action<,,,,,,,,,,>),
            typeof(Action<,,,,,,,,,,,>),
            typeof(Action<,,,,,,,,,,,,>),
        };
        static List<Type> GenericFuncs = new List<Type> {
            typeof(Func<>),
            typeof(Func<,>),
            typeof(Func<,,>),
            typeof(Func<,,,>),
            typeof(Func<,,,,>),
            typeof(Func<,,,,,>),
            typeof(Func<,,,,,,>),
            typeof(Func<,,,,,,,>),
            typeof(Func<,,,,,,,,>),
            typeof(Func<,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,>),
            typeof(Func<,,,,,,,,,,,,>),
        };
        static bool IsFunc(Type type)
        {
            Type? generic = null;
            if (type.IsGenericTypeDefinition) generic = type;
            else if (type.IsGenericType) generic = type.GetGenericTypeDefinition();
            if (generic == null) return false;
            return GenericFuncs.Contains(generic);
        }
        static bool IsAction(Type type)
        {
            if (type == typeof(Action)) return true;
            Type? generic = null;
            if (type.IsGenericTypeDefinition) generic = type;
            else if (type.IsGenericType) generic = type.GetGenericTypeDefinition();
            if (generic == null) return false;
            return GenericActions.Contains(generic);
        }
        private Dictionary<string, CallbackAction> _actionHandles = new Dictionary<string, CallbackAction>();
        List<CallSideParameter> additionalCallArgs { get; } = new List<CallSideParameter>();
        /// <summary>
        /// Pre-serialization that prepares call arguments before they are sent to the remote endpoint via a postMessage call<br />
        /// Any transferable objects are found in this stage as well and returned in an out param "transferable"
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="methodInfo"></param>
        /// <param name="args"></param>
        /// <param name="transferable"></param>
        /// <returns></returns>
        private object?[] PreSerializeArgs(string requestId, MethodInfo methodInfo, object?[]? args, out object[] transferable)
        {
            var transferableList = new List<object>();
            var methodsParamTypes = methodInfo.GetParameters();
            var argsLength = args == null ? 0 : args.Length;
            object?[]? ret = new object?[argsLength];
            for (var i = 0; i < argsLength; i++)
            {
                var arg = args![i];
                if (arg == null) continue;
                var methodParam = methodsParamTypes[i];
                var methodParamType = methodParam.ParameterType;
                Type? genericType = null;
                if (methodParamType.IsGenericTypeDefinition) genericType = methodParamType;
                else if (methodParamType.IsGenericType) genericType = methodParamType.GetGenericTypeDefinition();
#if DEBUG && false
                var genericTypeStr = genericType == null ? "NULL" : genericType.FullName;
                Console.WriteLine($"genericTypeStr: {genericTypeStr}");
#endif
                var coreType = genericType ?? methodParamType;

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
                if (IsCallSideParameter(methodParam))
                {
                    // resolved on the other side
                }
                else if (arg is Delegate argDelegate)
                {
                    if (IsAction(coreType))
                    {
                        var cb = new CallbackAction
                        {
                            RequestId = requestId,
                            ParameterTypes = genericTypes,
                            Target = argDelegate,
                        };
                        _actionHandles[cb.Id] = cb;
                        ret[i] = cb.Id;
                    }
                    else if (IsFunc(coreType))
                    {
                        throw new Exception("Func delegate parameters are not currently supported.");
                    }
                    else
                    {
                        throw new Exception("Unknown delegate parameter type");
                    }
                }
                else if (arg is CancellationToken token)
                {
                    if (token.IsCancellationRequested)
                    {
                        // "" represents an already cancelled token
                        ret[i] = "";
                    }
                    else if (token.CanBeCanceled)
                    {
                        // a token id will be sent which can be referenced later to cancel the token
                        // lsiten for the token cancellation event and send the cancel request at that time
                        var tokenId = Guid.NewGuid().ToString();
                        token.Register(() =>
                        {
                            // send cancel message to worker
                            var callbackMsg = new List<object?> { "cancelToken", tokenId };
                            _port?.PostMessage(callbackMsg);
                        });
                        ret[i] = tokenId;
                    }
                    else
                    {
                        // null represents CancellationToken.None (the default)
                        ret[i] = null;
                    }
                }
                else if (arg is byte[] bytes)
                {
                    // to get better performance when sending byte arrays we convert it to a Uint8Array reference first, and add its array buffer to the transferables list.
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
                        var propTransferable = conversionInfo.GetTransferablePropertyValues(arg);
                        transferableList.AddRange(propTransferable);
                    }
                    ret[i] = arg;
                }
            }
            transferable = transferableList.ToArray();
            return ret;
        }
        /// <summary>
        /// Holds references to deserialized CancellationTokens from requests<br/>
        /// These will be disposed and removed when the request is completed<br/>
        /// </summary>
        Dictionary<string, RemoteCancellationTokenSource> RemoteCancellationTokens = new Dictionary<string, RemoteCancellationTokenSource>();
        class RemoteCancellationTokenSource : IDisposable
        {
            public string TokenId { get; private set; }
            public CancellationTokenSource TokenSource { get; private set; } = new CancellationTokenSource();
            public string RequestId { get; private set; }
            public RemoteCancellationTokenSource(string requestId, string tokenId)
            {
                RequestId = requestId;
                TokenId = tokenId;
            }
            public void Dispose()
            {
                TokenSource.Dispose();
            }
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
        private async Task<object?[]?> PostDeserializeArgs(string requestId, MethodInfo methodInfo, Array callArgs)
        {
            if (callArgs == null) return null;
            var callArgsLength = callArgs.Length;
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
                var genericTypes = methodParamType.GenericTypeArguments;
                var (resolved, value) = await TryResolveCallSideParamValue(methodParam);
                if (resolved)
                {
                    ret[i] = value;
                }
                else if (typeof(CancellationToken) == methodParamType)
                {
                    // Create a local action that can be called to relay the call to the remote endpoint
                    var tokenId = callArgs.GetItem<string?>(i);
                    if (tokenId == null)
                    {
                        // default token
                        ret[i] = CancellationToken.None;
                    }
                    else if (tokenId == "")
                    {
                        // already cancelled
                        ret[i] = new CancellationToken(true);
                    }
                    else
                    {
                        // can be cancelled
                        var remoteCancellationToken = new RemoteCancellationTokenSource(requestId, tokenId);
                        RemoteCancellationTokens[tokenId] = remoteCancellationToken;
                        ret[i] = remoteCancellationToken.TokenSource.Token;
                    }
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
                            var callbackMsg = new List<object?> { "action", requestId, actionId };
                            _port?.PostMessage(callbackMsg);
                        });
                    }
                    else
                    {
                        ret[i] = CreateTypedAction(genericTypes, new Action<object?[]>((args) =>
                        {
                            //JS.Log($"Action called: {actionId} {o}");
                            var callbackMsg = new List<object?> { "action", requestId, actionId };
                            callbackMsg.AddRange(args);
                            _port?.PostMessage(callbackMsg);
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
        bool IsCallSideParameter(ParameterInfo methodParam)
        {
            var fromServiceAttr = methodParam.GetCustomAttribute<FromServicesAttribute>();
            if (fromServiceAttr != null) return true;
            if (GetCallSideParameter(methodParam) != null) return true;
            return false;
        }
        async Task<(bool, object?)> TryResolveCallSideParamValue(ParameterInfo methodParam)
        {
            object? value = null;
            // service
            var fromServiceAttr = methodParam.GetCustomAttribute<FromServicesAttribute>();
            if (fromServiceAttr != null)
            {
                value = await _serviceProvider.GetServiceAsync(methodParam.ParameterType);
                return (true, value);
            }
            // call side
            var callSideParam = GetCallSideParameter(methodParam);
            if (callSideParam != null)
            {
                value = callSideParam.GetValue();
                return (true, value);
            }
            return (false, value);
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
    }
}
