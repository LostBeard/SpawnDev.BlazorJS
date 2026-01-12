using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SpeechRecognitionResult interface of the Web Speech API represents a single recognition match, which may contain multiple SpeechRecognitionAlternative objects.
    /// </summary>
    public class SpeechRecognitionResult : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public SpeechRecognitionResult(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// A boolean value that states whether this result is final (true) or interim (false).
        /// </summary>
        public bool IsFinal => JSRef!.Get<bool>("isFinal");

        /// <summary>
        /// Returns the number of SpeechRecognitionAlternative objects contained in this result.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");

        /// <summary>
        /// Indexer for accessing SpeechRecognitionAlternative objects.
        /// </summary>
        public SpeechRecognitionAlternative this[int index] => JSRef!.Call<SpeechRecognitionAlternative>("item", index);
    }
}
