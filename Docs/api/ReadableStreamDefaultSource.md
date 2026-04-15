# ReadableStreamDefaultSource

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ReadableStreamUnderlyingSource`, `IDisposable`  
**Source:** `JSObjects/ReadableStreamDefaultSource.cs`  

> The ReadableStreamDefaultSource interface represents an underlying source for a ReadableStream.

## Constructors

| Signature | Description |
|---|---|
| `ReadableStreamDefaultSource(Func<ReadableStreamDefaultController, Task>? start, Func<ReadableStreamDefaultController, Task>? pull, Action<string?>? cancel)` | Creates a new instance |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Type` | `string?` | get/set |  |
| `AutoAllocateChunkSize` | `int?` | get |  |
| `Pull` | `FuncCallback<ReadableStreamDefaultController, Task>?` | get |  |
| `Start` | `FuncCallback<ReadableStreamDefaultController, Task>?` | get |  |
| `Cancel` | `ActionCallback<string?>?` | get |  |

