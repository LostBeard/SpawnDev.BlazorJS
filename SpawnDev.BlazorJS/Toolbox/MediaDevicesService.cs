using SpawnDev.BlazorJS.JSObjects;
using System.Dynamic;

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
            AreDevicesHidden = await MediaDevices.AreDevicesHidden();
            await _UpdateDeviceList();
            if (!AreDevicesHidden || !allowAsk) return !AreDevicesHidden;
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
