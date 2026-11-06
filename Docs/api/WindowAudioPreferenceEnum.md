# WindowAudioPreferenceEnum

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WindowAudioPreferenceEnum.cs`  

> Which audio, if any, the user agent should offer to share with a WINDOW capture from getDisplayMedia() (WindowAudio). Chromium shipped it around Chrome 141 (Chrome 140+ in the extensions reference). https://groups.google.com/a/chromium.org/g/blink-dev/c/66dDyQoX3RI

## Values

| Name | JSON Value | Description |
|---|---|---|
| `Exclude` | `"exclude"` | Offer no audio with a window capture. |
| `System` | `"system"` | Offer the system audio (everything the machine is playing) with a window capture. |
| `Window` | `"window"` | Offer only the audio of the captured window's own application, so other applications' sound (voice chat, music) is left out. |
