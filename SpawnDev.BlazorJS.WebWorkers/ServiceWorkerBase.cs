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
        public ServiceWorkerBase(BlazorJSRuntime js)
        {
            JS = js;
            if (JS.ServiceWorkerThis != null)
            {
                Console.WriteLine("ServiceWorker: IsServiceWorkerGlobalScope");
                JS.ServiceWorkerThis.OnFetch += ServiceWorker_OnFetch;
                JS.CallVoid("ServiceWorkerBaseInit");
            }
        }
        void ServiceWorker_OnFetch(FetchEvent e)
        {
            Console.WriteLine($"ServiceWorker_OnFetch: {e.ClientId} {e.Request.Url}");
            e.RespondWith(ServiceWorker_OnFetchAsync(e));
        }
        async Task<Response> ServiceWorker_OnFetchAsync(FetchEvent e)
        {
            Response? ret = null;
            Console.WriteLine($"ServiceWorker_OnFetchAsync: {e.ClientId} {e.Request.Url}");
            try
            {
                ret = await JS.Fetch(e.Request.Url);
                Console.WriteLine($"resp.ok: {ret.Ok}");
            }
            catch(Exception ex)
            {
                // return new Response('Server error', { "status": 500, headers: { "Content-Type": "text/plain" } });
                Console.WriteLine($"ServiceWorker_OnFetchAsync failed: {ex.Message}");
            }
            if (ret == null)
            {
                ret = new Response("File not found", new ResponseOptions { Status = 404, StatusText = "File not found" });
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

