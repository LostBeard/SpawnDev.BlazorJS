using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object containing option properties that can be set when creating the Worker instance.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Worker/Worker#options
    /// </summary>
    public class WorkerOptions
    {
        /// <summary>
        /// A string specifying the type of worker to create. The value can be classic or module. If not specified, the default used is classic.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; }
        /// <summary>
        /// A string specifying the type of credentials to use for the worker. The value can be omit, same-origin, or include. If not specified, or if type is classic, the default used is same-origin (only include credentials for same-origin requests).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Credentials { get; set; }
        /// <summary>
        /// A string specifying an identifying name for the DedicatedWorkerGlobalScope representing the scope of the worker, which is mainly useful for debugging purposes.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }
    }
}
