using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The TransformStream interface of the Streams API represents a concrete implementation of the pipe chain transform stream concept.<br/>
    /// TransformStream is a transferable object.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TransformStream
    /// </summary>
    [Transferable]
    public class TransformStream : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public TransformStream(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The readable end of a TransformStream.
        /// </summary>
        public ReadableStream Readable => JSRef!.Get<ReadableStream>("readable");
        /// <summary>
        /// The writable end of a TransformStream.
        /// </summary>
        public WritableStream Writable => JSRef!.Get<WritableStream>("writable");
    }
}
