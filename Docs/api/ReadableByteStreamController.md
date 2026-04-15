# ReadableByteStreamController

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ReadableByteStreamController.cs`  
**MDN Reference:** [ReadableByteStreamController on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReadableByteStreamController)

> The ReadableByteStreamController interface of the Streams API represents a controller for a readable byte stream. It allows control of the state and internal queue of a ReadableStream with an underlying byte source, and enables efficient zero-copy transfer of data from the underlying source to a consumer when the stream's internal queue is empty.>br /> https://developer.mozilla.org/en-US/docs/Web/API/ReadableByteStreamController

## Constructors

| Signature | Description |
|---|---|
| `ReadableByteStreamController(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ByobRequest` | `ReadableStreamBYOBRequest?` | get | Returns the current BYOB pull request, or null if there no outstanding request. |
| `DesiredSize` | `int` | get | Returns the desired size required to fill the stream's internal queue. Note that this can be negative if the queue is over-full. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Close()` | `void` | Closes the associated stream. |
| `Enqueue(object chunk)` | `void` | Enqueues a given chunk in the associated stream. |
| `Error(object errorObject)` | `void` | Any object that you want future interactions to fail with. |

