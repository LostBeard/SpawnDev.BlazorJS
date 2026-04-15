# FileSystemGetEntryOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/FileSystemGetEntryOptions.cs`  
**MDN Reference:** [FileSystemGetEntryOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryEntry/getDirectory#options_parameter)

> Options used for FileSystemDirectoryEntry.GetDirectory method. https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryEntry/getDirectory#options_parameter

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `FileSystemGetEntryOptions` | `class` | get | Options used for FileSystemDirectoryEntry.GetDirectory method. https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryEntry/getDirectory#options_parameter |
| `Exclusive` | `bool?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<FileSystemGetEntryOptions>(...)` or constructor `new FileSystemGetEntryOptions(...)`

```js
let dictionary = null;

function loadDictionaryForLanguage(appDataDirEntry, lang) {
  dictionary = null;

  appDataDirEntry.getDirectory("Dictionaries", {}, (dirEntry) => {
    dirEntry.getFile(`${lang}-dict.json`, {}, (fileEntry) => {
      fileEntry.file((dictFile) => {
        let reader = new FileReader();

        reader.addEventListener("loadend", () => {
          dictionary = JSON.parse(reader.result);
        });

        reader.readAsText(dictFile);
      });
    });
  });
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryEntry/getDirectory)*

