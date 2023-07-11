using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCRtpTransceiver : JSObject
    {
        public RTCRtpTransceiver(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void Stop() => JSRef.CallVoid("stop");
        /// <summary>
        /// The RTCRtpTransceiver property direction is a string which indicates the transceiver's preferred directionality.
        /// </summary>
        public string Direction => JSRef.Get<string>("direction");

    }
}
