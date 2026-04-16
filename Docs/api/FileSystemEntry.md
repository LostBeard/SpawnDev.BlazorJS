# FileSystemEntry

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/FileSystemEntry.cs`  
**MDN Reference:** [FileSystemEntry on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemEntry)

> The FileSystemEntry interface of the File and Directory Entries API represents a single entry in a file system. The entry can be a file or a directory (directories are represented by the FileSystemDirectoryEntry interface). It includes methods for working with files-including copying, moving, removing, and reading files-as well as information about a file it points to-including the file name and its path from the root to the entry. https://developer.mozilla.org/en-US/docs/Web/API/FileSystemEntry

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `FileSystem` | `FileSystem` | get | A FileSystem object representing the file system in which the entry is located. |
| `FullPath` | `string` | get | A string which provides the full, absolute path from the file system's root to the entry; it can also be thought of as a path which is relative to the root directory, prepended with a "/" character. |
| `IsDirectory` | `bool` | get | A boolean value which is true if the entry represents a directory; otherwise, it's false. |
| `IsFile` | `bool` | get | A Boolean which is true if the entry represents a file. If it's not a file, this value is false. |
| `Name` | `string` | get | A string containing the name of the entry (the final part of the path, after the last "/" character). |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetParent(ActionCallback<FileSystemDirectoryEntry> successCallback)` | `void` | The FileSystemEntry interface's method getParent() obtains a FileSystemDirectoryEntry. |
| `GetParent(ActionCallback<FileSystemDirectoryEntry> successCallback, ActionCallback<DOMException> errorCallback)` | `void` | The FileSystemEntry interface's method getParent() obtains a FileSystemDirectoryEntry. |
| `GetParentAsync()` | `Task<FileSystemDirectoryEntry>` | The FileSystemEntry interface's method getParent() obtains a FileSystemDirectoryEntry. |
| `ResolveType(bool moveJSRef)` | `FileSystemEntry` | Returns a FileSystemDirectoryEntry if IsDirectory, FileSystemFileEntry if IsFile, else FileSystemEntry If true, the IJSInProcessReference from this JSObject is moved to the new type instead of copied |
| `ToFileSystemDirectoryEntry(bool moveJSRef)` | `FileSystemDirectoryEntry?` | Returns a FileSystemDirectoryEntry JSObject for this entry if this entry IsDirectory |
| `ToFileSystemFileEntry(bool moveJSRef)` | `FileSystemFileEntry?` | Returns a FileSystemFileEntry JSObject for this entry if this entry IsFile |

## Examples

**JavaScript (MDN):**

```js
// Taking care of the browser-specific prefixes.
window.requestFileSystem =
  window.requestFileSystem || window.webkitRequestFileSystem;

// …

// Opening a file system with temporary storage
window.requestFileSystem(
  TEMPORARY,
  1024 * 1024 /* 1MB */,
  (fs) => {
    fs.root.getFile(
      "log.txt",
      {},
      (fileEntry) => {
        fileEntry.remove(() => {
          console.log("File removed.");
        }, onError);
      },
      onError,
    );
  },
  onError,
);
```

**C# (SpawnDev.BlazorJS):**

```csharp
// Requires: builder.Services.AddBlazorJSRuntime();
// Inject BlazorJSRuntime in your component or service:
// [Inject] BlazorJSRuntime JS { get; set; }

// Taking care of the browser-specific prefixes.
window.requestFileSystem =;
window.requestFileSystem || window.webkitRequestFileSystem;

// …

// Opening a file system with temporary storage
window.requestFileSystem(
TEMPORARY,
1024 * 1024 /* 1MB */,
(fs) => {
fs.root.getFile(
"log.txt",
{},
(fileEntry) => {
fileEntry.remove(() => {
Console.WriteLine("File removed.");
}, onError);
},
onError,
);
},
onError,
);
```

