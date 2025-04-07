using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The TextDecoderStream interface of the Encoding API converts a stream of text in a binary encoding, such as UTF-8 etc., to a stream of strings. It is the streaming equivalent of TextDecoder.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TextDecoderStream
    /// </summary>
    public class TextDecoderStream : JSObject
    {
        /// <summary>
        /// The TextDecoderStream() constructor creates a new TextDecoderStream object.
        /// </summary>
        public TextDecoderStream() : base(JS.New(nameof(TextDecoderStream))) { }
        /// <summary>
        /// The TextDecoderStream() constructor creates a new TextDecoderStream object.
        /// </summary>
        /// <param name="label">A string defaulting to utf-8. This may be any valid label.</param>
        public TextDecoderStream(string label) : base(JS.New(nameof(TextDecoderStream), label)) { }
        /// <summary>
        /// The TextDecoderStream() constructor creates a new TextDecoderStream object.
        /// </summary>
        /// <param name="label">A string defaulting to utf-8. This may be any valid label.</param>
        /// <param name="options">Options</param>
        public TextDecoderStream(string label, TextDecoderStreamOptions options) : base(JS.New(nameof(TextDecoderStream), label, options)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public TextDecoderStream(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An encoding.
        /// </summary>
        public string Encoding => JSRef!.Get<string>("encoding");
        /// <summary>
        /// A boolean indicating if the error mode is fatal.
        /// </summary>
        public bool Fatal => JSRef!.Get<bool>("fatal");
        /// <summary>
        /// A boolean indicating whether the byte order mark is ignored.
        /// </summary>
        public bool IgnoreBOM => JSRef!.Get<bool>("ignoreBOM");
        /// <summary>
        /// Returns the ReadableStream instance controlled by this object.
        /// </summary>
        public ReadableStream Readable => JSRef!.Get<ReadableStream>("readable");
        /// <summary>
        /// Returns the WritableStream instance controlled by this object.
        /// </summary>
        public WritableStream Writable => JSRef!.Get<WritableStream>("writable");
    }
}
