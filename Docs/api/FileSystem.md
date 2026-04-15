# FileSystem

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/FileSystem.cs`  
**MDN Reference:** [FileSystem on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystem)

> The File and Directory Entries API interface FileSystem is used to represent a file system. These objects can be obtained from the filesystem property on any file system entry. Some browsers offer additional APIs to create and manage file systems, such as Chrome's requestFileSystem() method. This interface will not grant you access to the users' filesystem. Instead, you will have a "virtual drive" within the browser sandbox if you want to gain access to the users' file system, you need to invoke the user, for example by installing a Chrome extension. The relevant Chrome API can be found here. NOTE: Chrome calls this class DOMFileSystem, while Firefox calls it FileSystem https://developer.mozilla.org/en-US/docs/Web/API/FileSystem

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `string` | get | A string representing the file system's name. This name is unique among the entire list of exposed file systems. |
| `Root` | `FileSystemEntry` | get | A FileSystemDirectoryEntry object which represents the file system's root directory. Through this object, you can gain access to all files and directories in the file system. |

