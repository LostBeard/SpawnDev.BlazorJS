using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ServiceWorkerContainer : EventTarget
    {
        public JSEventCallback<Event> OnControllerChange { get => new JSEventCallback<Event>(o => AddEventListener("controllerchange", o), o => RemoveEventListener("controllerchange", o)); set { } }
        public JSEventCallback<MessageEvent> OnMessage { get => new JSEventCallback<MessageEvent>(o => AddEventListener("message", o), o => RemoveEventListener("message", o)); set { } }
        public ServiceWorker Controller => JSRef.Get<ServiceWorker>("controller");
        public Task<ServiceWorkerRegistration> Ready => JSRef.GetAsync<ServiceWorkerRegistration>("ready");
        public ServiceWorkerContainer(IJSInProcessObjectReference _ref) : base(_ref) { }

        public Task<ServiceWorkerRegistration> GetRegistration() => JSRef.CallAsync<ServiceWorkerRegistration>("getRegistration");
        public async Task<ServiceWorkerRegistration> Register(string scriptURL, ServiceWorkerRegistrationOptions? options = null)
        {
            if (options != null) return await JSRef.CallAsync<ServiceWorkerRegistration>("register", scriptURL, options);
            return await JSRef.CallAsync<ServiceWorkerRegistration>("register", scriptURL);
        }
    }
}
