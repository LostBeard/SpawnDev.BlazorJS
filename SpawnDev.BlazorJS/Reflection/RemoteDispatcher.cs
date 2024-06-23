using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Array = SpawnDev.BlazorJS.JSObjects.Array;

namespace SpawnDev.BlazorJS.Reflection
{
    /// <summary>
    /// Client and server implementation for remotely calling .Net methods using SimplePeer
    /// </summary>
    public abstract class RemoteDispatcher : AsyncCallDispatcherSlim, IDisposable
    {
        public ClaimsPrincipal User { get; protected set; } = new ClaimsPrincipal(new ClaimsIdentity(nameof(RemoteDispatcher), ClaimTypes.Name, ClaimTypes.Role));
        protected TaskCompletionSource WhenReadySource { get; set; } = new TaskCompletionSource();
        public Task WhenReady => WhenReadySource.Task;
        public bool Ready => WhenReady.IsCompletedSuccessfully;
        protected BlazorJSRuntime JS { get; private set; }
        protected IServiceScope? ServiceProviderScope { get; private set; } = null;
        protected IServiceProvider ScopedServiceProvider { get; private set; }
        protected IServiceCollection ServiceDescriptors { get; private set; }
        protected Dictionary<string, TaskCompletionSource<Array>> waitingResponse { get; private set; } = new Dictionary<string, TaskCompletionSource<Array>>();
        protected bool InheritAttributes { get; set; } = true;
        /// <summary>
        /// If set to true, calls from the remote peer onto this peer are enabled<br/>
        /// Per call access, if enabled, will apply
        /// </summary>
        protected bool ServeEnabled { get; set; } = true;
        /// <summary>
        /// If false, static methods cannot be called
        /// </summary>
        protected bool AllowStaticMethods { get; set; } = true;
        /// <summary>
        /// If false, protected methods cannot be called
        /// </summary>
        protected bool AllowPrivateMethods { get; set; } = true;
        /// <summary>
        /// If true, static methods in non-service types can be called.<br/>
        /// </summary>
        protected bool AllowNonServiceStaticMethods { get; set; } = true;
        /// <summary>
        /// If true, special methods (like getters and setters) will be allowed
        /// </summary>
        protected bool AllowSpecialMethods { get; set; } = false;
        /// <summary>
        /// If true, the PeerCallable attribute must be present on the method or the containing class
        /// </summary>
        protected bool RequirePeerCallableAttribute { get; set; } = true;
        /// <summary>
        /// Returns true if this instance has been disposed
        /// </summary>
        public bool IsDisposed { get; protected set; }
        public RemoteDispatcher(IServiceProvider serviceProvider, bool createNewScope = true)
        {
            JS = serviceProvider.GetRequiredService<BlazorJSRuntime>();
            ServiceDescriptors = serviceProvider.GetRequiredService<IServiceCollection>();
            if (createNewScope)
            {
                ServiceProviderScope = serviceProvider.CreateScope();
                ScopedServiceProvider = ServiceProviderScope.ServiceProvider;
            }
            else
            {
                ScopedServiceProvider = serviceProvider;
            }
        }
        protected void ResetWhenReady()
        {
            if (WhenReadySource.Task.IsCompleted) return;
            //Console.WriteLine("ResetWhenReady");
            WhenReadySource = new TaskCompletionSource();
            NeedRemoteReadyFlag = true;
            CancelAllWaitingRequests();
            ReadyStateChanged?.Invoke(this);
        }
        /// <summary>
        /// This method will be called with the call data<br/>
        /// The inheriting class should pass the call to the remote side where it will be imported via HandleCall as an Array
        /// </summary>
        /// <param name="args"></param>
        protected abstract void SendCall(object?[] args);
        /// <summary>
        /// This should be called when the connection is established or after creation if already established
        /// </summary>
        protected virtual void SendReadyFlag() => SendCall(new object?[] { "!", NeedRemoteReadyFlag, GetReadyFlagData() });

        protected virtual object? GetReadyFlagData() => null;

