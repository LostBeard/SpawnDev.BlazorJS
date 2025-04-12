﻿using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ServiceWorkerGlobalScope interface of the Service Worker API represents the global execution context of a service worker.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope
    /// </summary>
    public class ServiceWorkerGlobalScope : WorkerGlobalScope
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ServiceWorkerGlobalScope(IJSInProcessObjectReference _ref) : base(_ref) { }
        #region Properties
        /// <summary>
        /// Contains the ServiceWorkerRegistration object that represents the service worker's registration.
        /// </summary>
        public ServiceWorkerRegistration Registration => JSRef!.Get<ServiceWorkerRegistration>("registration");
        /// <summary>
        /// Contains the Clients object associated with the service worker.
        /// </summary>
        public Clients Clients => JSRef!.Get<Clients>("clients");
        /// <summary>
        /// Returns an object reference to the ServiceWorkerGlobalScope object itself
        /// </summary>
        public override ServiceWorkerGlobalScope Self => JSRef!.Get<ServiceWorkerGlobalScope>("self");
        #endregion
        #region Methods
        /// <summary>
        /// The ServiceWorkerGlobalScope.skipWaiting() method of the ServiceWorkerGlobalScope forces the waiting service worker to become the active service worker<br/>
        /// Use this method with Clients.claim() to ensure that updates to the underlying service worker take effect immediately for both the current client and all other active<br/>
        /// Usually called in the service worker 'install' event
        /// </summary>
        /// <returns></returns>
        public Task SkipWaiting() => JSRef!.CallVoidAsync("skipWaiting");
        #endregion
        #region Events
        /// <summary>
        /// Occurs when a ServiceWorkerRegistration acquires a new ServiceWorkerRegistration.active worker.
        /// </summary>
        public ActionEvent<ExtendableEvent> OnActivate { get => new ActionEvent<ExtendableEvent>("activate", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when a fetch() is called.
        /// </summary>
        public ActionEvent<FetchEvent> OnFetch { get => new ActionEvent<FetchEvent>("fetch", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when a ServiceWorkerRegistration acquires a new ServiceWorkerRegistration.installing worker.
        /// </summary>
        public ActionEvent<ExtendableEvent> OnInstall { get => new ActionEvent<ExtendableEvent>("install", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when incoming messages are received. Controlled pages can use the MessagePort.postMessage() method to send messages to service workers.
        /// </summary>
        public ActionEvent<ExtendableMessageEvent> OnMessage { get => new ActionEvent<ExtendableMessageEvent>("message", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when incoming messages can't be deserialized.
        /// </summary>
        public ActionEvent<ExtendableMessageEvent> OnMessageError { get => new ActionEvent<ExtendableMessageEvent>("messageerror", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when a server push notification is received.
        /// </summary>
        public ActionEvent<PushEvent> OnPush { get => new ActionEvent<PushEvent>("push", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when a push subscription has been invalidated, or is about to be invalidated (e.g. when a push service sets an expiration time).
        /// </summary>
        public ActionEvent<PushSubscriptionChangeEvent> OnPushSubscriptionChange { get => new ActionEvent<PushSubscriptionChangeEvent>("pushsubscriptionchange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Triggered when a call to SyncManager.register is made from a service worker client page. The attempt to sync is made either immediately if the network is available or as soon as the network becomes available.
        /// </summary>
        public ActionEvent<SyncEvent> OnSync { get => new ActionEvent<SyncEvent>("sync", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs at periodic intervals, which were specified when registering a PeriodicSyncManager.
        /// </summary>
        public ActionEvent<PeriodicSyncEvent> OnPeriodicSync { get => new ActionEvent<PeriodicSyncEvent>("periodicsync", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when a user closes a displayed notification.
        /// </summary>
        public ActionEvent<NotificationEvent> OnNotificationClose { get => new ActionEvent<NotificationEvent>("notificationclose", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when a user clicks on a displayed notification.
        /// </summary>
        public ActionEvent<NotificationEvent> OnNotificationClick { get => new ActionEvent<NotificationEvent>("notificationclick", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
