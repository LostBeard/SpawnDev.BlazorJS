using Microsoft.JSInterop;
using System.Text.Json.Serialization;

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
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TextDecoder/TextDecoder#options
    /// </summary>
    public class TextDecoderOptions
    {
        /// <summary>
        /// A boolean value indicating whether the byte order mark will be included in the output or skipped over. It defaults to false, which means that the byte order mark will be skipped over when decoding and will not be included in the decoded text.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IgnoreBOM{ get; set; }
        /// <summary>
        /// A boolean value indicating if the TextDecoder.decode() method must throw a TypeError when decoding invalid data. It defaults to false, which means that the decoder will substitute malformed data with a replacement character.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Fatal { get; set; }
    }
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
        /// <param name="label"></param>
        /// <param name="options"></param>
        public TextDecoder(string label) : base(JS.New(nameof(TextDecoder), label)) { }
        /// <summary>
        /// A string, defaulting to "utf-8". This may be any valid label.
        /// </summary>
        /// <param name="label"></param>
        public TextDecoder(string label, TextDecoderOptions options) : base(JS.New(nameof(TextDecoder), label, options)) { }
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
        public string Decode(byte[] data) => JSRef!.Call<string>("decode", (ArrayBuffer)data);
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
