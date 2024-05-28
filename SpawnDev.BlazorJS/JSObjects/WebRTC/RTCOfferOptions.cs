using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// Options used for RTCPeerConnection.CreateOffer()
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/createOffer#options
    /// </summary>
    public class RTCOfferOptions
    {
        /// <summary>
        /// To restart ICE on an active connection, set this to true. This will cause the returned offer to have different credentials than those already in place. If you then apply the returned offer, ICE will restart. Specify false to keep the same credentials and therefore not restart ICE. The default is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IceRestart { get; set; }
    }
}
