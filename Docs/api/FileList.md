# FileList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`, `IEnumerable<File>`  
**Source:** `JSObjects/FileList.cs`  
**MDN Reference:** [FileList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileList)

> The FileList interface represents an object of this type returned by the files property of the HTML input element; this lets you access the list of files selected with the input type="file" element. It's also used for a list of files dropped into web content when using the drag and drop API; see the DataTransfer object for details on this usage. https://developer.mozilla.org/en-US/docs/Web/API/FileList

## Constructors

| Signature | Description |
|---|---|
| `FileList(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | A read-only value indicating the number of files in the list. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetEnumerator()` | `IEnumerator<File>` |  |
| `Item(int index)` | `File` | Returns a File object representing the file at the specified index in the file list. |
| `FirstOrDefault()` | `File?` | Returns first or default |
| `LastOrDefault()` | `File?` | Returns last or default |
| `ToArray()` | `File[]` | Returns the array as a .Net Array |
| `ToArray(int start, int count)` | `File[]` | Returns the array as a .Net Array |
| `ToList()` | `List<File>` | Returns the array as a .Net List |
| `ToList(int start, int count)` | `List<File>` | Returns the array as a .Net List |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<FileList>(...)` or constructor `new FileList(...)`

### Logging filenames

```js
const output = document.querySelector(".output");
const fileInput = document.querySelector("#myfiles");

fileInput.addEventListener("change", () => {
  for (const file of fileInput.files) {
    output.innerText += `\n${file.name}`;
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileList)*

