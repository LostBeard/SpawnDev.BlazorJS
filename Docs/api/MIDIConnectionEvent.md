# MIDIConnectionEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/MIDIConnectionEvent.cs`  

> The MIDIConnectionEvent interface of the Web MIDI API is the event passed to the statechange event of the MIDIAccess interface and the statechange event of the MIDIPort interface. This occurs any time a new port becomes available, or when a previously available port becomes unavailable. For example, this event is fired whenever a MIDI device is either plugged in to or unplugged from a computer.

## Constructors

| Signature | Description |
|---|---|
| `MIDIConnectionEvent(IJSInProcessObjectReference _ref)` | Creates a new instance of `MIDIConnectionEvent`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Port` | `MIDIPort` | get | Returns a reference to a MIDIPort instance for a port that has been connected or disconnected. |

