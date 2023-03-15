using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC {
    // https://developer.mozilla.org/en-US/docs/Web/API/RTCIceServer
    public class RTCIceServer {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Credential { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CredentialType { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Urls { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Username { get; set; } = null;
    }
}
