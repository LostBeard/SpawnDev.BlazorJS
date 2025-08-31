using Microsoft.JSInterop;
using SpawnDev.BlazorJS.Toolbox;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The TextDecoder interface represents a decoder for a specific text encoding, such as UTF-8, ISO-8859-2, KOI8-R, GBK, etc. A decoder takes a stream of bytes as input and emits a stream of code points.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TextDecoder
    /// </summary>
    public class TextDecoder : JSObject
    {
        /// <summary>
        /// Creates a new instance of TextDecoder
        /// </summary>
        public TextDecoder() : base(JS.New(nameof(TextDecoder))) { }
        /// <summary>
        /// A string, defaulting to "utf-8". This may be any valid label.
        /// </summary>
        /// <param name="label">A string identifying the character encoding that this decoder will use. This may be any valid label.<br/>
        /// Defaults to "utf-8".</param>
        /// <param name="options"></param>
        public TextDecoder(string label, TextDecoderOptions? options = null) : base(options == null ? JS.New(nameof(TextDecoder), label) : JS.New(nameof(TextDecoder), label, options)) { }
        ///<inheritdoc/>
        public TextDecoder(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a string containing the text decoded with the method of the specific TextDecoder object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Decode(ArrayBuffer data) => JSRef!.Call<string>("decode", data);
        /// <summary>
        /// Returns a string containing the text decoded with the method of the specific TextDecoder object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StringPrimitive DecodeToPrimitive(ArrayBuffer data) => JSRef!.Call<StringPrimitive>("decode", data);
        /// <summary>
        /// Returns a string containing the text decoded with the method of the specific TextDecoder object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Decode(DataView data) => JSRef!.Call<string>("decode", data);
        /// <summary>
        /// Returns a string containing the text decoded with the method of the specific TextDecoder object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StringPrimitive DecodeToPrimitive(DataView data) => JSRef!.Call<StringPrimitive>("decode", data);
        /// <summary>
        /// Returns a string containing the text decoded with the method of the specific TextDecoder object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Decode(TypedArray data) => JSRef!.Call<string>("decode", data);
        /// <summary>
        /// Returns a string containing the text decoded with the method of the specific TextDecoder object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StringPrimitive DecodeToPrimitive(TypedArray data) => JSRef!.Call<StringPrimitive>("decode", data);
        /// <summary>
        /// Returns a string containing the text decoded with the method of the specific TextDecoder object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Decode(byte[] data) => Decode((Uint8Array)(HeapView)data);
        /// <summary>
        /// Returns a string containing the text decoded with the method of the specific TextDecoder object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StringPrimitive DecodeToPrimitive(byte[] data) => DecodeToPrimitive((Uint8Array)(HeapView)data);
        /// <summary>
        /// A Boolean indicating whether the error mode is fatal.
        /// </summary>
        public bool FatalError => JSRef!.Get<bool>("fatal");
        /// <summary>
        /// A Boolean indicating whether the byte order mark is ignored.
        /// </summary>
        public bool IgnoreBOM => JSRef!.Get<bool>("ignoreBOM");
        /// <summary>
        /// A string containing the name of the decoder, which is a string describing the method the TextDecoder will use.
        /// </summary>
        public string Encoding => JSRef!.Get<string>("encoding");
    }
}
