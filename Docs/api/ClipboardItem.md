# ClipboardItem

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ClipboardItem.cs`  
**MDN Reference:** [ClipboardItem on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ClipboardItem)

> The ClipboardItem interface of the Clipboard API represents a single item format, used when reading or writing clipboard data using clipboard.read() and clipboard.write() respectively. https://developer.mozilla.org/en-US/docs/Web/API/ClipboardItem

## Constructors

| Signature | Description |
|---|---|
| `ClipboardItem(Dictionary<string, Union<string, Blob, Task<string>, Task<Blob>>> data, ClipboardItemOptions? options)` | The ClipboardItem() constructor creates a new ClipboardItem object, which represents data to be stored or retrieved via the Clipboard API clipboard.write() and clipboard.read() methods, respectively. |
| `ClipboardItem(Dictionary<string, string> data, ClipboardItemOptions? options)` | The ClipboardItem() constructor creates a new ClipboardItem object, which represents data to be stored or retrieved via the Clipboard API clipboard.write() and clipboard.read() methods, respectively. |
| `ClipboardItem(Dictionary<string, Blob> data, ClipboardItemOptions? options)` | The ClipboardItem() constructor creates a new ClipboardItem object, which represents data to be stored or retrieved via the Clipboard API clipboard.write() and clipboard.read() methods, respectively. |
| `ClipboardItem(Dictionary<string, Task<string>> data, ClipboardItemOptions? options)` | The ClipboardItem() constructor creates a new ClipboardItem object, which represents data to be stored or retrieved via the Clipboard API clipboard.write() and clipboard.read() methods, respectively. |
| `ClipboardItem(Dictionary<string, Task<Blob>> data, ClipboardItemOptions? options)` | The ClipboardItem() constructor creates a new ClipboardItem object, which represents data to be stored or retrieved via the Clipboard API clipboard.write() and clipboard.read() methods, respectively. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Types` | `string[]` | get | Returns an Array of MIME types available within the ClipboardItem. |
| `PresentationStyle` | `string?` | get | Returns one of the following: "unspecified", "inline" or "attachment". Support varies by browser |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Supports(string type)` | `bool` | Checks whether a given MIME type is supported by the clipboard. This enables a website to detect whether a MIME type is supported before attempting to write data. |
| `GetType(string type)` | `Task<Blob>` | Returns a Promise that resolves with a Blob of the requested MIME type, or an error if the MIME type is not found. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ClipboardItem>(...)` or constructor `new ClipboardItem(...)`

### Writing text to the clipboard

```js
const textSource = document.querySelector("p");
const copyBtn = document.querySelector("button");

async function copyToClipboard() {
  const type = "text/plain";
  const clipboardItemData = {
    [type]: textSource.textContent,
  };
  const clipboardItem = new ClipboardItem(clipboardItemData);
  await navigator.clipboard.write([clipboardItem]);
}

copyBtn.addEventListener("click", copyToClipboard);
```

### Writing an image to the clipboard

```js
async function writeClipImg() {
  try {
    if (ClipboardItem.supports("image/svg+xml")) {
      const imgURL = "/my-image.svg";
      const data = await fetch(imgURL);
      const blob = await data.blob();
      await navigator.clipboard.write([
        new ClipboardItem({
          [blob.type]: blob,
        }),
      ]);
      console.log("Fetched image copied.");
    } else {
      console.log("SVG images are not supported by the clipboard.");
    }
  } catch (err) {
    console.error(err.name, err.message);
  }
}
```

### Reading from the clipboard

```js
async function getClipboardContents() {
  try {
    const clipboardItems = await navigator.clipboard.read();

    for (const clipboardItem of clipboardItems) {
      for (const type of clipboardItem.types) {
        const blob = await clipboardItem.getType(type);
        // we can now use blob here
      }
    }
  } catch (err) {
    console.error(err.name, err.message);
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ClipboardItem)*

