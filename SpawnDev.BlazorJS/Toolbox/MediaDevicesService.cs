using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    public class MediaDevicesService : IAsyncBackgroundService, IDisposable
    {
        public MediaDevices MediaDevices { get; private set; }
        public List<MediaDeviceInfo> DeviceInfos { get; private set; } = new List<MediaDeviceInfo>();
        public bool MediaShareSupported { get; private set; }
        public bool DesktopShareSupported { get; private set; }
        public bool Supported { get; private set; }
        public bool AreDevicesHidden { get; private set; } = true;

        public delegate void DeviceInfosChangedDelegate();
        public event DeviceInfosChangedDelegate OnDeviceInfosChanged;
        BlazorJSRuntime JS;
        public MediaDevicesService(BlazorJSRuntime js)
        {
            JS = js;
            MediaShareSupported = MediaDevices.Supported;
            DesktopShareSupported = MediaDevices.GetDisplayMediaSupported;
            Supported = MediaShareSupported || DesktopShareSupported;
            if (!Supported) return;
            MediaDevices = JS.Get<MediaDevices>("navigator.mediaDevices");
            MediaDevices.OnDeviceChange += MediaDevices_OnDeviceChange;
#if DEBUG && false
            DebugCodecCheck();
#endif
        }

        public static List<string> VideoTypes = new List<string> { "webm", "mp4", "x-matroska", "ogg" };
        public static List<string> VideoCodecs = new List<string> { "vp9", "vp9.0", "vp8", "vp8.0", "avc1", "av1", "h265", "h.265", "h264", "h.264", "mpeg", "theora" };
        public static List<string> AudioTypes = new List<string> { "webm", "mp3", "mp4", "x-matroska", "ogg", "wav" };
        public static List<string> AudioCodecs = new List<string> { "opus", "vorbis", "aac", "mpeg", "mp4a", "pcm" };

        void DebugCodecCheck()
        {
            MediaRecorderAudioVideoFormats.ForEach(Console.WriteLine);
            MediaRecorderAudioFormats.ForEach(Console.WriteLine);
            MediaRecorderVideoFormats.ForEach(Console.WriteLine);
        }

        public Lazy<List<string>> _MediaRecorderVideoFormats = new Lazy<List<string>>(() =>
        {
            var supportVideoFormats = new List<string>();
            foreach (var videoType in VideoTypes)
            {
                foreach (var videoCodec in VideoCodecs)
                {
                    var type = $"video/{videoType};codecs={videoCodec}";
                    var supported = MediaRecorder.IsTypeSupported(type);
                    if (supported)
                    {
                        supportVideoFormats.Add(type);
                    }
                }
            }
            return supportVideoFormats;
        });
        public List<string> MediaRecorderVideoFormats => _MediaRecorderVideoFormats.Value;

        public Lazy<List<string>> _MediaRecorderAudioFormats = new Lazy<List<string>>(() =>
        {
            var supportAudioFormats = new List<string>();
            foreach (var audioType in AudioTypes)
            {
                foreach (var audioCodec in AudioCodecs)
                {
                    var type = $"audio/{audioType};codecs={audioCodec}";
                    var supported = MediaRecorder.IsTypeSupported(type);
                    if (supported)
                    {
                        supportAudioFormats.Add(type);
                    }
                }
            }
            return supportAudioFormats;
        });
        public List<string> MediaRecorderAudioFormats => _MediaRecorderAudioFormats.Value;

        public Lazy<List<string>> _MediaRecorderAudioVideoFormats = new Lazy<List<string>>(() =>
        {
            var supportAudioVideoFormats = new List<string>();
            foreach (var videoType in VideoTypes)
            {
                foreach (var videoCodec in VideoCodecs)
                {
                    foreach (var audioCodec in AudioCodecs)
                    {
                        var type = $"video/{videoType};codecs={videoCodec},{audioCodec}";
                        var supported = MediaRecorder.IsTypeSupported(type);
                        if (supported)
                        {
                            supportAudioVideoFormats.Add(type);
                        }
                    }
                }
            }
            return supportAudioVideoFormats;
        });
        public List<string> MediaRecorderAudioVideoFormats => _MediaRecorderAudioVideoFormats.Value;
        public Task Ready => _Ready ??= InitAsync();
        private Task? _Ready = null;
        async Task InitAsync()
        {
            if (!Supported) return;
            await UpdateDeviceList();
        }

        void MediaDevices_OnDeviceChange()
        {
            _ = UpdateDeviceList();
        }

        public bool IsDisposed { get; private set; } = false;

        public void Dispose()
        {
            if (IsDisposed) return;
            IsDisposed = true;
            if (MediaDevices != null)
            {
                MediaDevices.OnDeviceChange -= MediaDevices_OnDeviceChange;
                MediaDevices.Dispose();
            }
        }

        public async Task<MediaStream?> GetMediaStream(string? videoDeviceId = null, string? audioDeviceId = null)
        {
            MediaStream? stream = null;
            try
            {
                stream = await MediaDevices.GetMediaDeviceStream(videoDeviceId, audioDeviceId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetMediaDeviceStream error: " + ex.Message);
            }
            return stream;
        }

        // https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getUserMedia
        public async Task<bool> UpdateDeviceList(bool allowAsk = false, bool video = true, bool audio = true)
        {
            if (!MediaShareSupported) return false;
            AreDevicesHidden = await MediaDevices.AreDevicesHidden();
            await _UpdateDeviceList();
            if (!AreDevicesHidden || !allowAsk) return !AreDevicesHidden;
            try
            {
                using var stream = await MediaDevices.GetUserMedia(video, audio);
                if (stream != null)
                {
                    stream.RemoveAllTracks();
                    stream.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION getUserMedia: {ex.Message}");
            }
            await _UpdateDeviceList();
            AreDevicesHidden = await MediaDevices.AreDevicesHidden();
            return !AreDevicesHidden;
        }

        async Task _UpdateDeviceList()
        {
            var t = DeviceInfos.Select(o => o.DeviceId).ToList();
            var countNow = DeviceInfos.Count;
            DeviceInfos = (await MediaDevices.EnumerateDevices()).Where(o => !string.IsNullOrEmpty(o.DeviceId)).ToList();
            var changed = countNow != DeviceInfos.Count;
            if (!changed)
            {
                foreach (var d in DeviceInfos)
                {
                    if (!t.Contains(d.DeviceId))
                    {
                        changed = true;
                        break;
                    }
                }
            }
            if (changed)
            {
                OnDeviceInfosChanged?.Invoke();
            }
        }
    }
}
