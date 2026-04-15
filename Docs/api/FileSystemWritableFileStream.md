# FileSystemWritableFileStream

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `WritableStream`  
**Source:** `JSObjects/FileSystemWritableFileStream.cs`  
**MDN Reference:** [FileSystemWritableFileStream on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemWritableFileStream)

> The FileSystemWritableFileStream interface of the File System API is a WritableStream object with additional convenience methods, which operates on a single file on disk. The interface is accessed through the FileSystemFileHandle.createWritable() method. https://developer.mozilla.org/en-US/docs/Web/API/FileSystemWritableFileStream

## Constructors

| Signature | Description |
|---|---|
| `FileSystemWritableFileStream(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Write(ArrayBuffer data)` | `Task` | The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset. |
| `Write(Blob data)` | `Task` | The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset. |
| `Write(TypedArray data)` | `Task` | The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset. |
| `Write(byte[] data)` | `Task` | The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset. |
| `Write(DataView data)` | `Task` | The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset. |
| `Write(string data)` | `Task` | The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset. |
| `Write(FileSystemWriteOptions data)` | `Task` | The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset. |
| `Truncate(ulong size)` | `Task` | Resizes the file associated with the stream to be the specified size in bytes. |
| `Seek(ulong position)` | `Task` | Updates the current file cursor offset to the position (in bytes) specified. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<FileSystemWritableFileStream>(...)` or constructor `new FileSystemWritableFileStream(...)`

```js
async function saveFile() {
  // create a new handle
  const newHandle = await window.showSaveFilePicker();

  // create a FileSystemWritableFileStream to write to
  const writableStream = await newHandle.createWritable();

  // write our file
  await writableStream.write("This is my file content");

  // close the file and write the contents to disk.
  await writableStream.close();
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

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemWritableFileStream)*

