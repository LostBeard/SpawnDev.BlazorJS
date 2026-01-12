using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PresentationConnectionList interface of the Presentation API represents a list of PresentationConnection objects that are associated with a presentation.
    /// </summary>
    public class PresentationConnectionList : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public PresentationConnectionList(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns an array of PresentationConnection objects.
        /// </summary>
        public PresentationConnection[] Connections => JSRef!.Get<PresentationConnection[]>("connections");

        /// <summary>
        /// Fired when a presentation connection is available.
        /// </summary>
        public ActionEvent<PresentationConnectionAvailableEvent> OnConnectionAvailable { get => new ActionEvent<PresentationConnectionAvailableEvent>("connectionavailable", AddEventListener, RemoveEventListener); set { } }
    }
}
