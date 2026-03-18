using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCDTMFSender interface allows to send DTMF tones to a remote peer.
    /// </summary>
    public class RTCDTMFSender : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCDTMFSender(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a string containing the list of DTMF tones currently queued to be sent.
        /// </summary>
        public string ToneBuffer => JSRef!.Get<string>("toneBuffer");
        /// <summary>
        /// Sends DTMF tones over the connection.
        /// </summary>
        /// <param name="tones">A string containing the DTMF tones to send (characters 0-9, A-D, # and *).</param>
        /// <param name="duration">Duration each tone should play, in milliseconds. Must be between 40 and 6000. Defaults to 100.</param>
        /// <param name="interToneGap">Silence between tones, in milliseconds. Must be at least 30. Defaults to 70.</param>
        public void InsertDTMF(string tones, int duration = 100, int interToneGap = 70) => JSRef!.CallVoid("insertDTMF", tones, duration, interToneGap);
        /// <summary>
        /// Fired when a DTMF tone has been played.
        /// </summary>
        public ActionEvent<Event> OnToneChange { get => new ActionEvent<Event>("tonechange", AddEventListener, RemoveEventListener); set { } }
    }
}
