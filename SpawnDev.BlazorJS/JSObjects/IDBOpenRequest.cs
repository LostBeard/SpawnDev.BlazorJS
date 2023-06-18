using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class IDBOpenRequest : IDBRequest
    {
        public IDBOpenRequest(IJSInProcessObjectReference _ref) : base(_ref) { }
        public JSEventCallback OnBlocked { get => new JSEventCallback(o => AddEventListener("blocked", o), o => RemoveEventListener("blocked", o)); set { } }
        public JSEventCallback<IDBVersionChangeEvent> OnUpgradeNeeded { get => new JSEventCallback<IDBVersionChangeEvent>(o => AddEventListener("upgradeneeded", o), o => RemoveEventListener("upgradeneeded", o)); set { } }
    }
}
