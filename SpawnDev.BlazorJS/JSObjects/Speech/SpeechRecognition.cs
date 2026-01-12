using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SpeechRecognition interface of the Web Speech API is the controller interface for the recognition service; this also handles the SpeechRecognitionEvent sent from the recognition service.
    /// </summary>
    public class SpeechRecognition : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public SpeechRecognition(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new SpeechRecognition.
        /// </summary>
        public SpeechRecognition() : base(JS.New(nameof(SpeechRecognition))) { }

        /// <summary>
        /// Returns and sets a collection of SpeechGrammar objects that represent the grammars that will be understood by the current SpeechRecognition.
        /// </summary>
        public SpeechGrammarList Grammars
        {
            get => JSRef!.Get<SpeechGrammarList>("grammars");
            set => JSRef!.Set("grammars", value);
        }

        /// <summary>
        /// Returns and sets the language of the current SpeechRecognition. If not specified, this defaults to the HTML lang attribute value, or the user agent's language setting if that isn't set either.
        /// </summary>
        public string Lang
        {
            get => JSRef!.Get<string>("lang");
            set => JSRef!.Set("lang", value);
        }

        /// <summary>
        /// Returns and sets whether continuous results are returned for each recognition, or only a single result. Defaults to false (single result).
        /// </summary>
        public bool Continuous
        {
            get => JSRef!.Get<bool>("continuous");
            set => JSRef!.Set("continuous", value);
        }

        /// <summary>
        /// Returns and sets whether interim results should be returned (true) or not (false). Interim results are results that are not yet final (e.g. the SpeechRecognitionResult.isFinal property is false).
        /// </summary>
        public bool InterimResults
        {
            get => JSRef!.Get<bool>("interimResults");
            set => JSRef!.Set("interimResults", value);
        }

        /// <summary>
        /// Returns and sets the maximum number of SpeechRecognitionAlternative objects provided per result. The default value is 1.
        /// </summary>
        public int MaxAlternatives
        {
            get => JSRef!.Get<int>("maxAlternatives");
            set => JSRef!.Set("maxAlternatives", value);
        }

        /// <summary>
        /// Starts the speech recognition service listening to incoming audio with intent to recognize grammars associated with the current SpeechRecognition.
        /// </summary>
        public void Start() => JSRef!.CallVoid("start");

        /// <summary>
        /// Stops the speech recognition service from listening to incoming audio, and attempts to return a SpeechRecognitionResult using the audio captured so far.
        /// </summary>
        public void Stop() => JSRef!.CallVoid("stop");

        /// <summary>
        /// Stops the speech recognition service from listening to incoming audio, and doesn't attempt to return a SpeechRecognitionResult.
        /// </summary>
        public void Abort() => JSRef!.CallVoid("abort");

        /// <summary>
        /// Fired when the speech recognition service has detached from a stream or some other reason.
        /// </summary>
        public JSEventCallback<Event> OnAudioEnd { get => new JSEventCallback<Event>("audioend", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the user agent has started to capture audio.
        /// </summary>
        public JSEventCallback<Event> OnAudioStart { get => new JSEventCallback<Event>("audiostart", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the speech recognition service has finished listening to incoming audio.
        /// </summary>
        public JSEventCallback<Event> OnEnd { get => new JSEventCallback<Event>("end", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when a speech recognition error occurs.
        /// </summary>
        public JSEventCallback<SpeechRecognitionErrorEvent> OnError { get => new JSEventCallback<SpeechRecognitionErrorEvent>("error", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the speech recognition service returns a final result with no significant recognition. This may involve some degree of recognition, which doesn't meet or exceed the confidence threshold.
        /// </summary>
        public JSEventCallback<SpeechRecognitionEvent> OnNoMatch { get => new JSEventCallback<SpeechRecognitionEvent>("nomatch", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the speech recognition service returns a result — a word or phrase has been positively recognized and this has been communicated back to the app.
        /// </summary>
        public JSEventCallback<SpeechRecognitionEvent> OnResult { get => new JSEventCallback<SpeechRecognitionEvent>("result", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the sound that is being recognized has stopped being detected.
        /// </summary>
        public JSEventCallback<Event> OnSoundEnd { get => new JSEventCallback<Event>("soundend", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when any sound — recognisable speech or not — has been detected.
        /// </summary>
        public JSEventCallback<Event> OnSoundStart { get => new JSEventCallback<Event>("soundstart", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the speech recognition service has stopped being detected.
        /// </summary>
        public JSEventCallback<Event> OnSpeechEnd { get => new JSEventCallback<Event>("speechend", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when sound that is recognized by the speech recognition service as speech has been detected.
        /// </summary>
        public JSEventCallback<Event> OnSpeechStart { get => new JSEventCallback<Event>("speechstart", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the speech recognition service has begun listening to incoming audio with intent to recognize grammars associated with the current SpeechRecognition.
        /// </summary>
        public JSEventCallback<Event> OnStart { get => new JSEventCallback<Event>("start", AddEventListener, RemoveEventListener); set { } }
    }
}
