using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    /// <summary>
    /// The MessageEvent interface represents a message received by a target object.
    /// </summary>
    public class MessageEvent : JSObject {
        public MessageEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The data sent by the message emitter. (data property with T typed get accessor)
        /// </summary>
        /// <typeparam name="T">Type to get property as</typeparam>
        /// <returns></returns>
        public T GetData<T>() => JSRef.Get<T>("data");
        /// <summary>
        /// A string representing the origin of the message emitter.
        /// </summary>
        public string Origin => JSRef.Get<string>("origin");
        /// <summary>
        /// A string representing a unique ID for the event.
        /// </summary>
        public string LastEventId => JSRef.Get<string>("lastEventId");
        /// <summary>
        /// A MessageEventSource (which can be a WindowProxy, MessagePort, or ServiceWorker object) representing the message emitter. (source property with T typed get accessor)
        /// </summary>
        /// <typeparam name="T">Type to get property as</typeparam>
        /// <returns></returns>
        public T GetSource<T>() => JSRef.Get<T>("source");
    }
}
