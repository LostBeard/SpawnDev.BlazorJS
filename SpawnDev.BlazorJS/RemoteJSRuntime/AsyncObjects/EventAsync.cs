using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// The Event interface represents an event which takes place on an EventTarget.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Event
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class EventAsync : JSObjectAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public EventAsync(IJSObjectReference _ref) : base(_ref) { }
        #region Properties
        /// <summary>
        /// A boolean value indicating whether or not the event bubbles up through the DOM.
        /// </summary>
        public Task<bool> Get_Bubbles() => JSRef!.GetAsync<bool>("bubbles");
        /// <summary>
        /// A boolean value indicating whether the event is cancelable.
        /// </summary>
        public Task<bool> Get_Cancelable() => JSRef!.GetAsync<bool>("cancelable");
        /// <summary>
        /// A boolean indicating whether or not the event can bubble across the boundary between the shadow DOM and the regular DOM.
        /// </summary>
        public Task<bool> Get_Composed() => JSRef!.GetAsync<bool>("composed");
        /// <summary>
        /// A reference to the currently registered target for the event. This is the object to which the event is currently slated to be sent. It's possible this has been changed along the way through retargeting.
        /// </summary>
        //public virtual Task<EventTargetAsync?> Get_CurrentTarget() => JSRef!.GetAsync<EventTargetAsync?>("currentTarget");
        /// <summary>
        /// A reference to the currently registered target for the event. This is the object to which the event is currently slated to be sent. It's possible this has been changed along the way through retargeting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task<T> Get_CurrentTargetAs<T>() where T : EventTargetAsync => JSRef!.GetAsync<T>("currentTarget");
        /// <summary>
        /// Indicates whether or not the call to event.preventDefault() canceled the event.
        /// </summary>
        public Task<bool> Get_DefaultPrevented() => JSRef!.GetAsync<bool>("defaultPrevented");
        /// <summary>
        /// Indicates which phase of the event flow is being processed. It is one of the following numbers: NONE, CAPTURING_PHASE, AT_TARGET, BUBBLING_PHASE.
        /// </summary>
        public Task<int> Get_EventPhase() => JSRef!.GetAsync<int>("eventPhase");
        /// <summary>
        /// Indicates whether or not the event was initiated by the browser (after a user click, for instance) or by a script (using an event creation method, for example).
        /// </summary>
        public Task<bool> Get_IsTrusted() => JSRef!.GetAsync<bool>("isTrusted");
        /// <summary>
        /// A reference to the object to which the event was originally dispatched.
        /// </summary>
        //public virtual Task<EventTargetAsync> Get_Target() => JSRef!.GetAsync<EventTargetAsync>("target");
        /// <summary>
        /// A reference to the object to which the event was originally dispatched.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task<T> Get_TargetAs<T>() where T : EventTargetAsync => JSRef!.GetAsync<T>("target");
        /// <summary>
        /// The time at which the event was created (in milliseconds). By specification, this value is time since epoch—but in reality, browsers' definitions vary. In addition, work is underway to change this to be a DOMHighResTimeStamp instead.
        /// </summary>
        public Task<double> Get_TimeStamp() => JSRef!.GetAsync<double>("timeStamp");
        /// <summary>
        /// The name identifying the type of the event.
        /// </summary>
        public Task<string> Get_Type() => JSRef!.GetAsync<string>("type");
        #endregion
    }
    /// <summary>
    /// The Event interface represents an event which takes place in the DOM.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Event
    /// </summary>
    /// <typeparam name="TTarget"></typeparam>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class EventAsync<TTarget> : EventAsync where TTarget : EventTargetAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public EventAsync(IJSObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A reference to the object to which the event was originally dispatched.
        /// </summary>
        public async Task<TTarget> Get_Target() => await JSRef!.GetAsync<TTarget>("target");
    }
}

