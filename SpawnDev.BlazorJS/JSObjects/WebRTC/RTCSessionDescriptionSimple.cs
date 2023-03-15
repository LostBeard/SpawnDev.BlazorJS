namespace SpawnDev.BlazorJS.JSObjects.WebRTC {
    public class RTCSessionDescriptionSimple : IRTCSessionDescription {
        public string Type { get; set; }
        public string Sdp { get; set; }
        public RTCSessionDescriptionSimple() { }
        public RTCSessionDescriptionSimple(string type, string sdp) => (Type, Sdp) = (type, sdp);
    }
}
