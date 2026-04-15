# WebTransport

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebTransport/WebTransport.cs`  

> The WebTransport interface of the WebTransport API provides a modern, low-latency, bidirectional, client-server messaging transport.

## Constructors

| Signature | Description |
|---|---|
| `WebTransport(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `WebTransport(string url)` | Creates a new WebTransport object. |
| `WebTransport(string url, WebTransportOptions options)` | Creates a new WebTransport object. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Ready` | `Task` | get | Returns a Promise that resolves when the transport is ready to be used. |
| `Closed` | `Task<WebTransportCloseInfo>` | get | Returns a Promise that resolves when the transport is closed. |
| `Datagrams` | `WebTransportDatagramDuplexStream` | get | Returns a WebTransportDatagramDuplexStream instance that can be used to send and receive datagrams. |
| `IncomingBidirectionalStreams` | `ReadableStream` | get | Returns a ReadableStream of WebTransportBidirectionalStream objects. |
| `IncomingUnidirectionalStreams` | `ReadableStream` | get | Returns a ReadableStream of WebTransportReceiveStream objects. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Close(WebTransportCloseInfo? closeInfo)` | `void` | Closes the WebTransport connection. |
| `CreateBidirectionalStream()` | `Task<WebTransportBidirectionalStream>` | Creates a bidirectional stream. |
| `CreateUnidirectionalStream()` | `Task<WritableStream>` | Creates a unidirectional stream. |

