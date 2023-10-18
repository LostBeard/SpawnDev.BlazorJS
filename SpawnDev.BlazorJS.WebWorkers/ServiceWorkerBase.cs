using SpawnDev.BlazorJS.JSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public class ServiceWorkerBase : IAsyncBackgroundService
    {
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
                // let he worker script know we are loaded and ready to listen. (may need to handle missed events)
                JS.CallVoid("ServiceWorkerBaseInit");
            }
            else
            {
                // not running in a ServiceWorker. 
            }
        }
        void ServiceWorker_OnFetch(FetchEvent e)
        {
            Console.WriteLine($"ServiceWorker_OnFetch: {e.ClientId} {e.Request.Url}");
            // optionally handle the request
            // this handles them all for testing
            e.RespondWith(ServiceWorker_OnFetchAsync(e));
        }
        async Task<Response> ServiceWorker_OnFetchAsync(FetchEvent e)
        {
            Response ret;
            try
            {
                ret = await JS.Fetch(e.Request);
            }
            catch (Exception ex)
            {
                ret = new Response(ex.Message, new ResponseOptions { Status = 500, StatusText = ex.Message,  Headers = new Dictionary<string, string>{ { "Content-Type", "text/plain" } } });
                Console.WriteLine($"ServiceWorker_OnFetchAsync failed: {ex.Message}");
            }
            return ret;
        }
        public async Task InitAsync()
        {
            if (JS.IsServiceWorkerGlobalScope)
            {
                Console.WriteLine("ServiceWorker: ServiceWorkerBase.InitAsync");
            }
        }
    }
}

