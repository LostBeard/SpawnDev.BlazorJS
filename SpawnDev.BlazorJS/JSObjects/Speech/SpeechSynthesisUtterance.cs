using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SpeechSynthesisUtterance interface of the Web Speech API represents a speech request. It contains the content the speech service should read and information about how to read it (e.g. language, pitch and volume.)
    /// </summary>
    public class SpeechSynthesisUtterance : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public SpeechSynthesisUtterance(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new SpeechSynthesisUtterance.
        /// </summary>
        public SpeechSynthesisUtterance(string text) : base(JS.New(nameof(SpeechSynthesisUtterance), text)) { }

        /// <summary>
        /// Gets and sets the language of the utterance.
        /// </summary>
        public string Lang
        {
            get => JSRef!.Get<string>("lang");
            set => JSRef!.Set("lang", value);
        }

        /// <summary>
        /// Gets and sets the pitch at which the utterance will be spoken at.
        /// </summary>
        public float Pitch
        {
            get => JSRef!.Get<float>("pitch");
            set => JSRef!.Set("pitch", value);
        }

        /// <summary>
        /// Gets and sets the speed at which the utterance will be spoken at.
        /// </summary>
        public float Rate
        {
            get => JSRef!.Get<float>("rate");
            set => JSRef!.Set("rate", value);
        }

        /// <summary>
        /// Gets and sets the text that will be synthesized when the utterance is spoken.
        /// </summary>
        public string Text
        {
            get => JSRef!.Get<string>("text");
            set => JSRef!.Set("text", value);
        }

        /// <summary>
        /// Gets and sets the voice that will be used to speak the utterance.
        /// </summary>
        public SpeechSynthesisVoice Voice
        {
            get => JSRef!.Get<SpeechSynthesisVoice>("voice");
            set => JSRef!.Set("voice", value);
        }

        /// <summary>
        /// Gets and sets the volume that the utterance will be spoken at.
        /// </summary>
        public float Volume
        {
            get => JSRef!.Get<float>("volume");
            set => JSRef!.Set("volume", value);
        }

        /// <summary>
        /// Fired when the spoken utterance reaches a word or sentence boundary.
        /// </summary>
        public ActionEvent<SpeechSynthesisEvent> OnBoundary { get => new ActionEvent<SpeechSynthesisEvent>("boundary", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the utterance has finished being spoken.
        /// </summary>
        public ActionEvent<SpeechSynthesisEvent> OnEnd { get => new ActionEvent<SpeechSynthesisEvent>("end", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when an error occurs that prevents the utterance from being spoken.
        /// </summary>
        public ActionEvent<SpeechSynthesisEvent> OnError { get => new ActionEvent<SpeechSynthesisEvent>("error", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the spoken utterance reaches a named SSML "mark" tag.
        /// </summary>
        public ActionEvent<SpeechSynthesisEvent> OnMark { get => new ActionEvent<SpeechSynthesisEvent>("mark", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the utterance is paused part way through.
        /// </summary>
        public ActionEvent<SpeechSynthesisEvent> OnPause { get => new ActionEvent<SpeechSynthesisEvent>("pause", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when a paused utterance is resumed.
        /// </summary>
        public ActionEvent<SpeechSynthesisEvent> OnResume { get => new ActionEvent<SpeechSynthesisEvent>("resume", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the utterance has begun to be spoken.
        /// </summary>
        public ActionEvent<SpeechSynthesisEvent> OnStart { get => new ActionEvent<SpeechSynthesisEvent>("start", AddEventListener, RemoveEventListener); set { } }
    }
}
