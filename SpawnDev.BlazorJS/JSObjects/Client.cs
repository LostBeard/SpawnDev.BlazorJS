using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Client interface represents an executable context such as a Worker, or a SharedWorker. Window clients are represented by the more-specific WindowClient. You can get Client/WindowClient objects from methods such as Clients.matchAll() and Clients.get().<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Client
    /// </summary>
    public class Client : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Client(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Sends a message to the client.
        /// </summary>
        /// <param name="message"></param>
        public void PostMessage(object message) => JSRef.CallVoid("postMessage", message);
        /// <summary>
        /// Sends a message to the client.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="transfer"></param>
        public void PostMessage(object message, object[] transfer) => JSRef.CallVoid("postMessage", message, transfer);

        /// <summary>
        /// The universally unique identifier of the client as a string.
        /// </summary>
        public string Id => JSRef.Get<string>("id");
        /// <summary>
        /// The client's type as a string. It can be "window", "worker", or "sharedworker".
        /// </summary>
        public string Type => JSRef.Get<string>("type");
        /// <summary>
        /// The URL of the client as a string.
        /// </summary>
        public string Url => JSRef.Get<string>("url");
        /// <summary>
        /// The client's frame type as a string. It can be "auxiliary", "top-level", "nested", or "none".
        /// </summary>
        public string FrameType => JSRef.Get<string>("frameType");
    }
}
