using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BeforeUnloadEvent interface represents the event object for the beforeunload event, which is fired when the current window, contained document, and associated resources are about to be unloaded.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/BeforeUnloadEvent
    /// NOTE: WebKit-derived browsers don't follow the spec for the dialog box. (quoted from MDN page.)
    /// </summary>
    public class BeforeUnloadEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param
        public BeforeUnloadEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// When set to a truthy value, triggers a browser-controlled confirmation dialog asking users to confirm if they want to leave the page when they try to close or reload it. This is a legacy feature, and best practice is to trigger the dialog by invoking event.preventDefault(), while also setting returnValue to support legacy cases.<br />
        /// DEPRACATED
        /// </summary>
        public string? ReturnValue { get => JSRef.Get<string?>("returnValue"); set => JSRef.Set("returnValue", value); }
    }
}
