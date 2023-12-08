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
        public JSEventCallback<ExtendableEvent> OnActivate { get => new JSEventCallback<ExtendableEvent>(o => AddEventListener("activate", o), o => RemoveEventListener("activate", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<FetchEvent> OnFetch { get => new JSEventCallback<FetchEvent>(o => AddEventListener("fetch", o), o => RemoveEventListener("fetch", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<ExtendableEvent> OnInstall { get => new JSEventCallback<ExtendableEvent>(o => AddEventListener("install", o), o => RemoveEventListener("install", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        public JSEventCallback<ExtendableMessageEvent> OnMessage { get => new JSEventCallback<ExtendableMessageEvent>(o => AddEventListener("message", o), o => RemoveEventListener("message", o)); set { } }
        public JSEventCallback<PushEvent> OnPush { get => new JSEventCallback<PushEvent>(o => AddEventListener("push", o), o => RemoveEventListener("push", o)); set { } }
        public JSEventCallback<Event> OnPushSubscriptionChange { get => new JSEventCallback<Event>(o => AddEventListener("pushsubscriptionchange", o), o => RemoveEventListener("pushsubscriptionchange", o)); set { } }
        public JSEventCallback<SyncEvent> OnSync { get => new JSEventCallback<SyncEvent>(o => AddEventListener("sync", o), o => RemoveEventListener("sync", o)); set { } }
        public JSEventCallback<NotificationEvent> OnNotificationClose { get => new JSEventCallback<NotificationEvent>(o => AddEventListener("notificationclose", o), o => RemoveEventListener("notificationclose", o)); set { } }
        public JSEventCallback<NotificationEvent> OnNotificationClick { get => new JSEventCallback<NotificationEvent>(o => AddEventListener("notificationclick", o), o => RemoveEventListener("notificationclick", o)); set { } }
        #endregion
    }
}
