using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PresentationRequest interface of the Presentation API provides methods to start a new presentation or reconnect to an existing one.
    /// </summary>
    public class PresentationRequest : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public PresentationRequest(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new PresentationRequest.
        /// </summary>
        public PresentationRequest(string url) : base(JS.New(nameof(PresentationRequest), url)) { }
        
        /// <summary>
        /// Creates a new PresentationRequest.
        /// </summary>
        public PresentationRequest(IEnumerable<string> urls) : base(JS.New(nameof(PresentationRequest), urls)) { }

        /// <summary>
        /// Starts a new presentation connection.
        /// </summary>
        public Task<PresentationConnection> Start() => JSRef!.CallAsync<PresentationConnection>("start");

        /// <summary>
        /// Reconnects to an existing presentation connection.
        /// </summary>
        public Task<PresentationConnection> Reconnect(string id) => JSRef!.CallAsync<PresentationConnection>("reconnect", id);

        /// <summary>
        /// Returns a promise that resolves with a PresentationAvailability object.
        /// </summary>
        public Task<PresentationAvailability> GetAvailability() => JSRef!.CallAsync<PresentationAvailability>("getAvailability");

        /// <summary>
        /// Fired when a presentation connection is available.
        /// </summary>
        public ActionEvent<PresentationConnectionAvailableEvent> OnConnectionAvailable { get => new ActionEvent<PresentationConnectionAvailableEvent>("connectionavailable", AddEventListener, RemoveEventListener); set { } }
    }
}
