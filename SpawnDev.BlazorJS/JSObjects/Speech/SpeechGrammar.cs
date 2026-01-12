using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SpeechGrammar interface of the Web Speech API represents a set of words or patterns of words that we want the recognition service to recognize.
    /// </summary>
    public class SpeechGrammar : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public SpeechGrammar(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Sets and returns a string containing the grammar from a text structure.
        /// </summary>
        public string Src
        {
            get => JSRef!.Get<string>("src");
            set => JSRef!.Set("src", value);
        }

        /// <summary>
        /// Sets and returns a float representing the weight of the grammar.
        /// </summary>
        public float Weight
        {
            get => JSRef!.Get<float>("weight");
            set => JSRef!.Set("weight", value);
        }
    }
}
