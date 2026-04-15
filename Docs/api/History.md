# History

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/History.cs`  
**MDN Reference:** [History on MDN](https://developer.mozilla.org/en-US/docs/Web/API/History)

> The History interface allows manipulation of the browser session history, that is the pages visited in the tab or frame that the current page is loaded in. https://developer.mozilla.org/en-US/docs/Web/API/History

## Constructors

| Signature | Description |
|---|---|
| `History(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get/set | Returns an Integer representing the number of elements in the session history, including the currently loaded page. For example, for a page loaded in a new tab this property returns 1 |
| `ScrollRestoration` | `string` | get | Allows web applications to explicitly set default scroll restoration behavior on history navigation. This property can be either auto or manual |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `StateAs()` | `T` | Returns an any value representing the state at the top of the history stack. This is a way to look at the state without having to wait for a popstate event |
| `Back()` | `void` | Causes the browser to move back one page in the session history. It has the same effect as calling history.go(-1). If there is no previous page, this method call does nothing. |
| `Forward()` | `void` | Causes the browser to move forward one page in the session history. It has the same effect as calling history.go(1). |
| `Go(int delta)` | `void` | Loads a page from the session history, identified by its relative location to the current page, for example -1 for the previous page or 1 for the next page. |
| `PushState(object state, string unused)` | `void` | Pushes the given data onto the session history stack with the specified title (and, if provided, URL). |
| `PushState(object state, string unused, string url)` | `void` | Pushes the given data onto the session history stack with the specified title (and, if provided, URL). |
| `ReplaceState(object state, string unused)` | `void` | Updates the most recent entry on the history stack to have the specified data, title, and, if provided, URL. |
| `ReplaceState(object state, string unused, string url)` | `void` | Updates the most recent entry on the history stack to have the specified data, title, and, if provided, URL. |

## Example

```csharp
// Get the browser history object
using var history = JS.Get<History>("window.history");

// Check how many entries are in the session history
Console.WriteLine($"History length: {history.Length}");

// Get the scroll restoration mode
Console.WriteLine($"Scroll restoration: {history.ScrollRestoration}");

// Push a new entry onto the history stack with state and URL
history.PushState(new { page = 2 }, "", "/page/2");

// Push another entry
history.PushState(new { page = 3 }, "", "/page/3");

// Replace the current entry (does not add a new entry)
history.ReplaceState(new { page = 3, updated = true }, "", "/page/3?v=2");

// Read the current state
var state = history.StateAs<Dictionary<string, object>>();

// Navigate back one page
history.Back();

// Navigate forward one page
history.Forward();

// Navigate relative to current position (-2 = two pages back)
history.Go(-2);

// Set scroll restoration behavior
history.ScrollRestoration = "manual";
```

