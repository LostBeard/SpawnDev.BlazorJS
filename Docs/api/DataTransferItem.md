# DataTransferItem

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DataTransferItem.cs`  
**MDN Reference:** [DataTransferItem on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DataTransferItem)

> The DataTransferItem object represents one drag data item. During a drag operation, each drag event has a dataTransfer property which contains a list of drag data items. Each item in the list is a DataTransferItem object. https://developer.mozilla.org/en-US/docs/Web/API/DataTransferItem

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Kind` | `string` | get | The kind of drag data item, string or file. |
| `Type` | `string` | get | The drag data item's type, typically a MIME type. |
| `HasGetAsEntry` | `bool` | get | Returns true if the method exists, otherwise false. |
| `HasWebkitGetAsEntry` | `bool` | get | Returns true if the method exists, otherwise false. |
| `HasGetAsFileSystemHandle` | `bool` | get | Returns true if the method exists, otherwise false. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetAsFile()` | `File?` | Returns the File object associated with the drag data item (or null if the drag item is not a file). |
| `GetAsFileSystemHandle()` | `Task<FileSystemHandle?>` | Returns a FileSystemFileHandle if the dragged item is a file, or a FileSystemDirectoryHandle if the dragged item is a directory. Returns a FileSystemFileHandle, a FileSystemDirectoryHandle, or null |
| `GetAsString()` | `string?` | Invokes the specified callback with the drag data item string as its argument. |
| `GetAsEntry()` | `FileSystemEntry?` | Returns a FileSystemEntry object if the drag data item is a file or directory, or null otherwise. webkitGetAsEntry is used if it is found, getAsEntry is used if it is found, otherwise null is returned. A FileSystemDirectoryEntry, a FileSystemFileEntry, a FileSystemEntry, or null |

