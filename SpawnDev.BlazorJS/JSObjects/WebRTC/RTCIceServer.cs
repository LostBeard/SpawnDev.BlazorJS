using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// Describes one server which may be used by the ICE agent; these are typically STUN and/or TURN servers. If this isn't specified, the connection attempt will be made with no STUN or TURN server available, which limits the connection to local peers.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/RTCPeerConnection#iceservers
    /// </summary>
    public class RTCIceServer
    {
        /// <summary>
        /// The credential to use when logging into the server. This is only used if the object represents a TURN server.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("credential")]
        public string? Credential { get; set; }
        /// <summary>
        /// This required property is either a single string or an array of strings, each specifying a URL which can be used to connect to the server.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("urls")]
        public Union<string, string[]>? Urls { get; set; }
        /// <summary>
        /// If the object represents a TURN server, then this is the username to use during the authentication.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("username")]
        public string? Username { get; set; }
    }
}
