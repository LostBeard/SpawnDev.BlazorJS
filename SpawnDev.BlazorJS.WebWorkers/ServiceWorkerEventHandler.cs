using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public class ServiceWorkerEventHandler : IAsyncBackgroundService, IDisposable
    {
        protected BlazorJSRuntime JS;
        protected ServiceWorkerGlobalScope? ServiceWorkerThis = null;
        public string InstanceId { get; private set; } = Guid.NewGuid().ToString();
        ServiceWorkerConfig ServiceWorkerConfig;
        public ServiceWorkerEventHandler(BlazorJSRuntime js, ServiceWorkerConfig serviceWorkerConfig)
        {
            JS = js;
            ServiceWorkerThis = JS.ServiceWorkerThis;
            ServiceWorkerConfig = serviceWorkerConfig;
        }

        protected void Log(params object[] args)
        {
            JS.Log(new object?[] { $"ServiceWorkerEventHandler: {InstanceId}" }.Concat(args).ToArray());
        }

        public async Task InitAsync()
        {
            if (JS.IsWindow)
            {
                if (ServiceWorkerConfig.Register == ServiceWorkerStartupRegistration.Register)
                {
                    await Register();
                }
                else if (ServiceWorkerConfig.Register == ServiceWorkerStartupRegistration.Unregister)
                {
                    await Unregister();
                }
            }
            await OnInitializedAsync();
            if (ServiceWorkerThis != null)
            {
                // the service is running a ServiceWorker
                Log("Blazor WASM ServiceWorker");
                ServiceWorkerThis.OnFetch += ServiceWorker_OnFetch;
                ServiceWorkerThis.OnInstall += ServiceWorker_OnInstall;
                ServiceWorkerThis.OnActivate += ServiceWorker_OnActivate;
                ServiceWorkerThis.OnMessage += ServiceWorker_OnMessage;
                ServiceWorkerThis.OnPush += ServiceWorker_OnPush;
                ServiceWorkerThis.OnPushSubscriptionChange += ServiceWorker_OnPushSubscriptionChange;
                ServiceWorkerThis.OnSync += ServiceWorker_OnSync;
                ServiceWorkerThis.OnNotificationClose += ServiceWorker_OnNotificationClose;
                ServiceWorkerThis.OnNotificationClick += ServiceWorker_OnNotificationClick;
                GetMissedServiceWorkerEvents();
            }
        }

        /// <summary>
        /// registers the default 'service-worker.js' in the app's base path.<br />
        /// 'service-worker.js' must import the web worker script like the example below<br />
        /// importScripts('_content/SpawnDev.BlazorJS.WebWorkers/spawndev.blazorjs.webworkers.js');
        /// </summary>
        /// <returns></returns>
        public async Task Register()
        {
            if (JS.WindowThis != null)
            {
                using var navigator = JS.WindowThis.Navigator;
                using var serviceWorker = navigator.ServiceWorker;
                using var registration = await serviceWorker.Register(ServiceWorkerConfig.ScriptURL, ServiceWorkerConfig.Options);
            }
        }

        public Task Register(string scriptURL, ServiceWorkerRegistrationOptions? options = null)
        {
            ServiceWorkerConfig.Register = ServiceWorkerStartupRegistration.Register;
            ServiceWorkerConfig.ScriptURL = scriptURL;
            ServiceWorkerConfig.Options = options;
            return Register();
        }

        public async Task<bool> Unregister()
        {
            ServiceWorkerConfig.Register = ServiceWorkerStartupRegistration.Unregister;
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

        void GetMissedServiceWorkerEvents()
        {
            var missedEvents = JS.Call<JSObjects.Array>("GetMissedServiceWorkerEvents");
            missedEvents.ForEach<Event>(e =>
            {
                var type = e.Type;
                switch (type)
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
                        ServiceWorker_OnNotificationClose(e.JSRefMove<MissedNotificationEvent>());
                        break;
                    case "notificationclose":
                        ServiceWorker_OnNotificationClose(e.JSRefMove<MissedNotificationEvent>());
                        break;
                    case "push":
                        ServiceWorker_OnPush(e.JSRefMove<MissedPushEvent>());
                        break;
                    case "pushsubscriptionchange":
                        ServiceWorker_OnPushSubscriptionChange(e.JSRefMove<Event>());
                        break;
                    case "sync":
                        ServiceWorker_OnSync(e.JSRefMove<MissedSyncEvent>());
                        break;
                }
            });
        }

        void ServiceWorker_OnNotificationClose(NotificationEvent e)
        {
            if (e is MissedNotificationEvent missedEvent)
            {
                _ = Task.Run(async () =>
                {
                    await ServiceWorker_OnNotificationCloseAsync(e);
                    missedEvent.WaitResolve();
                });
            }
            else
            {
                e.WaitUntil(ServiceWorker_OnNotificationCloseAsync(e));
            }
        }

        void ServiceWorker_OnNotificationClick(NotificationEvent e)
        {
            if (e is MissedNotificationEvent missedEvent)
            {
                _ = Task.Run(async () =>
                {
                    await ServiceWorker_OnNotificationClickAsync(e);
                    missedEvent.WaitResolve();
                });
            }
            else
            {
                e.WaitUntil(ServiceWorker_OnNotificationClickAsync(e));
            }
        }

        protected virtual Task OnInitializedAsync() => Task.CompletedTask;

        protected virtual Task ServiceWorker_OnInstallAsync(ExtendableEvent e) => Task.CompletedTask;

        protected virtual Task ServiceWorker_OnActivateAsync(ExtendableEvent e) => Task.CompletedTask;

        protected virtual Task ServiceWorker_OnMessageAsync(ExtendableMessageEvent e) => Task.CompletedTask;

        protected virtual Task ServiceWorker_OnPushAsync(PushEvent e) => Task.CompletedTask;

        protected virtual void ServiceWorker_OnPushSubscriptionChange(Event e) { }

        protected virtual Task ServiceWorker_OnSyncAsync(SyncEvent e) => Task.CompletedTask;

        protected virtual Task ServiceWorker_OnNotificationCloseAsync(NotificationEvent e) => Task.CompletedTask;

        protected virtual Task ServiceWorker_OnNotificationClickAsync(NotificationEvent e) => Task.CompletedTask;

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
            }
            return ret;
        }

        void ServiceWorker_OnInstall(ExtendableEvent e)
        {
            if (e is MissedExtendableEvent missedEvent)
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        await ServiceWorker_OnInstallAsync(e);
                        missedEvent.WaitResolve();
                    }
                    catch
                    {
                        missedEvent.WaitReject();
                    }
                });
            }
            else
            {
                e.WaitUntil(ServiceWorker_OnInstallAsync(e));
            }
        }

        void ServiceWorker_OnActivate(ExtendableEvent e)
        {
            if (e is MissedExtendableEvent missedEvent)
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        await ServiceWorker_OnActivateAsync(e);
                        missedEvent.WaitResolve();
                    }
                    catch
                    {
                        missedEvent.WaitReject();
                    }
                });
            }
            else
            {
                e.WaitUntil(ServiceWorker_OnActivateAsync(e));
            }
        }

        void ServiceWorker_OnFetch(FetchEvent e)
        {
            if (e is MissedFetchEvent missedEvent)
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        var response = await ServiceWorker_OnFetchAsync(e);
                        missedEvent.ResponseResolve(response);
                    }
                    catch
                    {
                        missedEvent.ResponseReject();
                    }
                });
            }
            else
            {
                e.RespondWith(ServiceWorker_OnFetchAsync(e));
            }
        }

        void ServiceWorker_OnMessage(ExtendableMessageEvent e)
        {
            if (e is MissedExtendableMessageEvent missedEvent)
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        await ServiceWorker_OnMessageAsync(e);
                        missedEvent.WaitResolve();
                    }
                    catch
                    {
                        missedEvent.WaitReject();
                    }
                });
            }
            else
            {
                e.WaitUntil(ServiceWorker_OnMessageAsync(e));
            }
        }

        void ServiceWorker_OnPush(PushEvent e)
        {
            if (e is MissedPushEvent missedEvent)
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        await ServiceWorker_OnPushAsync(e);
                        missedEvent.WaitResolve();
                    }
                    catch
                    {
                        missedEvent.WaitReject();
                    }
                });
            }
            else
            {
                e.WaitUntil(ServiceWorker_OnPushAsync(e));
            }
        }

        void ServiceWorker_OnSync(SyncEvent e)
        {
            if (e is MissedSyncEvent missedEvent)
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        await ServiceWorker_OnSyncAsync(e);
                        missedEvent.WaitResolve();
                    }
                    catch
                    {
                        missedEvent.WaitReject();
                    }
                });
            }
            else
            {
                e.WaitUntil(ServiceWorker_OnSyncAsync(e));
            }
        }
        public virtual void Dispose()
        {
            if (ServiceWorkerThis != null)
            {
                Log("Dispose()");
            }
        }
    }
}

