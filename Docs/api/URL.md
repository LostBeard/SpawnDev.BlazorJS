# URL

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/URL.cs`  
**MDN Reference:** [URL on MDN](https://developer.mozilla.org/en-US/docs/Web/API/URL)

> The URL interface is used to parse, construct, normalize, and encode URLs. It works by providing properties which allow you to easily read and modify the components of a URL. https://developer.mozilla.org/en-US/docs/Web/API/URL

## Constructors

| Signature | Description |
|---|---|
| `URL(string url)` | The URL() constructor returns a newly created URL object representing the URL defined by the parameters. A string or any other object with a stringifier - including, for example, an a or area element - that represents an absolute or relative URL. If url is a relative URL, base is required, and will be used as the base URL. If url is an absolute URL, a given base will be ignored. |
| `URL(string url, string baseHref)` | The URL() constructor returns a newly created URL object representing the URL defined by the parameters. A string or any other object with a stringifier - including, for example, an a or area element - that represents an absolute or relative URL. If url is a relative URL, base is required, and will be used as the base URL. If url is an absolute URL, a given base will be ignored. A string representing the base URL to use in cases where url is a relative URL. If not specified, it defaults to undefined |
| `URL(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Hash` | `string` | get | A string containing a '#' followed by the fragment identifier of the URL. |
| `Host` | `string` | get/set | A string containing the domain (that is the hostname) followed by (if a port was specified) a ':' and the port of the URL. |
| `Hostname` | `string` | get/set | A string containing the domain of the URL. |
| `Href` | `string` | get | A stringifier that returns a string containing the whole URL. |
| `Origin` | `string` | get | Returns a string containing the origin of the URL, that is its scheme, its domain and its port. |
| `Password` | `string` | get | A string containing the password specified before the domain name. |
| `Pathname` | `string` | get/set | A string containing an initial '/' followed by the path of the URL, not including the query string or fragment. |
| `Port` | `string` | get | A string containing the port number of the URL. |
| `Protocol` | `string` | get | A string containing the protocol scheme of the URL, including the final ':'. |
| `Search` | `string` | get | A string indicating the URL's parameter string; if any parameters are provided, this string includes all of them, beginning with the leading ? character. |
| `SearchParams` | `URLSearchParams` | get | A URLSearchParams object which can be used to access the individual query parameters found in search. |
| `Username` | `string` | get | A string containing the username specified before the domain name. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateObjectURL(Blob obj)` | `string` | Returns a string containing a unique blob URL, that is a URL with blob: as its scheme, followed by an opaque string uniquely identifying the object in the browser. |
| `RevokeObjectURL(string objectUrl)` | `void` | Revokes an object URL previously created using URL.createObjectURL(). |
| `ToString()` | `string` | Returns a string containing the whole URL. It is a synonym for URL.href, though it can't be used to modify the value |
| `string(URL url)` | `implicit operator` | Returns a string containing the whole URL. It is a synonym for URL.href, though it can't be used to modify the value |

## Example

```csharp
// Parse a URL and access its components
using var url = new URL("https://user:pass@example.com:8080/path/page?q=hello&lang=en#section");

Console.WriteLine($"Protocol: {url.Protocol}");   // "https:"
Console.WriteLine($"Username: {url.Username}");    // "user"
Console.WriteLine($"Password: {url.Password}");    // "pass"
Console.WriteLine($"Hostname: {url.Hostname}");    // "example.com"
Console.WriteLine($"Port: {url.Port}");            // "8080"
Console.WriteLine($"Host: {url.Host}");            // "example.com:8080"
Console.WriteLine($"Origin: {url.Origin}");        // "https://example.com:8080"
Console.WriteLine($"Pathname: {url.Pathname}");    // "/path/page"
Console.WriteLine($"Search: {url.Search}");        // "?q=hello&lang=en"
Console.WriteLine($"Hash: {url.Hash}");            // "#section"
Console.WriteLine($"Href: {url.Href}");            // full URL

// Access query parameters via SearchParams
using var searchParams = url.SearchParams;

// Resolve a relative URL against a base
using var relative = new URL("/api/data", "https://example.com");
Console.WriteLine(relative.Href); // "https://example.com/api/data"

// Modify URL properties
url.Pathname = "/new/path";
url.Hash = "#updated";

// Create and revoke object URLs for Blobs
using var blob = new Blob(new[] { "file content" }, new BlobOptions { Type = "text/plain" });
var objectUrl = URL.CreateObjectURL(blob);
// ... use objectUrl in an anchor, image, etc. ...
URL.RevokeObjectURL(objectUrl);

// Implicit string conversion
string urlString = url; // calls ToString() implicitly
```

