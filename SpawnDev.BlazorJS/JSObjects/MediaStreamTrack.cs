using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<MediaStreamTrack>))]
    public class MediaStreamTrack : JSObject
    {
        public bool Active => _ref.Get<bool>("active");
        public bool Enabled => _ref.Get<bool>("enabled");
        public bool Muted => _ref.Get<bool>("muted");
        public string Id => _ref.Get<string>("id");
        public string Kind => _ref.Get<string>("kind");
        public string ContentHint => _ref.Get<string>("contentHint");
        public string Label => _ref.Get<string>("label");
        public string ReadyState => _ref.Get<string>("readyState");

        public MediaStreamTrack(IJSInProcessObjectReference _ref) : base(_ref) { }

        public T GetSettings<T>() where T : MediaStreamTrackSettings
        {
            return _ref.Call<T>("getSettings");
        }
        public MediaStreamTrackSettings GetSettings()
        {
            return _ref.Call<MediaStreamTrackSettings>("getSettings");
        }

        public void GetCapabilities()
        {

        }

        public void GetConstraints()
        {

        }
        public void Stop()
        {
            _ref.CallVoid("stop");
        }
    }
}
