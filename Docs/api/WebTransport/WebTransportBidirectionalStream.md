# WebTransportBidirectionalStream

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebTransport/WebTransportBidirectionalStream.cs`  

> The WebTransportBidirectionalStream interface of the WebTransport API represents a bidirectional stream created by a WebTransport.

## Constructors

| Signature | Description |
|---|---|
| `WebTransportBidirectionalStream(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Readable` | `WebTransportReceiveStream` | get | The readable property of the WebTransportBidirectionalStream interface returns a WebTransportReceiveStream instance that can be used to read data from the bidirectional stream. |
| `Writable` | `WebTransportSendStream` | get | The writable property of the WebTransportBidirectionalStream interface returns a WebTransportSendStream instance that can be used to write data to the bidirectional stream. |

