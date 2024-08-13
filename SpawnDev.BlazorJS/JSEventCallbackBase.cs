//using Microsoft.JSInterop;

//namespace SpawnDev.BlazorJS
//{
//    /// <summary>
//    /// JSEventCallback base class
//    /// </summary>
//    public abstract class JSEventCallbackBase
//    {
//        /// <summary>
//        /// The method that will be called when an event handler is attached via +=
//        /// </summary>
//        public Action<Callback> On { get; private set; }
//        /// <summary>
//        /// The method that will be called when an event handler is detached via -=
//        /// </summary>
//        public Action<Callback>? Off { get; private set; }
//        /// <summary>
//        /// Maps:<br />
//        /// JSEventCallback += callback - to on(eventName, callback)<br />
//        /// JSEventCallback -= callback - to off(eventName, callback)<br />
//        /// </summary>
//        /// <param name="eventName"></param>
//        /// <param name="on">add callback method - that takes (eventName, callback)</param>
//        /// <param name="off">remove callback method - that takes (eventName, callback)</param>
//        public JSEventCallbackBase(string eventName, Action<string, Callback> on, Action<string, Callback>? off = null)
//        {
//            On = (o) => on(eventName, o);
//            Off = off == null ? null : (o) => off(eventName, o);
//        }
//        /// <summary>
//        /// Maps:<br />
//        /// JSEventCallback += callback - to on(callback)<br />
//        /// JSEventCallback -= callback - to off(callback)<br />
//        /// </summary>
//        /// <param name="on">add callback method - that takes (Callback callback)</param>
//        /// <param name="off">remove callback method - that takes (Callback callback)</param>
//        public JSEventCallbackBase(Action<Callback> on, Action<Callback>? off = null)
//        {
//            On = on;
//            Off = off;
//        }
//        /// <summary>
//        /// Maps:<br />
//        /// JSEventCallback += callback - to JSRef!.Set(propertyName, callback)<br />
//        /// JSEventCallback -= callback - to JSRef!.Set(propertyName, null)<br />
//        /// </summary>
//        /// <param name="jsRef">Target JSObject's JSRef property (IJSInProcessObjectReference)</param>
//        /// <param name="propertyName">Property name to set</param>
//        public JSEventCallbackBase(IJSInProcessObjectReference jsRef, string propertyName)
//        {
//            On = (o) => jsRef.Set(propertyName, o);
//            Off = (o) => jsRef.Set(propertyName, null);
//        }
//        /// <summary>
//        /// Maps:<br />
//        /// JSEventCallback += callback - to JSRef!.CallVoid(onFn, callback)<br />
//        /// JSEventCallback -= callback - to JSRef!.CallVoid(OffFn, null)<br />
//        /// </summary>
//        /// <param name="jsRef">Target JSObject's JSRef property (IJSInProcessObjectReference)</param>
//        /// <param name="name">Event name to passed as the first argument to the onFn function</param>
//        /// <param name="onFn">The name of the function to call when adding a callback</param>
//        /// <param name="offFn">The name of the function to call when removing a callback</param>
//        public JSEventCallbackBase(IJSInProcessObjectReference jsRef, string name, string onFn, string offFn = "")
//        {
//            On = (o) => jsRef.CallVoid(onFn, name, o);
//            if (!string.IsNullOrEmpty(offFn)) Off = (o) => jsRef.CallVoid(offFn, name, o);
//        }
//    }
//}
