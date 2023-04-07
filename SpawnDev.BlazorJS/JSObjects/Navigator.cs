using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Navigator : JSObject {
        public Navigator() : base(JS.Get<IJSInProcessObjectReference>("navigator")) { }
        public Navigator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public MediaDevices MediaDevices => JSRef.Get<MediaDevices>("mediaDevices");
        public LockManager Locks => JSRef.Get<LockManager>("locks");
        public StorageManager Storage => JSRef.Get<StorageManager>("storage");
        public ServiceWorkerContainer ServiceWorker => JSRef.Get<ServiceWorkerContainer>("serviceWorker");
    }
}
