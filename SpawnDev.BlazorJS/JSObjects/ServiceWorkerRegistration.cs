using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ServiceWorkerRegistration interface of the Service Worker API represents the service worker registration. You register a service worker to control one or more pages that share the same origin.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration
    /// </summary>
    public class ServiceWorkerRegistration : EventTarget
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ServiceWorkerRegistration(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
        #region Properties
        /// <summary>
        /// Returns a service worker whose state is activating or activated. This is initially set to null. An active worker will control a Client if the client's URL falls within the scope of the registration (the scope option set when ServiceWorkerContainer.register is first called.)
        /// </summary>
        public ServiceWorker? Active => JSRef!.Get<ServiceWorker?>("active");
        /// <summary>
        /// Returns a service worker whose state is installing. This is initially set to null.
        /// </summary>
        public ServiceWorker? Installing => JSRef!.Get<ServiceWorker?>("installing");
        /// <summary>
        /// Returns a service worker whose state is installed. This is initially set to null.
        /// </summary>
        public ServiceWorker? Waiting => JSRef!.Get<ServiceWorker?>("waiting");
        /// <summary>
        /// Returns a reference to the PushManager interface for managing push subscriptions including subscribing, getting an active subscription, and accessing push permission status.
        /// </summary>
        public PushManager? PushManager => JSRef!.Get<PushManager?>("pushManager");
        /// <summary>
        /// Returns a reference to the SyncManager interface, which manages background synchronization processes.
        /// </summary>
        public SyncManager? Sync => JSRef!.Get<SyncManager?>("sync");
        /// <summary>
        /// Returns a reference to the PeriodicSyncManager interface, which allows for registering of tasks to run at specific intervals.
        /// </summary>
        public PeriodicSyncManager? PeriodicSync => JSRef!.Get<PeriodicSyncManager?>("periodicSync");
        /// <summary>
        /// Returns a string indicating what is the cache strategy to use when updating the service worker scripts. It can be one of the following: imports, all, or none.
        /// </summary>
        public string UpdateViaCache => JSRef!.Get<string>("updateViaCache");
        #endregion
        #region Methods
        /// <summary>
        /// Returns a list of the notifications in the order that they were created from the current origin via the current service worker registration.
        /// </summary>
        /// <returns></returns>
        public Task<Array<Notification>> GetNotifications() => JSRef!.CallAsync<Array<Notification>>("getNotifications");
        /// <summary>
        /// Returns a list of the notifications in the order that they were created from the current origin via the current service worker registration.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Array<Notification>> GetNotifications(GetNotificationsOptions options) => JSRef!.CallAsync<Array<Notification>>("getNotifications", options);
        /// <summary>
        /// Displays the notification with the requested title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public Task ShowNotification(string title) => JSRef!.CallVoidAsync("showNotification", title);
        /// <summary>
        /// Displays the notification with the requested title.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task ShowNotification(string title, ShowNotificationsOptions options) => JSRef!.CallVoidAsync("showNotification", title, options);
        /// <summary>
        /// Unregisters the service worker registration and returns a Promise. The service worker will finish any ongoing operations before it is unregistered.
        /// </summary>
        /// <returns></returns>
        public Task<bool> Unregister() => JSRef!.CallAsync<bool>("unregister");
        /// <summary>
        /// Checks the server for an updated version of the service worker without consulting caches.
        /// </summary>
        /// <returns></returns>
        public Task<ServiceWorkerRegistration> Update() => JSRef!.CallAsync<ServiceWorkerRegistration>("update");
        #endregion
        #region Events
        /// <summary>
        /// The updatefound event of the ServiceWorkerRegistration interface is fired any time the ServiceWorkerRegistration.installing property acquires a new service worker.
        /// </summary>
        public JSEventCallback<Event> OnUpdateFound { get => new JSEventCallback<Event>("updatefound", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
