using Microsoft.JSInterop;
using System.Data.Common;
using System.Net.Security;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ServiceWorkerGlobalScope : WorkerGlobalScope
    {
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
        /// Returns the CacheStorage object associated with the current context. This object enables functionality such as storing assets for offline use, and generating custom responses to requests.
        /// </summary>
        public CacheStorage Caches => JSRef.Get<CacheStorage>("caches");
        /// <summary>
        /// Provides a mechanism for applications to asynchronously access capabilities of indexed databases; returns an IDBFactory object.
        /// </summary>
        public IDBFactory IndexedDB => JSRef.Get<IDBFactory>("indexedDB");
        /// <summary>
        /// Returns a boolean indicating whether the current context is secure (true) or not (false)
        /// </summary>
        public bool IsSecureContext => JSRef.Get<bool>("IsSecureContext");
        /// <summary>
        /// The Window.location read-only property returns a Location object with information about the current location of the document.
        /// </summary>
        public Location Location => JSRef.Get<Location>("location");
        /// <summary>
        /// The Window.navigator read-only property returns a reference to the Navigator object, which has methods and properties about the application running the script.
        /// </summary>
        public Navigator Navigator => JSRef.Get<Navigator>("navigator");
        /// <summary>
        /// Returns the global object's origin, serialized as a string.
        /// </summary>
        public string Origin => JSRef.Get<string>("origin");
        /// <summary>
        /// Returns an object reference to the ServiceWorkerGlobalScope object itself
        /// </summary>
        public ServiceWorkerGlobalScope Self => JSRef.Get<ServiceWorkerGlobalScope>("self");
        #endregion
        #region methods
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
        #endregion
    }
}
