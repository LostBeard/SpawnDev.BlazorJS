# MIDIOutput

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `MIDIPort`  
**Source:** `JSObjects/MIDIOutput.cs`  

> The MIDIOutput interface of the Web MIDI API provides methods to add messages to the queue of an output device, and to clear the queue of messages.

## Constructors

| Signature | Description |
|---|---|
| `MIDIOutput(IJSInProcessObjectReference _ref)` | Creates a new instance of `MIDIOutput`. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Send(byte[] data)` | `void` | Queues a message to be sent to the MIDI port. |
| `Send(byte[] data, double timestamp)` | `void` | Queues a message to be sent to the MIDI port. |
| `Clear()` | `void` | Clears any pending send data from the queue. |

