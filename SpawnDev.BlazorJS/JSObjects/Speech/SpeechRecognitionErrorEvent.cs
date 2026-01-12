using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SpeechRecognitionErrorEvent interface of the Web Speech API represents the error event in the speech recognition service.
    /// </summary>
    public class SpeechRecognitionErrorEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public SpeechRecognitionErrorEvent(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns the type of error raised.
        /// </summary>
        public string Error => JSRef!.Get<string>("error");

        /// <summary>
        /// Returns a message describing the error in more detail.
        /// </summary>
        public string Message => JSRef!.Get<string>("message");
    }
}
