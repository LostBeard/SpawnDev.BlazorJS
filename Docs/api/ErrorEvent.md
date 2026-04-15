# ErrorEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/ErrorEvent.cs`  

> The ErrorEvent interface represents events providing information related to errors in scripts or in files.

## Constructors

| Signature | Description |
|---|---|
| `ErrorEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Message` | `string` | get | A string containing a human-readable error message describing the problem. Lacking a crossorigin setting reduces error logging. |
| `Filename` | `string` | get | A string containing the name of the script file in which the error occurred. |
| `LineNO` | `int` | get | An integer containing the line number of the script file on which the error occurred. |
| `ColNO` | `int` | get | An integer containing the column number of the script file on which the error occurred. |
| `Error` | `JSObject?` | get | A JavaScript Object that is concerned by the event. |

