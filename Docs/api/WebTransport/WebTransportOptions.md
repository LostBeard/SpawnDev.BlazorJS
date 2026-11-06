# WebTransportOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebTransport/WebTransportOptions.cs`  

> The WebTransportOptions dictionary includes options that can be passed to the WebTransport constructor.

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `WebTransportOptions` | `class` | get | The WebTransportOptions dictionary includes options that can be passed to the WebTransport constructor. |
| `RequireUnreliable` | `bool?` | get |  |
| `ServerCertificateHashes` | `List<object>?` | get |  |
| `AllowPooling` | `bool?` | get/set | A boolean indicating whether the connection can be pooled. |
| `CongestionControl` | `string?` | get/set | A string indicating the application's preference that the congestion control algorithm used when sending data over this connection be tuned for either throughput or low-latency. This is a hint to the user agent. The allowed values are: default (default), throughput, and low-latency. |

