# WebTransportReceiveStream

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ReadableStream`  
**Source:** `JSObjects/WebTransportReceiveStream.cs`  

> The WebTransportReceiveStream interface of the WebTransport API is a ReadableStream that can be used to read from an incoming unidirectional or bidirectional WebTransport stream. The stream is a readable byte stream of Uint8Array, and can be consumed using either a BYOB reader (ReadableStreamBYOBReader) or the default reader (ReadableStreamDefaultReader). Objects of this type are not constructed directly. Instead they are obtained using the WebTransport.incomingUnidirectionalStream property. WebTransportReceiveStream is a transferable object. https://developer.mozilla.org/en-US/docs/Web/API/WebTransportReceiveStream

## Constructors

| Signature | Description |
|---|---|
| `WebTransportReceiveStream(IJSInProcessObjectReference _ref)` | Deserialization constructor |
