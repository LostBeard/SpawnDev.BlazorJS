using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCDTMFSender interface allows to send DTMF tones to a remote peer.
    /// </summary>
    public class RTCDTMFSender : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCDTMFSender(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
