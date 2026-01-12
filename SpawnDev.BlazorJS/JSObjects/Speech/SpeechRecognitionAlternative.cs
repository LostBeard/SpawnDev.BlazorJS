using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SpeechRecognitionAlternative interface of the Web Speech API represents a single recognition alternative.
    /// </summary>
    public class SpeechRecognitionAlternative : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public SpeechRecognitionAlternative(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// A string containing the transcript of the recognized speech.
        /// </summary>
        public string Transcript => JSRef!.Get<string>("transcript");

        /// <summary>
        /// A numeric value representing the confidence of the recognition.
        /// </summary>
        public float Confidence => JSRef!.Get<float>("confidence");
    }
}
