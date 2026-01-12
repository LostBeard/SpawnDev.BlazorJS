using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CustomEvent interface represents events initialized by an application for any purpose.
    /// </summary>
    public class CustomEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CustomEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The CustomEvent() constructor creates a new CustomEvent object.
        /// </summary>
        /// <param name="type">A string providing the name of the event. Event names are case-sensitive.</param>
        public CustomEvent(string type) : base(JS.New(nameof(CustomEvent), type)) { }
        /// <summary>
        /// The CustomEvent() constructor creates a new CustomEvent object.
        /// </summary>
        /// <param name="type">A string providing the name of the event. Event names are case-sensitive.</param>
        /// <param name="options">An object that, in addition of the properties defined in Event(), can have the following properties:</param>
        public CustomEvent(string type, CustomEventOptions options) : base(JS.New(nameof(CustomEvent), type, options)) { }
        /// <summary>
        /// Returns any data passed when initializing the event.
        /// </summary>
        public JSObject? Detail => JSRef!.Get<JSObject?>("detail");
        /// <summary>
        /// Returns any data passed when initializing the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T DetailAs<T>() => JSRef!.Get<T>("detail");
    }
    /// <summary>
    /// The CustomEvent interface represents events initialized by an application for any purpose.
    /// </summary>
    public class CustomEvent<TDetail> : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CustomEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The CustomEvent() constructor creates a new CustomEvent object.
        /// </summary>
        /// <param name="type"></param>
        public CustomEvent(string type) : base(JS.New(nameof(CustomEvent), type)) { }
        /// <summary>
        /// The CustomEvent() constructor creates a new CustomEvent object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="options"></param>
        public CustomEvent(string type, CustomEventOptions<TDetail> options) : base(JS.New(nameof(CustomEvent), type, options)) { }
        /// <summary>
        /// Returns any data passed when initializing the event.
        /// </summary>
        public TDetail Detail => JSRef!.Get<TDetail>("detail");
    }
}
