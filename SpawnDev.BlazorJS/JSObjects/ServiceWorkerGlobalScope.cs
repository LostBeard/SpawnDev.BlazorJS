using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ServiceWorkerGlobalScope interface of the Service Worker API represents the global execution context of a service worker.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope
    /// </summary>
    public class ServiceWorkerGlobalScope : WorkerGlobalScope
    {
        /// <inheritdoc/>
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
        /// <summary>
        /// Returns a reference to the CookieStore object, or null if not supported.
        /// </summary>
        public CookieStore? CookieStore => JSRef!.Get<CookieStore?>("cookieStore");
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
        /// Fired when a background fetch operation has been canceled by the user or the app.
        /// </summary>
        public ActionEvent<BackgroundFetchEvent> OnBackgroundFetchAbort { get => new ActionEvent<BackgroundFetchEvent>("backgroundfetchabort", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the user has clicked on the UI for a background fetch operation.
        /// </summary>
        public ActionEvent<BackgroundFetchEvent> OnBackgroundFetchClick { get => new ActionEvent<BackgroundFetchEvent>("backgroundfetchclick", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when at least one of the requests in a background fetch operation has failed.
        /// </summary>
        public ActionEvent<BackgroundFetchUpdateUIEvent> OnBackgroundFetchFail { get => new ActionEvent<BackgroundFetchUpdateUIEvent>("backgroundfetchfail", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when all of the requests in a background fetch operation have succeeded.
        /// </summary>
        public ActionEvent<BackgroundFetchUpdateUIEvent> OnBackgroundFetchSuccess { get => new ActionEvent<BackgroundFetchUpdateUIEvent>("backgroundfetchsuccess", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired on a payment app's service worker to check whether it is ready to handle a payment. Specifically, it is fired when the merchant website calls the PaymentRequest() constructor.
        /// </summary>
        public ActionEvent<CanMakePaymentEvent> OnCanMakePayment { get => new ActionEvent<CanMakePaymentEvent>("canmakepayment", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when an item is removed from the ContentIndex.
        /// </summary>
        public ActionEvent<ContentIndexEvent> OnContentDelete { get => new ActionEvent<ContentIndexEvent>("contentdelete", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a cookie change has occurred that matches the service worker's cookie change subscription list.
        /// </summary>
        public ActionEvent<ExtendableCookieChangeEvent> OnCookieChange { get => new ActionEvent<ExtendableCookieChangeEvent>("cookiechange", AddEventListener, RemoveEventListener); set { } }
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
        /// Occurs when a user clicks on a displayed notification.
        /// </summary>
        public ActionEvent<NotificationEvent> OnNotificationClick { get => new ActionEvent<NotificationEvent>("notificationclick", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs when a user closes a displayed notification.
        /// </summary>
        public ActionEvent<NotificationEvent> OnNotificationClose { get => new ActionEvent<NotificationEvent>("notificationclose", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired on a payment app when a payment flow has been initiated on the merchant website via the PaymentRequest.show() method.
        /// </summary>
        public ActionEvent<PaymentRequestEvent> OnPaymentRequest { get => new ActionEvent<PaymentRequestEvent>("paymentrequest", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Occurs at periodic intervals, which were specified when registering a PeriodicSyncManager.
        /// </summary>
        public ActionEvent<PeriodicSyncEvent> OnPeriodicSync { get => new ActionEvent<PeriodicSyncEvent>("periodicsync", AddEventListener, RemoveEventListener); set { } }
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
        #endregion
    }
}
