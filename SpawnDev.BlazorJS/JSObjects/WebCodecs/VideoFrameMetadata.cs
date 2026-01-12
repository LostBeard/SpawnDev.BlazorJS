using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Metadata supplied to the callback registered with HTMLVideoElement.requestVideoFrameCallback().<br/>
    /// https://web.dev/articles/requestvideoframecallback-rvfc
    /// </summary>
    public class VideoFrameMetadata : JSObject
    {
        /// <inheritdoc/>
        public VideoFrameMetadata(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The time at which the user agent submitted the frame for composition.
        /// </summary>
        public double PresentationTime => JSRef!.Get<double>("presentationTime");
        /// <summary>
        /// The time at which the user agent expects the frame to be visible.
        /// </summary>
        public double ExpectedDisplayTime => JSRef!.Get<double>("expectedDisplayTime");
        /// <summary>
        /// The width of the video frame, in media pixels.
        /// </summary>
        public int Width => JSRef!.Get<int>("width");
        /// <summary>
        /// The height of the video frame, in media pixels.
        /// </summary>
        public int Height => JSRef!.Get<int>("height");
        /// <summary>
        /// The media presentation timestamp (PTS) in seconds of the frame presented (e.g., its timestamp on the video.currentTime timeline).
        /// </summary>
        public double MediaTime => JSRef!.Get<double>("mediaTime");
        /// <summary>
        /// A count of the number of frames submitted for composition. Allows clients to determine if frames were missed between instances of VideoFrameRequestCallback.
        /// </summary>
        public long PresentedFrames => JSRef!.Get<long>("presentedFrames");
        /// <summary>
        /// The elapsed duration in seconds from submission of the encoded packet with the same presentation timestamp (PTS) as this frame (e.g., same as the mediaTime) to the decoder until the decoded frame was ready for presentation.
        /// </summary>
        public double ProcessingDuration => JSRef!.Get<double>("processingDuration");
        /// <summary>
        /// For video frames coming from either a local or remote source, this is the time at which the frame was captured by the camera. For a remote source, the capture time is estimated using clock synchronization and RTCP sender reports to convert RTP timestamps to capture time.
        /// </summary>
        public double? CaptureTime => JSRef!.Get<double?>("captureTime");
        /// <summary>
        /// For video frames coming from a remote source, this is the time the encoded frame was received by the platform, that is, the time at which the last packet belonging to this frame was received over the network.
        /// </summary>
        public double? ReceiveTime => JSRef!.Get<double?>("receiveTime");
        /// <summary>
        /// The RTP timestamp associated with this video frame.
        /// </summary>
        public long RtpTimestamp => JSRef!.Get<long>("rtpTimestamp");
    }
}