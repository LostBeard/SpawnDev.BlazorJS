using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMessagePort : IMessagePortSimple
    {
        /// <summary>
        /// Sends a message from the port, and optionally, transfers ownership of objects to other browsing contexts.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="transfer"></param>
        void PostMessage(object message, object[] transfer);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IMessagePortSimple : IDisposable
    {
        /// <summary>
        /// Fired when a MessagePort object receives a message that can't be deserialized.
        /// </summary>
        JSEventCallback<MessageEvent> OnMessageError { get; set; }
        /// <summary>
        /// Fired when a MessagePort object receives a message.
        /// Start() must be called to start receiving messages when using addEventListener instead of assigning onmessage.
        /// </summary>
        JSEventCallback<MessageEvent> OnMessage { get; set; }
        /// <summary>
        /// Sends a message from the port, and optionally, transfers ownership of objects to other browsing contexts.
        /// </summary>
        /// <param name="message"></param>
        void PostMessage(object message);
    }

    /// <summary>
    /// The MessagePort interface of the Channel Messaging API represents one of the two ports of a MessageChannel, allowing messages to be sent from one port and listening out for them arriving at the other.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MessagePort
    /// </summary>
    public class MessagePort : EventTarget, IMessagePort
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MessagePort(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Fired when a MessagePort object receives a message.
        /// Start() must be called to start receiving messages when using addEventListener instead of assigning onmessage.
        /// </summary>
        public JSEventCallback<MessageEvent> OnMessage { get => new JSEventCallback<MessageEvent>("message", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a MessagePort object receives a message that can't be deserialized.
        /// </summary>
        public JSEventCallback<MessageEvent> OnMessageError { get => new JSEventCallback<MessageEvent>("messageerror", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Starts the sending of messages queued on the port (only needed when using EventTarget.addEventListener; it is implied when using onmessage).
        /// </summary>
        public void Start() => JSRef!.CallVoid("start");
        /// <summary>
        /// Disconnects the port, so it is no longer active.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");
        /// <summary>
        /// Sends a message from the port, and optionally, transfers ownership of objects to other browsing contexts.
        /// </summary>
        /// <param name="message"></param>
        public void PostMessage(object message) => JSRef!.CallVoid("postMessage", message);
        /// <summary>
        /// Sends a message from the port, and optionally, transfers ownership of objects to other browsing contexts.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="transfer"></param>
        public void PostMessage(object message, object[] transfer) => JSRef!.CallVoid("postMessage", message, transfer);
    }
}
