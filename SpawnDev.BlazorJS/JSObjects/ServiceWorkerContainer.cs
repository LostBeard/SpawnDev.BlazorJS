using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ServiceWorkerContainer interface of the Service Worker API provides an object representing the service worker as an overall unit in the network ecosystem, including facilities to register, unregister and update service workers, and access the state of service workers and their registrations.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer
    /// </summary>
    public class ServiceWorkerContainer : EventTarget
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ServiceWorkerContainer(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
        #region Properties
        /// <summary>
        /// Returns a ServiceWorker object if its state is activating or activated (the same object returned by ServiceWorkerRegistration.active). This property returns null during a force-refresh request (Shift + refresh) or if there is no active worker.
        /// </summary>
        public ServiceWorker? Controller => JSRef!.Get<ServiceWorker?>("controller");
        /// <summary>
        /// Provides a way of delaying code execution until a service worker is active. It returns a Promise that will never reject, and which waits indefinitely until the ServiceWorkerRegistration associated with the current page has an ServiceWorkerRegistration.active worker. Once that condition is met, it resolves with the ServiceWorkerRegistration.
        /// </summary>
        public Task<ServiceWorkerRegistration> Ready => JSRef!.GetAsync<ServiceWorkerRegistration>("ready");
        #endregion
        #region Methods
        /// <summary>
        /// Returns all ServiceWorkerRegistration objects associated with a ServiceWorkerContainer in an array. The method returns a Promise that resolves to an array of ServiceWorkerRegistration.
        /// </summary>
        /// <returns></returns>
        public Task<ServiceWorkerRegistration> GetRegistration() => JSRef!.CallAsync<ServiceWorkerRegistration>("getRegistration");
        /// <summary>
        /// Creates or updates a ServiceWorkerRegistration for the given scriptURL.
        /// </summary>
        /// <param name="scriptURL"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<ServiceWorkerRegistration> Register(string scriptURL, ServiceWorkerRegistrationOptions? options = null) => options == null ? JSRef!.CallAsync<ServiceWorkerRegistration>("register", scriptURL) : JSRef!.CallAsync<ServiceWorkerRegistration>("register", scriptURL, options);
        #endregion
        #region Events
        /// <summary>
        /// Occurs when the document's associated ServiceWorkerRegistration acquires a new active worker.
        /// </summary>
        public ActionEvent<Event> OnControllerChange { get => new ActionEvent<Event>("controllerchange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when incoming messages are received by the ServiceWorkerContainer object (e.g. via a MessagePort.postMessage() call).
        /// </summary>
        public ActionEvent<MessageEvent> OnMessage { get => new ActionEvent<MessageEvent>("message", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
