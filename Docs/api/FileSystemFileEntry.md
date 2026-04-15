# FileSystemFileEntry

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `FileSystemEntry`  
**Source:** `JSObjects/FileSystemFileEntry.cs`  
**MDN Reference:** [FileSystemFileEntry on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemFileEntry)

> The FileSystemFileEntry interface of the File and Directory Entries API represents a file in a file system. It offers properties describing the file's attributes, as well as the file() method, which creates a File object that can be used to read the file. NOTE: Chrome calls this class FileEntry, while Firefox calls it FileSystemFileEntry https://developer.mozilla.org/en-US/docs/Web/API/FileSystemFileEntry

## Methods

| Method | Return Type | Description |
|---|---|---|
| `File(ActionCallback<File> successCallback)` | `void` | The FileSystemFileEntry interface's method file() returns a File object which can be used to read data from the file represented by the directory entry. |
| `File(ActionCallback<File> successCallback, ActionCallback<DOMException> errorCallback)` | `void` | The FileSystemFileEntry interface's method file() returns a File object which can be used to read data from the file represented by the directory entry. |
| `FileAsync()` | `Task<File>` | The FileSystemFileEntry interface's method file() returns a File object which can be used to read data from the file represented by the directory entry. |

