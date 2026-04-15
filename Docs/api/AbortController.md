# AbortController

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/AbortController.cs`  
**MDN Reference:** [AbortController on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AbortController)

> The AbortController interface represents a controller object that allows you to abort one or more Web requests as and when desired. https://developer.mozilla.org/en-US/docs/Web/API/AbortController

## Constructors

| Signature | Description |
|---|---|
| `AbortController()` | The AbortController() constructor creates a new AbortController object instance. |
| `AbortController(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Signal` | `AbortSignal` | get | Returns an AbortSignal object instance, which can be used to communicate with, or to abort, a DOM request. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Abort()` | `void` | The abort() method of the AbortController interface aborts a DOM request before it has completed. This is able to abort fetch requests, the consumption of any response bodies, or streams. |
| `Abort(object reason)` | `void` | The abort() method of the AbortController interface aborts a DOM request before it has completed. This is able to abort fetch requests, the consumption of any response bodies, or streams. The reason why the operation was aborted, which can be any JavaScript value. If not specified, the reason is set to "AbortError" DOMException. |

## Example

```csharp
// Create an AbortController and use its signal to cancel a fetch request
using var controller = new AbortController();
using var signal = controller.Signal;

// Pass the signal to fetch via RequestOptions
try
{
    using var response = await JS.CallAsync<Response>(
        "fetch",
        "https://example.com/api/large-data",
        new RequestOptions { Signal = signal }
    );
    var text = await response.Text();
    Console.WriteLine($"Response: {text}");
}
catch (Exception ex)
{
    Console.WriteLine($"Fetch aborted: {ex.Message}");
}

// Abort the request (e.g., on a timeout or user action)
controller.Abort();

// Abort with a custom reason
controller.Abort("User cancelled the request");
```

