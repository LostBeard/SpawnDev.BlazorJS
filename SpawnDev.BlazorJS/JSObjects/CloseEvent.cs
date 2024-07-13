using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A CloseEvent is sent to clients using WebSockets when the connection is closed. This is delivered to the listener indicated by the WebSocket object's onclose attribute.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/CloseEvent
    /// </summary>
    public class CloseEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CloseEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an unsigned short containing the close code sent by the server.
        /// </summary>
        public ushort Code => JSRef!.Get< ushort>("code");
        /// <summary>
        /// Returns a string indicating the reason the server closed the connection. This is specific to the particular server and sub-protocol.
        /// </summary>
        public string Reason => JSRef!.Get<string>("reason");
        /// <summary>
        /// Returns a boolean value that Indicates whether or not the connection was cleanly closed.
        /// </summary>
        public bool WasClean=> JSRef!.Get<bool>("wasClean");
    }
}
