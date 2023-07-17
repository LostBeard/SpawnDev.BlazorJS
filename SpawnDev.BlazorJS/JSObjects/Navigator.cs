using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Navigator interface represents the state and the identity of the user agent. It allows scripts to query it and to register themselves to carry on some activities.
    /// </summary>
    public class Navigator : JSObject {
        public Navigator() : base(JS.Get<IJSInProcessObjectReference>("navigator")) { }
        public Navigator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public MediaDevices MediaDevices => JSRef.Get<MediaDevices>("mediaDevices");
        public LockManager Locks => JSRef.Get<LockManager>("locks");
        public StorageManager Storage => JSRef.Get<StorageManager>("storage");
        public ServiceWorkerContainer ServiceWorker => JSRef.Get<ServiceWorkerContainer>("serviceWorker");
        public WakeLock WakeLock => JSRef.Get<WakeLock>("wakeLock");
        public Clipboard Clipboard => JSRef.Get<Clipboard>("clipboard");
        public UserActivation UserActivation => JSRef.Get<UserActivation>("userActivation");
        public bool OnLine => JSRef.Get<bool>("onLine");
        public Gamepad[] GetGamepads() => JSRef.Call<Gamepad[]>("getGamepads");
    }
}
