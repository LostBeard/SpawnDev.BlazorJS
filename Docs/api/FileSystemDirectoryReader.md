# FileSystemDirectoryReader

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/FileSystemDirectoryReader.cs`  
**MDN Reference:** [FileSystemDirectoryReader on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryReader)

> The FileSystemDirectoryReader interface of the File and Directory Entries API lets you access the FileSystemFileEntry-based objects (generally FileSystemFileEntry or FileSystemDirectoryEntry) representing each entry in a directory. https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryReader

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ReadEntries(ActionCallback<Array<FileSystemEntry>> successCallback)` | `void` | The FileSystemDirectoryReader interface's readEntries() method retrieves the directory entries within the directory being read and delivers them in an array to a provided callback function. |
| `ReadEntries(ActionCallback<Array<FileSystemEntry>> successCallback, ActionCallback<DOMException> errorCallback)` | `void` | The FileSystemDirectoryReader interface's readEntries() method retrieves the directory entries within the directory being read and delivers them in an array to a provided callback function. |
| `ReadEntriesAsync()` | `Task<Array<FileSystemEntry>>` | Returns an array containing some number of the directory's entries. Each item in the array is an object based on FileSystemEntry-typically either FileSystemFileEntry or FileSystemDirectoryEntry. |

