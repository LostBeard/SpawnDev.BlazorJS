using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Provides access to navigator.mediaDevices
    /// </summary>
    public class MediaDevicesService : IAsyncBackgroundService, IDisposable
    {
        /// <summary>
        /// Returns when the service is ready
        /// </summary>
        public Task Ready => _Ready ??= InitAsync();
        private Task? _Ready = null;
        /// <summary>
        /// navigator.mediaDevices
        /// </summary>
        public MediaDevices? MediaDevices { get; private set; }
        /// <summary>
        /// Current list of MediaDeviceInfo
        /// </summary>
        public List<MediaDeviceInfo> DeviceInfos { get; private set; } = new List<MediaDeviceInfo>();
        /// <summary>
        /// Returns true if navigator.mediaDevices.enumerateDevices is supported
        /// </summary>
        public bool MediaShareSupported { get; private set; }
        /// <summary>
        /// Returns true if navigator.mediaDevices.getDisplayMedia is supported
        /// </summary>
        public bool DesktopShareSupported { get; private set; }
        /// <summary>
        /// Returns true if MediaDevices is supported
        /// </summary>
        public bool Supported { get; private set; }
        /// <summary>
        /// Returns true if a device without an empty label has not been seen
        /// </summary>
        public bool AreDevicesHidden { get; private set; } = true;
        /// <summary>
        /// Returns a list of supported known audio video types using MediaRecorder.IsTypeSupported
        /// </summary>
        public List<string> MediaRecorderAudioVideoFormats => _MediaRecorderAudioVideoFormats.Value;
        /// <summary>
        /// Known video types that will be tested
        /// </summary>
        public static List<string> VideoTypes { get; } = new List<string> { "webm", "mp4", "x-matroska", "ogg" };
        /// <summary>
        /// Known video codecs that will be tested
        /// </summary>
        public static List<string> VideoCodecs { get; } = new List<string> { "vp9", "vp9.0", "vp8", "vp8.0", "avc1", "av1", "h265", "h.265", "h264", "h.264", "mpeg", "theora" };
        /// <summary>
        /// Known audio types that will be tested
        /// </summary>
        public static List<string> AudioTypes { get; } = new List<string> { "webm", "mp3", "mp4", "x-matroska", "ogg", "wav" };
        /// <summary>
        /// Known audio codecs that will be tested
        /// </summary>
        public static List<string> AudioCodecs { get; } = new List<string> { "opus", "vorbis", "aac", "mpeg", "mp4a", "pcm" };
        /// <summary>
        /// Returns true if a device has been seen without an empty label
        /// </summary>
        public bool DevicesSeenUnhidden { get; private set; } = false;
        /// <summary>
        /// An event related to a MediaDeviceInfo
        /// </summary>
        /// <param name="mediaDeviceInfo"></param>
        public delegate void MediaDeviceInfoEvent(MediaDeviceInfo mediaDeviceInfo);
        /// <summary>
        /// Occurs when a MediaDeviceInfo has been removed
        /// </summary>
        public event MediaDeviceInfoEvent OnMediaDeviceFound = default!;
        /// <summary>
        /// Occurs when a MediaDeviceInfo has been added
        /// </summary>
        public event MediaDeviceInfoEvent OnMediaDeviceLost = default!;
        /// <summary>
        /// Occurs when the DeviceInfos, or an object it contains, has been modified
        /// </summary>
        public event Action OnDeviceInfosChanged = default!;
        private BlazorJSRuntime JS;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="js"></param>
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
        private async Task InitAsync()
        {
            if (!Supported) return;
            await UpdateDeviceList();
        }
        private void DebugCodecCheck()
        {
            MediaRecorderAudioVideoFormats.ForEach(Console.WriteLine);
            MediaRecorderAudioFormats.ForEach(Console.WriteLine);
            MediaRecorderVideoFormats.ForEach(Console.WriteLine);
        }
        private Lazy<List<string>> _MediaRecorderVideoFormats = new Lazy<List<string>>(() =>
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
        /// <summary>
        /// Returns a list of supported known video types using MediaRecorder.IsTypeSupported
        /// </summary>
        public List<string> MediaRecorderVideoFormats => _MediaRecorderVideoFormats.Value;
        private Lazy<List<string>> _MediaRecorderAudioFormats = new Lazy<List<string>>(() =>
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
        /// <summary>
        /// Returns a list of supported known audio types using MediaRecorder.IsTypeSupported
        /// </summary>
        public List<string> MediaRecorderAudioFormats => _MediaRecorderAudioFormats.Value;
        private Lazy<List<string>> _MediaRecorderAudioVideoFormats = new Lazy<List<string>>(() =>
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
        private void MediaDevices_OnDeviceChange()
        {
            _ = UpdateDeviceList();
        }
        /// <summary>
        /// Returns true if this instance has been disposed
        /// </summary>
        public bool IsDisposed { get; private set; } = false;
        /// <summary>
        /// Disposes resources
        /// </summary>
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
        /// <summary>
        /// Updates the device list, optionally allowing a prompt if necessary
        /// </summary>
        /// <param name="allowAsk"></param>
        /// <param name="video"></param>
        /// <param name="audio"></param>
        /// <returns></returns>
        public async Task<bool> UpdateDeviceList(bool allowAsk = false, bool video = true, bool audio = true)
        {
            if (MediaDevices == null) return false;
            var areDevicesHidden = await MediaDevices.AreDevicesHidden();
            try
            {
                if (!areDevicesHidden)
                {
                    await _UpdateDeviceList();
                    return !areDevicesHidden;
                }
                if (!DevicesSeenUnhidden && !allowAsk) return !areDevicesHidden;
                // getting device infos is going to require getting a MediaStream first
                try
                {
                    // Firefox has been seen reverting to basic mediadeviceinfo when no streams are active, even if one was allowed
                    // update infos now
                    using var stream = await MediaDevices.GetUserMedia(video, audio);
                    if (stream != null)
                    {
                        await _UpdateDeviceList();
                        DevicesSeenUnhidden = true;
                        areDevicesHidden = false;
                        stream.RemoveAllTracks();
                        stream.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"EXCEPTION getUserMedia: {ex.Message}");
                }
            }
            finally
            {
                AreDevicesHidden = areDevicesHidden;
            }
            return !areDevicesHidden;
        }
        private async Task _UpdateDeviceList()
        {
            if (MediaDevices == null) return;
            var oldDeviceInfos = DeviceInfos;
            var oldDeviceIds = DeviceInfos.Select(o => o.DeviceId).ToList();
            var newDeviceInfos = (await MediaDevices.EnumerateDevices()).Where(o => !string.IsNullOrEmpty(o.DeviceId) && !string.IsNullOrEmpty(o.Label)).ToList();
            var newDeviceIds = newDeviceInfos.Select(o => o.DeviceId).ToList();
            var lostDeviceIds = oldDeviceIds.Except(newDeviceIds);
            var foundDeviceIds = newDeviceIds.Except(oldDeviceIds);
            var lostDevices = DeviceInfos.Where(o => lostDeviceIds.Contains(o.DeviceId)).ToList();
            var foundDevices = newDeviceInfos.Where(o => foundDeviceIds.Contains(o.DeviceId)).ToList();
            DeviceInfos = newDeviceInfos;
            foreach (var item in lostDevices)
            {
                OnMediaDeviceLost?.Invoke(item);
            }
            foreach (var item in foundDevices)
            {
                OnMediaDeviceFound?.Invoke(item);
            }
            oldDeviceInfos.ToArray().DisposeAll();
            var changed = lostDevices.Count > 0 || foundDevices.Count > 0;
            if (changed)
            {
                OnDeviceInfosChanged?.Invoke();
            }
        }
    }
}
