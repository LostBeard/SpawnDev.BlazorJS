using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class IDBVersionChangeEvent : Event
    {
        public IDBVersionChangeEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ulong OldVersion => JSRef.Get<ulong>("oldVersion");
        public ulong NewVersion => JSRef.Get<ulong>("newVersion");
        public IDBDatabase Database => JSRef.Get<IDBDatabase>("target.result");
        public IDBOpenRequest TargetRequest => TargetAs<IDBOpenRequest>();
    }
}
