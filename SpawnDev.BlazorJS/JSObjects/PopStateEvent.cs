using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class PopStateEvent : Event
    {
        public PopStateEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public T StateAs<T>() => JSRef!.Get<T>("state");
    }
}
