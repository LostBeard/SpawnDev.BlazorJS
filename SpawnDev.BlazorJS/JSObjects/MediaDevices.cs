using Microsoft.JSInterop;
using System.Dynamic;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class MediaDevices : EventTarget
    {
        public static string VIDEO_INPUT { get; } = "videoinput";
        public static string AUDIO_INPUT { get; } = "audioinput";
        public static string AUDIO_OUTPUT { get; } = "audiooutput";
        public MediaDevices(IJSInProcessObjectReference _ref) : base(_ref) { }
        public static bool Supported => !JS.IsUndefined("navigator.mediaDevices") && !JS.IsUndefined("navigator.mediaDevices.enumerateDevices");
        public static bool GetDisplayMediaSupported => !JS.IsUndefined("navigator.mediaDevices") && !JS.IsUndefined("navigator.mediaDevices.getDisplayMedia");

        public JSEventCallback OnDeviceChange { get => new JSEventCallback(o => AddEventListener("devicechange", o), o => RemoveEventListener("devicechange", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }

        public async Task<MediaStream> GetMediaDeviceStream(MediaDeviceInfo deviceVideo, MediaDeviceInfo deviceAudio)
        {
            var deviceIdVideo = deviceVideo == null ? null : deviceVideo.DeviceId;
            var deviceIdAudio = deviceAudio == null ? null : deviceAudio.DeviceId;
            return await GetMediaDeviceStream(deviceIdVideo, deviceIdAudio);
        }

        // https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getUserMedia
        //public async Task<MediaStream> GetCamera()
        //{
        //    dynamic constraints = new ExpandoObject();
        //    constraints.audio = false;
        //    constraints.video = new ExpandoObject();
        //    constraints.video.width = new ExpandoObject();
        //    constraints.video.width.ideal = 4096;
        //    constraints.video.height = new ExpandoObject();
        //    constraints.video.height.ideal = 2160;
        //    MediaStream stream = null;
        //    try
        //    {
        //        stream = await GetPropertyAsync<MediaStream>("getUserMedia", constraints);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"EXCEPTION getUserMedia: {ex.Message}");
        //        return stream;
        //    }
        //    return stream;
        //}

        //class VideoMinWidthObject
        //{
        //    public int MinWidth { get; set; }
        //    public VideoMinWidthObject() { }
        //    public VideoMinWidthObject(int MinWidth) { this.MinWidth = MinWidth; }
        //}

        public async Task<MediaStream?> GetMediaDeviceStream(string deviceIdVideo, string deviceIdAudio)
        {
            dynamic constraints = new ExpandoObject();
            if (!string.IsNullOrEmpty(deviceIdVideo))
            {
                constraints.video = new ExpandoObject();
                constraints.video.deviceId = new ExpandoObject();
                constraints.video.deviceId.exact = deviceIdVideo;

                //// get largest
                //var minWidths = new List<VideoMinWidthObject> {
                //    new VideoMinWidthObject(320),
                //    new VideoMinWidthObject(640),
                //    new VideoMinWidthObject(1024),
                //    new VideoMinWidthObject(1280),
                //    new VideoMinWidthObject(1920),
                //    new VideoMinWidthObject(2560),
                //};
                //constraints.video.optional = minWidths;

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
            MediaStream? stream = null;
            try
            {
                stream = await JSRef.CallAsync<MediaStream>("getUserMedia", (object)constraints);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION getUserMedia: {ex.Message}");
            }
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
#if DEBUG
            Console.WriteLine("AreDevicesHidden");
#endif
            var tmp = await EnumerateDevices();
            foreach (var t in tmp)
            {
                if (string.IsNullOrEmpty(t.DeviceId) || string.IsNullOrEmpty(t.Label))
                {
#if DEBUG
                    Console.WriteLine("AreDevicesHidden true");
#endif
                    return true;
                }
            }
#if DEBUG
            Console.WriteLine("AreDevicesHidden false");
#endif
            return false;
        }

        public Task<MediaDeviceInfo[]> EnumerateDevices() => JSRef.CallAsync<MediaDeviceInfo[]>("enumerateDevices");

        public Task<MediaStream?> GetUserMedia(ExpandoObject constraints) => JSRef.CallAsync<MediaStream?>("getUserMedia", constraints);
    }
}
