using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The TextEncoder interface takes a stream of code points as input and emits a stream of UTF-8 bytes.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TextEncoder
    /// </summary>
    public class TextEncoder : JSObject
    {
        /// <summary>
        /// Creates a new instance of TextEncoder
        /// </summary>
        /// <param name="_ref"></param>
        public TextEncoder() : base(JS.New(nameof(TextEncoder))) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public TextEncoder(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Takes a string as input, and returns a Uint8Array containing UTF-8 encoded text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Uint8Array Encode(string text) => JSRef!.Call<Uint8Array>("encode", text);
        /// <summary>
        /// Takes a string to encode and a destination Uint8Array to put resulting UTF-8 encoded text into, and returns an object indicating the progress of the encoding. This is potentially more performant than the older encode() method.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public EncodeIntoProgress EncodeInto(string text, Uint8Array dest) => JSRef!.Call<EncodeIntoProgress>("encodeInto", text, dest);
    }
}
