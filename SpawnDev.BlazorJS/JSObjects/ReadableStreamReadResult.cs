using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents the result of a read operation on a ReadableStream.
    /// </summary>
    public class ReadableStreamReadResult : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public ReadableStreamReadResult(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// A boolean indicating whether the stream has been closed.
        /// </summary>
        public bool Done => JSRef!.Get<bool>("done");

        /// <summary>
        /// The value read from the stream.
        /// </summary>
        /// <remarks>
        /// For BYOB readers, this is typically the TypedArray view that was passed into the Read() method.
        /// </remarks>
        public JSObject? Value => JSRef!.Get<JSObject?>("value");
    }
}
