using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WorkerNavigator interface represents a subset of the Navigator interface allowed to be accessed from a Worker<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/WorkerNavigator
    /// </summary>
    public class WorkerNavigator : JSObject
    {
        public WorkerNavigator() : base(JS.Get<IJSInProcessObjectReference>("navigator")) { }
        public WorkerNavigator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int HardwareConcurrency => JSRef.Get<int>("hardwareConcurrency");
        public string? Language => JSRef.Get<string?>("language");
        public string[]? Languages => JSRef.Get<string[]?>("languages");
        public LockManager Locks => JSRef.Get<LockManager>("locks");
        //public MediaCapabilities=> JSRef.Get<MediaCapabilities>("mediaCapabilities");
        public bool OnLine => JSRef.Get<bool>("onLine");
        public Permissions Permissions => JSRef.Get<Permissions>("permissions");
        //public Serial Serial => JSRef.Get<Serial>("serial");
        public StorageManager Storage => JSRef.Get<StorageManager>("storage");
        public string UserAgent => JSRef.Get<string>("userAgent");
    }
}
