using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PresentationConnection interface of the Presentation API provides the methods for a presentation connection.
    /// </summary>
    public class PresentationConnection : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public PresentationConnection(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns the ID of the presentation connection.
        /// </summary>
        public string Id => JSRef!.Get<string>("id");

        /// <summary>
        /// Returns the URL of the presentation connection.
        /// </summary>
        public string Url => JSRef!.Get<string>("url");

        /// <summary>
        /// Returns the state of the presentation connection.
        /// </summary>
        public string State => JSRef!.Get<string>("state");

        /// <summary>
        /// Returns and sets the binary type of the presentation connection.
        /// </summary>
        public string BinaryType
        {
            get => JSRef!.Get<string>("binaryType");
            set => JSRef!.Set("binaryType", value);
        }

        /// <summary>
        /// Closes the presentation connection.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");

        /// <summary>
        /// Terminates the presentation connection.
        /// </summary>
        public void Terminate() => JSRef!.CallVoid("terminate");

        /// <summary>
        /// Sends a message to the presentation connection.
        /// </summary>
        /// <param name="message"></param>
        public void Send(string message) => JSRef!.CallVoid("send", message);
        
        /// <summary>
        /// Sends a message to the presentation connection.
        /// </summary>
        /// <param name="message"></param>
        public void Send(Blob message) => JSRef!.CallVoid("send", message);
        
        /// <summary>
        /// Sends a message to the presentation connection.
        /// </summary>
        /// <param name="message"></param>
        public void Send(ArrayBuffer message) => JSRef!.CallVoid("send", message);

        /// <summary>
        /// Fired when the state of the presentation connection changes to closed.
        /// </summary>
        public ActionEvent<PresentationConnectionCloseEvent> OnClose { get => new ActionEvent<PresentationConnectionCloseEvent>("close", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the state of the presentation connection changes to connected.
        /// </summary>
        public ActionEvent<Event> OnConnect { get => new ActionEvent<Event>("connect", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when a message is received from the presentation connection.
        /// </summary>
        public ActionEvent<MessageEvent> OnMessage { get => new ActionEvent<MessageEvent>("message", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the state of the presentation connection changes to terminated.
        /// </summary>
        public ActionEvent<Event> OnTerminate { get => new ActionEvent<Event>("terminate", AddEventListener, RemoveEventListener); set { } }
    }
}
