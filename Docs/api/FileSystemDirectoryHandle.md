# FileSystemDirectoryHandle

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `FileSystemHandle`  
**Source:** `JSObjects/FileSystemDirectoryHandle.cs`  
**MDN Reference:** [FileSystemDirectoryHandle on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryHandle)

> The FileSystemDirectoryHandle interface of the File System API provides a handle to a file system directory. https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryHandle

## Constructors

| Signature | Description |
|---|---|
| `FileSystemDirectoryHandle(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetDirectoryHandle(string name, bool create)` | `Task<FileSystemDirectoryHandle>` | Returns a Promise fulfilled with a FileSystemDirectoryHandle for a subdirectory with the specified name within the directory handle on which the method is called. |
| `GetFileHandle(string name, bool create)` | `Task<FileSystemFileHandle>` | Returns a Promise fulfilled with a FileSystemFileHandle for a file with the specified name, within the directory the method is called. |
| `RemoveEntry(string name, bool recursive)` | `Task` | Attempts to asynchronously remove an entry if the directory handle contains a file or directory called the name specified. A string representing the FileSystemHandle.name of the entry you wish to remove. A boolean value, which defaults to false. When set to true entries will be removed recursively. |
| `Resolve(FileSystemHandle possibleDescendant)` | `Task<List<string>?>` | The resolve() method of the FileSystemDirectoryHandle interface returns an Array of directory names from the parent handle to the specified child entry, with the name of the child entry as the last array item. The FileSystemHandle from which to return the relative path. A Promise which resolves with an Array of strings, or null if possibleDescendant is not a descendant of this FileSystemDirectoryHandle. |
| `EntriesDictionary()` | `Task<Dictionary<string, FileSystemHandle>>` | Returns Entries as a Dictionary |
| `ValuesEnumerable()` | `IAsyncEnumerable<FileSystemHandle>` | Returns a new async iterator containing the values for each index in the FileSystemDirectoryHandle object. |
| `KeysEnumerable()` | `IAsyncEnumerable<string>` | Returns a new async iterator containing the keys for each item in FileSystemDirectoryHandle. |
| `Values()` | `AsyncIterator<FileSystemHandle>` | Returns a new async iterator containing the values for each index in the FileSystemDirectoryHandle object. |
| `ValuesList()` | `Task<List<FileSystemHandle>>` | Returns Values as a List FileSystemHandle types are resolved to FileSystemFileHandle, or FileSystemDirectoryHandle depending on their type |
| `Keys()` | `AsyncIterator<string>` | Returns a new async iterator containing the keys for each item in FileSystemDirectoryHandle. |
| `KeysList()` | `Task<List<string>>` | Returns a new async iterator containing the keys for each item in FileSystemDirectoryHandle. |

## Example

```csharp
// Get the Origin Private File System (OPFS) root directory
using var navigator = JS.Get<Navigator>("navigator");
using var storage = navigator.Storage;
using var root = await storage.GetDirectory();

// Create or get a subdirectory
using var dataDir = await root.GetDirectoryHandle("app-data", create: true);

// Create or get a file handle inside the directory
using var fileHandle = await dataDir.GetFileHandle("config.json", create: true);

// List all entries in the directory
var entries = await dataDir.EntriesDictionary();
foreach (var (name, handle) in entries)
{
    Console.WriteLine($"{name}: {handle.Kind}");
    handle.Dispose();
}

// Iterate entries as an async enumerable
await foreach (var (name, handle) in dataDir.EntriesEnumerable())
{
    Console.WriteLine($"Entry: {name}");
    handle.Dispose();
}

// Get just the file/directory names
List<string> names = await dataDir.KeysList();

// Remove an entry
await dataDir.RemoveEntry("old-file.txt");

// Remove a directory recursively
await dataDir.RemoveEntry("temp-folder", recursive: true);

// Resolve a path from root to a descendant handle
List<string>? path = await root.Resolve(fileHandle);
if (path != null)
{
    Console.WriteLine($"Path: {string.Join("/", path)}");
}
```

