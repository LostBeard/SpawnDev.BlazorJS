using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The TransformStream interface of the Streams API represents a concrete implementation of the pipe chain transform stream concept.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/TransformStream
    /// </summary>
    public class TransformStream : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public TransformStream(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
