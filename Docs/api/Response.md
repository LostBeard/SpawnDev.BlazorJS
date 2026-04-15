# Response

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Response.cs`  
**MDN Reference:** [Response on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Response)

> The Response interface of the Fetch API represents the response to a request. https://developer.mozilla.org/en-US/docs/Web/API/Response

## Constructors

| Signature | Description |
|---|---|
| `Response(IJSInProcessObjectReference _ref)` | The Request() constructor creates a new Request object. |
| `Response()` | Creates a new Response object. |
| `Response(string body, ResponseOptions? options)` | Creates a new Response object. |
| `Response(Blob body, ResponseOptions? options)` | Creates a new Response object. |
| `Response(ArrayBuffer body, ResponseOptions? options)` | Creates a new Response object. |
| `Response(ReadableStream body, ResponseOptions? options)` | Creates a new Response object. |
| `Response(TypedArray body, ResponseOptions? options)` | Creates a new Response object. |
| `Response(DataView body, ResponseOptions? options)` | Creates a new Response object. |
| `Response(FormData body, ResponseOptions? options)` | Creates a new Response object. |
| `Response(URLSearchParams body, ResponseOptions? options)` | Creates a new Response object. |
| `Response(string body, Response options)` | Creates a new Response object. |
| `Response(Blob body, Response options)` | Creates a new Response object. |
| `Response(ArrayBuffer body, Response options)` | Creates a new Response object. |
| `Response(ReadableStream body, Response options)` | Creates a new Response object. |
| `Response(TypedArray body, Response options)` | Creates a new Response object. |
| `Response(DataView body, Response options)` | Creates a new Response object. |
| `Response(FormData body, Response options)` | Creates a new Response object. |
| `Response(URLSearchParams body, Response options)` | Creates a new Response object. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Body` | `ReadableStream?` | get | A ReadableStream of the body contents. |
| `BodyUsed` | `bool` | get | Stores a boolean value that declares whether the body has been used in a response yet. |
| `Headers` | `Headers` | get | The Headers object associated with the response. |
| `Ok` | `bool` | get | A boolean indicating whether the response was successful (status in the range 200 - 299) or not. |
| `Redirected` | `bool` | get | Indicates whether or not the response is the result of a redirect (that is, its URL list has more than one entry). |
| `Status` | `ushort` | get | The status code of the response. (This will be 200 for a success). |
| `StatusText` | `string` | get | The status message corresponding to the status code. (e.g., OK for 200). |
| `Type` | `string` | get | The type of the response (e.g., basic, cors). |
| `Url` | `string` | get | The URL of the response. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Error()` | `Response` | Returns a new Response object associated with a network error. |
| `Redirect(string url, ushort status)` | `Response` | Returns a new response with a different URL. The URL that the new response is to originate from. An optional number indicating the status code for the response: one of 301, 302, 303, 307, or 308. If omitted, 302 (Found) is used by default. A Response object. |
| `Redirect(string url)` | `Response` | Returns a new response with a different URL. The URL that the new response is to originate from. A Response object. |
| `Json(object data, ResponseOptions? options)` | `Response` | Returns a new Response object for returning the provided JSON encoded data. The JSON data to be used as the response body. An options object containing settings for the response, including the status code, status text, and headers. This is the same as the options parameter of the Response() constructor. |
| `ArrayBuffer()` | `Task<ArrayBuffer>` | Returns a promise that resolves with an ArrayBuffer representation of the response body. |
| `Blob()` | `Task<Blob>` | Returns a promise that resolves with a Blob representation of the response body. |
| `Bytes()` | `Task<Uint8Array>` | Returns a promise that resolves with a Uint8Array representation of the response body. |
| `Clone()` | `Response` | Creates a clone of a Response object. |
| `FormData()` | `Task<FormData>` | Returns a promise that resolves with a FormData representation of the response body. |
| `Json()` | `Task<T>` | Returns a promise that resolves with the result of parsing the response body text as JSON. |
| `Text()` | `Task<string>` | Returns a promise that resolves with a text representation of the response body. |
| `ReadBytes()` | `Task<byte[]>` | Non-standard method that returns a .Net byte[] |

## Example

```csharp
// Fetch a response from a URL
using var response = await JS.CallAsync<Response>("fetch", "/api/data");

// Check status
if (response.Ok)
{
    ushort status = response.Status;       // 200
    string statusText = response.StatusText; // "OK"

    // Read as text
    string text = await response.Text();

    // Or read as typed JSON
    // var data = await response.Json<MyDataType>();
}

// Read response as binary data
using var binaryResponse = await JS.CallAsync<Response>("fetch", "/files/image.png");
using var arrayBuffer = await binaryResponse.ArrayBuffer();
byte[] bytes = await binaryResponse.Clone().ReadBytes();

// Read response as a Blob
using var blobResponse = await JS.CallAsync<Response>("fetch", "/files/document.pdf");
using var blob = await blobResponse.Blob();

// Read response headers
using var headers = response.Headers;
string contentType = headers.Get("content-type");

// Create a Response manually (useful for Service Workers)
using var customResponse = new Response("Hello, world!", new ResponseOptions
{
    Status = 200,
    StatusText = "OK",
    Headers = new Dictionary<string, string>
    {
        { "Content-Type", "text/plain" }
    }
});

// Create a JSON response
using var jsonResponse = Response.Json(new { message = "success", count = 42 });

// Create a redirect response
using var redirect = Response.Redirect("https://example.com/new-page", 301);

// Clone a response (body can only be consumed once)
using var original = await JS.CallAsync<Response>("fetch", "/api/data");
using var clone = original.Clone();
string text1 = await original.Text();
string text2 = await clone.Text(); // Same data
```

