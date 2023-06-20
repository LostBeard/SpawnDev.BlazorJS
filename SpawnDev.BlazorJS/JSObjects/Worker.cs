using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/Worker
    public class Worker : EventTarget, IMessagePort
    {
        public Worker(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Worker(string url) : base(JS.New(nameof(Worker), url)) { }
        public JSEventCallback OnError { get => new JSEventCallback(o => AddEventListener("error", o), o => RemoveEventListener("error", o)); set { } }
        public JSEventCallback<MessageEvent> OnMessage { get => new JSEventCallback<MessageEvent>(o => AddEventListener("message", o), o => RemoveEventListener("message", o)); set { } }
        public JSEventCallback OnMessageError { get => new JSEventCallback(o => AddEventListener("messageerror", o), o => RemoveEventListener("messageerror", o)); set { } }
        public JSEventCallback OnRejectionHandled { get => new JSEventCallback(o => AddEventListener("rejectionhandled", o), o => RemoveEventListener("rejectionhandled", o)); set { } }
        public JSEventCallback OnUnhandledRejection { get => new JSEventCallback(o => AddEventListener("unhandledrejection", o), o => RemoveEventListener("unhandledrejection", o)); set { } }
        public void Start() => JSRef.CallVoid("start");
        public void Terminate() => JSRef.CallVoid("terminate");
        public void PostMessage(object message) => JSRef.CallVoid("postMessage", message);
        public void PostMessage(object message, object[] transfer) => JSRef.CallVoid("postMessage", message, transfer);
    }
}
