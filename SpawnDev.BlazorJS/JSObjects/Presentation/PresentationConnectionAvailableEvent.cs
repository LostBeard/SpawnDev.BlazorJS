using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PresentationConnectionAvailableEvent interface of the Presentation API is fired on a PresentationRequest when a connection is available.
    /// </summary>
    public class PresentationConnectionAvailableEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public PresentationConnectionAvailableEvent(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns the PresentationConnection instance that is now available.
        /// </summary>
        public PresentationConnection Connection => JSRef!.Get<PresentationConnection>("connection");
    }
}
