using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class MediaStream : EventTarget
    {
        public bool Active => JSRef.Get<bool>("active");
        public bool Ended => JSRef.Get<bool>("ended");
        public string Id => JSRef.Get<string>("id");

        public MediaStream(IJSInProcessObjectReference _ref) : base(_ref) { }

        public JSEventCallback OnEnded { get => new JSEventCallback(o => AddEventListener("ended", o), o => RemoveEventListener("ended", o)); set { } }
        public JSEventCallback OnAddTrack { get => new JSEventCallback(o => AddEventListener("addtrack", o), o => RemoveEventListener("addtrack", o)); set { } }
        public JSEventCallback OnRemoveTrack { get => new JSEventCallback(o => AddEventListener("removetrack", o), o => RemoveEventListener("removetrack", o)); set { } }
        public JSEventCallback OnActive { get => new JSEventCallback(o => AddEventListener("active", o), o => RemoveEventListener("active", o)); set { } }
        public JSEventCallback OnInactive { get => new JSEventCallback(o => AddEventListener("inactive", o), o => RemoveEventListener("inactive", o)); set { } }

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
        public MediaStreamTrack GetFirstVideoTrack()
        {
            var tracks = GetVideoTracks();
            for (var i = 1; i < tracks.Length; i++) tracks[i].Dispose();
            return tracks.Length == 0 ? null : tracks[0];
        }

        public MediaStreamVideoTrackSettings GetFirstVideoTrackSettings()
        {
            using var track = GetFirstVideoTrack();
#if DEBUG && false
            Console.WriteLine(track == null ? "track == null" : "track != null");
            var w = IJSObject.GetWindow();
            w._ref.Set("__vtrack1", track);
            var settings = track._this.getSettings<IJSObject>();
            w._ref.Set("__vsettings", settings);
#endif
            return track == null ? null : track.GetSettings<MediaStreamVideoTrackSettings>();
        }

        public MediaStreamAudioTrackSettings GetFirstAudioTrackSettings()
        {
            using var track = GetFirstAudioTrack();
            return track == null ? null : track.GetSettings<MediaStreamAudioTrackSettings>();
        }

        public MediaStreamTrack GetFirstAudioTrack()
        {
            var tracks = GetAudioTracks();
            for (var i = 1; i < tracks.Length; i++) tracks[i].Dispose();
            return tracks.Length == 0 ? null : tracks[0];
        }

        //

        public void StopAllTracks()
        {
            var tracks = GetTracks();
            foreach (var t in tracks)
            {
                t.Stop();
                t.Dispose();
            }
        }

        public void RemoveAllTracks(bool stopTracks = true)
        {
            var tracks = GetTracks();
            foreach (var t in tracks)
            {
                if (stopTracks) t.Stop();
                RemoveTrack(t);
                t.Dispose();
            }
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
