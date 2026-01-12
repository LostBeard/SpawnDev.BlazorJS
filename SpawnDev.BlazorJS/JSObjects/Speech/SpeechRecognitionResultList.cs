using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SpeechRecognitionResultList interface of the Web Speech API represents a list of SpeechRecognitionResult objects, or a single one, if results are being returned in standard mode.
    /// </summary>
    public class SpeechRecognitionResultList : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public SpeechRecognitionResultList(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns the number of SpeechRecognitionResult objects contained in the list.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");

        /// <summary>
        /// Indexer for accessing SpeechRecognitionResult objects.
        /// </summary>
        public SpeechRecognitionResult this[int index] => JSRef!.Call<SpeechRecognitionResult>("item", index);
    }
}
