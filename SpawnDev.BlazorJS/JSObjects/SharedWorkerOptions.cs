using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object containing option properties that can set when creating the SharedWorker instance.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/SharedWorker/SharedWorker#options
    /// </summary>
    public class SharedWorkerOptions
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
        /// A string specifying an identifying name for the SharedWorkerGlobalScope representing the scope of the worker, which is useful for creating new instances of the same SharedWorker and debugging.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }
        /// <summary>
        /// A string indicating which SameSite cookies should be available to the worker. Can have one of the following two values:<br/>
        /// "all" - SameSite=Strict, SameSite=Lax, and SameSite=None cookies will all be available to the worker. This option is only supported in first-party contexts, and is the default in first-party contexts.<br/>
        /// "none" - Only SameSite=None cookies will be available to the worker. This option is supported in first-party and third-party contexts, and is the default in third-party contexts.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SameSiteCookies { get; set; }
    }
}
