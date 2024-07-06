using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaStream interface of the Media Capture and Streams API represents a stream of media content. A stream consists of several tracks, such as video or audio tracks. Each track is specified as an instance of MediaStreamTrack.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaStream
    /// </summary>
    public class MediaStream : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MediaStream(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance of MediaStream
        /// </summary>
        public MediaStream() : base(JS.New(nameof(MediaStream))) { }
        /// <summary>
        /// Creates a new instance of MediaStream
        /// </summary>
        /// <param name="stream">A different MediaStream object whose tracks are added to the newly-created stream automatically. The tracks are not removed from the original stream, so they're shared by the two streams.</param>
        public MediaStream(MediaStream stream) : base(JS.New(nameof(MediaStream), stream)) { }
        /// <summary>
        /// Creates a new instance of MediaStream
        /// </summary>
        /// <param name="tracks">An Array of MediaStreamTrack objects, one for each track to add to the stream.</param>
        public MediaStream(IEnumerable<MediaStreamTrack> tracks) : base(JS.New(nameof(MediaStream), tracks)) { }
        /// <summary>
        /// Creates a new instance of MediaStream
        /// </summary>
        /// <param name="tracks">An Array of MediaStreamTrack objects, one for each track to add to the stream.</param>
        public MediaStream(Array<MediaStreamTrack> tracks) : base(JS.New(nameof(MediaStream), tracks)) { }
        /// <summary>
        /// The active read-only property of the MediaStream interface returns a Boolean value which is true if the stream is currently active; otherwise, it returns false. A stream is considered active if at least one of its MediaStreamTracks does not have its property MediaStreamTrack.readyState set to ended. Once every track has ended, the stream's active property becomes false.
        /// </summary>
        public bool Active => JSRef!.Get<bool>("active");
        /// <summary>
        /// The MediaStream.id read-only property is a string containing 36 characters denoting a unique identifier (GUID) for the object.
        /// </summary>
        public string Id => JSRef!.Get<string>("id");
        /// <summary>
        /// The addtrack event is fired when a new MediaStreamTrack object has been added to a MediaStream.
        /// </summary>
        public JSEventCallback<MediaStreamTrackEvent> OnAddTrack { get => new JSEventCallback<MediaStreamTrackEvent>("addtrack", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The removetrack event is fired when a new MediaStreamTrack object has been removed from a MediaStream.
        /// </summary>
        public JSEventCallback<MediaStreamTrackEvent> OnRemoveTrack { get => new JSEventCallback<MediaStreamTrackEvent>("removetrack", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Removes the MediaStreamTrack given as argument. If the track is not part of the MediaStream object, nothing happens.
        /// </summary>
        /// <param name="track"></param>
        public void RemoveTrack(MediaStreamTrack track) => JSRef!.CallVoid("removeTrack", track);
        /// <summary>
        /// Stores a copy of the MediaStreamTrack given as argument. If the track has already been added to the MediaStream object, nothing happens.
        /// </summary>
        /// <param name="track"></param>
        public void AddTrack(MediaStreamTrack track) => JSRef!.CallVoid("addTrack", track);
        /// <summary>
        /// Returns a clone of the MediaStream object. The clone will, however, have a unique value for id.
        /// </summary>
        /// <returns></returns>
        public MediaStream Clone() => JSRef!.Call<MediaStream>("clone");
        /// <summary>
        /// Returns the track whose ID corresponds to the one given in parameters, trackid. If no parameter is given, or if no track with that ID does exist, it returns null. If several tracks have the same ID, it returns the first one.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MediaStreamTrack? GetTrackById(string id) => JSRef!.Call<MediaStreamTrack?>("getTrackById", id);
        /// <summary>
        /// Returns the total number of tracks
        /// </summary>
        /// <returns></returns>
        public int GetTracksLength()
        {
            using var tmp = GetTracks();
            return tmp.Length;
        }
        /// <summary>
        /// Returns a list of all MediaStreamTrack objects stored in the MediaStream object, regardless of the value of the kind attribute. The order is not defined, and may not only vary from one browser to another, but also from one call to another.
        /// </summary>
        /// <returns></returns>
        public Array<MediaStreamTrack> GetTracks() => JSRef!.Call<Array<MediaStreamTrack>>("getTracks");
        /// <summary>
        /// Returns a list of the MediaStreamTrack objects stored in the MediaStream object that have their kind attribute set to "video". The order is not defined, and may not only vary from one browser to another, but also from one call to another.
        /// </summary>
        /// <returns></returns>
        public Array<MediaStreamTrack> GetVideoTracks() => JSRef!.Call<Array<MediaStreamTrack>>("getVideoTracks");
        /// <summary>
        /// Returns a list of the MediaStreamTrack objects stored in the MediaStream object that have their kind attribute set to audio. The order is not defined, and may not only vary from one browser to another, but also from one call to another.
        /// </summary>
        /// <returns></returns>
        public Array<MediaStreamTrack> GetAudioTracks() => JSRef!.Call<Array<MediaStreamTrack>>("getAudioTracks");
        /// <summary>
        /// Returns the first video track or null
        /// </summary>
        /// <returns></returns>
        public MediaStreamTrack? GetFirstVideoTrack()
        {
            using var tracks = GetVideoTracks();
            return tracks.FirstOrDefault();
        }
        /// <summary>
        /// Returns the first video track settings
        /// </summary>
        /// <returns></returns>
        public MediaTrackSettings? GetFirstVideoTrackSettings()
        {
            using var track = GetFirstVideoTrack();
            return track?.GetSettings();
        }
        /// <summary>
        /// Returns the first audio track settings
        /// </summary>
        /// <returns></returns>
        public MediaTrackSettings? GetFirstAudioTrackSettings()
        {
            using var track = GetFirstAudioTrack();
            return track?.GetSettings();
        }
        /// <summary>
        /// Returns the first audio track or null
        /// </summary>
        /// <returns></returns>
        public MediaStreamTrack? GetFirstAudioTrack()
        {
            using var tracks = GetAudioTracks();
            return tracks.FirstOrDefault();
        }
        /// <summary>
        /// Calls stop on all tracks
        /// </summary>
        public void StopAllTracks()
        {
            using var tracks = GetTracks();
            tracks.ToArray().UsingEach(o => o.Stop());
        }
        /// <summary>
        /// Removes all tracks and optionally stops them first (default)
        /// </summary>
        /// <param name="stopTracks">If true, stop() will be called on the track before removing</param>
        public void RemoveAllTracks(bool stopTracks = true)
        {
            using var tracks = GetTracks();
            tracks.ToArray().UsingEach(o =>
            {
                if (stopTracks) o.Stop();
                RemoveTrack(o);
            });
        }
        /// <summary>
        /// Removes all video tracks and optionally stops them first (default)
        /// </summary>
        /// <param name="stopTracks">If true, stop() will be called on the track before removing</param>
        public void RemoveAllVideoTracks(bool stopTracks = true)
        {
            using var tracks = GetVideoTracks();
            tracks.ToArray().UsingEach(o =>
            {
                if (stopTracks) o.Stop();
                RemoveTrack(o);
            });
        }
        /// <summary>
        /// Removes all audio tracks and optionally stops them first (default)
        /// </summary>
        /// <param name="stopTracks">If true, stop() will be called on the track before removing</param>
        public void RemoveAllAudioTracks(bool stopTracks = true)
        {
            using var tracks = GetAudioTracks();
            tracks.ToArray().UsingEach(o =>
            {
                if (stopTracks) o.Stop();
                RemoveTrack(o);
            });
        }
    }
}