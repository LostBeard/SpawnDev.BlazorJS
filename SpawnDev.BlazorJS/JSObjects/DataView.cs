using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DataView view provides a low-level interface for reading and writing multiple number types in a binary ArrayBuffer, without having to care about the platform's endianness.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/DataView
    /// </summary>
    public class DataView : JSObject
    {
        /// <summary>
        /// Creates a new DataView object.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public DataView(ArrayBuffer arrayBuffer) : base(JS.New(nameof(DataView), arrayBuffer)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DataView(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The ArrayBuffer referenced by this view. Fixed at construction time and thus read only.
        /// </summary>
        public ArrayBuffer Buffer => JSRef.Get<ArrayBuffer>("buffer");
        /// <summary>
        /// The length (in bytes) of this view. Fixed at construction time and thus read only.
        /// </summary>
        public long ByteLength => JSRef.Get<long>("byteLength");
        /// <summary>
        /// The offset (in bytes) of this view from the start of its ArrayBuffer. Fixed at construction time and thus read only.
        /// </summary>
        public long ByteOffset => JSRef.Get<long>("byteOffset");
        
        // TODO finish methods
    }
}
