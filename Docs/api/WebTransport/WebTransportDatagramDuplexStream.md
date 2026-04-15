# WebTransportDatagramDuplexStream

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebTransport/WebTransportDatagramDuplexStream.cs`  

> The WebTransportDatagramDuplexStream interface of the WebTransport API represents a duplex stream for sending and receiving datagrams.

## Constructors

| Signature | Description |
|---|---|
| `WebTransportDatagramDuplexStream(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Readable` | `ReadableStream` | get | Returns a ReadableStream instance that can be used to read datagrams from the stream. |
| `Writable` | `WritableStream` | get | Returns a WritableStream instance that can be used to write datagrams to the stream. |
| `IncomingMaxAge` | `float` | get | Returns the maximum age for incoming datagrams in milliseconds. |
| `OutgoingMaxAge` | `float` | get | Returns the maximum age for outgoing datagrams in milliseconds. |
| `IncomingHighWaterMark` | `float` | get | Returns the high water mark for incoming datagrams. |
| `OutgoingHighWaterMark` | `float` | get | Returns the high water mark for outgoing datagrams. |

