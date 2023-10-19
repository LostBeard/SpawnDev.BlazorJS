using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.WebWorkers
{
    internal class MissedFetchEvent : FetchEvent
    {
        public MissedFetchEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void ResponseResolve(Response response) => JSRef.CallVoid("responseResolve", response);
        public void ResponseReject() => JSRef.CallVoid("responseReject");
    }
}

