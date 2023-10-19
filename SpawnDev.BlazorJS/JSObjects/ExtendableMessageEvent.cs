using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ExtendableMessageEvent : ExtendableEvent
    {
        public ExtendableMessageEvent(IJSInProcessObjectReference _ref) : base(_ref){ }
        public T GetData<T>() => JSRef.Get<T>("data");
        public string Origin => JSRef.Get<string>("origin");
        public string LastEventID => JSRef.Get<string>("lastEventID");
        public Client Source => JSRef.Get<Client>("source");
        public Array<MessagePort> Ports => JSRef.Get<Array<MessagePort>>("ports");
    }
}
