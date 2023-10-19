using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public class MissedFetchEvent : FetchEvent
    {
        public MissedFetchEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void ResponseResolve(Response response) => JSRef.CallVoid("responseResolve", response);
        public void ResponseReject() => JSRef.CallVoid("responseReject");
    }
    // Firefox service worker debug page
    // about:debugging#/runtime/this-firefox
    public class ServiceWorkerBase : IBackgroundService, IDisposable
    {
        Timer tmr = new Timer();
        BlazorJSRuntime JS;
        ServiceWorkerGlobalScope? ServiceWorkerThis = null;
        public ServiceWorkerBase(BlazorJSRuntime js)
        {
            JS = js;
            ServiceWorkerThis = JS.ServiceWorkerThis;
            if (ServiceWorkerThis != null)
            {
                // the service is running a ServiceWorker
                Console.WriteLine("ServiceWorker: IsServiceWorkerGlobalScope");
                ServiceWorkerThis.OnFetch += ServiceWorker_OnFetch;
                ServiceWorkerThis.OnInstall += ServiceWorker_OnInstall;
                ServiceWorkerThis.OnActivate += ServiceWorker_OnActivate;
                // let he worker script know we are loaded and ready to listen. (may need to handle missed events)
                var missedEvents = JS.Call<Array<MissedFetchEvent>>("ServiceWorkerBaseInit").ToList();
                missedEvents.ForEach(ServiceWorker_OnFetch);
                tmr.Elapsed += Tmr_Elapsed;
                tmr.Interval = 5000;
                tmr.Enabled = true;
            }
            else
            {
                // not running in a ServiceWorker. 
            }
        }

        private void Tmr_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("ServiceWorker: Tmr_Elapsed");
        }

        void ServiceWorker_OnInstall(ExtendableEvent e)
        {
            Console.WriteLine($"ServiceWorker: ServiceWorker_OnInstall");
            _ = ServiceWorkerThis!.SkipWaiting();
        }

        void ServiceWorker_OnActivate(ExtendableEvent e)
        {
            Console.WriteLine($"ServiceWorker: ServiceWorker_OnActivate");
        }

        void ServiceWorker_OnFetch(FetchEvent e)
        {
            Console.WriteLine($"ServiceWorker_OnFetch: {e.ClientId} {e.Request.Url}");
            // optionally handle the request
            // this handles them all for testing
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

        async Task<Response> ServiceWorker_OnFetchAsync(FetchEvent e)
        {
            Response ret;
            try
            {
                var newUrl = e.Request.Url.Split('?')[0] + "?HandledByTheServiceWorker=1";
                ret = await JS.Fetch(newUrl);
            }
            catch (Exception ex)
            {
                ret = new Response(ex.Message, new ResponseOptions { Status = 500, StatusText = ex.Message, Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } } });
                Console.WriteLine($"ServiceWorker_OnFetchAsync failed: {ex.Message}");
            }
            return ret;
        }

        public void Dispose()
        {
            if (ServiceWorkerThis != null)
            {
                Console.WriteLine("ServiceWorker: Dispose()");
            }
        }
    }
}

