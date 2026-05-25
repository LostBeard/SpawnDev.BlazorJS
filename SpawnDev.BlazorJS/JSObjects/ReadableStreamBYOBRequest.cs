using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ReadableStreamBYOBRequest interface of the Streams API represents a pull request in a ReadableByteStreamController, which can be used to read data into a provided buffer.
    /// https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamBYOBRequest
    /// </summary>
    public class ReadableStreamBYOBRequest : JSObject
    {
        /// <inheritdoc/>
        public ReadableStreamBYOBRequest(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// The view that the underlying source should write to.
        /// </summary>
        public ArrayBufferView View => JSRef!.Get<ArrayBufferView>("view");

        /// <summary>
        /// Signals that the underlying source has finished writing data to the view.
        /// </summary>
        /// <param name="bytesWritten">The number of bytes written to the view.</param>
        public void Respond(double bytesWritten) => JSRef!.CallVoid("respond", bytesWritten);

        /// <summary>
        /// Signals that the underlying source has finished writing data to the view, 
        /// and provides a new view to be used for the next read operation.
        /// </summary>
        /// <param name="view">The new view.</param>
        public void RespondWithNewView(ArrayBufferView view) => JSRef!.CallVoid("respondWithNewView", view);
    }
}
