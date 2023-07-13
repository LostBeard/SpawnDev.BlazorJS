using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class MediaStream : EventTarget
    {
        /// <summary>
        /// The active read-only property of the MediaStream interface returns a Boolean value which is true if the stream is currently active; otherwise, it returns false. A stream is considered active if at least one of its MediaStreamTracks does not have its property MediaStreamTrack.readyState set to ended. Once every track has ended, the stream's active property becomes false.
        /// </summary>
        public bool Active => JSRef.Get<bool>("active");
        /// <summary>
        /// The MediaStream.id read-only property is a string containing 36 characters denoting a unique identifier (GUID) for the object.
        /// </summary>
        public string Id => JSRef.Get<string>("id");

        public MediaStream(IJSInProcessObjectReference _ref) : base(_ref) { }
        public MediaStream() : base(JS.New(nameof(MediaStream))) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream">A different MediaStream object whose tracks are added to the newly-created stream automatically. The tracks are not removed from the original stream, so they're shared by the two streams.</param>
        public MediaStream(MediaStream stream) : base(JS.New(nameof(MediaStream), stream)) { }
        /// <summary>
        /// An Array of MediaStreamTrack objects, one for each track to add to the stream.
        /// </summary>
        /// <param name="tracks"></param>
        public MediaStream(MediaStreamTrack[] tracks) : base(JS.New(nameof(MediaStream), tracks)) { }

        public JSEventCallback OnAddTrack { get => new JSEventCallback(o => AddEventListener("addtrack", o), o => RemoveEventListener("addtrack", o)); set { } }
        public JSEventCallback OnRemoveTrack { get => new JSEventCallback(o => AddEventListener("removetrack", o), o => RemoveEventListener("removetrack", o)); set { } }

        // Not sure why I had these here... According to MDN they do not exist.
        //public JSEventCallback OnActive { get => new JSEventCallback(o => AddEventListener("active", o), o => RemoveEventListener("active", o)); set { } }
        //public JSEventCallback OnInactive { get => new JSEventCallback(o => AddEventListener("inactive", o), o => RemoveEventListener("inactive", o)); set { } }
        //public JSEventCallback OnEnded { get => new JSEventCallback(o => AddEventListener("ended", o), o => RemoveEventListener("ended", o)); set { } }

        public void RemoveTrack(MediaStreamTrack track) => JSRef.CallVoid("removeTrack", track);
        public void AddTrack(MediaStreamTrack track) => JSRef.CallVoid("addTrack", track);
        public MediaStream Clone() => JSRef.Call<MediaStream>("clone");
        public MediaStreamTrack GetTrackById(string id) => JSRef.Call<MediaStreamTrack>("getTrackById", id);
        public int GetTracksLength()
        {
            using var tmp = JSRef.Get<IJSInProcessObjectReference>("getTracks");
            return tmp.Get<int>("length");
        }
        public MediaStreamTrack[] GetTracks() => JSRef.Call<MediaStreamTrack[]>("getTracks");
        public MediaStreamTrack[] GetVideoTracks() => JSRef.Call<MediaStreamTrack[]>("getVideoTracks");
        public MediaStreamTrack[] GetAudioTracks() => JSRef.Call<MediaStreamTrack[]>("getAudioTracks");
        public MediaStreamTrack? GetFirstVideoTrack()
        {
            var tracks = GetVideoTracks();
            for (var i = 1; i < tracks.Length; i++) tracks[i].Dispose();
            return tracks.FirstOrDefault();
        }

        public MediaStreamVideoTrackSettings? GetFirstVideoTrackSettings()
        {
            using var track = GetFirstVideoTrack();
            return track == null ? null : track.GetSettings<MediaStreamVideoTrackSettings>();
        }

        public MediaStreamAudioTrackSettings? GetFirstAudioTrackSettings()
        {
            using var track = GetFirstAudioTrack();
            return track == null ? null : track.GetSettings<MediaStreamAudioTrackSettings>();
        }

        public MediaStreamTrack? GetFirstAudioTrack()
        {
            var tracks = GetAudioTracks();
            for (var i = 1; i < tracks.Length; i++) tracks[i].Dispose();
            return tracks.Length == 0 ? null : tracks[0];
        }

        //

        public void StopAllTracks()
        {
            var tracks = GetTracks();
            foreach (var t in tracks) t.Stop();
            tracks.DisposeAll();
        }

        public void RemoveAllTracks(bool stopTracks = true)
        {
            var tracks = GetTracks();
            foreach (var t in tracks)
            {
                if (stopTracks) t.Stop();
                RemoveTrack(t);
            }
            tracks.DisposeAll();
        }

        public void RemoveAllVideoTracks(bool stopTracks = true)
        {
            var tracks = GetVideoTracks();
            foreach (var t in tracks)
            {
                if (stopTracks) t.Stop();
                RemoveTrack(t);
                t.Dispose();
            }
        }

        public void RemoveAllAudioTracks(bool stopTracks = true)
        {
            var tracks = GetAudioTracks();
            foreach (var t in tracks)
            {
                if (stopTracks) t.Stop();
                RemoveTrack(t);
                t.Dispose();
            }
        }
    }
}
