using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // Inconsistent implementation between Chrome and Firefox
    public class ClipboardItem : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ClipboardItem(IJSInProcessObjectReference _ref) : base(_ref) { }

    }
    /// <summary>
    /// The Clipboard API provides the ability to respond to clipboard commands (cut, copy, and paste) as well as to asynchronously read from and write to the system clipboard.
    /// </summary>
    public class Clipboard : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Clipboard(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Requests arbitrary data (such as images) from the clipboard, returning a Promise that resolves with an array of ClipboardItem objects containing the clipboard's contents.
        /// </summary>
        /// <returns></returns>
        public Task<ClipboardItem[]> Read() => JSRef.CallAsync<ClipboardItem[]>("read");
        /// <summary>
        /// Requests text from the system clipboard; returns a Promise which is resolved with a string containing the clipboard's text once it's available.
        /// </summary>
        /// <returns></returns>
        public Task<string> ReadText() => JSRef.CallAsync<string>("readText");
        /// <summary>
        /// Writes arbitrary data to the system clipboard. This asynchronous operation signals that it's finished by resolving the returned Promise
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task Write(object data) => JSRef.CallAsync<string>("write", data);
        /// <summary>
        /// Writes text to the system clipboard, returning a Promise which is resolved once the text is fully copied into the clipboard.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task WriteText(string data) => JSRef.CallAsync<string>("writeText", data);
    }
}
