# FileSystemHandle

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/FileSystemHandle.cs`  
**MDN Reference:** [FileSystemHandle on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemHandle)

> The FileSystemHandle interface of the File System API is an object which represents a file or directory entry. Multiple handles can represent the same entry. For the most part you do not work with FileSystemHandle directly but rather its child interfaces FileSystemFileHandle and FileSystemDirectoryHandle. https://developer.mozilla.org/en-US/docs/Web/API/FileSystemHandle

## Constructors

| Signature | Description |
|---|---|
| `FileSystemHandle(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `string` | get | Returns the name of the associated entry. |
| `Kind` | `string` | get | Returns the type of entry. This is 'file' if the associated entry is a file or 'directory'. |
| `FilePermissionsOptions` | `class` | get | Options for requesting file permissions |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `IsSameEntry(FileSystemHandle fsHandle)` | `bool` | Compares two handles to see if the associated entries (either a file or directory) match. |
| `ResolveType(bool moveJSRef)` | `FileSystemHandle` | Returns a FileSystemDirectoryHandle or FileSystemFileHandle based on the FileSystemHandle.Kind If true, the IJSInProcessReference from this JSObject is moved to the new type instead of copied |
| `ToFileSystemDirectoryHandle(bool moveJSRef)` | `FileSystemDirectoryHandle?` | Returns a FileSystemDirectoryHandle JSObject for this entry if this entry Kind is directory |
| `ToFileSystemFileHandle(bool moveJSRef)` | `FileSystemFileHandle?` | Returns a FileSystemFileHandle JSObject for this entry if this entry Kind is file |
| `GetReadWritePermissions()` | `Task<string>` | Returns a string with "r", "rw", or "" indicating read, write permissions |
| `IsWritable()` | `Task<bool>` | Returns true if the FileSystemHandle is writable |
| `IsReadable()` | `Task<bool>` | Returns true if the FileSystemHandle is readable |
| `QueryPermission(bool writePermission)` | `Task<string>` | Queries the current permission state of the file or directory handle. If true, queries for write permission; otherwise, queries for read permission. A string representing the permission state (e.g., "granted", "denied", "prompt"). |
| `RequestPermission(bool writePermission)` | `Task<string>` | Requests permission to read or write to the file or directory handle. If true, requests write permission; otherwise, requests read permission. A string representing the new permission state (e.g., "granted", "denied", "prompt"). |
| `VerifyPermission(bool readWrite, bool askIfNeeded)` | `Task<bool>` | Verifies if the user has granted the specified permission (read or read/write). Optionally requests permission if it hasn't been granted yet. If true,ifies write permission; otherwise, verifies read permission. If true, requests permission if the current state is "prompt". True if permission is granted, otherwise false. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<FileSystemHandle>(...)` or constructor `new FileSystemHandle(...)`

### Checking Type

```js
// store a reference to our file handle
let fileHandle;

async function getFile() {
  // open file picker
  [fileHandle] = await window.showOpenFilePicker();

  if (fileHandle.kind === "file") {
    // run file code
  } else if (fileHandle.kind === "directory") {
    // run directory code
  }
}
```

### Query/Request Permissions

```js
// fileHandle is a FileSystemFileHandle
// withWrite is a boolean set to true if write

async function verifyPermission(fileHandle, withWrite) {
  const opts = {};
  if (withWrite) {
    opts.mode = "readwrite";
  }

  // Check if we already have permission, if so, return true.
  if ((await fileHandle.queryPermission(opts)) === "granted") {
    return true;
  }

  // Request permission to the file, if the user grants permission, return true.
  if ((await fileHandle.requestPermission(opts)) === "granted") {
    return true;
  }

  // The user did not grant permission, return false.
  return false;
}
```

### Comparing Entries

```js
function removeMatches(fileEntry, entriesArr) {
  const newArr = entriesArr.filter((entry) => !fileEntry.isSameEntry(entry));

  return newArr;
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemHandle)*

