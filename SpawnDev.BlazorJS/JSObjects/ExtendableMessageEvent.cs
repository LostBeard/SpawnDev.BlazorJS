using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ExtendableMessageEvent interface of the Service Worker API represents the event object of a message event fired on a service worker (when a message is received on the ServiceWorkerGlobalScope from another context) — extends the lifetime of such events.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/ExtendableMessageEvent
    /// </summary>
    public class ExtendableMessageEvent : ExtendableEvent
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ExtendableMessageEvent(IJSInProcessObjectReference _ref) : base(_ref){ }
        /// <summary>
        /// Returns the event's data. It can be any data type. If dispatched in messageerror event, the property will be null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetData<T>() => JSRef.Get<T>("data");
        /// <summary>
        /// Returns the origin of the Client that sent the message.
        /// </summary>
        public string Origin => JSRef.Get<string>("origin");
        /// <summary>
        /// Represents, in server-sent events, the last event ID of the event source.
        /// </summary>
        public string LastEventID => JSRef.Get<string>("lastEventID");
        /// <summary>
        /// Returns a reference to the Client object that sent the message.
        /// </summary>
        public Client Source => JSRef.Get<Client>("source");
        /// <summary>
        /// Returns the array containing the MessagePort objects representing the ports of the associated message channel.
        /// </summary>
        public Array<MessagePort> Ports => JSRef.Get<Array<MessagePort>>("ports");
    }
}
