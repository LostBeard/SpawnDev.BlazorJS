using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.WebWorkers
{
    internal class MissedPushEvent : PushEvent
    {
        public MissedPushEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void WaitResolve() => JSRef.CallVoid("waitResolve");
        public void WaitReject() => JSRef.CallVoid("waitReject");
    }
}

