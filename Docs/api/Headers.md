# Headers

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Headers.cs`  
**MDN Reference:** [Headers on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Headers)

> The Headers interface of the Fetch API allows you to perform various actions on HTTP request and response headers. These actions include retrieving, setting, adding to, and removing headers from the list of the request's headers. https://developer.mozilla.org/en-US/docs/Web/API/Headers

## Constructors

| Signature | Description |
|---|---|
| `Headers(IJSInProcessObjectReference _ref)` | The Request() constructor creates a new Request object. |
| `Headers()` | Creates a new Headers object. |
| `Headers(Dictionary<string, string> init)` | Creates a new Headers object. |
| `Headers(Headers init)` | Creates a new Headers object. |
| `Headers(List<(string, string)` | Creates a new Headers object. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Append(string name, string value)` | `void` | Appends a new value onto an existing header inside a Headers object, or adds the header if it does not already exist. |
| `Delete(string name)` | `void` | Deletes a header from a Headers object. |
| `Get(string name)` | `string` | Returns a String sequence of all the values of a header within a Headers object with a given name. Values are separated by a command and a space (", ") |
| `GetSetCookie()` | `List<string>` | Returns an array containing the values of all Set-Cookie headers associated with a response. |
| `Has(string name)` | `bool` | Returns a boolean stating whether a Headers object contains a certain header. |
| `Keys()` | `List<string>` | Returns an iterator allowing you to go through all keys of the key/value pairs contained in this object. |
| `Set(string name, string value)` | `void` | Sets a new value for an existing header inside a Headers object, or adds the header if it does not already exist. |
| `Values()` | `List<string>` | Returns an iterator allowing you to go through all values of the key/value pairs contained in this object. |

## Example

```csharp
// Create an empty Headers object
using var headers = new Headers();

// Add headers with Append (allows multiple values for the same key)
headers.Append("Accept", "application/json");
headers.Append("Accept", "text/plain");

// Set a header (replaces any existing values)
headers.Set("Content-Type", "application/json");

// Read a header value
string contentType = headers.Get("Content-Type"); // "application/json"

// Check if a header exists
bool hasAuth = headers.Has("Authorization"); // false

// Delete a header
headers.Delete("Accept");

// Create Headers from a dictionary
using var initHeaders = new Headers(new Dictionary<string, string>
{
    { "Content-Type", "application/json" },
    { "Authorization", "Bearer token123" },
    { "X-Custom-Header", "custom-value" }
});

// Iterate over all keys and values
List<string> keys = initHeaders.Keys();
List<string> values = initHeaders.Values();
List<(string, string)> entries = initHeaders.Entries();

foreach (var (key, value) in entries)
{
    Console.WriteLine($"{key}: {value}");
}

// Use Headers with a Request
using var request = new Request("https://api.example.com/data", new RequestOptions
{
    Method = "GET",
    Headers = new Dictionary<string, string>
    {
        { "Accept", "application/json" }
    }
});

// Read headers from a Response
using var response = await JS.CallAsync<Response>("fetch", request);
using var responseHeaders = response.Headers;
string serverType = responseHeaders.Get("content-type");
```

