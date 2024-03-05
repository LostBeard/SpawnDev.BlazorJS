using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CustomEvent interface represents events initialized by an application for any purpose.
    /// </summary>
    public class CustomEvent : Event
    {
        public CustomEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public CustomEvent(string type) : base(JS.New(nameof(CustomEvent), type)) { }
        public CustomEvent(string type, CustomEventOptions options) : base(JS.New(nameof(CustomEvent), type, options)) { }
        /// <summary>
        /// Returns any data passed when initializing the event.
        /// </summary>
        public JSObject? Detail => JSRef.Get<JSObject?>("detail");
        /// <summary>
        /// Returns any data passed when initializing the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T DetailAs<T>() => JSRef.Get<T>("detail");
    }
    /// <summary>
    /// The CustomEvent interface represents events initialized by an application for any purpose.
    /// </summary>
    public class CustomEvent<TDetail> : Event
    {
        public CustomEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public CustomEvent(string type) : base(JS.New(nameof(CustomEvent), type)) { }
        public CustomEvent(string type, CustomEventOptions<TDetail> options) : base(JS.New(nameof(CustomEvent), type, options)) { }
        /// <summary>
        /// Returns any data passed when initializing the event.
        /// </summary>
        public TDetail Detail => JSRef.Get<TDetail>("detail");
    }
}
