using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ReadableStreamBYOBRequest interface of the Streams API represents a "pull request" for data from an underlying source that will made as a zero-copy transfer to a consumer (bypassing the stream's internal queues).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamBYOBRequest
    /// </summary>
    public class ReadableStreamBYOBRequest : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ReadableStreamBYOBRequest(IJSInProcessObjectReference _ref) : base(_ref) { }

        // TODO - finish
    }
}
