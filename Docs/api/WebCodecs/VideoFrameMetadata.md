# VideoFrameMetadata

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebCodecs/VideoFrameMetadata.cs`  

> Metadata supplied to the callback registered with HTMLVideoElement.requestVideoFrameCallback(). https://web.dev/articles/requestvideoframecallback-rvfc

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PresentationTime` | `double` | get | The time at which the user agent submitted the frame for composition. |
| `ExpectedDisplayTime` | `double` | get | The time at which the user agent expects the frame to be visible. |
| `Width` | `int` | get | The width of the video frame, in media pixels. |
| `Height` | `int` | get | The height of the video frame, in media pixels. |
| `MediaTime` | `double` | get | The media presentation timestamp (PTS) in seconds of the frame presented (e.g., its timestamp on the video.currentTime timeline). |
| `PresentedFrames` | `long` | get | A count of the number of frames submitted for composition. Allows clients to determine if frames were missed between instances of VideoFrameRequestCallback. |
| `ProcessingDuration` | `double` | get | The elapsed duration in seconds from submission of the encoded packet with the same presentation timestamp (PTS) as this frame (e.g., same as the mediaTime) to the decoder until the decoded frame was ready for presentation. |
| `CaptureTime` | `double?` | get | For video frames coming from either a local or remote source, this is the time at which the frame was captured by the camera. For a remote source, the capture time is estimated using clock synchronization and RTCP sender reports to convert RTP timestamps to capture time. |
| `ReceiveTime` | `double?` | get | For video frames coming from a remote source, this is the time the encoded frame was received by the platform, that is, the time at which the last packet belonging to this frame was received over the network. |
| `RtpTimestamp` | `long` | get | The RTP timestamp associated with this video frame. |

