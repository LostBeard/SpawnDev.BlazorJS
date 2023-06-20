using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public interface IMessagePort
    {
        JSEventCallback OnMessageError { get; set; }
        JSEventCallback<MessageEvent> OnMessage { get; set; }
        void Dispose();
        void PostMessage(object message);
        void PostMessage(object message, object[] transfer);
    }

    // https://developer.mozilla.org/en-US/docs/Web/API/MessagePort
    public class MessagePort : EventTarget, IMessagePort
    {
        public MessagePort(IJSInProcessObjectReference _ref) : base(_ref) { }
        public JSEventCallback<MessageEvent> OnMessage { get => new JSEventCallback<MessageEvent>(o => AddEventListener("message", o), o => RemoveEventListener("message", o)); set { } }
        public JSEventCallback OnMessageError { get => new JSEventCallback(o => AddEventListener("messageerror", o), o => RemoveEventListener("messageerror", o)); set { } }
        public void Start() => JSRef.CallVoid("start");
        public void Close() => JSRef.CallVoid("close");
        public void PostMessage(object message) => JSRef.CallVoid("postMessage", message);
        public void PostMessage(object message, object[] transfer) => JSRef.CallVoid("postMessage", message, transfer);
    }
}
