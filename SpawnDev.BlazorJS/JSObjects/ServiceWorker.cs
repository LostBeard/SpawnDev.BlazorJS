using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ServiceWorker interface of the Service Worker API provides a reference to a service worker. Multiple browsing contexts (e.g. pages, workers, etc.) can be associated with the same service worker, each through a unique ServiceWorker object.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorker
    /// </summary>
    public class ServiceWorker : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ServiceWorker(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the state of the service worker. It returns one of the following values: parsed, installing, installed, activating, activated, or redundant.
        /// </summary>
        public string State => JSRef.Get<string>("state");
        /// <summary>
        /// Returns the ServiceWorker serialized script URL defined as part of ServiceWorkerRegistration. The URL must be on the same origin as the document that registers the ServiceWorker.
        /// </summary>
        public string ScriptURL => JSRef.Get<string>("scriptURL");
        /// <summary>
        /// Returns true if navigator.serviceWorker is defined
        /// </summary>
        public static bool IsSupported => !JS.IsUndefined("navigator.serviceWorker");
        /// <summary>
        /// Sends a message — consisting of any structured-cloneable JavaScript object — to the service worker. The message is transmitted to the service worker using a message event on its global scope.
        /// </summary>
        /// <param name="message"></param>
        public void PostMessage(object message) => JSRef.CallVoid("postMessage", message);
        /// <summary>
        /// Sends a message — consisting of any structured-cloneable JavaScript object — to the service worker. The message is transmitted to the service worker using a message event on its global scope.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="transfer"></param>
        public void PostMessage(object message, object[] transfer) => JSRef.CallVoid("postMessage", message, transfer);
        /// <summary>
        /// Fired when ServiceWorker.state changes.
        /// </summary>
        public JSEventCallback<Event> OnStateChange { get => new JSEventCallback<Event>("statechange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when an error happens inside the ServiceWorker object.
        /// </summary>
        public JSEventCallback<Event> OnError { get => new JSEventCallback<Event>("error", AddEventListener, RemoveEventListener); set { } }
    }
}
