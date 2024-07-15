using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options used when registering a ServiceWorker via ServiceWorkerContainer.Register()<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer/register#options
    /// </summary>
    public class ServiceWorkerRegistrationOptions
    {
        /// <summary>
        /// A string representing a URL that defines a service worker's registration scope; that is, what range of URLs a service worker can control. This is usually a relative URL. It is relative to the base URL of the application. By default, the scope value for a service worker registration is set to the directory where the service worker script is located (by resolving ./ against scriptURL). See the Examples section for more information on how it works.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Scope { get; set; }
        /// <summary>
        /// A string specifying the type of worker to create. Valid values are:<br/>
        /// "classic" - The loaded service worker is in a standard script. This is the default.<br/>
        /// "module" - The loaded service worker is in an ES module and the import statement is available on worker contexts. For ES module compatibility info, see the browser compatibility data table for the ServiceWorker interface.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; }
        /// <summary>
        /// A string indicating how the HTTP cache is used for service worker scripts resources during updates. Note: This only refers to the service worker script and its imports, not other resources fetched by these scripts.<br/>
        /// "all" - The HTTP cache will be queried for the main script, and all imported scripts. If no fresh entry is found in the HTTP cache, then the scripts are fetched from the network.<br/>
        /// "imports" - The HTTP cache will be queried for imports, but the main script will always be updated from the network. If no fresh entry is found in the HTTP cache for the imports, they're fetched from the network.<br/>
        /// "none" - The HTTP cache will not be used for the main script or its imports. All service worker script resources will be updated from the network.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UpdateViaCache { get; set; } = "none";
    }
}
