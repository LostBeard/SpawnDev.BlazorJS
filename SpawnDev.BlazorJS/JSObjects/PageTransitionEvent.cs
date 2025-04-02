using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PageTransitionEvent event object is available inside handler functions for the pageshow and pagehide events, fired when a document is being loaded or unloaded.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PageTransitionEvent
    /// </summary>
    public class PageTransitionEvent : Event
    {
        ///<inheritdoc/>
        public PageTransitionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Indicates if the document is loading from a cache.
        /// </summary>
        public bool Persisted => JSRef!.Get<bool>("persisted");
    }
}
