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
        public ActionEvent<ProgressEvent> OnAbort { get => new ActionEvent<ProgressEvent>("abort", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the request encountered an error. Also available via the onerror event handler property.
        /// </summary>
        public ActionEvent<ProgressEvent> OnError { get => new ActionEvent<ProgressEvent>("error", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a request transaction completes successfully. Also available via the onload event handler property.
        /// </summary>
        public ActionEvent<ProgressEvent> OnLoad { get => new ActionEvent<ProgressEvent>("load", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a request has completed, whether successfully (after load) or unsuccessfully (after abort or error). Also available via the onloadend event handler property.
        /// </summary>
        public ActionEvent<ProgressEvent> OnLoadEnd { get => new ActionEvent<ProgressEvent>("loadend", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a request has started to load data. Also available via the onloadstart event handler property.
        /// </summary>
        public ActionEvent<ProgressEvent> OnLoadStart { get => new ActionEvent<ProgressEvent>("loadstart", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired periodically when a request receives more data. Also available via the onprogress event handler property.
        /// </summary>
        public ActionEvent<ProgressEvent> OnProgress { get => new ActionEvent<ProgressEvent>("progress", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when progress is terminated due to preset time expiring. Also available via the ontimeout event handler property.
        /// </summary>
        public ActionEvent<ProgressEvent> OnTimeout { get => new ActionEvent<ProgressEvent>("timeout", AddEventListener, RemoveEventListener); set { } }

    }
}
