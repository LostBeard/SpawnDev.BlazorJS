using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MessageEvent interface represents a message received by a target object.
    /// https://developer.mozilla.org/en-US/docs/Web/API/MessageEvent
    /// </summary>
    public class MessageEvent : Event
    {
        public MessageEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The data sent by the message emitter. (data property with TValue typed get accessor)
        /// </summary>
        /// <typeparam name="T">Type to get property as</typeparam>
        /// <returns></returns>
        public T GetData<T>() => JSRef.Get<T>("data");

        /// <summary>
        /// non-standard method returns the typeof this.data
        /// returns "String", "Blob", or "ArrayBuffer"
        /// </summary>
        public string TypeOfData => JSRef.PropertyInstanceOf("data");

        /// <summary>
        /// A string representing the origin of the message emitter.
        /// </summary>
        public string Origin => JSRef.Get<string>("origin");
        /// <summary>
        /// A string representing a unique ID for the event.
        /// </summary>
        public string LastEventId => JSRef.Get<string>("lastEventId");
        /// <summary>
        /// A MessageEventSource (which can be a WindowProxy, MessagePort, or ServiceWorker object) representing the message emitter. (source property with TValue typed get accessor)
        /// </summary>
        /// <typeparam name="T">Type to get property as</typeparam>
        /// <returns></returns>
        public T GetSource<T>() => JSRef.Get<T>("source");
        public Array<MessagePort> Ports => JSRef.Get<Array<MessagePort>>("ports");
    }
}
