# FileSystemWriteOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/FileSystemWriteOptions.cs`  
**MDN Reference:** [FileSystemWriteOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemWritableFileStream/write#data)

> Options used when calling FileSystemWritableFileStream.Write() https://developer.mozilla.org/en-US/docs/Web/API/FileSystemWritableFileStream/write#data

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `FileSystemWriteOptions` | `class` | get | Options used when calling FileSystemWritableFileStream.Write() https://developer.mozilla.org/en-US/docs/Web/API/FileSystemWritableFileStream/write#data |
| `Data` | `Union<ArrayBuffer, TypedArray, DataView, Blob, string, byte[]>?` | get/set |  |
| `Position` | `ulong?` | get/set |  |
| `Size` | `ulong?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<FileSystemWriteOptions>(...)` or constructor `new FileSystemWriteOptions(...)`

```js
async function saveFile() {
  try {
    // create a new handle
    const newHandle = await window.showSaveFilePicker();

    // create a FileSystemWritableFileStream to write to
    const writableStream = await newHandle.createWritable();

    // write our file
    await writableStream.write("This is my file content");

    // close the file and write the contents to disk.
    await writableStream.close();
  } catch (err) {
    console.error(err.name, err.message);
  }
}
```

```js
// just pass in the data (no options)
writableStream.write(data);

// writes the data to the stream from the determined position
writableStream.write({ type: "write", position, data });

// updates the current file cursor offset to the position specified
writableStream.write({ type: "seek", position });

// resizes the file to be size bytes long
writableStream.write({ type: "truncate", size });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemWritableFileStream/write)*

