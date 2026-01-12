using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SpeechSynthesisVoice interface of the Web Speech API represents a voice that the system supports. Every SpeechSynthesisVoice has its own relative speech service including information about language, name and URI.
    /// </summary>
    public class SpeechSynthesisVoice : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public SpeechSynthesisVoice(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// A Boolean indicating whether the voice is the default voice for the current app language (true), or not (false).
        /// </summary>
        public bool Default => JSRef!.Get<bool>("default");

        /// <summary>
        /// Returns a BCP 47 language tag indicating the language of the voice.
        /// </summary>
        public string Lang => JSRef!.Get<string>("lang");

        /// <summary>
        /// Returns a Boolean indicating whether the voice is supplied by a local speech synthesizer service (true) or a remote speech synthesizer service (false).
        /// </summary>
        public bool LocalService => JSRef!.Get<bool>("localService");

        /// <summary>
        /// Returns a human-readable name that represents the voice.
        /// </summary>
        public string Name => JSRef!.Get<string>("name");

        /// <summary>
        /// Returns the type of URI and location of the speech synthesis service for this voice.
        /// </summary>
        public string VoiceURI => JSRef!.Get<string>("voiceURI");
    }
}
