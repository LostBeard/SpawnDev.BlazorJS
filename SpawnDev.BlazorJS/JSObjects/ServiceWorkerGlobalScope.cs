using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ServiceWorkerGlobalScope interface of the Service Worker API represents the global execution context of a service worker.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope
    /// </summary>
    public class ServiceWorkerGlobalScope : WorkerGlobalScope
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ServiceWorkerGlobalScope(IJSInProcessObjectReference _ref) : base(_ref) { }
        #region properties
        /// <summary>
        /// Contains the ServiceWorkerRegistration object that represents the service worker's registration.
        /// </summary>
        public ServiceWorkerRegistration Registration => JSRef.Get<ServiceWorkerRegistration>("registration");
        /// <summary>
        /// Contains the Clients object associated with the service worker.
        /// </summary>
        public Clients Clients => JSRef.Get<Clients>("clients");
        /// <summary>
        /// Returns an object reference to the ServiceWorkerGlobalScope object itself
        /// </summary>
        public override ServiceWorkerGlobalScope Self => JSRef.Get<ServiceWorkerGlobalScope>("self");
        #endregion
        #region methods
        /// <summary>
        /// The ServiceWorkerGlobalScope.skipWaiting() method of the ServiceWorkerGlobalScope forces the waiting service worker to become the active service worker<br />
        /// Use this method with Clients.claim() to ensure that updates to the underlying service worker take effect immediately for both the current client and all other active
        /// </summary>
        /// <returns></returns>
        public Task SkipWaiting() => JSRef.CallVoidAsync("skipWaiting");
        #endregion
        #region events
        /// <summary>
        /// Occurs when a ServiceWorkerRegistration acquires a new ServiceWorkerRegistration.active worker.
        /// </summary>
        public JSEventCallback<ExtendableEvent> OnActivate { get => new JSEventCallback<ExtendableEvent>("activate", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when a fetch() is called.
        /// </summary>
        public JSEventCallback<FetchEvent> OnFetch { get => new JSEventCallback<FetchEvent>("fetch", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when a ServiceWorkerRegistration acquires a new ServiceWorkerRegistration.installing worker.
        /// </summary>
        public JSEventCallback<ExtendableEvent> OnInstall { get => new JSEventCallback<ExtendableEvent>("install", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when incoming messages are received. Controlled pages can use the MessagePort.postMessage() method to send messages to service workers.
        /// </summary>
        public JSEventCallback<ExtendableMessageEvent> OnMessage { get => new JSEventCallback<ExtendableMessageEvent>("message", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when incoming messages can't be deserialized.
        /// </summary>
        public JSEventCallback<ExtendableMessageEvent> OnMessageError { get => new JSEventCallback<ExtendableMessageEvent>("messageerror", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when a server push notification is received.
        /// </summary>
        public JSEventCallback<PushEvent> OnPush { get => new JSEventCallback<PushEvent>("push", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when a push subscription has been invalidated, or is about to be invalidated (e.g. when a push service sets an expiration time).
        /// </summary>
        public JSEventCallback<Event> OnPushSubscriptionChange { get => new JSEventCallback<Event>("pushsubscriptionchange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Triggered when a call to SyncManager.register is made from a service worker client page. The attempt to sync is made either immediately if the network is available or as soon as the network becomes available.
        /// </summary>
        public JSEventCallback<SyncEvent> OnSync { get => new JSEventCallback<SyncEvent>("sync", AddEventListener, RemoveEventListener); set { } }

        public JSEventCallback<PeriodicSyncEvent> OnPeriodicSync { get => new JSEventCallback<PeriodicSyncEvent>("periodicsync", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when a user closes a displayed notification.
        /// </summary>
        public JSEventCallback<NotificationEvent> OnNotificationClose { get => new JSEventCallback<NotificationEvent>("notificationclose", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when a user clicks on a displayed notification.
        /// </summary>
        public JSEventCallback<NotificationEvent> OnNotificationClick { get => new JSEventCallback<NotificationEvent>("notificationclick", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
