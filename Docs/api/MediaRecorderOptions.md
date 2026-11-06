# MediaRecorderOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/MediaRecorderOptions.cs`  

> Options used when creating a new MediaRecorder

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MediaRecorderOptions` | `class` | get | Options used when creating a new MediaRecorder |
| `AudioBitsPerSecond` | `long?` | get |  |
| `VideoBitsPerSecond` | `long?` | get |  |
| `BitsPerSecond` | `long?` | get |  |
| `MimeType` | `string?` | get/set | A MIME type specifying the format for the resulting media; you may specify the container format (the browser will select its preferred codecs for audio and/or video), or you may use the codecs parameter and/or the profiles parameter to provide detailed information about which codecs to use and how to configure them. Applications can check in advance if a mimeType is supported by the user agent by calling MediaRecorder.isTypeSupported() |

