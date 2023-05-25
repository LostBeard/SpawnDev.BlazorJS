using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaRecorder
    /// </summary>
    public partial class MediaRecorder : EventTarget
    {
        public static List<string> CommonMimeTypes = new List<string> {
          "video/webm",
          "audio/webm",
          "video/webm;codecs=vp8",
          "video/webm;codecs=daala",
          "video/webm;codecs=h264",
          "audio/webm;codecs=opus",
          "video/mpeg",
          "video/mp4",
        };
        public MediaRecorder(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream">The MediaStream that will be recorded. This source media can come from a stream created using navigator.mediaDevices.getUserMedia() or from an <audio>, <video> or <canvas> element.</param>
        public MediaRecorder(MediaStream stream) : base(JS.New(nameof(MediaRecorder), stream)) { }
        public MediaRecorder(MediaStream stream, MediaRecorderOptions options) : base(JS.New(nameof(MediaRecorder), stream, options)) { }
        public static bool IsTypeSupported(string mimeType) => JS.Call<bool>("MediaRecorder.isTypeSupported", mimeType);
        /// <summary>
        /// Returns the MIME type that was selected as the recording container for the MediaRecorder object when it was created.
        /// </summary>
        public string MimeType => JSRef.Get<string>("mimeType");
        /// <summary>
        /// Returns the current state of the MediaRecorder object (inactive, recording, or paused.)
        /// </summary>
        public string State => JSRef.Get<string>("state");
        /// <summary>
        /// Returns the stream that was passed into the constructor when the MediaRecorder was created.
        /// </summary>
        public MediaStream Stream => JSRef.Get<MediaStream>("strean");
        /// <summary>
        /// Returns the video encoding bit rate in use. This may differ from the bit rate specified in the constructor (if it was provided).
        /// </summary>
        public long VideoBitsPerSecond => JSRef.Get<long>("videoBitsPerSecond");
        /// <summary>
        /// Returns the audio encoding bit rate in use. This may differ from the bit rate specified in the constructor (if it was provided).
        /// </summary>
        public long AudioBitsPerSecond => JSRef.Get<long>("audioBitsPerSecond");
        /// <summary>
        /// Pauses the recording of media.
        /// </summary>
        public void Pause() => JSRef.CallVoid("pause");
        /// <summary>
        /// Used to raise a dataavailable event containing a Blob object of the captured media as it was when the method was called. This can then be grabbed and manipulated as you wish.
        /// </summary>
        public void RequestData() => JSRef.CallVoid("requestData");
        /// <summary>
        /// Resumes recording of media after having been paused.
        /// </summary>
        public void Resume() => JSRef.CallVoid("resume");
        /// <summary>
        /// Begins recording media; this method can optionally be passed a timeslice argument with a value in milliseconds. If this is specified, the media will be captured in separate chunks of that duration, rather than the default behavior of recording the media in a single large chunk.
        /// </summary>
        public void Start() => JSRef.CallVoid("start");
        /// <summary>
        /// Begins recording media; this method can optionally be passed a timeslice argument with a value in milliseconds. If this is specified, the media will be captured in separate chunks of that duration, rather than the default behavior of recording the media in a single large chunk.
        /// </summary>
        /// <param name="timeslice">The number of milliseconds to record into each Blob. If this parameter isn't included, the entire media duration is recorded into a single Blob unless the requestData() method is called to obtain the Blob and trigger the creation of a new Blob into which the media continues to be recorded.</param>
        public void Start(double timeslice) => JSRef.CallVoid("start", timeslice);
        /// <summary>
        /// Stops recording, at which point a dataavailable event containing the final Blob of saved data is fired. No more recording occurs.
        /// </summary>
        public void Stop() => JSRef.CallVoid("stop");
        /// <summary>
        /// Fires periodically each time timeslice milliseconds of media have been recorded (or when the entire media has been recorded, if timeslice wasn't specified). The event, of type BlobEvent, contains the recorded media in its data property.
        /// </summary>
        public JSEventCallback<BlobEvent> OnDataAvailable { get => new JSEventCallback<BlobEvent>(o => AddEventListener("dataavailable", o), o => RemoveEventListener("dataavailable", o)); set { } }
        public class MediaRecorderErrorEvent : Event
        {
            public MediaRecorderErrorEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        }
        /// <summary>
        /// Fired when there are fatal errors that stop recording. The received event is based on the MediaRecorderErrorEvent interface, whose error property contains a DOMException that describes the actual error that occurred.
        /// </summary>
        public JSEventCallback<MediaRecorderErrorEvent> OnError { get => new JSEventCallback<MediaRecorderErrorEvent>(o => AddEventListener("error", o), o => RemoveEventListener("error", o)); set { } }
        /// <summary>
        /// Fired when media recording is paused.
        /// </summary>
        public JSEventCallback OnPause { get => new JSEventCallback(o => AddEventListener("pause", o), o => RemoveEventListener("pause", o)); set { } }
        /// <summary>
        /// Fired when media recording resumes after being paused.
        /// </summary>
        public JSEventCallback OnResume { get => new JSEventCallback(o => AddEventListener("resume", o), o => RemoveEventListener("resume", o)); set { } }
        /// <summary>
        /// Fired when media recording starts.
        /// </summary>
        public JSEventCallback OnStart { get => new JSEventCallback(o => AddEventListener("start", o), o => RemoveEventListener("start", o)); set { } }
        /// <summary>
        /// Fired when media recording ends, either when the MediaStream ends, or after the MediaRecorder.stop() method is called.
        /// </summary>
        public JSEventCallback OnStop { get => new JSEventCallback(o => AddEventListener("stop", o), o => RemoveEventListener("stop", o)); set { } }
    }
}
