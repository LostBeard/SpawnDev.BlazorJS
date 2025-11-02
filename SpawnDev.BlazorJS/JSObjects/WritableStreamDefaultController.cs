using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WritableStreamDefaultController interface of the Streams API represents a controller allowing control of a WritableStream's state. When constructing a WritableStream, the underlying sink is given a corresponding WritableStreamDefaultController instance to manipulate.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WritableStreamDefaultController
    /// https://streams.spec.whatwg.org/#writablestreamdefaultcontroller
    /// </summary>
    public class WritableStreamDefaultController : JSObject
    {
        /// <inheritdoc/>
        public WritableStreamDefaultController(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the AbortSignal associated with the controller.
        /// </summary>
        public AbortSignal Signal => JSRef!.Get<AbortSignal>("signal");
        /// <summary>
        /// The error() method of the WritableStreamDefaultController interface causes any future interactions with the associated stream to error.<br/>
        /// This method is rarely used, since usually it suffices to return a rejected promise from one of the underlying sink's methods. However, it can be useful for suddenly shutting down a stream in response to an event outside the normal lifecycle of interactions with the underlying sink.
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message) => JSRef!.CallVoid("error", message);
    }
}
