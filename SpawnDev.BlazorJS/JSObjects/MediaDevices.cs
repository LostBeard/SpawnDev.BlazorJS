using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System.Dynamic;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaDevices interface provides access to connected media input devices like cameras and microphones, as well as screen sharing. In essence, it lets you obtain access to any hardware source of media data.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices
    /// </summary>
    public class MediaDevices : EventTarget
    {
        public const string VIDEO_INPUT = "videoinput";
        public const string AUDIO_INPUT = "audioinput";
        public const string AUDIO_OUTPUT = "audiooutput";
        public MediaDevices(IJSInProcessObjectReference _ref) : base(_ref) { }
        public static bool Supported => !JS.IsUndefined("navigator.mediaDevices") && !JS.IsUndefined("navigator.mediaDevices.enumerateDevices");
        public static bool GetDisplayMediaSupported => !JS.IsUndefined("navigator.mediaDevices") && !JS.IsUndefined("navigator.mediaDevices.getDisplayMedia");

        public JSEventCallback OnDeviceChange { get => new JSEventCallback(o => AddEventListener("devicechange", o), o => RemoveEventListener("devicechange", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }

        public async Task<MediaStream?> GetMediaDeviceStream(MediaDeviceInfo? deviceVideo, MediaDeviceInfo? deviceAudio)
        {
            var deviceIdVideo = deviceVideo == null ? null : deviceVideo.DeviceId;
            var deviceIdAudio = deviceAudio == null ? null : deviceAudio.DeviceId;
            return await GetMediaDeviceStream(deviceIdVideo, deviceIdAudio);
        }

        public async Task<MediaStream?> GetUserMedia()
        {
            dynamic constraints = new ExpandoObject();
            constraints.video = true;
            constraints.audio = true;
            return await GetUserMedia(constraints); ;
        }

        public async Task<MediaStream?> GetMediaDeviceStream(string? deviceIdVideo, string? deviceIdAudio)
        {
            dynamic constraints = new ExpandoObject();
            if (!string.IsNullOrEmpty(deviceIdVideo))
            {
                constraints.video = new ExpandoObject();
                constraints.video.deviceId = new ExpandoObject();
                constraints.video.deviceId.exact = deviceIdVideo;
                //// get largest
                constraints.video.width = new ExpandoObject();//= 4096;
                constraints.video.width.ideal = 4096;
                constraints.video.height = new ExpandoObject();//= 2160;
                constraints.video.height.ideal = 2160;
            }
            else
            {
                constraints.video = false;
            }
            if (!string.IsNullOrEmpty(deviceIdAudio))
            {
                constraints.audio = new ExpandoObject();
                constraints.audio.deviceId = new ExpandoObject();
                constraints.audio.deviceId.exact = deviceIdAudio;
            }
            else
            {
                constraints.audio = false;
            }
            var stream = await GetUserMedia(constraints);
            return stream;
        }

        // https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getDisplayMedia
        // TODO
        public async Task<MediaStream?> GetDisplayMedia()
        {
            dynamic constraints = new ExpandoObject();
            MediaStream? stream = null;
            try
            {
                stream = await JSRef.CallAsync<MediaStream>("getDisplayMedia", (object)constraints);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION getDisplayMedia: {ex.Message}");
                return stream;
            }
            return stream;
        }

        public async Task<bool> AreDevicesHidden()
        {
            var tmp = await EnumerateDevices();
            foreach (var t in tmp)
            {
                if (string.IsNullOrEmpty(t.DeviceId) || string.IsNullOrEmpty(t.Label))
                {
                    return true;
                }
            }
            return false;
        }

        public Task<MediaDeviceInfo[]> EnumerateDevices() => JSRef.CallAsync<MediaDeviceInfo[]>("enumerateDevices");

        public Task<MediaStream?> GetUserMedia(ExpandoObject constraints) => JSRef.CallAsync<MediaStream?>("getUserMedia", constraints);
    }
}
