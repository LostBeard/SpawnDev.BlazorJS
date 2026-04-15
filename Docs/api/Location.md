# Location

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Location.cs`  
**MDN Reference:** [Location on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Location)

> The Location interface represents the location (URL) of the object it is linked to. Changes done on it are reflected on the object it relates to. Both the Document and Window interface have such a linked Location, accessible via Document.location and Window.location respectively. https://developer.mozilla.org/en-US/docs/Web/API/Location

## Constructors

| Signature | Description |
|---|---|
| `Location(IJSInProcessObjectReference _ref)` | Creates a new instance of `Location`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Hash` | `string` | get | A string containing a '#' followed by the fragment identifier of the URL. |
| `Host` | `string` | get | A string containing the host, that is the hostname, a ':', and the port of the URL. |
| `HostName` | `string` | get | A string containing the domain of the URL. |
| `Href` | `string` | get | A stringifier that returns a string containing the entire URL. If changed, the associated document navigates to the new page. It can be set from a different origin than the associated document |
| `Origin` | `string` | get | Returns a string containing the canonical form of the origin of the specific location. |
| `PathName` | `string` | get | A string containing an initial '/' followed by the path of the URL, not including the query string or fragment. |
| `Port` | `string` | get | A string containing the port number of the URL. |
| `Protocol` | `string` | get | A string containing the protocol scheme of the URL, including the final ':' |
| `Search` | `string` | get | A string containing a '?' followed by the parameters or "querystring" of the URL. Modern browsers provide URLSearchParams and URL.searchParams to make it easy to parse out the parameters from the querystring. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Assign(string url)` | `void` | Loads the resource at the URL provided in parameter. |
| `Reload()` | `void` | Reloads the current URL, like the Refresh button. |
| `Replace(string url)` | `void` | Replaces the current resource with the one at the provided URL (redirects to the provided URL). The difference from the assign() method and setting the href property is that after using replace() the current page will not be saved in session History, meaning the user won't be able to use the back button to navigate to it. |
| `ToString()` | `string` | Returns a string containing the whole URL. It is a synonym for Location.href, though it can't be used to modify the value. |

## Example

```csharp
// Get the current window.location
using var location = JS.Get<Location>("window.location");

// Read URL components
Console.WriteLine($"Full URL: {location.Href}");
Console.WriteLine($"Protocol: {location.Protocol}");  // "https:"
Console.WriteLine($"Host: {location.Host}");            // "example.com:8080"
Console.WriteLine($"Hostname: {location.HostName}");    // "example.com"
Console.WriteLine($"Port: {location.Port}");            // "8080"
Console.WriteLine($"Pathname: {location.PathName}");    // "/app/page"
Console.WriteLine($"Search: {location.Search}");        // "?q=hello"
Console.WriteLine($"Hash: {location.Hash}");            // "#section"
Console.WriteLine($"Origin: {location.Origin}");        // "https://example.com:8080"

// Navigate to a new URL (adds to history)
location.Assign("https://example.com/new-page");

// Navigate to a new URL (replaces current history entry - no back button)
location.Replace("https://example.com/redirect-target");

// Reload the current page
location.Reload();

// Set Href directly to navigate
location.Href = "https://example.com/another-page";

// Get the full URL as a string
string urlString = location.ToString();
```

