# Clipboard

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Clipboard.cs`  
**MDN Reference:** [Clipboard on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Clipboard)

> The Clipboard API provides the ability to respond to clipboard commands (cut, copy, and paste) as well as to asynchronously read from and write to the system clipboard. https://developer.mozilla.org/en-US/docs/Web/API/Clipboard

## Constructors

| Signature | Description |
|---|---|
| `Clipboard(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Read()` | `Task<ClipboardItem[]>` | Requests arbitrary data (such as images) from the clipboard, returning a Promise that resolves with an array of ClipboardItem objects containing the clipboard's contents. |
| `ReadText()` | `Task<string>` | Requests text from the system clipboard; returns a Promise which is resolved with a string containing the clipboard's text once it's available. |
| `Write(IEnumerable<ClipboardItem> data)` | `Task` | Writes arbitrary data to the system clipboard. This asynchronous operation signals that it's finished by resolving the returned Promise |
| `WriteText(string data)` | `Task` | Writes text to the system clipboard, returning a Promise which is resolved once the text is fully copied into the clipboard. |

## Example

```csharp
// Get the Clipboard object from Navigator
using var navigator = new Navigator();
using var clipboard = navigator.Clipboard;

// Write text to the clipboard
await clipboard.WriteText("Hello from Blazor WASM!");

// Read text from the clipboard
var text = await clipboard.ReadText();
Console.WriteLine($"Clipboard text: {text}");

// Read arbitrary clipboard data (images, files, etc.)
var items = await clipboard.Read();
foreach (var item in items)
{
    // Process each ClipboardItem
    item.Dispose();
}

// Write arbitrary data to the clipboard
// using var clipboardItem = new ClipboardItem(...);
// await clipboard.Write(new[] { clipboardItem });
```

