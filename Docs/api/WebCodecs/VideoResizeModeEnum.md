# VideoResizeModeEnum

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebCodecs/VideoResizeModeEnum.cs`  

> The VideoResizeModeEnum enum of the Media Statistics API is used to describe the resize mode of a video source.

## Values

| Name | JSON Value | Description |
|---|---|---|
| `None` | `"none"` | This resolution and frame rate is offered by the camera, its driver, or the OS. |
| `CropAndScale` | `"crop-and-scale"` | This resolution is downscaled and/or cropped from a higher camera resolution by the User Agent, or its frame rate is decimated by the User Agent. The media MUST NOT be upscaled, stretched or have fake data created that did not occur in the input source, except as noted below. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `VideoResizeModeEnum` | `enum` | get | The VideoResizeModeEnum enum of the Media Statistics API is used to describe the resize mode of a video source. |

