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

        /// <summary>
        /// Fired when a MessagePort object receives a message.
        /// Start() must be called to start receiving messages when using addEventListener instead of assigning onmessage.
        /// </summary>
        public JSEventCallback<MessageEvent> OnMessage { get => new JSEventCallback<MessageEvent>(o => AddEventListener("message", o), o => RemoveEventListener("message", o)); set { } }
        public JSEventCallback OnMessageError { get => new JSEventCallback(o => AddEventListener("messageerror", o), o => RemoveEventListener("messageerror", o)); set { } }
        /// <summary>
        /// Starts the sending of messages queued on the port (only needed when using EventTarget.addEventListener; it is implied when using onmessage).
        /// </summary>
        public void Start() => JSRef.CallVoid("start");
        /// <summary>
        /// Disconnects the port, so it is no longer active.
        /// </summary>
        public void Close() => JSRef.CallVoid("close");
        /// <summary>
        /// Sends a message from the port, and optionally, transfers ownership of objects to other browsing contexts.
        /// </summary>
        /// <param name="message"></param>
        public void PostMessage(object message) => JSRef.CallVoid("postMessage", message);
        /// <summary>
        /// Sends a message from the port, and optionally, transfers ownership of objects to other browsing contexts.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="transfer"></param>
        public void PostMessage(object message, object[] transfer) => JSRef.CallVoid("postMessage", message, transfer);
    }
}
