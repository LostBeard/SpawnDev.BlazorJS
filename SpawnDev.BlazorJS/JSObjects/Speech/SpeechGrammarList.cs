using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SpeechGrammarList interface of the Web Speech API represents a list of SpeechGrammar objects.
    /// </summary>
    public class SpeechGrammarList : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public SpeechGrammarList(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new SpeechGrammarList.
        /// </summary>
        public SpeechGrammarList() : base(JS.New(nameof(SpeechGrammarList))) { }

        /// <summary>
        /// Returns the number of SpeechGrammar objects contained in the list.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");

        /// <summary>
        /// Takes a grammar and adds it to the SpeechGrammarList.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="weight"></param>
        public void AddFromString(string src, float weight = 1.0f) => JSRef!.CallVoid("addFromString", src, weight);

        /// <summary>
        /// Takes a grammar and adds it to the SpeechGrammarList.
        /// </summary>
        public void AddFromURI(string src, float weight = 1.0f) => JSRef!.CallVoid("addFromURI", src, weight);

        /// <summary>
        /// Indexer for accessing SpeechGrammar objects.
        /// </summary>
        public SpeechGrammar this[int index] => JSRef!.Call<SpeechGrammar>("item", index);
    }
}
