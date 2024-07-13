using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ContentVisibilityAutoStateChangeEvent interface is the event object for the contentvisibilityautostatechange event, which fires on any element with content-visibility: auto set on it when it starts or stops being relevant to the user and skipping its contents.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ContentVisibilityAutoStateChangeEvent
    /// </summary>
    public class ContentVisibilityAutoStateChangeEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ContentVisibilityAutoStateChangeEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns true if the user agent is skipping the element's rendering, or false otherwise.
        /// </summary>
        public bool Skipped => JSRef!.Get<bool>("skipped");
    }
}
