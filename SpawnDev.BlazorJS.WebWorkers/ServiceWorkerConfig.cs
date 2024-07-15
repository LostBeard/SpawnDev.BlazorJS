using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.WebWorkers
{
    /// <summary>
    /// Options for managing ServiceWorker registration
    /// </summary>
    public class ServiceWorkerConfig
    {
        /// <summary>
        /// The registration action to take when the app starts in a Window scope
        /// </summary>
        public ServiceWorkerStartupRegistration Register { get; set; } = ServiceWorkerStartupRegistration.Register;
        /// <summary>
        /// Defaults to WebWorkerService.WebWorkerJSScript ('spawndev.blazorjs.webworkers.js')
        /// </summary>
        public string? ScriptURL { get; set; }
        /// <summary>
        /// Options used when registering a ServiceWorker via ServiceWorkerContainer.Register()
        /// </summary>
        public ServiceWorkerRegistrationOptions? Options { get; set; }
    }
}

