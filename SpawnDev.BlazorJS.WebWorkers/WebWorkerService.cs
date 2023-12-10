using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Reflection;

namespace SpawnDev.BlazorJS.WebWorkers
{
    // chrome://inspect/#workers
    public class WebWorkerService : IDisposable, IAsyncBackgroundService
    {
        public ServiceCallDispatcher? DedicatedWorkerParent { get; private set; } = null;
        public List<ServiceCallDispatcher> SharedWorkerIncomingConnections { get; private set; } = new List<ServiceCallDispatcher>();
        public bool SharedWebWorkerSupported { get; private set; }
        public bool WebWorkerSupported { get; private set; }
        public bool ServiceWorkerSupported { get; private set; }
        public ServiceCallDispatcher Local { get; }
        public IServiceProvider ServiceProvider { get; }
        public IServiceCollection ServiceDescriptors { get; }
        public string AppBaseUri { get; }
        public bool BeenInit { get; private set; }
        DateTime StartTime = DateTime.Now;
        public int MaxWorkerCount { get; private set; } = 0;
        public string ThisSharedWorkerName { get; private set; } = "";
        Callback? OnSharedWorkerConnectCallback = null;
        public string InstanceId { get; }
        public string WebWorkerJSScript { get; } = "_content/SpawnDev.BlazorJS.WebWorkers/spawndev.blazorjs.webworkers.js";
        public BlazorJSRuntime JS { get; }
        public GlobalScope GlobalScope { get; }
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
#if DEBUG && false
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

        class WebWorkerServiceEventMsgBase
        {
            public string SrcId { get; set; } = "";
            public string Event { get; set; } = "";
        }
        class WebWorkerServiceEventMsgOutgoing : WebWorkerServiceEventMsgBase
        {
            public object? Data { get; set; } = null;
        }

        public void SendEventToParents(string eventName, object? data = null)
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

        public async Task InitAsync()
        {
            if (BeenInit) return;
            BeenInit = true;
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
                await DedicatedWorkerParent.WhenReady;
                var isParentAWindow = DedicatedWorkerParent.RemoteInfo!.GlobalThisTypeName == "Window";
                if (isParentAWindow)
                {
                    WindowTask = DedicatedWorkerParent;
                }
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
                Console.WriteLine($"WebWorkerService: ServiceWorkerGlobalScope");
                // 
            }
            else
            {
                Console.WriteLine($"WebWorkerService: UNKNOWN");

            }
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
        /// Returns a WebWorker
        /// </summary>
        /// <returns></returns>
        public async Task<WebWorker?> GetWebWorker()
        {
            if (!WebWorkerSupported) return null;
            var worker = new Worker(WebWorkerJSScript);
            var webWorker = new WebWorker(worker, ServiceProvider, ServiceDescriptors);
            await webWorker.WhenReady;
            return webWorker;
        }

        /// <summary>
        /// Returns a SharedWebWorker
        /// </summary>
        /// <param name="sharedWorkerName">SharedWebWorkers are identified by name. 1 shared worker will be created per name.</param>
        /// <returns></returns>
        public async Task<SharedWebWorker?> GetSharedWebWorker(string sharedWorkerName = "")
        {
            if (!SharedWebWorkerSupported) return null;
            var sharedWorker = new SharedWorker(WebWorkerJSScript, sharedWorkerName);
            var sharedWebWorker = new SharedWebWorker(sharedWorkerName, sharedWorker, ServiceProvider, ServiceDescriptors);
            await sharedWebWorker.WhenReady;
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
