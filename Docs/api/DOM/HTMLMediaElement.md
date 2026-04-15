# HTMLMediaElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLElement`  
**Source:** `JSObjects/DOM/HTMLMediaElement.cs`  
**MDN Reference:** [HTMLMediaElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLMediaElement)

> The HTMLMediaElement interface adds to HTMLElement the properties and methods needed to support basic media-related capabilities that are common to audio and video. https://developer.mozilla.org/en-US/docs/Web/API/HTMLMediaElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLMediaElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLMediaElement(ElementReference elementReference)` | Get an instance from an ElementReference |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `SrcObject` | `Union<MediaStream, File, Blob, MediaSource>?` | get | A MediaStream representing the media to play or that has played in the current HTMLMediaElement, or null if not assigned. |
| `Src` | `string?` | get | A string that reflects the src HTML attribute, which contains the URL of a media resource to use. |
| `CurrentTime` | `double` | get | A double-precision floating-point value indicating the current playback time in seconds; if the media has not started to play and has not been seeked, this value is the media's initial playback time. Setting this value seeks the media to the new time. The time is specified relative to the media's timeline. |
| `Duration` | `double?` | get | A read-only double-precision floating-point value indicating the total duration of the media in seconds. If no media data is available, the returned value is NaN. If the media is of indefinite length (such as streamed live media, a WebRTC call's media, or similar), the value is +Infinity. |
| `Volume` | `double` | get | A double indicating the audio volume, from 0.0 (silent) to 1.0 (loudest). |
| `DefaultPlaybackRate` | `double` | get | A double indicating the default playback rate for the media. |
| `PlaybackRate` | `double` | get | A double that indicates the rate at which the media is being played back. |
| `AutoPlay` | `bool` | get | A boolean value that reflects the autoplay HTML attribute, indicating whether playback should automatically begin as soon as enough media is available to do so without interruption. |
| `Muted` | `bool` | get | A boolean that determines whether audio is muted. true if the audio is muted and false otherwise. |
| `DefaultMuted` | `bool` | get | A boolean that reflects the muted HTML attribute, which indicates whether the media element's audio output should be muted by default. |
| `DisableRemotePlayback` | `bool` | get | A boolean that sets or returns the remote playback state, indicating whether the media element is allowed to have a remote playback UI. |
| `Controls` | `bool` | get | A boolean that reflects the controls HTML attribute, indicating whether user interface items for controlling the resource should be displayed. |
| `Paused` | `bool` | get | Returns a boolean that indicates whether the media element is paused. |
| `Ended` | `bool` | get | Returns a boolean that indicates whether the media element has finished playing. |
| `Loop` | `bool` | get | A boolean that reflects the loop HTML attribute, which indicates whether the media element should start over when it reaches the end. |
| `CurrentSrc` | `string?` | get | Returns a string with the absolute URL of the chosen media resource. |
| `CrossOrigin` | `string?` | get | A string indicating the CORS setting for this media element. |
| `Error` | `MediaError?` | get | Returns a MediaError object for the most recent error, or null if there has not been an error. |
| `ReadyState` | `ushort` | get | Returns a unsigned short (enumeration) indicating the readiness state of the media. 0 HAVE_NOTHING - No information is available about the media resource. 1 HAVE_METADATA - Enough of the media resource has been retrieved that the metadata attributes are initialized. Seeking will no longer raise an exception. 2 HAVE_CURRENT_DATA - Data is available for the current playback position, but not enough to actually play more than one frame. 3 HAVE_FUTURE_DATA - Data for the current playback position as well as for at least a little bit of time into the future is available (in other words, at least two frames of video, for example). 4 HAVE_ENOUGH_DATA - Enough data is available-and the download rate is high enough-that the media can be played through to the end without interruption. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetSrcObject()` | `T?` | Returns the srcObject property cast to the specified type. |
| `Play()` | `Task` | Begins playback of the media. |
| `Pause()` | `void` | Pauses the media playback. |
| `Load()` | `void` | Resets the media to the beginning and selects the best available source from the sources provided using the src attribute or the source element. |
| `CanPlayType(string mimeType)` | `string` | Given a string specifying a MIME media type (potentially with the codecs parameter included), canPlayType() returns the string probably if the media should be playable, maybe if there's not enough information to determine whether the media will play or not, or an empty string if the media cannot be played. |
| `CaptureStream()` | `MediaStream` | Returns MediaStream, captures a stream of the media content. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAbort` | `ActionEvent<Event>` | Fired when the resource was not fully loaded, but not as the result of an error. |
| `OnCanPlay` | `ActionEvent<Event>` | Fired when the user agent can play the media, but estimates that not enough data has been loaded to play the media up to its end without having to stop for further buffering of content. |
| `OnCanPlayThrough` | `ActionEvent<Event>` | Fired when the user agent can play the media, and estimates that enough data has been loaded to play the media up to its end without having to stop for further buffering of content. |
| `OnDurationChange` | `ActionEvent<Event>` | Fired when the duration property has been updated. |
| `OnEmptied` | `ActionEvent<Event>` | Fired when the media has become empty; for example, when the media has already been loaded (or partially loaded), and the HTMLMediaElement.load() method is called to reload it. |
| `OnEncrypted` | `ActionEvent<MediaEncryptedEvent>` | Fired when the media encounters some initialization data indicating it is encrypted. |
| `OnEnded` | `ActionEvent<Event>` | Fired when playback stops when end of the media (audio or video) is reached or because no further data is available. |
| `OnLoadedData` | `ActionEvent<Event>` | Fired when the first frame of the media has finished loading. |
| `OnLoadedMetadata` | `ActionEvent<Event>` | Fired when the metadata has been loaded. |
| `OnLoadStart` | `ActionEvent<Event>` | Fired when the browser has started to load a resource. |
| `OnPause` | `ActionEvent<Event>` | Fired when a request to pause play is handled and the activity has entered its paused state, most commonly occurring when the media's HTMLMediaElement.pause() method is called. |
| `OnPlay` | `ActionEvent<Event>` | Fired when the paused property is changed from true to false, as a result of the HTMLMediaElement.play() method, or the autoplay attribute. |
| `OnPlaying` | `ActionEvent<Event>` | Fired when playback is ready to start after having been paused or delayed due to lack of data. |
| `OnProgress` | `ActionEvent<Event>` | Fired periodically as the browser loads a resource. |
| `OnRateChange` | `ActionEvent<Event>` | Fired when the playback rate has changed. |
| `OnSeeked` | `ActionEvent<Event>` | Fired when a seek operation completes. |
| `OnSeeking` | `ActionEvent<Event>` | Fired when a seek operation begins. |
| `OnStalled` | `ActionEvent<Event>` | Fired when the user agent is trying to fetch media data, but data is unexpectedly not forthcoming. |
| `OnSuspend` | `ActionEvent<Event>` | Fired when the media data loading has been suspended. |
| `OnTimeUpdate` | `ActionEvent<Event>` | Fired when the time indicated by the currentTime property has been updated. |
| `OnVolumeChange` | `ActionEvent<Event>` | Fired when the volume has changed. |
| `OnWaiting` | `ActionEvent<Event>` | Fired when playback has stopped because of a temporary lack of data. |

