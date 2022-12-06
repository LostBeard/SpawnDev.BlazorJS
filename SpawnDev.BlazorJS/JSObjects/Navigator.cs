using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Navigator>))]
    public class Navigator : JSObject
    {
        public Navigator() : base(JS.Get<IJSInProcessObjectReference>("navigator")) { }
        public Navigator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public MediaDevices MediaDevices => _ref.Get<MediaDevices>("mediaDevices");
        public ServiceWorkerContainer ServiceWorker => _ref.Get<ServiceWorkerContainer>("serviceWorker");
    }
}
