namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCRtpSenderCapabilityCodec
    {
        public int Channels { get; set; }
        public int ClockRate { get; set; }
        public string MimeType { get; set; } = "";
        public string SdpFmtpLine { get; set; } = "";
    }
}
