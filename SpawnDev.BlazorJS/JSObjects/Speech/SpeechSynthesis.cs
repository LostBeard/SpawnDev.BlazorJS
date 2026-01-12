using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SpeechSynthesis interface of the Web Speech API is the controller interface for the speech service; this can be used to retrieve information about the synthesis voices available on the device, start and pause speech, and other commands besides.
    /// </summary>
    public class SpeechSynthesis : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public SpeechSynthesis(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns a boolean value that returns true if the SpeechSynthesis object is in a paused state.
        /// </summary>
        public bool Paused => JSRef!.Get<bool>("paused");

        /// <summary>
        /// Returns a boolean value that returns true if the utterance queue contains as-yet-unspoken utterances.
        /// </summary>
        public bool Pending => JSRef!.Get<bool>("pending");

        /// <summary>
        /// Returns a boolean value that returns true if an utterance is currently in the process of being spoken — even if SpeechSynthesis is in a paused state.
        /// </summary>
        public bool Speaking => JSRef!.Get<bool>("speaking");

        /// <summary>
        /// Removes all utterances from the utterance queue.
        /// </summary>
        public void Cancel() => JSRef!.CallVoid("cancel");

        /// <summary>
        /// Returns a list of SpeechSynthesisVoice objects representing all the available voices on the current device.
        /// </summary>
        public List<SpeechSynthesisVoice> GetVoices() => JSRef!.Call<List<SpeechSynthesisVoice>>("getVoices");

        /// <summary>
        /// Puts the SpeechSynthesis object into a paused state.
        /// </summary>
        public void Pause() => JSRef!.CallVoid("pause");

        /// <summary>
        /// Puts the SpeechSynthesis object into a non-paused state: resumes it if it was previously paused.
        /// </summary>
        public void Resume() => JSRef!.CallVoid("resume");

        /// <summary>
        /// Adds an utterance to the utterance queue; it will be spoken when any other utterances queued before it have been spoken.
        /// </summary>
        public void Speak(SpeechSynthesisUtterance utterance) => JSRef!.CallVoid("speak", utterance);

        /// <summary>
        /// Fired when the list of available voices has changed.
        /// </summary>
        public JSEventCallback<Event> OnVoicesChanged { get => new JSEventCallback<Event>("voiceschanged", AddEventListener, RemoveEventListener); set { } }
    }
}
