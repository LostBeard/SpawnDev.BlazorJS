using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.WebWorkers
{

    internal class MissedNotificationEvent : NotificationEvent
    {
        public MissedNotificationEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void WaitResolve() => JSRef.CallVoid("waitResolve");
        public void WaitReject() => JSRef.CallVoid("waitReject");
    }
    internal class MissedPushEvent : PushEvent
    {
        public MissedPushEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void WaitResolve() => JSRef.CallVoid("waitResolve");
        public void WaitReject() => JSRef.CallVoid("waitReject");
    }
    internal class MissedSyncEvent : SyncEvent
    {
        public MissedSyncEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void WaitResolve() => JSRef.CallVoid("waitResolve");
        public void WaitReject() => JSRef.CallVoid("waitReject");
    }
    internal class MissedExtendableMessageEvent : ExtendableMessageEvent
    {
        public MissedExtendableMessageEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void WaitResolve() => JSRef.CallVoid("waitResolve");
        public void WaitReject() => JSRef.CallVoid("waitReject");
    }
    internal class MissedFetchEvent : FetchEvent
    {
        public MissedFetchEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void ResponseResolve(Response response) => JSRef.CallVoid("responseResolve", response);
        public void ResponseReject() => JSRef.CallVoid("responseReject");
    }

    internal class MissedExtendableEvent : ExtendableEvent
    {
        public MissedExtendableEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void WaitResolve() => JSRef.CallVoid("waitResolve");
        public void WaitReject() => JSRef.CallVoid("waitReject");
    }

    public class ServiceWorkerManager : IAsyncBackgroundService, IDisposable
    {
        BlazorJSRuntime JS;
        ServiceWorkerGlobalScope? ServiceWorkerThis = null;
        public string InstanceId { get; private set; }  = Guid.NewGuid().ToString();
        public ServiceWorkerManager(BlazorJSRuntime js)
        {
            JS = js;
            ServiceWorkerThis = JS.ServiceWorkerThis;
        }

        void Log(params object[] args)
        {
            JS.Log(new object?[] { $"ServiceWorkerManager: {InstanceId}" }.Concat(args).ToArray());
        }

        public async Task InitAsync()
        {
            await OnInitialized();
            if (ServiceWorkerThis != null)
            {
                // the service is running a ServiceWorker
                Log("Blazor WASM ServiceWorker");
                ServiceWorkerThis.OnFetch += ServiceWorker_OnFetch;
                ServiceWorkerThis.OnInstall += ServiceWorker_OnInstall;
                ServiceWorkerThis.OnActivate += ServiceWorker_OnActivate;
                ServiceWorkerThis.OnMessage += ServiceWorker_OnMessage;
                ServiceWorkerThis.OnPush += ServiceWorker_OnPush;
                ServiceWorkerThis.OnPushSubscriptionChange += OnPushSubscriptionChange;
                ServiceWorkerThis.OnSync += ServiceWorker_OnSync;
                ServiceWorkerThis.OnNotificationClose += ServiceWorker_OnNotificationClose;
                ServiceWorkerThis.OnNotificationClick += ServiceWorker_OnNotificationClick;
                GetMissedServiceWorkerEvents();
            }
        }

        void GetMissedServiceWorkerEvents()
        {
            var missedEvents = JS.Call<JSObjects.Array>("GetMissedServiceWorkerEvents");
            missedEvents.ForEach<Event>(e => {
                var type = e.Type;
                switch(type)
                {
                    case "activate":
                        ServiceWorker_OnActivate(e.JSRefMove<MissedExtendableEvent>());
                        break;
                    case "fetch":
                        ServiceWorker_OnFetch(e.JSRefMove<MissedFetchEvent>());
                        break;
                    case "install":
                        ServiceWorker_OnInstall(e.JSRefMove<MissedExtendableEvent>());
                        break;
                    case "message":
                        ServiceWorker_OnMessage(e.JSRefMove<MissedExtendableMessageEvent>());
                        break;
                    case "notificationclick":
                        ServiceWorker_OnNotificationClose(e.JSRefMove<NotificationEvent>());
                        break;
                    case "notificationclose":
                        ServiceWorker_OnNotificationClose(e.JSRefMove<NotificationEvent>());
                        break;
                    case "push":
                        ServiceWorker_OnPush(e.JSRefMove<MissedPushEvent>());
                        break;
                    case "pushsubscriptionchange":
                        OnPushSubscriptionChange(e.JSRefMove<Event>());
                        break;
                    case "sync":
                        ServiceWorker_OnSync(e.JSRefMove<MissedSyncEvent>());
                        break;
                }
            });
        }

        void ServiceWorker_OnNotificationClose(NotificationEvent e)
        {
            if (e is MissedNotificationEvent missedFetchEvent)
            {
                _ = Task.Run(async () =>
                {
                    await ServiceWorker_OnNotificationCloseAsync(e);
                    missedFetchEvent.WaitResolve();
                });
            }
            else
            {
                e.WaitUntil(ServiceWorker_OnNotificationCloseAsync(e));
            }
        }

        void ServiceWorker_OnNotificationClick(NotificationEvent e)
        {
            if (e is MissedNotificationEvent missedFetchEvent)
            {
                _ = Task.Run(async () =>
                {
                    await ServiceWorker_OnNotificationClickAsync(e);
                    missedFetchEvent.WaitResolve();
                });
            }
            else
            {
                e.WaitUntil(ServiceWorker_OnNotificationClickAsync(e));
            }
        }

        protected virtual async Task ServiceWorker_OnNotificationCloseAsync(NotificationEvent e)
        {
            Log($"ServiceWorker_OnNotificationCloseAsync");
        }

        protected virtual async Task ServiceWorker_OnNotificationClickAsync(NotificationEvent e)
        {
            Log($"ServiceWorker_OnNotificationClickAsync");
        }

        /// <summary>
        /// This is the default implementation of InitAsync for this class. It calls Register() which registers the default service-worker.js script location.
        /// </summary>
        /// <returns></returns>
        protected virtual async Task OnInitialized()
        {
            await Register();
        }

        public async Task Register()
        {
            if (JS.WindowThis != null)
            {
                using var navigator = JS.WindowThis.Navigator;
                using var serviceWorker = navigator.ServiceWorker;
                using var registration = await serviceWorker.Register("service-worker.js");
            }
        }

        public async Task Register(string scriptURL, ServiceWorkerRegistrationOptions? options = null)
        {
            if (JS.WindowThis != null)
            {
                using var navigator = JS.WindowThis.Navigator;
                using var serviceWorker = navigator.ServiceWorker;
                using var registration = await serviceWorker.Register(scriptURL, options);
            }
        }

        public async Task<bool> Unregister()
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

        void ServiceWorker_OnInstall(ExtendableEvent e)
        {
            if (e is MissedExtendableEvent missedFetchEvent)
            {
                _ = Task.Run(async () =>
                {
                    await ServiceWorker_OnInstallAsync(e);
                    missedFetchEvent.WaitResolve();
                });
            }
            else
            {
                e.WaitUntil(ServiceWorker_OnInstallAsync(e));
            }
        }

        protected virtual async Task ServiceWorker_OnInstallAsync(ExtendableEvent e)
        {
            Log($"ServiceWorker_OnInstallAsync");
            _ = ServiceWorkerThis!.SkipWaiting();   // returned task can be ignored
        }

        void ServiceWorker_OnActivate(ExtendableEvent e)
        {
            if (e is MissedExtendableEvent missedFetchEvent)
            {
                _ = Task.Run(async () =>
                {
                    await ServiceWorker_OnActivateAsync(e);
                    missedFetchEvent.WaitResolve();
                });
            }
            else
            {
                e.WaitUntil(ServiceWorker_OnActivateAsync(e));
            }
        }

        protected virtual async Task ServiceWorker_OnActivateAsync(ExtendableEvent e)
        {
            Log($"ServiceWorker_OnActivateAsync");
            await ServiceWorkerThis!.Clients.Claim();
        }

        void ServiceWorker_OnFetch(FetchEvent e)
        {
            if (e is MissedFetchEvent missedFetchEvent)
            {
                _ = Task.Run(async () =>
                {
                    var response = await ServiceWorker_OnFetchAsync(e);
                    missedFetchEvent.ResponseResolve(response);
                });
            }
            else
            {
                e.RespondWith(ServiceWorker_OnFetchAsync(e));
            }
        }

        protected virtual async Task<Response> ServiceWorker_OnFetchAsync(FetchEvent e)
        {
            Response ret;
            try
            {
                ret = await JS.Fetch(e.Request);
            }
            catch (Exception ex)
            {
                ret = new Response(ex.Message, new ResponseOptions { Status = 500, StatusText = ex.Message, Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } } });
                Log($"ServiceWorker_OnFetchAsync failed: {ex.Message}");
            }
            return ret;
        }

        void ServiceWorker_OnMessage(ExtendableMessageEvent e)
        {
            e.WaitUntil(ServiceWorker_OnMessageAsync(e));
        }

        protected virtual async Task ServiceWorker_OnMessageAsync(ExtendableMessageEvent e)
        {
            Log($"ServiceWorker_OnMessageAsync");
        }

        void ServiceWorker_OnPush(PushEvent e)
        {
            e.WaitUntil(ServiceWorker_OnPushAsync(e));
        }

        protected virtual async Task ServiceWorker_OnPushAsync(PushEvent e)
        {
            Log($"ServiceWorker_OnPushAsync");
        }

        protected virtual void OnPushSubscriptionChange(Event e)
        {
            Log($"OnPushSubscriptionChange");
        }

        void ServiceWorker_OnSync(SyncEvent e)
        {
            e.WaitUntil(ServiceWorker_OnSyncAsync(e));
        }

        protected virtual async Task ServiceWorker_OnSyncAsync(SyncEvent e)
        {
            Log($"ServiceWorker_OnSyncAsync");
        }
        public void Dispose()
        {
            if (ServiceWorkerThis != null)
            {
                Log("Dispose()");
            }
        }
    }
}

