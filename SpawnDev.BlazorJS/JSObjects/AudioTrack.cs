using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AudioTrack interface represents a single audio track from one of the HTML media elements, &lt;audio> or &lt;video>.<br/>
    /// The most common use for accessing an AudioTrack object is to toggle its enabled property in order to mute and unmute the track.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioTrack
    /// </summary>
    public class AudioTrack : MediaTrack
    {
        /// <inheritdoc/>
        public AudioTrack(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A Boolean value which controls whether or not the audio track's sound is enabled. Setting this value to false mutes the track's audio.
        /// </summary>
        public bool Enabled  { get => JSRef!.Get<bool>("enabled"); set => JSRef!.Set("enabled", value); }
        /// <summary>
        /// A string specifying the category into which the track falls. For example, the main audio track would have a kind of "main".
        /// </summary>
        public string Kind => JSRef!.Get<string>("kind");
        /// <summary>
        /// A string providing a human-readable label for the track. For example, an audio commentary track for a movie might have a label of "Commentary with director Christopher Nolan and actors Leonardo DiCaprio and Elliot Page." This string is empty if no label is provided.
        /// </summary>
        public string Label => JSRef!.Get<string>("label");
        /// <summary>
        /// A string specifying the audio track's primary language, or an empty string if unknown. The language is specified as a BCP 47 language tag, such as "en-US" or "pt-BR".
        /// </summary>
        public string Language => JSRef!.Get<string>("language");
        /// <summary>
        /// The SourceBuffer that created the track. Returns null if the track was not created by a SourceBuffer or the SourceBuffer has been removed from the MediaSource.sourceBuffers attribute of its parent media source.
        /// </summary>
        public SourceBuffer? SourceBuffer => JSRef!.Get<SourceBuffer?>("sourceBuffer");
    }
}