        public event Action<RemoteDispatcher> ReadyStateChanged;
        protected bool NeedRemoteReadyFlag { get; set; } = true;
        protected virtual async Task<object?> ReadyFlagReceived(JSObject? remoteFlagData)
        {
            //Console.WriteLine("ReadyFlagReceived");
            remoteFlagData?.Dispose();
            return null;
        }
        protected virtual async Task ReadyFlagResultReceived(JSObject? flagDataResult)
        {
            flagDataResult?.Dispose();
        }
        /// <summary>
        /// The inheriting class must call this method with the incoming message<br/>
        /// msg is an Array the resides in the Javascript environment
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected async Task HandleCall(Array msg)
        {
            if (msg == null) return;
            if (Array.IsArray(msg) && msg.Length > 0)
            {
                try
                {
                    var msgType = msg.Shift<string>();
                    switch (msgType)
                    {
                        case ".": // message
                            await HandleCall(msg, false);
                            return;
                        case "?": // call
                            await HandleCall(msg, true);
                            return;
                        case "=": // response
                            HandleReply(msg);
                            return;
                        case "!": // ready flag
                            NeedRemoteReadyFlag = false;
                            var remoteNeedsReadyFlag = msg.Shift<bool>();
                            var args = msg.Shift<JSObject?>();
                            if (remoteNeedsReadyFlag) SendReadyFlag();
                            var ret = await ReadyFlagReceived(args);
                            SendCall(new object?[] { "+", ret });
                            return;
                        case "+": // ready result
                            var args1 = msg.Shift<JSObject?>();
                            try
                            {
                                await ReadyFlagResultReceived(args1);
                                if (!WhenReady.IsCompleted)
                                {
                                    Console.WriteLine("Ready set");
                                    WhenReadySource.TrySetResult();
                                    ReadyStateChanged?.Invoke(this);
                                }
                            }
                            catch
                            {

                            }
                            return;
                    }
                    if (DynamicCallables.TryGetValue(msgType, out var dynamicCallable))
                    {
                        await dynamicCallable(msg);
                    }
                }
                catch (Exception ex)
                {
                    JS.Log($"DataConnection_OnData: {ex.Message}");
                }
            }
            msg.Dispose();
        }
        /// <summary>
        /// This method will be called be a call is sent to the remote dispatcher<br/>
        /// If this method returns a non-empty string an exception will be thrown aborting the call
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task<string?> PreCallCheck(MethodInfo methodInfo, object?[]? args = null)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected override async Task<object?> DispatchCallAsync(MethodInfo methodInfo, object?[]? args)
        {
            var callError = await PreCallCheck(methodInfo, args);
            if (!string.IsNullOrEmpty(callError)) throw new Exception($"DispatchCall error: {callError}");
            object? retValue = null;
            var methodInfoSerialized = SerializableMethodInfoSlim.SerializeMethodInfo(methodInfo);
            var msgId = Guid.NewGuid().ToString();
            var outArgs = await PreSerializeArgs(msgId, methodInfo, args);
            var remoteCallableAttribute = methodInfo.GetCustomAttribute<RemoteCallableAttribute>(true);
            var resultRequested = remoteCallableAttribute == null || !remoteCallableAttribute.NoReply;
            try
            {
                SendCall(new object?[] { resultRequested ? "?" : ".", msgId, methodInfoSerialized, outArgs });
                if (resultRequested)
                {
                    var tcs = new TaskCompletionSource<Array>();
                    waitingResponse.Add(msgId, tcs);
                    var finalReturnType = methodInfo.GetFinalReturnType();
                    var ret = await tcs.Task;
                    var retError = ret.Shift<string?>();
                    if (!string.IsNullOrEmpty(retError))
                    {
                        var error = DeserializeException(retError);
                        throw error;
                    }
                    if (finalReturnType != typeof(void))
                    {
                        // custom deserialization of result if needed
                        retValue = await PostDeserializeArgument(msgId, methodInfo, methodInfo.ReturnParameter, true, ret, 0);
                    }
                }
                return retValue;
            }
            finally
            {
                StartRequestCleanup(msgId);
            }
        }
        protected void CancelAllWaitingRequests(string message) => CancelAllWaitingRequests(new Exception(message));
        protected void CancelAllWaitingRequests(Exception? exception = null)
        {
            exception ??= new TargetException();
            foreach (var waiting in waitingResponse.Values)
            {
                waiting.TrySetException(exception);
            }
            waitingResponse.Clear();
        }
        /// <summary>
        /// Disposes resources
        /// </summary>
        public virtual void Dispose()
        {
            if (IsDisposed) return;
            IsDisposed = true;
            ServiceProviderScope?.Dispose();
            CancelAllWaitingRequests();
        }
        /// <summary>
        /// This method should return an error string or throw an exception if the call pre-check fails
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="remoteCallableAttr"></param>
        /// <param name="info"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        protected virtual async Task<string?> CanCallCheck(MethodInfo methodInfo, RemoteCallableAttribute? remoteCallableAttr, ServiceDescriptor? info, object? instance)
        {
            if (!AllowNonServiceStaticMethods && info == null)
            {
                return "HandleCallError: Service not found";
            }
            if (!AllowSpecialMethods && methodInfo.IsSpecialName)
            {
                return "HandleCallError: Access denied to special methods";
            }
            if (!AllowPrivateMethods && methodInfo.IsPrivate)
            {
                return "HandleCallError: Access denied protected method";
            }
            if (!AllowStaticMethods && methodInfo.IsStatic)
            {
                return "HandleCallError: Access denied static method";
            }
            if (RequirePeerCallableAttribute && remoteCallableAttr == null)
            {
                return "HandleCallError: Access denied not PeerCallable";
            }
            return null;
        }
        /// <summary>
        /// This method is called when a parameter is marked with [FromLocal] is a called method to populate the argument with the lcoal variable
        /// </summary>
        /// <param name="parameterType"></param>
        /// <returns></returns>
        protected virtual async Task<object?> ResolveLocalInstance(Type parameterType)
        {
            if (typeof(RemoteDispatcher).IsAssignableFrom(parameterType))
            {
                return this;
            }
            return parameterType.GetDefaultValue();
        }
        protected async Task<object?> PreSerializeArgument(string msgId, MethodInfo methodInfo, ParameterInfo parameterInfo, bool isReturnValue, object? value, int paramIndex)
        {
            object? ret = null;
            var attributes = parameterInfo.GetCustomAttributes(InheritAttributes).Cast<Attribute>().ToArray();
            var methodParamType = parameterInfo.ParameterType;
#if NET8_0_OR_GREATER
            var fromKeyedServicesAttr = attributes.FirstOrDefault(o => o is FromKeyedServicesAttribute);
            if (fromKeyedServicesAttr != null) return ret;
#endif
            var fromServicesAttr = attributes.FirstOrDefault(o => o is FromServicesAttribute);
            if (fromServicesAttr != null) return ret;
            var fromLocalAttr = attributes.FirstOrDefault(o => o is FromLocalAttribute);
            if (fromLocalAttr != null) return ret;
            Type? genericType = null;
            if (methodParamType.IsGenericTypeDefinition) genericType = methodParamType;
            else if (methodParamType.IsGenericType) genericType = methodParamType.GetGenericTypeDefinition();
            var coreType = genericType ?? methodParamType;
            // custom serialization can be done here tp package args![i]
            if (value is ClaimsIdentity claimsIdentity)
            {
                ret = claimsIdentity == null ? null : claimsIdentity.ToBase64();
            }
            else if (value is CancellationToken token)
            {
                if (token.IsCancellationRequested)
                {
                    // "" represents an already cancelled token
                    ret = "";
                }
                else if (token.CanBeCanceled)
                {
                    // a token id will be sent which can be referenced later to cancel the token
                    // listen for the token cancellation event and send the cancel request at that time
                    var tokenId = Guid.NewGuid().ToString();
                    token.Register(() =>
                    {
                        try
                        {
                            SendCall(new object?[] { tokenId });
                        }
                        catch { }
                    });
                    ret = tokenId;
                }
                else
                {
                    // null represents CancellationToken.None (the default)
                    ret = null;
                }
            }
            else if (value is Delegate argDelegate)
            {
                var genericTypes = methodParamType.GenericTypeArguments;
                if (IsAction(coreType))
                {
                    var actionParameterTypes = argDelegate.Method.GetParameters().Select(o => o.ParameterType).ToArray();
                    var actionId = Guid.NewGuid().ToString();
                    AddDynamicCallable(msgId, actionId, async (msg) =>
                    {
                        var actionArgs = new object?[actionParameterTypes.Length];
                        if (actionArgs.Length > 0)
                        {
                            var argsLength = msg.Length;
                            if (actionArgs.Length != argsLength)
                            {
                                throw new Exception("Invalid argument count on Action callback");
                            }
                            for (var n = 0; n < actionArgs.Length; n++)
                            {
                                // TODO - use post-deserialize
                                actionArgs[n] = msg.GetItem(actionParameterTypes[n], n);
                            }
                        }
                        argDelegate.DynamicInvoke(actionArgs);
                    });
                    ret = actionId;
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
            else
            {
                ret = value;
            }
            return ret;
        }
        protected void OnRequestCleanup(string msgId, Action action)
        {
            if (action == null) return;
            if (!RequestCleanup.TryGetValue(msgId, out var cleanUps))
            {
                cleanUps = new List<Action>();
                RequestCleanup[msgId] = cleanUps;
            }
            cleanUps.Add(action);
        }
        protected void StartRequestCleanup(string msgId)
        {
            if (RequestCleanup.TryGetValue(msgId, out var cleanUps))
            {
                RequestCleanup.Remove(msgId);
                foreach (var cleanUp in cleanUps) cleanUp();
            }
        }
        protected Dictionary<string, List<Action>> RequestCleanup = new Dictionary<string, List<Action>>();
        protected async Task<object?> PostDeserializeArgument(string msgId, MethodInfo methodInfo, ParameterInfo parameterInfo, bool isReturnValue, Array? callArgs, int paramIndex)
        {
            var callArgsLength = callArgs?.Length ?? 0;
            var finalType = isReturnValue ? parameterInfo.ParameterType.AsyncReturnType() ?? parameterInfo.ParameterType : parameterInfo.ParameterType;
            var genericTypes = finalType.GenericTypeArguments;
            //var attributes = parameterInfo.GetCustomAttributes(InheritAttributes).Cast<Attribute>().ToArray();
#if NET8_0_OR_GREATER
            var fromKeyedServicesAttr = parameterInfo.GetCustomAttribute<FromKeyedServicesAttribute>(InheritAttributes);
            if (fromKeyedServicesAttr != null)
            {
                return ScopedServiceProvider.GetRequiredKeyedService(finalType, fromKeyedServicesAttr.Key);
            }
#endif
            var fromServicesAttr = parameterInfo.GetCustomAttribute<FromServicesAttribute>(InheritAttributes);
            if (fromServicesAttr != null)
            {
                return ScopedServiceProvider.GetRequiredService(finalType);
            }
            var fromLocalAttr = parameterInfo.GetCustomAttribute<FromLocalAttribute>(InheritAttributes);
            if (fromLocalAttr != null)
            {
                return await ResolveLocalInstance(finalType);
            }
            if (paramIndex < callArgsLength)
            {
                // custom deserialization can be done here to get type methodParamType from callArgs Array
                if (typeof(Delegate).IsAssignableFrom(finalType))
                {
                    // Create a local action that can be called to relay the call to the remote endpoint
                    var actionId = callArgs!.GetItem<string>(paramIndex);
                    if (genericTypes.Length == 0)
                    {
                        return new Action(() => SendCall(new object?[] { actionId }));
                    }
                    else
                    {
                        return CreateTypedAction(genericTypes, new Action<object?[]>((args) =>
                        {
                            // TODO - pre-serialize args
                            var callbackMsg = new List<object?> { actionId };
                            callbackMsg.AddRange(args);
                            SendCall(callbackMsg.ToArray());
                        }));
                    }
                }
                else if (finalType == typeof(ClaimsIdentity))
                {
                    var sData = callArgs!.GetItem<string?>(paramIndex);
                    return string.IsNullOrEmpty(sData) ? null : sData.Base64ToClaimsIdentity();
                }
                else if (finalType == typeof(CancellationToken))
                {
                    // Create a local action that can be called to relay the call to the remote endpoint
                    var tokenId = callArgs!.GetItem<string?>(paramIndex);
                    if (tokenId == null)
                    {
                        // default token
                        return CancellationToken.None;
                    }
                    else if (tokenId == "")
                    {
                        // already cancelled
                        return new CancellationToken(true);
                    }
                    else
                    {
                        // can be cancelled
                        var tokenSource = new CancellationTokenSource();
                        AddDynamicCallable(msgId, tokenId, async (msg) => tokenSource.Cancel());
                        return tokenSource.Token;
                    }
                }
                else
                {
                    return callArgs!.GetItem(finalType, paramIndex);
                }
            }
            else if (parameterInfo.HasDefaultValue)
            {
                return parameterInfo.DefaultValue;
            }
            return finalType.GetDefaultValue();
        }
        protected async Task<object?[]> PreSerializeArgs(string msgId, MethodInfo methodInfo, object?[]? args)
        {
            var methodParams = methodInfo.GetParameters();
            var ret = new object?[methodParams.Length];
            var callArgsLength = args == null ? 0 : args.Length;
            for (var i = 0; i < methodParams.Length; i++)
            {
                ret[i] = await PreSerializeArgument(msgId, methodInfo, methodParams[i], false, i < callArgsLength ? args[i] : null, i);
            }
            return ret;
        }
        protected async Task<object?[]> PostDeserializeArgs(string msgId, MethodInfo methodInfo, Array? callArgs)
        {
            var methodParams = methodInfo.GetParameters();
            var ret = new object?[methodParams.Length];
            var callArgsLength = callArgs == null ? 0 : callArgs.Length;
            for (var i = 0; i < methodParams.Length; i++)
            {
                var methodParam = methodParams[i];
                var methodParamType = methodParam.ParameterType;
                ret[i] = await PostDeserializeArgument(msgId, methodInfo, methodParams[i], false, callArgs, i);
            }
            return ret;
        }
        protected async Task HandleCall(Array msg, bool resultRequested)
        {
            object? instance = null;
            object? retValue = null;
            string? retError = null;
            string? msgId = null;
            Type? targetType = null;
            MethodInfo? methodInfo = null;
            object?[]? args = null;
            RemoteCallableAttribute? remoteCallableAttr = null;
            ServiceDescriptor? info = null;
            // rebuild request MethodInfo and arguments
            Array? argsPreDeser = null;
            try
            {
                msgId = msg.Shift<string>();
                if (string.IsNullOrEmpty(msgId)) return;
                if (!ServeEnabled)
                {
                    retError = "HandleCallError: Offline";
                    goto SendResponse;
                }
                var methodInfoSerialized = msg.Shift<string>();
                methodInfo = SerializableMethodInfoSlim.DeserializeMethodInfo(methodInfoSerialized);
                if (methodInfo == null)
                {
                    retError = "HandleCallError: Method not found";
                    goto SendResponse;
                }
                targetType = methodInfo!.ReflectedType;
                Console.WriteLine($"targetType: {targetType?.Name ?? "ReflectedType == null"}.{methodInfo.Name}");
                remoteCallableAttr = methodInfo.GetCustomAttribute<RemoteCallableAttribute>();
                // locate info about the type being called
                info = ServiceDescriptors.FindServiceDescriptors(methodInfo.ReflectedType)!.FirstOrDefault();
                // what is left in `msg` is the call arguments
                argsPreDeser = msg.Shift<Array>();
                args = argsPreDeser == null ? null : await PostDeserializeArgs(msgId, methodInfo, argsPreDeser);
            }
            catch (Exception ex)
            {
                //JS.Log($"HandleCall failed to rebuild the request method or args: {ex.Message}");
                retError = $"HandleCallError: Failed to rebuild the request method or args: {ex.Message}";
                goto SendResponse;
            }
            finally
            {
                argsPreDeser?.Dispose();
                msg.Dispose();
            }
            // get the instance for this call (if non-static)
            if (!methodInfo.IsStatic)
            {
                instance = info == null ? null : await ScopedServiceProvider.GetServiceAsync(info!.ServiceType);
                if (instance == null)
                {
                    retError = "HandleCallError: Service not found";
                    goto SendResponse;
                }
            }
            var deniedError = await CanCallCheck(methodInfo, remoteCallableAttr, info, instance);
            if (!string.IsNullOrEmpty(deniedError))
            {
                retError = deniedError;
                goto SendResponse;
            }
            // Authorize check
            var authorized = true;
            if (remoteCallableAttr != null)
            {
                if (!string.IsNullOrEmpty(remoteCallableAttr.Roles))
                {
                    var allowedRoles = Regex.Split(remoteCallableAttr.Roles, @",\s*|,?\s+");
                    authorized = allowedRoles.Any(User.IsInRole);
                }
            }
            if (!authorized)
            {
                retError = "HandleCallError: Access denied";
                goto SendResponse;
            }
            // invoke the call capturing the result or exception
            try
            {
                retValue = await methodInfo.InvokeAsync(instance, args);
            }
            catch (Exception ex)
            {
                retError = SerializeException(ex);
                goto SendResponse;
            }
        SendResponse:
            try
            {
                if (!resultRequested) return;
                if (remoteCallableAttr != null && remoteCallableAttr.NoReply) return;
                if (retError == null)
                {
                    retValue = await PreSerializeArgument(msgId!, methodInfo!, methodInfo!.ReturnParameter, true, retValue, 0);
                }
                SendCall(new object?[] { "=", msgId, retError, retValue });
            }
            catch (Exception ex)
            {
                JS.Log($"DataConnection.Send failed: {ex.Message}");
            }
            finally
            {
                StartRequestCleanup(msgId!);
            }
        }
        protected void HandleReply(Array? msg)
        {
            if (msg == null) return;
            var msgId = msg.Shift<string>();
            if (waitingResponse.TryGetValue(msgId, out var waiter))
            {
                waitingResponse.Remove(msgId);
                waiter.TrySetResult(msg);
            }
            msg.Dispose();
        }
        protected static string SerializeException(Exception exception)
        {
            return exception.Message;
        }
        protected static Exception DeserializeException(string exception)
        {
            var ret = new Exception(exception);
            return ret;
        }
        protected void AddDynamicCallable(string msgId, string key, Func<Array, Task> handler)
        {
            AddDynamicCallable(key, handler);
            OnRequestCleanup(msgId, () => RemoveDynamicHandler(key));
        }
        protected void AddDynamicCallable(string key, Func<Array, Task> handler) => DynamicCallables.Add(key, handler);
        protected bool RemoveDynamicHandler(string key) => DynamicCallables.Remove(key);
        protected Dictionary<string, Func<Array, Task>> DynamicCallables = new Dictionary<string, Func<Array, Task>>();
        protected static Action<T0> CreateTypedActionT1<T0>(Action<object?[]> arg) => new Action<T0>((t0) => arg(new object[] { t0 }));
        protected static Action<T0, T1> CreateTypedActionT2<T0, T1>(Action<object?[]> arg) => new Action<T0, T1>((t0, t1) => arg(new object[] { t0, t1 }));
        protected static Action<T0, T1, T2> CreateTypedActionT3<T0, T1, T2>(Action<object?[]> arg) => new Action<T0, T1, T2>((t0, t1, t2) => arg(new object[] { t0, t1 }));
        protected static Action<T0, T1, T2, T3> CreateTypedActionT4<T0, T1, T2, T3>(Action<object?[]> arg) => new Action<T0, T1, T2, T3>((t0, t1, t2, t3) => arg(new object[] { t0, t1, t2, t3 }));
        protected static Action<T0, T1, T2, T3, T4> CreateTypedActionT5<T0, T1, T2, T3, T4>(Action<object?[]> arg) => new Action<T0, T1, T2, T3, T4>((t0, t1, t2, t3, t4) => arg(new object[] { t0, t1, t2, t3, t4 }));
        protected static object CreateTypedAction(Type[] paramTypes, Action<object?[]> arg)
        {
            var methodKey = $"CreateTypedActionT{paramTypes.Length}";
            if (!ActionMakerCache.TryGetValue(methodKey, out var methodInfo))
            {
                methodInfo = typeof(RemoteDispatcher).GetMethod(methodKey, BindingFlags.NonPublic | BindingFlags.Static);
                ActionMakerCache[methodKey] = methodInfo;
            }
            var gmeth = methodInfo.MakeGenericMethod(paramTypes);
            var genericAction = gmeth.Invoke(null, new object[] { arg });
            return genericAction;
        }
        protected static Dictionary<string, MethodInfo> ActionMakerCache = new Dictionary<string, MethodInfo>();
        protected static List<Type> GenericActions = new List<Type> {
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
        protected static List<Type> GenericFuncs = new List<Type> {
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
        protected static bool IsFunc(Type type)
        {
            Type? generic = null;
            if (type.IsGenericTypeDefinition) generic = type;
            else if (type.IsGenericType) generic = type.GetGenericTypeDefinition();
            if (generic == null) return false;
            return GenericFuncs.Contains(generic);
        }
        protected static bool IsAction(Type type)
        {
            if (type == typeof(Action)) return true;
            Type? generic = null;
            if (type.IsGenericTypeDefinition) generic = type;
            else if (type.IsGenericType) generic = type.GetGenericTypeDefinition();
            if (generic == null) return false;
            return GenericActions.Contains(generic);
        }
    }
}
