using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration
    public class ServiceWorkerRegistration : EventTarget
    {
        public ServiceWorkerRegistration(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ServiceWorker? Active => JSRef.Get<ServiceWorker?>("active");
        public ServiceWorker? Installing => JSRef.Get<ServiceWorker?>("installing");
        public ServiceWorker? Waiting => JSRef.Get<ServiceWorker?>("waiting");
        public PushManager? PushManager => JSRef.Get<PushManager?>("pushManager");
        public SyncManager? Sync => JSRef.Get<SyncManager?>("sync");
        public string UpdateViaCache => JSRef.Get<string>("updateViaCache");

        public Task<Array<Notification>> GetNotifications() => JSRef.CallAsync<Array<Notification>>("getNotifications");
        public Task<Array<Notification>> GetNotifications(GetNotificationsOptions options) => JSRef.CallAsync<Array<Notification>>("getNotifications", options);

        public Task ShowNotification(string title) => JSRef.CallVoidAsync("showNotification", title);
        public Task ShowNotification(string title, ShowNotificationsOptions options) => JSRef.CallVoidAsync("showNotification", title, options);

        public Task<bool> Unregister() => JSRef.CallAsync<bool>("unregister");
        public Task<ServiceWorkerRegistration> Update() => JSRef.CallAsync<ServiceWorkerRegistration>("update");
        /// <summary>
        /// The updatefound event of the ServiceWorkerRegistration interface is fired any time the ServiceWorkerRegistration.installing property acquires a new service worker.
        /// </summary>
        public JSEventCallback<Event> OnUpdateFound { get => new JSEventCallback<Event>(o => AddEventListener("updatefound", o), o => RemoveEventListener("updatefound", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
    }
}
