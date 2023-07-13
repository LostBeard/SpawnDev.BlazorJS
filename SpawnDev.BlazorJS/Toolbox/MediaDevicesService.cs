using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.JSObjects;
using System.Dynamic;
using System.Text.RegularExpressions;

namespace SpawnDev.BlazorJS.Toolbox
{
    public static class ListMediaDeviceInfoExtensions
    {
        public static Dictionary<string, List<MediaDeviceInfo>> GetAudioVideoInputDevices(this List<MediaDeviceInfo> _this, string requireInputType = "")
        {
            var list = _this.Where(o => o.Kind == MediaDevices.AUDIO_INPUT || o.Kind == MediaDevices.VIDEO_INPUT).GroupBy(o => o.GroupId).ToDictionary(o => o.Key, o => o.ToList());
            if (!string.IsNullOrEmpty(requireInputType)) list = list.Where(o => o.Value.GetInputType() == requireInputType).ToDictionary(o => o.Key, o => o.Value);
            return list;
        }

        public static List<MediaDeviceInfo> GetVideoInputs(this List<MediaDeviceInfo> _this)
        {
            return _this.Where(o => o.Kind == MediaDevices.VIDEO_INPUT).ToList();
        }

        public static List<MediaDeviceInfo> GetAudioInputs(this List<MediaDeviceInfo> _this)
        {
            return _this.Where(o => o.Kind == MediaDevices.AUDIO_INPUT).ToList();
        }

        public static List<MediaDeviceInfo> GetAudioOutputs(this List<MediaDeviceInfo> _this)
        {
            return _this.Where(o => o.Kind == MediaDevices.AUDIO_OUTPUT).ToList();
        }

        public static string GetGroupInputType(this List<MediaDeviceInfo> _this, string groupId)
        {
            var groupDevices = _this.Where(o => o.GroupId == groupId).ToList();
            return groupDevices.GetInputType();
        }

        public static string GetInputType(this List<MediaDeviceInfo> _this)
        {
            if (_this.Count == 0) return "";
            var hasAudioInput = _this.Any(o => o.Kind == MediaDevices.AUDIO_INPUT);
            var hasVideoInput = _this.Any(o => o.Kind == MediaDevices.VIDEO_INPUT);
            if (hasAudioInput && hasVideoInput) return "audiovideoinput";
            else if (hasVideoInput) return "videoinput";
            else if (hasAudioInput) return "audioinput";
            return "";
        }
    }
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

        public MediaDevicesService()
        {
            MediaShareSupported = MediaDevices.Supported;
            DesktopShareSupported = MediaDevices.GetDisplayMediaSupported;
            Supported = MediaShareSupported || DesktopShareSupported;
            if (!Supported) return;
            MediaDevices = BlazorJSRuntime.JS.Get<MediaDevices>("navigator.mediaDevices");
            MediaDevices.OnDeviceChange += MediaDevices_OnDeviceChange;
        }

        public async Task InitAsync()
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
        public async Task<bool> UpdateDeviceList(bool allowAsk = false)
        {
            if (!Supported) return false;
            var ret = !await MediaDevices.AreDevicesHidden();
            AreDevicesHidden = !ret;
            await _UpdateDeviceList();
            if (ret || !allowAsk) return ret;
            dynamic constraints = new ExpandoObject();
            constraints.audio = true;
            constraints.video = true;
            try
            {
                using var stream = await MediaDevices.GetUserMedia(constraints);
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
            ret = !await MediaDevices.AreDevicesHidden();
            AreDevicesHidden = !ret;
            return ret;
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
