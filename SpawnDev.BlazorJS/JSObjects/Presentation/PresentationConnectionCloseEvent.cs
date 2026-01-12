using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PresentationConnectionCloseEvent interface of the Presentation API is fired on a PresentationConnection when it is closed.
    /// </summary>
    public class PresentationConnectionCloseEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public PresentationConnectionCloseEvent(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns a human-readable message that explains why the connection closed.
        /// </summary>
        public string Message => JSRef!.Get<string>("message");

        /// <summary>
        /// Returns the reason why the connection closed.
        /// </summary>
        public string Reason => JSRef!.Get<string>("reason");
    }
}
