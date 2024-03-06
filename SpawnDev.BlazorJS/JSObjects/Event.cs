using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Event interface represents an event which takes place on an EventTarget.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Event
    /// </summary>
    public class Event : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Event(IJSInProcessObjectReference _ref) : base(_ref) { }
        #region Properties
        /// <summary>
        /// A boolean value indicating whether or not the event bubbles up through the DOM.
        /// </summary>
        public bool Bubbles => JSRef.Get<bool>("bubbles");
        /// <summary>
        /// A boolean value indicating whether the event is cancelable.
        /// </summary>
        public bool Cancelable => JSRef.Get<bool>("cancelable");
        /// <summary>
        /// A boolean indicating whether or not the event can bubble across the boundary between the shadow DOM and the regular DOM.
        /// </summary>
        public bool Composed => JSRef.Get<bool>("composed");
        /// <summary>
        /// A reference to the currently registered target for the event. This is the object to which the event is currently slated to be sent. It's possible this has been changed along the way through retargeting.
        /// </summary>
        public virtual EventTarget CurrentTarget => JSRef.Get<EventTarget>("currentTarget");
        /// <summary>
        /// A reference to the currently registered target for the event. This is the object to which the event is currently slated to be sent. It's possible this has been changed along the way through retargeting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T CurrentTargetAs<T>() where T : EventTarget => JSRef.Get<T>("currentTarget");
        /// <summary>
        /// Indicates whether or not the call to event.preventDefault() canceled the event.
        /// </summary>
        public bool DefaultPrevented => JSRef.Get<bool>("defaultPrevented");
        /// <summary>
        /// Indicates which phase of the event flow is being processed. It is one of the following numbers: NONE, CAPTURING_PHASE, AT_TARGET, BUBBLING_PHASE.
        /// </summary>
        public int EventPhase => JSRef.Get<int>("eventPhase");
        /// <summary>
        /// Indicates whether or not the event was initiated by the browser (after a user click, for instance) or by a script (using an event creation method, for example).
        /// </summary>
        public bool IsTrusted => JSRef.Get<bool>("isTrusted");
        /// <summary>
        /// A reference to the object to which the event was originally dispatched.
        /// </summary>
        public virtual EventTarget Target => JSRef.Get<EventTarget>("target");
        /// <summary>
        /// A reference to the object to which the event was originally dispatched.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T TargetAs<T>() where T : EventTarget => JSRef.Get<T>("target");
        /// <summary>
        /// The time at which the event was created (in milliseconds). By specification, this value is time since epoch—but in reality, browsers' definitions vary. In addition, work is underway to change this to be a DOMHighResTimeStamp instead.
        /// </summary>
        public double TimeStamp => JSRef.Get<double>("timeStamp");
        /// <summary>
        /// The name identifying the type of the event.
        /// </summary>
        public string Type => JSRef.Get<string>("type");
        #endregion
        #region Methods
        /// <summary>
        /// Returns the event's path (an array of objects on which listeners will be invoked). This does not include nodes in shadow trees if the shadow root was created with its ShadowRoot.mode closed.
        /// </summary>
        /// <returns></returns>
        public Array<EventTarget> ComposedPath() => JSRef.Call<Array<EventTarget>>("composedPath");
        /// <summary>
        /// Cancels the event (if it is cancelable).
        /// </summary>
        public void PreventDefault() => JSRef.CallVoid("preventDefault");
        /// <summary>
        /// The stopImmediatePropagation() method of the Event interface prevents other listeners of the same event from being called.<br />
        /// If several listeners are attached to the same element for the same event type, they are called in the order in which they were added. If stopImmediatePropagation() is invoked during one such call, no remaining listeners will be called, either on that element or any other element.
        /// </summary>
        public void StopImmediatePropagation() => JSRef.CallVoid("stopImmediatePropagation");
        /// <summary>
        /// The stopPropagation() method of the Event interface prevents further propagation of the current event in the capturing and bubbling phases. It does not, however, prevent any default behaviors from occurring; for instance, clicks on links are still processed. If you want to stop those behaviors, see the preventDefault() method. It also does not prevent propagation to other event-handlers of the current element. If you want to stop those, see stopImmediatePropagation().
        /// </summary>
        public void StopPropagation() => JSRef.CallVoid("stopPropagation");
        #endregion
    }
    /// <summary>
    /// The Event interface represents an event which takes place in the DOM.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Event
    /// </summary>
    /// <typeparam name="TTarget"></typeparam>
    public class Event<TTarget> : Event where TTarget : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Event(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A reference to the object to which the event was originally dispatched.
        /// </summary>
        public override TTarget Target => JSRef.Get<TTarget>("target");
    }
}
