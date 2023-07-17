using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class PromiseRejectionEvent : Event
    {
        public PromiseRejectionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public T ReasonAs<T>() => JSRef.Get<T>("reason");
        public Promise Promise => JSRef.Get<Promise>("promise");
    }
}
