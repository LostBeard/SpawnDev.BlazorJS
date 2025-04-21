using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The contentdelete event of the ServiceWorkerGlobalScope interface is fired when an item is removed from the indexed content via the user agent.<br/>
    /// This event is not cancelable and does not bubble.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope/contentdelete_event
    /// </summary>
    public class ContentIndexEvent : ExtendableEvent
    {
        /// <inheritdoc/>
        public ContentIndexEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string which identifies the deleted content index via it's id.
        /// </summary>
        public string Id => JSRef!.Get<string>("id");
    }
}
