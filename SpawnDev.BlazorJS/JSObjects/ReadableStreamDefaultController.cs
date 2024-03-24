using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ReadableStreamDefaultController interface of the Streams API represents a controller allowing control of a ReadableStream's state and internal queue. Default controllers are for streams that are not byte streams.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamDefaultController
    /// </summary>
    public class ReadableStreamDefaultController : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
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
