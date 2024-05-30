namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCRtpSenderCapabilities
    {
        public List<RTCRtpTransceiverCodec> Codecs { get; set; }
        public List<RTCRtpSenderCapabilityHeaderExtension> HeaderExtensions { get; set; }
    }
}
