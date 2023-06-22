using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ReadableStreamDefaultController : JSObject
    {
        public ReadableStreamDefaultController(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Closes the associated stream.
        /// </summary>
        public void Close() => JSRef.CallVoid("close");
        /// <summary>
        /// Enqueues a given chunk in the associated stream.
        /// </summary>
        public void Enqueue(object data) => JSRef.CallVoid("enqueue", data);
        /// <summary>
        /// Causes any future interactions with the associated stream to error.
        /// </summary>
        public void Error() => JSRef.CallVoid("error");
        /// <summary>
        /// Causes any future interactions with the associated stream to error.
        /// </summary>
        public void Error(object error) => JSRef.CallVoid("error", error);
    }
}
