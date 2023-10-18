using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Client
    /// </summary>
    public class Client : JSObject
    {
        public Client(IJSInProcessObjectReference _ref) : base(_ref) { }

        public void PostMessage(object message) => JSRef.CallVoid("postMessage", message);

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
    }
}
