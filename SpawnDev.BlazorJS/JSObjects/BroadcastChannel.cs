using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Broadcast_Channel_API
    /// </summary>
    public class BroadcastChannel : EventTarget {
        public BroadcastChannel(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Name => JSRef.Get<string>("name");
        public BroadcastChannel(string channelName) : base(JS.New("BroadcastChannel", channelName)) { }

        public JSEventCallback<MessageEvent> OnMessageError { get => new JSEventCallback<MessageEvent>(o => AddEventListener("messageerror", o), o => RemoveEventListener("messageerror", o)); set { } }
        public JSEventCallback<MessageEvent> OnMessage { get => new JSEventCallback<MessageEvent>(o => AddEventListener("message", o), o => RemoveEventListener("message", o)); set { } }

        /// <summary>
        /// The BroadcastChannel.close() terminates the connection to the underlying channel, allowing the object to be garbage collected. This is a necessary step to perform as there is no other way for a browser to know that this channel is not needed anymore.
        /// </summary>
        public void Close() => JSRef.CallVoid("close");
        /// <summary>
        /// The BroadcastChannel.postMessage() sends a message, which can be of any kind of Object, to each listener in any browsing context with the same origin. The message is transmitted as a 'message' event targeted at each BroadcastChannel bound to the channel.
        /// </summary>
        /// <param name="message">Data to be sent to the other window. The data is serialized using the structured clone algorithm. This means you can pass a broad variety of data objects safely to the destination window without having to serialize them yourself.</param>
        public void PostMessaage(object message) => JSRef.CallVoid("postMessage", message);
    }
}
