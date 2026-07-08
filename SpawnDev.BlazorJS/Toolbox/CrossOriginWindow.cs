using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Can be used to safely access a cross origin window without triggering an exception due to the the way Blazor WebAssembly handles IJSInProcessObjectReference.
    /// </summary>
    public class CrossOriginWindow : IDisposable
    {
        static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        JSObject _proxy;
        /// <summary>
        /// Creates a new instance of a 
        /// </summary>
        /// <param name="window"></param>
        public CrossOriginWindow(Window window)
        {
            _proxy = JS.New<JSObject>("Object");
            _proxy.JSRef!.Set("window", window);
        }
        /// <inheritdoc/>
        public void Dispose()
        {
            _proxy?.Dispose();
            _proxy = null!;
        }
        /// <summary>
        /// The Window.closed read-only property indicates whether the referenced window is closed or not.
        /// </summary>
        public bool Closed => _proxy.JSRef!.Get<bool>("window.closed");
        /// <summary>
        /// The Window interface's opener property returns a reference to the window that opened the window, either with open(), or by navigating a link with a target attribute.
        /// </summary>
        public Window? Opener => _proxy.JSRef!.Get<Window?>("window.opener");
        /// <summary>
        /// Returns the number of frames (either frame or iframe elements) in the window.
        /// </summary>
        public int Length => _proxy.JSRef!.Get<int>("window.length");
        /// <summary>
        /// The window.postMessage() method safely enables cross-origin communication between Window objects; e.g., between a page and a pop-up that it spawned, or between a page and an iframe embedded within it.
        /// </summary>
        /// <param name="message">Data to be dispatched to the other window. The data is serialized using the structured clone algorithm. This means you can pass a broad variety of data objects safely to the destination window without having to serialize them yourself.</param>
        /// <param name="targetOrigin">Specifies the origin the recipient window must have in order to receive the event. In order for the event to be dispatched, the origin must match exactly (including scheme, hostname, and port). If omitted, then defaults to the origin that is calling the method. This mechanism provides control over where messages are sent; for example, if postMessage() was used to transmit a password, it would be absolutely critical that this argument be a URI whose origin is the same as the intended receiver of the message containing the password, to prevent interception of the password by a malicious third party. * may also be provided, which means the message can be dispatched to a listener with any origin.</param>
        /// <param name="transfer">An optional array of transferable objects to transfer ownership of. The ownership of these objects is given to the destination side and they are no longer usable on the sending side. These transferable objects should be attached to the message; otherwise they would be moved but not actually accessible on the receiving end.</param>
        public void PostMessage(object message, string targetOrigin, object[] transfer) => _proxy.JSRef!.CallVoid("window.postMessage", message, targetOrigin, transfer);
        /// <summary>
        /// The window.postMessage() method safely enables cross-origin communication between Window objects; e.g., between a page and a pop-up that it spawned, or between a page and an iframe embedded within it.
        /// </summary>
        /// <param name="message">Data to be dispatched to the other window. The data is serialized using the structured clone algorithm. This means you can pass a broad variety of data objects safely to the destination window without having to serialize them yourself.</param>
        /// <param name="targetOrigin">Specifies the origin the recipient window must have in order to receive the event. In order for the event to be dispatched, the origin must match exactly (including scheme, hostname, and port). If omitted, then defaults to the origin that is calling the method. This mechanism provides control over where messages are sent; for example, if postMessage() was used to transmit a password, it would be absolutely critical that this argument be a URI whose origin is the same as the intended receiver of the message containing the password, to prevent interception of the password by a malicious third party. * may also be provided, which means the message can be dispatched to a listener with any origin.</param>
        public void PostMessage(object message, string targetOrigin) => _proxy.JSRef!.CallVoid("window.postMessage", message, targetOrigin);
        /// <summary>
        /// The window.postMessage() method safely enables cross-origin communication between Window objects; e.g., between a page and a pop-up that it spawned, or between a page and an iframe embedded within it.
        /// </summary>
        /// <param name="message">Data to be dispatched to the other window. The data is serialized using the structured clone algorithm. This means you can pass a broad variety of data objects safely to the destination window without having to serialize them yourself.</param>
        public void PostMessage(object message) => _proxy.JSRef!.CallVoid("window.postMessage", message);
        /// <summary>
        /// Closes the current window.
        /// </summary>
        public void Close() => _proxy.JSRef!.CallVoid("window.close");
        /// <summary>
        /// Makes a request to bring the window to the front. It may fail due to user settings and the window isn't guaranteed to be frontmost before this method returns.
        /// </summary>
        public void Focus() => _proxy.JSRef!.CallVoid("window.focus");
    }
}
