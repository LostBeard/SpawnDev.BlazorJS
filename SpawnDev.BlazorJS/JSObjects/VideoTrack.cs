using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/VideoTrack
    /// </summary>
    public class VideoTrack : MediaTrack
    {
        /// <inheritdoc/>
        public VideoTrack(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A Boolean value which controls whether or not the video track is active. Only a single video track can be active at any given time, so setting this property to true for one track while another track is active will make that other track inactive.
        /// </summary>
        public bool Selected { get => JSRef!.Get<bool>("selected"); set => JSRef!.Set("selected", value); }
        /// <summary>
        /// A string which uniquely identifies the track within the media. This ID can be used to locate a specific track within a video track list by calling VideoTrackList.getTrackById(). The ID can also be used as the fragment part of the URL if the media supports seeking by media fragment per the Media Fragments URI specification.
        /// </summary>
        public string Id => JSRef!.Get<string>("id");
        /// <summary>
        /// A string specifying the category into which the track falls. For example, the main video track would have a kind of "main".
        /// </summary>
        public string Kind => JSRef!.Get<string>("kind");
        /// <summary>
        /// A string providing a human-readable label for the track. For example, a track whose kind is "sign" might have a label of "A sign-language interpretation". This string is empty if no label is provided.
        /// </summary>
        public string Label => JSRef!.Get<string>("label");
        /// <summary>
        /// A string specifying the video track's primary language, or an empty string if unknown. The language is specified as a BCP 47 language tag such as "en-US" or "pt-BR".
        /// </summary>
        public string Language => JSRef!.Get<string>("language");
        /// <summary>
        /// The SourceBuffer that created the track. Returns null if the track was not created by a SourceBuffer or the SourceBuffer has been removed from the MediaSource.sourceBuffers attribute of its parent media source.
        /// </summary>
        public SourceBuffer? SourceBuffer => JSRef!.Get<SourceBuffer?>("sourceBuffer");
    }
}