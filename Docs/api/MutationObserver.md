# MutationObserver

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/MutationObserver.cs`  
**MDN Reference:** [MutationObserver on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MutationObserver)

> The MutationObserver interface provides the ability to watch for changes being made to the DOM tree. It is designed as a replacement for the older Mutation Events feature, which was part of the DOM3 Events specification. https://developer.mozilla.org/en-US/docs/Web/API/MutationObserver

## Constructors

| Signature | Description |
|---|---|
| `MutationObserver(ActionCallback<Array<MutationRecord>, MutationObserver> callback)` | Creates a new instance of MutationObserver |
| `MutationObserver(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Disconnect()` | `void` | Stops the MutationObserver instance from receiving further notifications until and unless observe() is called again. |
| `Observe(Node target, MutationObserveOptions options)` | `void` | Configures the MutationObserver to begin receiving notifications through its callback function when DOM changes matching the given options occur. A DOM Node (which may be an Element) within the DOM tree to watch for changes, or to be the root of a subtree of nodes to be watched. An object providing options that describe which DOM mutations should be reported to mutationObserver's callback. At a minimum, one of childList, attributes, and/or characterData must be true when you call observe(). Otherwise, a TypeError exception will be thrown. |
| `TakeRecords()` | `MutationRecord[]` | Removes all pending notifications from the MutationObserver's notification queue and returns them in a new Array of MutationRecord objects. |

## Example

```csharp
// Create the callback for mutation notifications
using var callback = Callback.Create<Array<MutationRecord>, MutationObserver>(
    (mutations, observer) =>
    {
        using var mutationList = mutations;
        foreach (using var mutation in mutationList.ToArray())
        {
            string type = mutation.Type;
            if (type == "childList")
            {
                Console.WriteLine("A child node was added or removed.");
            }
            else if (type == "attributes")
            {
                Console.WriteLine($"Attribute '{mutation.AttributeName}' was modified.");
            }
        }
    });

// Create the MutationObserver
using var observer = new MutationObserver(callback);

// Get the target node to observe
using var document = JS.Get<Document>("document");
using var targetNode = document.GetElementById("some-id");

// Start observing with options
observer.Observe(targetNode, new MutationObserveOptions
{
    Attributes = true,
    ChildList = true,
    Subtree = true
});

// Later, take any pending records
var records = observer.TakeRecords();

// Stop observing
observer.Disconnect();
```

