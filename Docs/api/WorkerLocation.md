# WorkerLocation

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WorkerLocation.cs`  
**MDN Reference:** [WorkerLocation on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WorkerLocation)

> The WorkerLocation interface defines the absolute location of the script executed by the Worker. Such an object is initialized for each worker and is available via the WorkerGlobalScope.location property obtained by calling self.location. https://developer.mozilla.org/en-US/docs/Web/API/WorkerLocation

## Constructors

| Signature | Description |
|---|---|
| `WorkerLocation(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Href` | `string` | get | Returns a string containing the serialized URL for the worker's location. |
| `Protocol` | `string` | get | Returns the protocol part of the worker's location. |
| `Host` | `string` | get | A string containing the host, that is the hostname, a ':', and the port of the URL. |
| `HostName` | `string` | get | A string containing the domain of the URL. |
| `Origin` | `string` | get | Returns a string containing the canonical form of the origin of the specific location. |
| `Port` | `string` | get | A string containing the port number of the URL. |
| `PathName` | `string` | get | A string containing an initial '/' followed by the path of the URL, not including the query string or fragment. |
| `Search` | `string` | get | A string containing a '?' followed by the parameters or "querystring" of the URL. Modern browsers provide URLSearchParams and URL.searchParams to make it easy to parse out the parameters from the querystring. |
| `Hash` | `string` | get | A string containing a '#' followed by the fragment identifier of the URL. |

