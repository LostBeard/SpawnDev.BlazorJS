using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<ServiceWorkerContainer>))]
    public class ServiceWorkerContainer : EventTarget
    {
        public ServiceWorker Controller => _ref.Get<ServiceWorker>("controller");
        public ValueTask<ServiceWorkerRegistration> Ready => _ref.GetAsync<ServiceWorkerRegistration>("ready");
        public ServiceWorkerContainer(IJSInProcessObjectReference _ref) : base(_ref) { }

        public async Task<ServiceWorkerRegistration> Register(string scriptURL, RegisterOptions options = null)
        {
            if (options != null) return await _ref.CallAsync<ServiceWorkerRegistration>("register", scriptURL, options);
            return await _ref.CallAsync<ServiceWorkerRegistration>("register", scriptURL);
        }

        public class RegisterOptions
        {
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string Scope { get; set; }
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string Type { get; set; }
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string UpdateViaCache { get; set; }
        }
    }
}
