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
        /// Defaults to WebWorkerService.WebWorkerJSScript ('spawndev.blazorjs.webworkers.js')<br/>
        /// This should be the value from &lt;ServiceWorkerAssetsManifest&gt; in your project's .csproj file if different than the default
        /// </summary>
        public string? ScriptURL { get; set; }
        /// <summary>
        /// By default, this is "service-worker-assets.js"
        /// </summary>
        public string? ServiceWorkerAssetsManifest { get; set; }
        /// <summary>
        /// This should be true if using &lt;ServiceWorkerAssetsManifest&gt; in your project's .csproj file
        /// </summary>
        public bool ImportServiceWorkerAssets { get; set; }
        /// <summary>
        /// Options used when registering a ServiceWorker via ServiceWorkerContainer.Register()
        /// </summary>
        public ServiceWorkerRegistrationOptions? Options { get; set; }
    }
}

