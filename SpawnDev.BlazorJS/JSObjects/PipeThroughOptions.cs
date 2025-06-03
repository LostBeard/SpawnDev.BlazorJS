using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for the pipeThrough method of the ReadableStream interface.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream/pipeThrough#options
    /// </summary>
    public class PipeThroughOptions
    {
        /// <summary>
        /// If this is set to true, closing the source ReadableStream will no longer cause the destination WritableStream to be closed.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PreventClose { get; set; }
        /// <summary>
        /// If this is set to true, errors in the source ReadableStream will no longer abort the destination WritableStream.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PreventAbort { get; set; }
        /// <summary>
        /// If this is set to true, errors in the destination WritableStream will no longer cancel the source ReadableStream.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PreventCancel { get; set; }
        /// <summary>
        /// If set to an AbortSignal object, ongoing pipe operations can then be aborted via the corresponding AbortController.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AbortSignal? Signal { get; set; }
    }
}
