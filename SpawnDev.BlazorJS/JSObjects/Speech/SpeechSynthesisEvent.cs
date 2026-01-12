using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SpeechSynthesisEvent interface of the Web Speech API contains information about the current state of SpeechSynthesisUtterance objects that have been processed in the speech service.
    /// </summary>
    public class SpeechSynthesisEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public SpeechSynthesisEvent(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns the SpeechSynthesisUtterance instance that the event was triggered on.
        /// </summary>
        public SpeechSynthesisUtterance Utterance => JSRef!.Get<SpeechSynthesisUtterance>("utterance");

        /// <summary>
        /// Returns the index position of the character in the SpeechSynthesisUtterance.text that was being spoken when the event was triggered.
        /// </summary>
        public int CharIndex => JSRef!.Get<int>("charIndex");
        
        /// <summary>
        /// Returns the length of the character in the SpeechSynthesisUtterance.text that was being spoken when the event was triggered.
        /// </summary>
        public int? CharLength => JSRef!.Get<int?>("charLength");

        /// <summary>
        /// Returns the elapsed time in seconds after the SpeechSynthesisUtterance.text started being spoken that the event was triggered at.
        /// </summary>
        public float ElapsedTime => JSRef!.Get<float>("elapsedTime");

        /// <summary>
        /// Returns the name associated with certain types of events occurring as the SpeechSynthesisUtterance.text is being spoken: the name of the SSML marker reached in the case of a mark event, or the type of boundary reached in the case of a boundary event.
        /// </summary>
        public string Name => JSRef!.Get<string>("name");
    }
}
