using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.WebWorkers
{
    internal class MissedExtendableEvent : ExtendableEvent
    {
        public MissedExtendableEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void WaitResolve() => JSRef.CallVoid("waitResolve");
        public void WaitReject() => JSRef.CallVoid("waitReject");
    }
}

