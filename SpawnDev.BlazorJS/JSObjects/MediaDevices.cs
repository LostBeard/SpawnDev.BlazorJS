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
        /// <summary>
        /// Fired when a media input or output device is attached to or removed from the user's computer.
        /// </summary>
        public JSEventCallback<Event> OnDeviceChange { get => new JSEventCallback<Event>("devicechange", AddEventListener, RemoveEventListener); set { } }

        public async Task<MediaStream?> GetMediaDeviceStream(MediaDeviceInfo? deviceVideo, MediaDeviceInfo? deviceAudio)
        {
            var deviceIdVideo = deviceVideo == null ? null : deviceVideo.DeviceId;
            var deviceIdAudio = deviceAudio == null ? null : deviceAudio.DeviceId;
            return await GetMediaDeviceStream(deviceIdVideo, deviceIdAudio);
        }

        public async Task<MediaStream?> GetMediaDeviceStream(string? deviceIdVideo, string? deviceIdAudio)
        {
            dynamic constraints = new ExpandoObject();
            if (!string.IsNullOrEmpty(deviceIdVideo))
            {
                constraints.video = new
                {
                    deviceId = deviceIdVideo,
                    width = new { ideal = 4096 },
                    height = new { ideal = 2160 },
                };
                //constraints.video = new ExpandoObject();
                //constraints.video.deviceId = new ExpandoObject();
                //constraints.video.deviceId.exact = deviceIdVideo;
                ////// get largest
                //constraints.video.width = new ExpandoObject();//= 4096;
                //constraints.video.width.ideal = 4096;
                //constraints.video.height = new ExpandoObject();//= 2160;
                //constraints.video.height.ideal = 2160;
            }
            else
            {
                constraints.video = false;
            }
            if (!string.IsNullOrEmpty(deviceIdAudio))
            {
                //constraints.audio = new ExpandoObject();
                //constraints.audio.deviceId = new ExpandoObject();
                //constraints.audio.deviceId.exact = deviceIdAudio; 
                constraints.audio = new
                {
                    deviceId = deviceIdAudio,
                };
            }
            else
            {
                constraints.audio = false;
            }
            var stream = await GetUserMedia(constraints);
            return stream;
        }

        // https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getDisplayMedia
        public Task<MediaStream?> GetDisplayMedia(object constraints) => JSRef.CallAsync<MediaStream?>("getDisplayMedia", constraints);
        public Task<MediaStream?> GetDisplayMedia() => JSRef.CallAsync<MediaStream?>("getDisplayMedia");

        public async Task<bool> AreDevicesHidden()
        {
            var tmp = await EnumerateDevices();
            var ret = false;
            if (tmp == null) return ret;
            foreach (var t in tmp)
            {
                if (string.IsNullOrEmpty(t.DeviceId) || string.IsNullOrEmpty(t.Label))
                {
                    ret = true;
                    break;
                }
            }
            //tmp.DisposeAll();
            return ret;
        }

        public Task<MediaDeviceInfo[]> EnumerateDevices() => JSRef.CallAsync<MediaDeviceInfo[]>("enumerateDevices");

        public Task<MediaStream?> GetUserMedia(object constraints) => JSRef.CallAsync<MediaStream?>("getUserMedia", constraints);

        /// <summary>
        /// With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input.
        /// </summary>
        /// <returns>A Task whose fulfillment handler receives a MediaStream object when the requested media has successfully been obtained.</returns>
        public Task<MediaStream?> GetUserMedia(bool video, bool audio) => GetUserMedia(new { video = video, audio = audio });

        /// <summary>
        /// Returns an object conforming to MediaTrackSupportedConstraints indicating which constrainable properties are supported on the MediaStreamTrack interface. See Media Streams API to learn more about constraints and how to use them.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, bool> GetSupportedConstraints() => JSRef.Call<Dictionary<string, bool>>("getSupportedConstraints");
    }
}
