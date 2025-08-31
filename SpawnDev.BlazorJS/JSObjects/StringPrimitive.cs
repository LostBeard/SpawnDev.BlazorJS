using Microsoft.JSInterop;
using SpawnDev.BlazorJS.Toolbox;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Glossary/Primitive
    /// </summary>
    public class StringPrimitive : JSObject
    {
        /// <summary>
        /// Explicit cast from StringPrimitive to .Net string
        /// </summary>
        /// <param name="stringPrimitive">StringPrimitive</param>
        public static explicit operator string(StringPrimitive stringPrimitive) => stringPrimitive.ToString();
        /// <summary>
        /// Explicit cast from .Net string to StringPrimitive
        /// </summary>
        /// <param name="source">.Net string</param>
        public static explicit operator StringPrimitive(string source) => Create(source);
        /// <summary>
        /// The StringPrimitive() constructor calls the String function to create a new string primitive.
        /// </summary>
        /// <param name="thing">Anything to be converted to a string.</param>
        public StringPrimitive(object thing) : base(JS.Call<IJSInProcessObjectReference>(nameof(String), thing is string thingStr ? (StringPrimitive)thingStr : thing)) { }
        /// <inheritdoc/>
        public StringPrimitive(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the string's length
        /// </summary>
        public long Length => JSRef!.Get<long>("length");
        /// <summary>
        /// Create a new from a Uint8Array
        /// </summary>
        /// <param name="stringBytes"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public static StringPrimitive Create(Uint8Array stringBytes, string label)
        {
            using var textDecoder = new TextDecoder(label);
            return textDecoder.DecodeToPrimitive(stringBytes);
        }
        /// <summary>
        /// Create a new from a byte[]
        /// </summary>
        /// <param name="stringBytes"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public static StringPrimitive Create(byte[] stringBytes, string label)
        {
            using var textDecoder = new TextDecoder(label);
            return textDecoder.DecodeToPrimitive(stringBytes);
        }
        /// <summary>
        /// Create a new from a string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static StringPrimitive Create(string source)
        {
            using var textDecoder = new TextDecoder("utf-16");
            using var heapView = HeapView.Create(source);
            return textDecoder.DecodeToPrimitive((Uint8Array)heapView);
        }
        /// <summary>
        /// Returns the primitive string as a .Net string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JSRef!.As<string>();
    }
}
