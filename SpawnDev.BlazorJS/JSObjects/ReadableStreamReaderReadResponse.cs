using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Returned by ReadableStreamDefaultReader.Read
    /// </summary>
    public class ReadableStreamReaderReadResponse : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ReadableStreamReaderReadResponse(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// True if there is no more data to read
        /// </summary>
        public bool Done => JSRef.Get<bool>("done");
        /// <summary>
        /// The current chunk if not done
        /// </summary>
        public Uint8Array? Value => JSRef.Get<Uint8Array?>("value");
    }
}
