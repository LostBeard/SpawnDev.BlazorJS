namespace SpawnDev.BlazorJS.JSObjects.WebRTC {
    public class RTCIceCandidate {
        public string Address { get; set; } = "";
        public string Candidate { get; set; } = "";
        public string Component { get; set; } = "";
        public string Foundation { get; set; } = "";
        public int? Port { get; set; }
        public int? Priority { get; set; }
        public string Protocol { get; set; } = "";
        public int? SdpMLineIndex { get; set; }
        public string SdpMid { get; set; } = "";
        public string Type { get; set; } = "";
        public string UsernameFragment { get; set; } = "";
        public RTCIceCandidate() { }
    }
}
