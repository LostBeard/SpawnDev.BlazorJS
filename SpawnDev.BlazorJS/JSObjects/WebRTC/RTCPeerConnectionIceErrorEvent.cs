using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCPeerConnectionIceErrorEvent interface represents an error that occurred during the ICE candidate gathering or connection process.
    /// </summary>
    public class RTCPeerConnectionIceErrorEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCPeerConnectionIceErrorEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string providing the local IP address used to communicate with the STUN or TURN server being used to negotiate the connection.
        /// </summary>
        public string? Address => JSRef!.Get<string?>("address");
        /// <summary>
        /// An unsigned integer value giving the port number over which the communication with the STUN or TURN server is taking place.
        /// </summary>
        public uint? Port => JSRef!.Get<uint?>("port");
        /// <summary>
        /// An unsigned integer value stating the numeric STUN error code returned by the STUN or TURN server.
        /// </summary>
        public uint ErrorCode => JSRef!.Get<uint>("errorCode");
        /// <summary>
        /// A string containing the STUN error text returned by the STUN or TURN server.
        /// </summary>
        public string ErrorText => JSRef!.Get<string>("errorText");
        /// <summary>
        /// A string giving the URL of the STUN or TURN server which it was attempting to reach when the error occurred.
        /// </summary>
        public string Url => JSRef!.Get<string>("url");
    }
}
