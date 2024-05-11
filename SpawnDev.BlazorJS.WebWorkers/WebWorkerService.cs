using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Reflection;
using SpawnDev.BlazorJS.Toolbox;
using System.Text.Json;
using Array = SpawnDev.BlazorJS.JSObjects.Array;

namespace SpawnDev.BlazorJS.WebWorkers
{
    // chrome://inspect/#workers
    /// <summary>
    /// WebWorkerService provides access to WebWorkers, SharedWebWorkers, ServiceWorkers, and other running Windows from this origin<br/>
    /// </summary>
    public class WebWorkerService : IDisposable, IAsyncBackgroundService
    {
        /// <summary>
        /// If this instance is running in a DedicatedWorkerGlobalScope this is a connection to the parent instance
        /// </summary>
        public ServiceCallDispatcher? DedicatedWorkerParent { get; private set; } = null;
        /// <summary>        
        /// If this instance is running in a SharedWorkerGlobalScope this is all the incoming connections
        /// </summary>
        public List<ServiceCallDispatcher> SharedWorkerIncomingConnections { get; private set; } = new List<ServiceCallDispatcher>();
        /// <summary>
        /// Returns true if SharedWebWorker is supported
        /// </summary>
        public bool SharedWebWorkerSupported { get; private set; }
        /// <summary>
        /// Returns true if WebWorker is supported
        /// </summary>
        public bool WebWorkerSupported { get; private set; }
        /// <summary>
        /// Returns true if ServiceWorker is supported
        /// </summary>
        public bool ServiceWorkerSupported { get; private set; }
        /// <summary>
        /// Returns true if BroadcastChannel is supported
        /// </summary>
        public bool BroadcastChannelSupported { get; private set; }
        /// <summary>
        /// Returns true if LockManager is supported
        /// </summary>
        public bool LockManagerSupported { get; private set; }
        /// <summary>
        /// If true, InterConnect can be used for inter-instance communication negotiation
        /// </summary>
        public bool InterConnectSupported { get; private set; }
        /// <summary>
        /// If set to true and InterConnectSupported == true, the interconnect shared worker will be used to enable using MessagePort for inter-instance communication instead of BroadcastChannel>br/>
        /// MessagePort supports transferable objects, BroadcastChannel does not. 
        /// </summary>
        public bool InterConnectEnabled { get; set; } = true;
        /// <summary>
        /// A ServiceCallDispatcher that executes on this instance
        /// </summary>
        public ServiceCallDispatcher Local { get; }
        public IServiceProvider ServiceProvider { get; }
        public IServiceCollection ServiceDescriptors { get; }
        public string AppBaseUri { get; }
        public bool BeenInit { get; private set; }
        DateTime StartTime = DateTime.Now;
        /// <summary>
        /// The navigator.hardwareConcurrency value
        /// </summary>
        public int MaxWorkerCount { get; private set; } = 0;
        /// <summary>
        /// If this is a shared worker, this is the shared worker's name
        /// </summary>
        public string ThisSharedWorkerName { get; private set; } = "";
        Callback? OnSharedWorkerConnectCallback = null;
        /// <summary>
        /// This app instance's id
        /// </summary>
        public string InstanceId { get; }
        /// <summary>
        /// The script location used for new worker instances
        /// </summary>
        public string WebWorkerJSScript { get; } = "_content/SpawnDev.BlazorJS.WebWorkers/spawndev.blazorjs.webworkers.js";
        /// <summary>
        /// The script used for instance interconnect shared worker instance (if used)
        /// </summary>
        public string WebWorkerInterconnectJSScript { get; } = "_content/SpawnDev.BlazorJS.WebWorkers/interconnect.js";
        public BlazorJSRuntime JS { get; }
        public GlobalScope GlobalScope { get; }
        TaskCompletionSource? InstanceLock = null;
        /// <summary>
        /// If WebWorkers are supported it dispatches on a free WebWorker in the WebWorkerPool<br />
        /// If WebWorkers are not supported it dispatches on the local scope
        /// </summary>
        public WebWorkerPool TaskPool { get; }
        /// <summary>
        /// If this scope is a Window it dispatches on this scope<br />
        /// If this scope is a WebWorker and its parent is a Window it will dispatch on the parent's scope<br />
        /// Only available in a Window context, or in a WebWorker created by a Window
        /// </summary>
        public AsyncCallDispatcher? WindowTask { get; private set; }
        public ServiceWorkerConfig ServiceWorkerConfig { get; private set; } = new ServiceWorkerConfig { Register = ServiceWorkerStartupRegistration.None };
        // below is set to true if base address starts with chrome-extension
        public string WorkerIndexHtml { get; private set; } = "";
        public AppInstanceInfo Info { get; }
        BroadcastChannel? SharedBroadcastChannel = null;
        /// <summary>
        /// Navigator.Locks instance of LockManager or null if not supported
        /// </summary>
        public LockManager? Locks { get; private set; }
        SharedWorker? Interconnect = null;
        public WebWorkerService(NavigationManager navigationManager, IServiceProvider serviceProvider, IServiceCollection serviceDescriptors, IWebAssemblyHostEnvironment hostEnvironment, BlazorJSRuntime js)
        {
            JS = js;
            GlobalScope = JS.GlobalScope;
            InstanceId = JS.InstanceId;
            WebWorkerSupported = !JS.IsUndefined("Worker");
            SharedWebWorkerSupported = !JS.IsUndefined("SharedWorker");
            ServiceWorkerSupported = !JS.IsUndefined("ServiceWorkerRegistration");
            ServiceProvider = serviceProvider;
            ServiceDescriptors = serviceDescriptors;
            AppBaseUri = JS.Get<string>("document.baseURI");
            var workerScriptUri = new Uri(new Uri(AppBaseUri), WebWorkerJSScript);
            WebWorkerJSScript = workerScriptUri.ToString();
            Locks = JS.Get<LockManager>("navigator.locks");
            LockManagerSupported = Locks != null;
            Info = new AppInstanceInfo
            {
                InstanceId = InstanceId,
                Scope = GlobalScope,
                Name = GetName(),
                BaseUrl = AppBaseUri,
                Url = navigationManager.Uri,
            };
            BroadcastChannelSupported = !JS.IsUndefined(nameof(BroadcastChannel));
            if (BroadcastChannelSupported)
            {
                // this is the BroadcastChannel all instances will send their instance info on at startup
                SharedBroadcastChannel = new BroadcastChannel(nameof(WebWorkerService));
                SharedBroadcastChannel.OnMessage += SharedBroadcastChannel_OnMessage;
                // this is the BroadcastChannel the interconnect shared worker will message this instance on when messages are waiting
                // - the message contains the from instance info object and a MessagePort
                // if shared workers are not supported, instead of interconnect, a separate broadcast channel will be used and the request will come on this channel
                // - the message contains the from instance info object and a broadcast channel name to use for the connection
                InstanceBroadcastChannel = new BroadcastChannel(InstanceId);
                InstanceBroadcastChannel.OnMessage += InstanceBroadcastChannel_OnMessage;
            }
            InterConnectSupported = SharedWebWorkerSupported && BroadcastChannelSupported;
#if DEBUG && false
            Console.WriteLine($"InterConnectSupported: {InterConnectSupported}");
            Console.WriteLine("hostEnvironment.BaseAddress: " + hostEnvironment.BaseAddress);
            Console.WriteLine("AppBaseUri: " + AppBaseUri);
            Console.WriteLine("WebWorkerJSScript: " + WebWorkerJSScript);
#endif
            var hardwareConcurrency = JS.Get<int?>("navigator.hardwareConcurrency");
            MaxWorkerCount = hardwareConcurrency == null || hardwareConcurrency.Value == 0 ? 0 : hardwareConcurrency.Value;
            if (IServiceCollectionExtensions.ServiceWorkerConfig != null)
            {
                ServiceWorkerConfig = IServiceCollectionExtensions.ServiceWorkerConfig;
            };
            Local = new ServiceCallDispatcher(ServiceProvider, ServiceDescriptors);
            TaskPool = new WebWorkerPool(this, 0, 1, true);
        }
        BroadcastChannel? InstanceBroadcastChannel = null;
        void EnableInterconnectWorker()
        {
            if (Interconnect == null)
            {
                Interconnect = new SharedWorker(WebWorkerInterconnectJSScript);
                Interconnect.Port.OnMessage += Interconnect_OnMessage;
                Interconnect.Port.Start();
            }
        }
        internal void SendInterconnectPort(string instanceId, MessagePort port)
        {
            EnableInterconnectWorker();
            Interconnect!.Port.PostMessage(new object[] { "dropOff", instanceId, Info }, new object[] { port });
        }
        void GetInterconnectMessages()
        {
            EnableInterconnectWorker();
            // tell the interconnect we would like to pickup our messages
            Interconnect!.Port.PostMessage(new object[] { "pickUp", InstanceId });
        }
        void InstanceBroadcastChannel_OnMessage(MessageEvent messageEvent)
        {
            // if interconnect is not available (likely due to missing SharedWorker support (Chrome Android))
            using var args = messageEvent.GetData<Array>();
            if (args != null && args.Length > 0)
            {
                var cmd = args.Shift<string>();
                if (cmd == "interconnect")
                {
                    // pick up the ports the interconnect has waiting for us.
                    GetInterconnectMessages();
                }
                else
                {
                    // message directly from another instance
                    var instanceInfo = args.Shift<AppInstanceInfo>();
                    if (!_Instances.TryGetValue(instanceInfo.InstanceId, out var fromInstance))
                    {
                        InstanceFound(instanceInfo, true);
                        _Instances.TryGetValue(instanceInfo.InstanceId, out fromInstance);
                    }
                    if (fromInstance == null) return;
                    switch (cmd)
                    {
                        case "broadcastChannelConnect":
                            var connectionId = args.Shift<string>();
                            fromInstance.AddIncomingInterconnectPort(new BroadcastChannel(connectionId));
                            break;
                    }
                }
            }
        }
        class InterconnectIncomingMessage
        {
            public AppInstanceInfo FromInstanceInfo { get; set; }
            public long Time { get; set; }
        }
        void Interconnect_OnMessage(MessageEvent messageEvent)
        {
            InterconnectIncomingMessage data;
            try
            {
                data = messageEvent.GetData<InterconnectIncomingMessage>();
            }
            catch
            {
                return;
            }
            if (data == null || data.FromInstanceInfo == null || string.IsNullOrEmpty(data.FromInstanceInfo.InstanceId)) return;
            var instanceInfo = data.FromInstanceInfo;
            if (!_Instances.TryGetValue(instanceInfo.InstanceId, out var fromInstance))
            {
                InstanceFound(instanceInfo, true);
                _Instances.TryGetValue(instanceInfo.InstanceId, out fromInstance);
            }
            if (fromInstance == null)
            {
                return;
            }
            using var ports = messageEvent.Ports;
            if (ports == null || ports.Length == 0) return;
            var port = ports[0];
            fromInstance.AddIncomingInterconnectPort(port);
        }
        void SharedBroadcastChannel_OnMessage(MessageEvent messageEvent)
        {
            try
            {
                using var args = messageEvent.GetData<Array>();
                var argsLength = args.Length;
                var targetInstanceId = args.Shift<string>();
                if (targetInstanceId == AllInstancedId || targetInstanceId == InstanceId)
                {
                    var instanceInfo = args.Shift<AppInstanceInfo>();
                    if (!_Instances.TryGetValue(instanceInfo.InstanceId, out var fromInstance))
                    {
                        InstanceFound(instanceInfo, true);
                        _Instances.TryGetValue(instanceInfo.InstanceId, out fromInstance);
                    }
                    if (fromInstance == null)
                    {
                        return;
                    }
                    var cmd = args.Shift<string>();
                    switch (cmd)
                    {
                        case "register":
                            {
                                _ = UpdateInstancesViaLocks();
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                // Invalid message
                Console.WriteLine($"InstanceConnectChannel_OnMessage: {ex.Message}");
            }
            finally
            {
                messageEvent.Dispose();
            }
        }
        /// <summary>
        /// If true, incoming instance connections ill be allowed
        /// </summary>
        public bool EnableIncomingInstanceConnections { get; set; } = true;
        const string AllInstancedId = "*";
        internal void BroadcastCall(string targetInstanceId, string cmd, params object?[]? args)
        {
            var allArgs = new List<object>();
            allArgs.Add(targetInstanceId);
            allArgs.Add(Info);
            allArgs.Add(cmd);
            if (args != null && args.Length > 0) allArgs.AddRange(args);
            if (SharedBroadcastChannel != null)
            {
                SharedBroadcastChannel.PostMessage(allArgs);
            }
            else
            {
                // TODO
            }
        }
        internal void BroadcastCall(string cmd, params object?[]? args) => BroadcastCall(AllInstancedId, cmd, args);
        /// <summary>
        /// If this instance is a dedicated worker the message is sent to the parent that created this worker<br/>
        /// If this instance is a shared worker the message is sent to all of the instances that have connected to this instance
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data"></param>
        public void SendEventToParents(string eventName, params object?[]? data)
        {
            if (DedicatedWorkerParent != null)
            {
                DedicatedWorkerParent.SendEvent(eventName, data);
            }
            foreach (var p in SharedWorkerIncomingConnections)
            {
                p.SendEvent(eventName, data);
            }
        }
        public event Action OnDedicatedWorkerParentReady;
        /// <summary>
        /// A list of running instances including this one
        /// </summary>
        public List<AppInstance> Instances => _Instances.Values.ToList();
        /// <summary>
        /// A list of known instances running in a window scope
        /// </summary>
        public List<AppInstance> Windows => _Instances.Values.Where(o => o.Info.Scope == GlobalScope.Window).ToList();
        Dictionary<string, AppInstance> _Instances = new Dictionary<string, AppInstance>();
        /// <summary>
        /// Fires when a new instance is found
        /// </summary>
        public event Action<AppInstance> OnInstanceFound;
        /// <summary>
        /// Fires when an instance is no longer running
        /// </summary>
        public event Action<AppInstance> OnInstanceLost;
        /// <summary>
        /// Fires when one or more instances have been found or lost
        /// </summary>
        public event Action OnInstancesChanged;
        bool InstanceLost(string instanceId, bool fireChangedEvent)
        {
            if (!_Instances.TryGetValue(instanceId, out var instance)) return false;
            if (instance.IsLocal) return false;
            _Instances.Remove(instanceId);
#if DEBUG
            JS.Log($"Instance lost: {instanceId}", instance.Info, Instances.Select(o => o.Info).ToList());
#endif
            OnInstanceLost?.Invoke(instance);
            instance.Dispose();
            if (fireChangedEvent) OnInstancesChanged?.Invoke();
            return true;
        }
        bool InstanceFound(AppInstanceInfo instanceInfo, bool fireChangedEvent)
        {
            var instanceId = instanceInfo.InstanceId;
            if (_Instances.ContainsKey(instanceId)) return false;
            var instance = new AppInstance(this, instanceInfo);
            _Instances.Add(instanceId, instance);
#if DEBUG
            JS.Log($"Instance found: {instanceId}", instanceInfo, Instances.Select(o => o.Info).ToList());
#endif
            if (!instance.IsLocal)
            {
                if (Locks != null && !string.IsNullOrEmpty(instanceInfo.LockName))
                {
                    // this lock will be granted when the given instance terminates and releases their exclusive lock
                    _ = Locks.Request(instanceInfo.LockName, new LockRequestOptions { Mode = "shared" }, () =>
                    {
                        InstanceLost(instanceId, true);
                    });
                }
                else
                {
                    // TODO
                    // fallback termination detection
                }
            }
            OnInstanceFound?.Invoke(instance);
            if (fireChangedEvent) OnInstancesChanged?.Invoke();
            return true;
        }
        /// <summary>
        /// Returns information about running instances using locks to obtain it
        /// </summary>
        /// <returns></returns>
        async Task UpdateInstancesViaLocks()
        {
            // client id is used here as it will be available due to also using LockManager
            if (Locks != null)
            {
                var state = await Locks.Query();
                var previousClientIds = _Instances.Values.Select(o => o.Info.ClientId!).ToList();
                var currentClientIds = state.Held.Select(o => o.ClientId).ToList();
                var instancesLost = _Instances.Values.Where(o => !currentClientIds.Contains(o.Info.ClientId!)).ToList();
                var instancesFound = state.Held.Where(o => !previousClientIds.Contains(o.ClientId) && o.Name.StartsWith(IdentPrefix)).Select(o =>
                {
                    try
                    {
                        var ret = JsonSerializer.Deserialize<AppInstanceInfo>(o.Name.Substring(IdentPrefix.Length))!;
                        ret.ClientId = o.ClientId;
                        ret.LockName = o.Name;
                        return ret;
                    }
                    catch
                    {
                        return null;
                    }
                }).Where(o => o != null).ToList();
                // process instances found
                foreach (var instance in instancesFound)
                {
                    InstanceFound(instance!, false);
                }
                // process instances lost
                foreach (var instance in instancesLost)
                {
                    InstanceLost(instance.Info.InstanceId, false);
                }
                // fire changed event if instances were lost or found
                if (instancesFound.Count > 0 || instancesLost.Count > 0)
                {
                    OnInstancesChanged?.Invoke();
                }
            }
        }
        static readonly string IdentPrefix = $"{nameof(AppInstanceInfo)}:";
        string GetName()
        {
            if (JS.WindowThis != null) return JS.WindowThis.Name ?? "";
            if (JS.DedicateWorkerThis != null) return JS.DedicateWorkerThis.Name ?? "";
            if (JS.SharedWorkerThis != null) return JS.SharedWorkerThis.Name ?? "";
            return "";
        }
        string GetParentInstanceId()
        {
            if (JS.WindowThis != null) return JS.WindowThis.Name ?? "";
            if (JS.DedicateWorkerThis != null) return JS.DedicateWorkerThis.Name ?? "";
            if (JS.SharedWorkerThis != null) return JS.SharedWorkerThis.Name ?? "";
            return "";
        }
        public async Task InitAsync()
        {
            if (BeenInit) return;
            BeenInit = true;
            if (Locks != null)
            {
                Info.ClientId = await Locks.GetClientId();
            }
            if (JS.GlobalThis is Window window)
            {
                WindowTask = Local;
                switch (ServiceWorkerConfig.Register)
                {
                    case ServiceWorkerStartupRegistration.Register:
                        await RegisterServiceWorker();
                        break;
                    case ServiceWorkerStartupRegistration.Unregister:
                        await UnregisterServiceWorker();
                        break;
                }
            }
            else if (JS.GlobalThis is DedicatedWorkerGlobalScope workerGlobalScope)
            {
                DedicatedWorkerParent = new ServiceCallDispatcher(ServiceProvider, ServiceDescriptors, workerGlobalScope);
                DedicatedWorkerParent.SendReadyFlag();
                Async.Run(async () =>
                {
                    await DedicatedWorkerParent.WhenReady;
                    var isParentAWindow = DedicatedWorkerParent.RemoteInfo!.GlobalThisTypeName == "Window";
                    if (isParentAWindow)
                    {
                        WindowTask = DedicatedWorkerParent;
                    }
                    OnDedicatedWorkerParentReady?.Invoke();
                    Info.ParentInstanceId = DedicatedWorkerParent.RemoteInfo.InstanceId;
                    await RegisterInstance();
                });
                return;
            }
            else if (JS.GlobalThis is SharedWorkerGlobalScope sharedWorkerGlobalScope)
            {
                var missedConnections = JS.Call<MessagePort[]>("takeOverOnConnectEvent", OnSharedWorkerConnectCallback = Callback.Create<MessageEvent>(OnSharedWorkerConnect));
                if (missedConnections != null)
                {
                    foreach (var m in missedConnections)
                    {
                        AddIncomingPort(m);
                    }
                }
                var tmpName = sharedWorkerGlobalScope.Name;
                if (!string.IsNullOrEmpty(tmpName))
                {
                    ThisSharedWorkerName = tmpName;
                }
            }
            else if (JS.GlobalThis is ServiceWorkerGlobalScope serviceWorkerGlobalScope)
            {
                //Console.WriteLine($"WebWorkerService: ServiceWorkerGlobalScope");
                // 
            }
            else
            {
                //Console.WriteLine($"WebWorkerService: UNKNOWN");
            }
            await RegisterInstance();
        }

        /// <summary>
        /// Returns true if this instance has notified other instances
        /// </summary>
        public bool InstanceRegistered { get; private set; } = false;
        bool InstanceRegistering = false;
        async Task RegisterInstance()
        {
            if (InstanceRegistered || InstanceRegistering) return;
            InstanceRegistering = true;
            if (Locks != null)
            {
                // hold a lock with this instance's instanceId to allow instance termination detection
                var lockName = IdentPrefix + JsonSerializer.Serialize(Info);
                InstanceLock = await Locks.RequestHandle(lockName);
                Info.LockName = lockName;
            }
            InstanceFound(Info, true);
            BroadcastCall("register");
            InstanceRegistering = false;
            InstanceRegistered = true;
            await UpdateInstancesViaLocks();
        }
        /// <summary>
        /// Registers the default 'service-worker.js' in the app's base path.<br />
        /// 'service-worker.js' must import the web worker script like the example below<br />
        /// importScripts('_content/SpawnDev.BlazorJS.WebWorkers/spawndev.blazorjs.webworkers.js');
        /// </summary>
        /// <returns></returns>
        public async Task RegisterServiceWorker()
        {
            if (JS.WindowThis != null)
            {
                using var navigator = JS.WindowThis.Navigator;
                using var serviceWorker = navigator.ServiceWorker;
                using var registration = await serviceWorker.Register(ServiceWorkerConfig.ScriptURL, ServiceWorkerConfig.Options);
            }
        }

        /// <summary>
        /// Registers the default 'service-worker.js' in the app's base path.<br />
        /// </summary>
        /// <param name="scriptURL"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task RegisterServiceWorker(string scriptURL, ServiceWorkerRegistrationOptions? options = null)
        {
            ServiceWorkerConfig.ScriptURL = scriptURL;
            ServiceWorkerConfig.Options = options;
            return RegisterServiceWorker();
        }

        /// <summary>
        /// Unregisters a registered service worker
        /// </summary>
        /// <returns></returns>
        public async Task<bool> UnregisterServiceWorker()
        {
            if (JS.WindowThis != null)
            {
                using var navigator = JS.WindowThis.Navigator;
                using var serviceWorker = navigator.ServiceWorker;
                using var registration = await serviceWorker.GetRegistration();
                if (registration != null)
                {
                    return await registration.Unregister();
                }
            }
            return false;
        }

        /// <summary>
        /// Creates a new a WebWorker instance and returns it when it when it is ready for use.
        /// </summary>
        /// <returns></returns>
        public async Task<WebWorker?> GetWebWorker()
        {
            if (!WebWorkerSupported) return null;
            var queryParams = new Dictionary<string, string>();
#if DEBUG
            queryParams["forceCompatMode"] = "0";
#endif
            if (!string.IsNullOrEmpty(WorkerIndexHtml))
            {
                queryParams["indexHtml"] = WorkerIndexHtml;
            }
            var scriptUrl = WebWorkerJSScript;
            if (queryParams.Count > 0)
            {
                scriptUrl += "?" + string.Join('&', queryParams.Select(o => $""));
            }
            var worker = new Worker(scriptUrl);
            var webWorker = new WebWorker(worker, ServiceProvider, ServiceDescriptors);
            await webWorker.WhenReady;
            return webWorker;
        }
        /// <summary>
        /// Creates a new a WebWorker instance and returns.
        /// </summary>
        /// <returns></returns>
        public WebWorker? GetWebWorkerSync()
        {
            if (!WebWorkerSupported) return null;
            var queryParams = new Dictionary<string, string>();
#if DEBUG
            queryParams["forceCompatMode"] = "0";
#endif
            if (!string.IsNullOrEmpty(WorkerIndexHtml))
            {
                queryParams["indexHtml"] = WorkerIndexHtml;
            }
            var scriptUrl = WebWorkerJSScript;
            if (queryParams.Count > 0)
            {
                scriptUrl += "?" + string.Join('&', queryParams.Select(o => $""));
            }
            var worker = new Worker(scriptUrl);
            var webWorker = new WebWorker(worker, ServiceProvider, ServiceDescriptors);
            return webWorker;
        }

        /// <summary>
        /// Returns a new SharedWebWorker instance. If a SharedWorker already existed by this name SharedWebWorker will be connected to that instance.
        /// </summary>
        /// <param name="sharedWorkerName">SharedWebWorkers are identified by name. 1 shared worker will be created per name.</param>
        /// <returns></returns>
        public async Task<SharedWebWorker?> GetSharedWebWorker(string sharedWorkerName = "")
        {
            if (!SharedWebWorkerSupported) return null;
            var queryParams = new Dictionary<string, string>();
#if DEBUG
            queryParams["forceCompatMode"] = "0";
#endif
            if (!string.IsNullOrEmpty(WorkerIndexHtml))
            {
                queryParams["indexHtml"] = WorkerIndexHtml;
            }
            var scriptUrl = WebWorkerJSScript;
            if (queryParams.Count > 0)
            {
                scriptUrl += "?" + string.Join('&', queryParams.Select(o => $""));
            }
            var sharedWorker = new SharedWorker(scriptUrl, sharedWorkerName);
            var sharedWebWorker = new SharedWebWorker(sharedWorkerName, sharedWorker, ServiceProvider, ServiceDescriptors);
            await sharedWebWorker.WhenReady;
            return sharedWebWorker;
        }
        /// <summary>
        /// Returns a new SharedWebWorker instance. If a SharedWorker already existed by this name SharedWebWorker will be connected to that instance.
        /// </summary>
        /// <param name="sharedWorkerName"></param>
        /// <returns></returns>
        public SharedWebWorker? GetSharedWebWorkerSync(string sharedWorkerName = "")
        {
            if (!SharedWebWorkerSupported) return null;
            var queryParams = new Dictionary<string, string>();
#if DEBUG
            queryParams["forceCompatMode"] = "0";
#endif
            if (!string.IsNullOrEmpty(WorkerIndexHtml))
            {
                queryParams["indexHtml"] = WorkerIndexHtml;
            }
            var scriptUrl = WebWorkerJSScript;
            if (queryParams.Count > 0)
            {
                scriptUrl += "?" + string.Join('&', queryParams.Select(o => $""));
            }
            var sharedWorker = new SharedWorker(scriptUrl, sharedWorkerName);
            var sharedWebWorker = new SharedWebWorker(sharedWorkerName, sharedWorker, ServiceProvider, ServiceDescriptors);
            return sharedWebWorker;
        }

        /// <summary>
        /// Disposes all disposable resources used by this object
        /// </summary>
        public void Dispose()
        {
            OnSharedWorkerConnectCallback?.Dispose();
        }

        void OnSharedWorkerConnect(MessageEvent e)
        {
            e.Ports.ToList().ForEach(AddIncomingPort);
        }

        void AddIncomingPort(MessagePort incomingPort)
        {
            var incomingHandler = new ServiceCallDispatcher(ServiceProvider, ServiceDescriptors, incomingPort);
            incomingPort.Start();
            SharedWorkerIncomingConnections.Add(incomingHandler);
            incomingHandler.SendReadyFlag();
        }
    }
}
