# MIDIAccess

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/MIDIAccess.cs`  

> The MIDIAccess interface of the Web MIDI API provides methods for listing MIDI input and output devices, and obtaining access to those devices. https://developer.mozilla.org/en-US/docs/Web/API/MIDIAccess

## Constructors

| Signature | Description |
|---|---|
| `MIDIAccess(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Inputs` | `MIDIInputMap` | get | Returns an instance of MIDIInputMap which provides access to any available MIDI input ports. |
| `Outputs` | `MIDIOutputMap` | get | Returns an instance of MIDIOutputMap which provides access to any available MIDI output ports. |
| `SysexEnabled` | `bool` | get | A boolean attribute indicating whether system exclusive support is enabled on the current MIDIAccess instance. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnStateChange` | `ActionEvent<MIDIConnectionEvent>` | Called whenever a new MIDI port is added or an existing port changes state. |
