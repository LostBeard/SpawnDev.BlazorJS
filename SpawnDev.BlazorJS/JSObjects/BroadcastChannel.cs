using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Broadcast Channel API allows basic communication between browsing contexts (that is, windows, tabs, frames, or iframes) and workers on the same origin.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/BroadcastChannel
    /// </summary>
    public class BroadcastChannel : EventTarget, IMessagePortSimple
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public BroadcastChannel(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The BroadcastChannel() constructor creates a new BroadcastChannel and connects it to the underlying channel.
        /// </summary>
        /// <param name="channelName">A string representing the name of the channel; there is one single channel with this name for all browsing contexts with the same origin.</param>
        public BroadcastChannel(string channelName) : base(JS.New(nameof(BroadcastChannel), channelName)) { }
        /// <summary>
        /// Returns a string, the name of the channel.
        /// </summary>
        public string Name => JSRef!.Get<string>("name");
        /// <summary>
        /// Fired when a message arrives on the channel. Also available via the onmessage property.
        /// </summary>
        public JSEventCallback<MessageEvent> OnMessage { get => new JSEventCallback<MessageEvent>("message", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a message arrives that can't be deserialized. Also available via the onmessageerror property.
        /// </summary>
        public JSEventCallback<MessageEvent> OnMessageError { get => new JSEventCallback<MessageEvent>("messageerror", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The BroadcastChannel.close() terminates the connection to the underlying channel, allowing the object to be garbage collected. This is a necessary step to perform as there is no other way for a browser to know that this channel is not needed anymore.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");
        /// <summary>
        /// The BroadcastChannel.postMessage() sends a message, which can be of any kind of Object, to each listener in any browsing context with the same origin. The message is transmitted as a 'message' event targeted at each BroadcastChannel bound to the channel.
        /// </summary>
        /// <param name="message">Data to be sent to the other window. The data is serialized using the structured clone algorithm. This means you can pass a broad variety of data objects safely to the destination window without having to serialize them yourself.</param>
        public void PostMessage(object message) => JSRef!.CallVoid("postMessage", message);
    }
}
