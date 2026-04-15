# XRInputSourcesChangeEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/WebXR/XRInputSourcesChangeEvent.cs`  

> The WebXR Device API interface XRInputSourcesChangeEvent is used to represent the inputsourceschange event sent to an XRSession when the set of available WebXR input controllers changes.

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Session` | `XRSession` | get | The XRSession to which the event refers. |
| `Added` | `XRInputSource[]` | get | An array of zero or more XRInputSource objects, each representing an input device which has been newly connected or enabled for use. |
| `Removed` | `XRInputSource[]` | get | An array of zero or more XRInputSource objects representing the input devices newly disconnected or no longer available. |

