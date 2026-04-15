# FileSystemFileHandle

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `FileSystemHandle`  
**Source:** `JSObjects/FileSystemFileHandle.cs`  
**MDN Reference:** [FileSystemFileHandle on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemFileHandle)

> The FileSystemFileHandle interface of the File System API represents a handle to a file system entry. The interface is accessed through the window.showOpenFilePicker() method. https://developer.mozilla.org/en-US/docs/Web/API/FileSystemFileHandle

## Constructors

| Signature | Description |
|---|---|
| `FileSystemFileHandle(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetFile()` | `Task<File>` | Returns a Promise which resolves to a File object representing the state on disk of the entry represented by the handle. |
| `CreateWritable()` | `Task<FileSystemWritableFileStream>` | Returns a Promise which resolves to a newly created FileSystemWritableFileStream object that can be used to write to a file. |
| `CreateWritable(FileSystemCreateWritableOptions options)` | `Task<FileSystemWritableFileStream>` | Returns a Promise which resolves to a newly created FileSystemWritableFileStream object that can be used to write to a file. |
| `GetSize()` | `Task<long>` | Returns the file's size non-standard |
| `GetLastModified()` | `Task<long>` | Returns the file's last modified value non-standard |
| `CreateSyncAccessHandle(FileSystemSyncAccessOptions? options)` | `Task<FileSystemSyncAccessHandle>` | The createSyncAccessHandle() method of the FileSystemFileHandle interface returns a Promise which resolves to a FileSystemSyncAccessHandle object that can be used to synchronously read from and write to a file. The synchronous nature of this method brings performance advantages, but it is only usable inside dedicated Web Workers for files within the origin private file system. Creating a FileSystemSyncAccessHandle takes an exclusive lock on the file associated with the file handle. This prevents the creation of further FileSystemSyncAccessHandles or FileSystemWritableFileStreams for the file until the existing access handle is closed. |

## Example

```csharp
// Get a file handle from OPFS
using var navigator = JS.Get<Navigator>("navigator");
using var storage = navigator.Storage;
using var root = await storage.GetDirectory();
using var fileHandle = await root.GetFileHandle("data.txt", create: true);

// Write to a file using FileSystemWritableFileStream
await using var writable = await fileHandle.CreateWritable();
await writable.Write("Hello from BlazorJS!");
await writable.Close();

// Read the file back
using var file = await fileHandle.GetFile();
long size = file.Size;
Console.WriteLine($"File size: {size} bytes");

// Read file contents as text
string? text = await FileReader.ReadAsTextAsync(file);
Console.WriteLine($"Content: {text}");

// Get file metadata
long fileSize = await fileHandle.GetSize();
long lastModified = await fileHandle.GetLastModified();

// Use synchronous access handle in a Web Worker (OPFS only)
using var syncHandle = await fileHandle.CreateSyncAccessHandle();
// syncHandle provides synchronous Read/Write/Flush/Close
```

