# FileSystemDirectoryEntry

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `FileSystemEntry`  
**Source:** `JSObjects/FileSystemDirectoryEntry.cs`  
**MDN Reference:** [FileSystemDirectoryEntry on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryEntry)

> The FileSystemDirectoryEntry interface of the File and Directory Entries API represents a directory in a file system. It provides methods which make it possible to access and manipulate the files in a directory, as well as to access the entries within the directory. NOTE: Chrome calls this class DirectoryEntry, while Firefox calls it FileSystemDirectoryEntry https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryEntry

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateReader()` | `FileSystemDirectoryReader` | The FileSystemDirectoryEntry interface's method createReader() returns a FileSystemDirectoryReader object which can be used to read the entries in the directory. |
| `GetDirectory(string path, FileSystemGetEntryOptions? options, ActionCallback<FileSystemDirectoryEntry> successCallback, ActionCallback<DOMException> errorCallback)` | `void` | The FileSystemDirectoryEntry interface's method getDirectory() returns a FileSystemDirectoryEntry object corresponding to a directory contained somewhere within the directory subtree rooted at the directory on which it's called. |
| `GetDirectoryAsync(string path, FileSystemGetEntryOptions? options)` | `Task<FileSystemDirectoryEntry>` | Returns a FileSystemDirectoryEntry object representing a directory located at a given path, relative to the directory on which the method is called. |
| `GetFile(string path, FileSystemGetEntryOptions? options, ActionCallback<FileSystemFileEntry> successCallback, ActionCallback<DOMException> errorCallback)` | `void` | The FileSystemDirectoryEntry interface's method getFile() returns a FileSystemFileEntry object corresponding to a file contained somewhere within the directory subtree rooted at the directory on which it's called. |
| `GetFileAsync(string path, FileSystemGetEntryOptions? options)` | `Task<FileSystemFileEntry>` | Returns a FileSystemFileEntry object representing a file located within the directory's hierarchy, given a path relative to the directory on which the method is called. |

## Examples

**JavaScript (MDN):**

```js
// Taking care of the browser-specific prefixes.
window.requestFileSystem =
  window.requestFileSystem || window.webkitRequestFileSystem;
window.directoryEntry = window.directoryEntry || window.webkitDirectoryEntry;

// …

function onFs(fs) {
  fs.root.getDirectory(
    "Documents",
    { create: true },
    (directoryEntry) => {
      // directoryEntry.isFile === false
      // directoryEntry.isDirectory === true
      // directoryEntry.name === 'Documents'
      // directoryEntry.fullPath === '/Documents'
    },
    onError,
  );
}

// Opening a file system with temporary storage
window.requestFileSystem(TEMPORARY, 1024 * 1024 /* 1MB */, onFs, onError);
```

**C# (SpawnDev.BlazorJS):**

```csharp
// Requires: builder.Services.AddBlazorJSRuntime();
// Inject BlazorJSRuntime in your component or service:
// [Inject] BlazorJSRuntime JS { get; set; }

// Taking care of the browser-specific prefixes.
window.requestFileSystem =;
window.requestFileSystem || window.webkitRequestFileSystem;
window.directoryEntry = window.directoryEntry || window.webkitDirectoryEntry;

// …

void onFs(fs)
{
fs.root.GetDirectory(
"Documents",
{ create: true },
(directoryEntry) => {
// directoryEntry.isFile === false
// directoryEntry.isDirectory === true
// directoryEntry.name === 'Documents'
// directoryEntry.fullPath === '/Documents'
},
onError,
);
}

// Opening a file system with temporary storage
window.requestFileSystem(TEMPORARY, 1024 * 1024 /* 1MB */, onFs, onError);
```

