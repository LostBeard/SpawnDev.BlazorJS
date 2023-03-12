using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Navigator>))]
    public class Navigator : JSObject
    {
        public Navigator() : base(JS.Get<IJSInProcessObjectReference>("navigator")) { }
        public Navigator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public MediaDevices MediaDevices => JSRef.Get<MediaDevices>("mediaDevices");
        public LockManager Locks => JSRef.Get<LockManager>("locks");
        public ServiceWorkerContainer ServiceWorker => JSRef.Get<ServiceWorkerContainer>("serviceWorker");

    }
}
