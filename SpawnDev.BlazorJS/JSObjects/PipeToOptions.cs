using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// ReadableStream pipTo options<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream/pipeTo#options
    /// </summary>
    public class PipeToOptions
    {
        /// <summary>
        /// If this is set to true, the source ReadableStream closing will no longer cause the destination WritableStream to be closed. The method will return a fulfilled promise once this process completes, unless an error is encountered while closing the destination in which case it will be rejected with that error.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PreventClose { get; set; }
        /// <summary>
        /// If this is set to true, errors in the source ReadableStream will no longer abort the destination WritableStream. The method will return a promise rejected with the source's error, or with any error that occurs during aborting the destination.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PreventAbort { get; set; }
        /// <summary>
        /// If this is set to true, errors in the destination WritableStream will no longer cancel the source ReadableStream. In this case the method will return a promise rejected with the source's error, or with any error that occurs during canceling the source. In addition, if the destination writable stream starts out closed or closing, the source readable stream will no longer be canceled. In this case the method will return a promise rejected with an error indicating piping to a closed stream failed, or with any error that occurs during canceling the source.
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
