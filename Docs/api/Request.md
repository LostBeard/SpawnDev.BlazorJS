# Request

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Request.cs`  
**MDN Reference:** [Request on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Request)

> The Request interface of the Fetch API represents a resource request. https://developer.mozilla.org/en-US/docs/Web/API/Request

## Constructors

| Signature | Description |
|---|---|
| `Request(string input)` | The Request() constructor creates a new Request object. |
| `Request(string input, RequestOptions options)` | The Request() constructor creates a new Request object. |
| `Request(Request input)` | The Request() constructor creates a new Request object. |
| `Request(Request input, RequestOptions options)` | The Request() constructor creates a new Request object. |
| `Request(IJSInProcessObjectReference _ref)` | The Request() constructor creates a new Request object. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Body` | `ReadableStream` | get | A ReadableStream of the body contents. |
| `BodyUsed` | `bool` | get | Stores true or false to indicate whether or not the body has been used in a request yet. |
| `Cache` | `string` | get | Contains the cache mode of the request (e.g., default, reload, no-cache). |
| `Credentials` | `string` | get | Contains the credentials of the request (e.g., omit, same-origin, include). The default is same-origin. |
| `Destination` | `string` | get | A string describing the type of content being requested |
| `Headers` | `Headers` | get | Contains the associated Headers object of the request. |
| `Integrity` | `string` | get | Contains the subresource integrity value of the request (e.g., sha256-BpfBw7ivV8q2jLiT13fxDYAe2tJllusRSZ273h2nFSE=) |
| `Method` | `string` | get | Contains the request's method (GET, POST, etc.) |
| `Mode` | `string` | get | Contains the mode of the request (e.g., cors, no-cors, same-origin, navigate.) |
| `Redirect` | `string` | get | Contains the mode for how redirects are handled. It may be one of follow, error, or manual. |
| `Referrer` | `string` | get | Contains the referrer of the request (e.g., client) |
| `ReferrerPolicy` | `string` | get | Contains the referrer policy of the request (e.g., no-referrer). |
| `Signal` | `AbortSignal` | get | Returns the AbortSignal associated with the request |
| `Url` | `string` | get | Contains the URL of the request. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ArrayBuffer()` | `Task<ArrayBuffer>` | Returns a promise that resolves with an ArrayBuffer representation of the request body. |
| `Blob()` | `Task<Blob>` | Returns a promise that resolves with a Blob representation of the request body. |
| `Clone()` | `Request` | Creates a copy of the current Request object. |
| `FormData()` | `Task<FormData>` | Returns a promise that resolves with a FormData representation of the request body. |
| `Json()` | `Task<T>` | Returns a promise that resolves with the result of parsing the request body as JSON. |
| `Text()` | `Task<string>` | Returns a promise that resolves with a text representation of the request body. |

## Example

```csharp
// Create a simple GET request
using var request = new Request("https://api.example.com/data");
string url = request.Url;
string method = request.Method;       // "GET"
string credentials = request.Credentials;

// Create a POST request with options
using var postRequest = new Request("https://api.example.com/submit", new RequestOptions
{
    Method = "POST",
    Body = "{\"name\": \"BlazorJS\"}",
    Headers = new Dictionary<string, string>
    {
        { "Content-Type", "application/json" }
    }
});

// Read request properties
using var headers = postRequest.Headers;
bool bodyUsed = postRequest.BodyUsed;

// Clone a request (useful when body can only be consumed once)
using var cloned = request.Clone();

// Read the request body as text
string bodyText = await postRequest.Text();

// Use a Request with fetch
using var response = await JS.CallAsync<Response>("fetch", request);
```

