using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.WebWorkers
{
    public class ServiceWorkerConfig
    {
        public ServiceWorkerStartupRegistration Register { get; set; } = ServiceWorkerStartupRegistration.Register;
        public string ScriptURL { get; set; } = "service-worker.js";
        public ServiceWorkerRegistrationOptions? Options { get; set; } = null;
    }
}

