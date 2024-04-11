using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCSessionDescription
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "";
        [JsonPropertyName("sdp")]
        public string Sdp { get; set; } = "";
    }
}
