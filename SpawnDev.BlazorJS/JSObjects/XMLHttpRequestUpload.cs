using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XMLHttpRequestUpload interface represents the upload process for a specific XMLHttpRequest. It is an opaque object that represents the underlying, browser-dependent, upload process. It is an XMLHttpRequestEventTarget and can be obtained by calling XMLHttpRequest.upload.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequestUpload
    /// </summary>
    public class XMLHttpRequestUpload : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public XMLHttpRequestUpload(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Fired when a request has been aborted, for example because the program called XMLHttpRequest.abort(). Also available via the onabort event handler property.
        /// </summary>
        public JSEventCallback<ProgressEvent> OnAbort { get => new JSEventCallback<ProgressEvent>("abort", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the request encountered an error. Also available via the onerror event handler property.
        /// </summary>
        public JSEventCallback<ProgressEvent> OnError { get => new JSEventCallback<ProgressEvent>("error", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a request transaction completes successfully. Also available via the onload event handler property.
        /// </summary>
        public JSEventCallback<ProgressEvent> OnLoad { get => new JSEventCallback<ProgressEvent>("load", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a request has completed, whether successfully (after load) or unsuccessfully (after abort or error). Also available via the onloadend event handler property.
        /// </summary>
        public JSEventCallback<ProgressEvent> OnLoadEnd { get => new JSEventCallback<ProgressEvent>("loadend", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a request has started to load data. Also available via the onloadstart event handler property.
        /// </summary>
        public JSEventCallback<ProgressEvent> OnLoadStart { get => new JSEventCallback<ProgressEvent>("loadstart", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired periodically when a request receives more data. Also available via the onprogress event handler property.
        /// </summary>
        public JSEventCallback<ProgressEvent> OnProgress { get => new JSEventCallback<ProgressEvent>("progress", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when progress is terminated due to preset time expiring. Also available via the ontimeout event handler property.
        /// </summary>
        public JSEventCallback<ProgressEvent> OnTimeout { get => new JSEventCallback<ProgressEvent>("timeout", AddEventListener, RemoveEventListener); set { } }

    }
}
