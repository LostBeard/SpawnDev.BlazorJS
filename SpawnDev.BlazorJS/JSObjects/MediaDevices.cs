using Microsoft.JSInterop;
//using System.Dynamic;

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
        // https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getDisplayMedia
        /// <summary>
        /// Prompts the user to select a display or portion of a display (such as a window) to capture as a MediaStream for sharing or recording purposes. Returns a promise that resolves to a MediaStream.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<MediaStream?> GetDisplayMedia(object options) => JSRef!.CallAsync<MediaStream?>("getDisplayMedia", options);
        /// <summary>
        /// The getDisplayMedia() method of the MediaDevices interface prompts the user to select and grant permission to capture the contents of a display or portion thereof (such as a window) as a MediaStream.
        /// </summary>
        /// <param name="options">An optional object specifying requirements for the returned MediaStream. The options for getDisplayMedia() work in the same as the constraints for the MediaDevices.getUserMedia() method, although in that case only audio and video can be specified.</param>
        /// <returns>A Promise that resolves to a MediaStream containing a video track whose contents come from a user-selected screen area, as well as an optional audio track.</returns>
        public Task<MediaStream?> GetDisplayMedia(DisplayMediaStreamOptions options) => JSRef!.CallAsync<MediaStream?>("getDisplayMedia", options);
        /// <summary>
        /// Prompts the user to select a display or portion of a display (such as a window) to capture as a MediaStream for sharing or recording purposes. Returns a promise that resolves to a MediaStream.
        /// </summary>
        /// <returns></returns>
        public Task<MediaStream?> GetDisplayMedia() => JSRef!.CallAsync<MediaStream?>("getDisplayMedia");
        /// <summary>
        /// Returns true if there is at least 1 device enumerated with an empty or null label or deviceId<br/>
        /// </summary>
        /// <returns></returns>
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
            tmp.DisposeAll();
            return ret;
        }
        /// <summary>
        /// Obtains an array of information about the media input and output devices available on the system.
        /// </summary>
        /// <returns></returns>
        public Task<MediaDeviceInfo[]> EnumerateDevices() => JSRef!.CallAsync<MediaDeviceInfo[]>("enumerateDevices");
        /// <summary>
        /// With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input.
        /// </summary>
        /// <param name="constraints">
        /// An object specifying the types of media to request, along with any requirements for each type.<br/>
        /// The constraints parameter is an object with two members: video and audio, describing the media types requested. Either or both must be specified. If the browser cannot find all media tracks with the specified types that meet the constraints given, then the returned promise is rejected with NotFoundError DOMException.<br/>
        /// </param>
        /// <returns></returns>
        public Task<MediaStream?> GetUserMedia(object constraints) => JSRef!.CallAsync<MediaStream?>("getUserMedia", constraints);
        /// <summary>
        /// With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input.
        /// </summary>
        /// <param name="constraints">
        /// An object specifying the types of media to request, along with any requirements for each type.<br/>
        /// The constraints parameter is an object with two members: video and audio, describing the media types requested. Either or both must be specified. If the browser cannot find all media tracks with the specified types that meet the constraints given, then the returned promise is rejected with NotFoundError DOMException.<br/>
        /// </param>
        /// <returns></returns>
        public Task<MediaStream?> GetUserMedia(MediaStreamConstraints constraints) => JSRef!.CallAsync<MediaStream?>("getUserMedia", constraints);
        /// <summary>
        /// With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input.
        /// </summary>
        /// <returns>A Task whose fulfillment handler receives a MediaStream object when the requested media has successfully been obtained.</returns>
        public Task<MediaStream?> GetUserMedia(bool video, bool audio) => GetUserMedia(new { video = video, audio = audio });
        /// <summary>
        /// With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input.
        /// </summary>
        /// <param name="deviceIdVideo"></param>
        /// <param name="deviceIdAudio"></param>
        /// <returns></returns>
        public Task<MediaStream?> GetMediaDeviceStream(string? deviceIdVideo, string? deviceIdAudio)
        {
            var constraints = new MediaStreamConstraints();
            if (!string.IsNullOrEmpty(deviceIdVideo))
            {
                constraints.Video = new MediaTrackConstraints
                {
                    DeviceId = deviceIdVideo,
                    Width = new ConstrainULongRange { Ideal = 4096 },
                    Height = new ConstrainULongRange { Ideal = 2160 },
                };
            }
            if (!string.IsNullOrEmpty(deviceIdAudio))
            {
                constraints.Audio = new MediaTrackConstraints
                {
                    DeviceId = deviceIdAudio,
                };
            }
            return GetUserMedia(constraints);
        }
        /// <summary>
        /// Returns an object conforming to MediaTrackSupportedConstraints indicating which constrainable properties are supported on the MediaStreamTrack interface. See Media Streams API to learn more about constraints and how to use them.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, bool> GetSupportedConstraints() => JSRef!.Call<Dictionary<string, bool>>("getSupportedConstraints");
    }
}
