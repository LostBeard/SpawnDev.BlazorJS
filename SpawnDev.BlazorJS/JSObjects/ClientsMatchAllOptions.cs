using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for Clients.matchAll
    /// </summary>
    public class ClientsMatchAllOptions
    {
        /// <summary>
        /// A boolean value — if set to true, the matching operation will return all service worker clients who share the same origin as the current service worker. Otherwise, it returns only the service worker clients controlled by the current service worker. The default is false
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeUncontrolled { get; set; }

        /// <summary>
        /// Sets the type of clients you want matched. Available values are "window", "worker", "sharedworker", and "all". The default is "window"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; }
    }
}
