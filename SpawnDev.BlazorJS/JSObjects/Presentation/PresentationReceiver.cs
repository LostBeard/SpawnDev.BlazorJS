using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PresentationReceiver interface of the Presentation API provides a way for a receiving browsing context to access the controlling browsing contexts and communicate with them.
    /// </summary>
    public class PresentationReceiver : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public PresentationReceiver(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns a Promise that resolves with a PresentationConnectionList object containing a list of incoming presentation connections.
        /// </summary>
        public Task<PresentationConnectionList> ConnectionList => JSRef!.GetAsync<PresentationConnectionList>("connectionList");
    }
}
