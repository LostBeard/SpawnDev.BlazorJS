# ReadableByteStreamSource

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ReadableStreamUnderlyingSource`, `IDisposable`  
**Source:** `JSObjects/ReadableByteStreamSource.cs`  

> The ReadableByteStreamSource interface represents an underlying source for a ReadableStream of bytes.

## Constructors

| Signature | Description |
|---|---|
| `ReadableByteStreamSource(Action<ReadableByteStreamController>? pull, Action<ReadableByteStreamController>? start, Action<string?>? cancel)` | Creates a new instance |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Type` | `string?` | get/set |  |
| `AutoAllocateChunkSize` | `int?` | get |  |
| `Pull` | `ActionCallback<ReadableByteStreamController>?` | get |  |
| `Start` | `ActionCallback<ReadableByteStreamController>?` | get |  |
| `Cancel` | `ActionCallback<string?>?` | get |  |

