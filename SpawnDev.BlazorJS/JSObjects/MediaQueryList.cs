using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A MediaQueryList object stores information on a media query applied to a document, with support for both immediate and event-driven matching against the state of the document.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaQueryList
    /// </summary>
    public class MediaQueryList : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MediaQueryList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A boolean value that returns true if the document currently matches the media query list, or false if not.
        /// </summary>
        public bool Matches => JSRef.Get<bool>("matches");
        /// <summary>
        /// A string representing a serialized media query.
        /// </summary>
        public string Media => JSRef.Get<string>("media");
        /// <summary>
        /// Sent to the MediaQueryList when the result of running the media query against the document changes. For example, if the media query is (min-width: 400px), the change event is fired any time the width of the document's viewport changes such that its width moves across the 400px boundary in either direction.
        /// </summary>
        public JSEventCallback<MediaQueryListEvent> OnChange { get => new JSEventCallback<MediaQueryListEvent>("change", AddEventListener, RemoveEventListener); set { } }
    }
}
