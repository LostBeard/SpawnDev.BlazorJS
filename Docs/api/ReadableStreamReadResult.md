# ReadableStreamReadResult

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ReadableStreamReadResult.cs`  

> Represents the result of a read operation on a ReadableStream.

## Constructors

| Signature | Description |
|---|---|
| `ReadableStreamReadResult(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Done` | `bool` | get | A boolean indicating whether the stream has been closed. |
| `Value` | `JSObject?` | get | The value read from the stream. |
