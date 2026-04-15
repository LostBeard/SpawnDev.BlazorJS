# FileSystemSyncAccessHandle

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/FileSystemSyncAccessHandle.cs`  
**MDN Reference:** [FileSystemSyncAccessHandle on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemSyncAccessHandle)

> https://developer.mozilla.org/en-US/docs/Web/API/FileSystemSyncAccessHandle

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Close()` | `void` | The close() method of the FileSystemSyncAccessHandle interface closes an open synchronous file handle, disabling any further operations on it and releasing the exclusive lock previously put on the file associated with the file handle. |
| `Flush()` | `void` | The flush() method of the FileSystemSyncAccessHandle interface persists any changes made to the file associated with the handle via the write() method to disk. Bear in mind that you only need to call this method if you need the changes committed to disk at a specific time, otherwise you can leave the underlying operating system to handle this when it sees fit, which should be OK in most cases. |
| `GetSize()` | `long` | The getSize() method of the FileSystemSyncAccessHandle interface returns the size of the file associated with the handle in bytes. |
| `Read(ArrayBuffer buffer, FileSystemSyncReadWriteOptions? options)` | `long` | The read() method of the FileSystemSyncAccessHandle interface reads the content of the file associated with the handle into a specified buffer, optionally at a given offset. |
| `Read(TypedArray buffer, FileSystemSyncReadWriteOptions? options)` | `long` | The read() method of the FileSystemSyncAccessHandle interface reads the content of the file associated with the handle into a specified buffer, optionally at a given offset. |
| `Read(DataView buffer, FileSystemSyncReadWriteOptions? options)` | `long` | The read() method of the FileSystemSyncAccessHandle interface reads the content of the file associated with the handle into a specified buffer, optionally at a given offset. |
| `Read(byte[] buffer, FileSystemSyncReadWriteOptions? options)` | `long` | The read() method of the FileSystemSyncAccessHandle interface reads the content of the file associated with the handle into a specified buffer, optionally at a given offset. |
| `Truncate(long newSize)` | `void` | The truncate() method of the FileSystemSyncAccessHandle interface resizes the file associated with the handle to a specified number of bytes. |
| `Write(ArrayBuffer buffer, FileSystemSyncReadWriteOptions? options)` | `long` | The write() method of the FileSystemSyncAccessHandle interface writes the content of a specified buffer to the file associated with the handle, optionally at a given offset. Files within the origin private file system are not visible to end-users, therefore are not subject to the same security checks as methods running on files within the user-visible file system. As a result, writes performed using FileSystemSyncAccessHandle.write() are much more performant. This makes them suitable for significant, large-scale file updates such as SQLite database modifications. |
| `Write(TypedArray buffer, FileSystemSyncReadWriteOptions? options)` | `long` | The write() method of the FileSystemSyncAccessHandle interface writes the content of a specified buffer to the file associated with the handle, optionally at a given offset. Files within the origin private file system are not visible to end-users, therefore are not subject to the same security checks as methods running on files within the user-visible file system. As a result, writes performed using FileSystemSyncAccessHandle.write() are much more performant. This makes them suitable for significant, large-scale file updates such as SQLite database modifications. |
| `Write(DataView buffer, FileSystemSyncReadWriteOptions? options)` | `long` | The write() method of the FileSystemSyncAccessHandle interface writes the content of a specified buffer to the file associated with the handle, optionally at a given offset. Files within the origin private file system are not visible to end-users, therefore are not subject to the same security checks as methods running on files within the user-visible file system. As a result, writes performed using FileSystemSyncAccessHandle.write() are much more performant. This makes them suitable for significant, large-scale file updates such as SQLite database modifications. |
| `Write(byte[] buffer, FileSystemSyncReadWriteOptions? options)` | `long` | The write() method of the FileSystemSyncAccessHandle interface writes the content of a specified buffer to the file associated with the handle, optionally at a given offset. Files within the origin private file system are not visible to end-users, therefore are not subject to the same security checks as methods running on files within the user-visible file system. As a result, writes performed using FileSystemSyncAccessHandle.write() are much more performant. This makes them suitable for significant, large-scale file updates such as SQLite database modifications. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<FileSystemSyncAccessHandle>(...)` or constructor `new FileSystemSyncAccessHandle(...)`

```js
onmessage = async (e) => {
  // Retrieve message sent to work from main script
  const message = e.data;

  // Get handle to draft file
  const root = await navigator.storage.getDirectory();
  const draftHandle = await root.getFileHandle("draft.txt", { create: true });
  // Get sync access handle
  const accessHandle = await draftHandle.createSyncAccessHandle();

  // Get size of the file.
  const fileSize = accessHandle.getSize();
  // Read file content to a buffer.
  const buffer = new DataView(new ArrayBuffer(fileSize));
  const readBuffer = accessHandle.read(buffer, { at: 0 });

  // Write the message to the end of the file.
  const encoder = new TextEncoder();
  const encodedMessage = encoder.encode(message);
  const writeBuffer = accessHandle.write(encodedMessage, { at: readBuffer });

  // Persist changes to disk.
  accessHandle.flush();

  // Always close FileSystemSyncAccessHandle if done.
  accessHandle.close();
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemSyncAccessHandle)*

