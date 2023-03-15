using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects {
    public class ServiceWorkerContainer : EventTarget {
        public ServiceWorker Controller => JSRef.Get<ServiceWorker>("controller");
        public Task<ServiceWorkerRegistration> Ready => JSRef.GetAsync<ServiceWorkerRegistration>("ready");
        public ServiceWorkerContainer(IJSInProcessObjectReference _ref) : base(_ref) { }

        public async Task<ServiceWorkerRegistration> Register(string scriptURL, RegisterOptions options = null) {
            if (options != null) return await JSRef.CallAsync<ServiceWorkerRegistration>("register", scriptURL, options);
            return await JSRef.CallAsync<ServiceWorkerRegistration>("register", scriptURL);
        }

        public class RegisterOptions {
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string Scope { get; set; }
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string Type { get; set; }
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string UpdateViaCache { get; set; }
        }
    }
}
