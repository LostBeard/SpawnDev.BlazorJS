using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaQueryListEvent object stores information on the changes that have occurred to a MediaQueryList object.
    /// </summary>
    public class MediaQueryListEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MediaQueryListEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A boolean value that returns true if the document currently matches the media query list, or false if not.
        /// </summary>
        public bool Matches => JSRef!.Get<bool>("matches");
        /// <summary>
        /// A string representing the serialized media query.
        /// </summary>
        public string Media => JSRef!.Get<string>("media");
    }
}
