using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaMetadata interface of the Media Session API allows a web page to provide rich media metadata for display in a platform UI.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaMetadata
    /// </summary>
    public class MediaMetadata : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MediaMetadata(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new MediaMetadata object.
        /// </summary>
        /// <param name="init"></param>
        public MediaMetadata(MediaMetadataInit init) : base(JS.New(nameof(MediaMetadata), init)) { }
        /// <summary>
        /// The title of the media to be played.
        /// </summary>
        public string Title { get => JSRef!.Get<string>("title"); set => JSRef!.Set("title", value); }
        /// <summary>
        /// The name of the artist, group, creator, etc., of the media to be played.
        /// </summary>
        public string Artist { get => JSRef!.Get<string>("artist"); set => JSRef!.Set("artist", value); }
        /// <summary>
        /// The name of the album or collection containing the media to be played.
        /// </summary>
        public string Album { get => JSRef!.Get<string>("album"); set => JSRef!.Set("album", value); }
        /// <summary>
        /// An array of MediaImage objects, each of which contains information about an image associated with the media.
        /// </summary>
        public MediaImage[] Artwork { get => JSRef!.Get<MediaImage[]>("artwork"); set => JSRef!.Set("artwork", value); }
    }
}
