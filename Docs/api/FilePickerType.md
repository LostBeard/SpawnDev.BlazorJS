# FilePickerType

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/FilePickerType.cs`  
**MDN Reference:** [FilePickerType on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker#description)

> https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker#description

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `FilePickerType` | `class` | get/set | https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker#description |
| `Accept` | `Dictionary<string, IEnumerable<string>>?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<FilePickerType>(...)` or constructor `new FilePickerType(...)`

```js
const pickerOpts = {
  types: [
    {
      description: "Images",
      accept: {
        "image/*": [".png", ".gif", ".jpeg", ".jpg"],
      },
    },
  ],
  excludeAcceptAllOption: true,
  multiple: false,
};
```

```js
// create a reference for our file handle
let fileHandle;

async function getFile() {
  // open file picker, destructure the one element returned array
  [fileHandle] = await window.showOpenFilePicker(pickerOpts);

  // run code with our fileHandle
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker)*

