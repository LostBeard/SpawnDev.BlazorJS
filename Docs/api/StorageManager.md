# StorageManager

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/StorageManager.cs`  
**MDN Reference:** [StorageManager on MDN](https://developer.mozilla.org/en-US/docs/Web/API/StorageManager)

> The StorageManager interface of the Storage API provides an interface for managing persistence permissions and estimating available storage. You can get a reference to this interface using either navigator.storage or WorkerNavigator.storage. https://developer.mozilla.org/en-US/docs/Web/API/StorageManager

## Constructors

| Signature | Description |
|---|---|
| `StorageManager(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Supported` | `bool` | get | Returns true if OffscreenCanvas appears to be supported |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Persisted()` | `Task<bool>` | Returns a Promise that resolves to true if persistence has already been granted for your site's storage. |
| `Persist()` | `Task<bool>` | Returns a Promise that resolves to true if the user agent is able to persist your site's storage. |
| `Estimate()` | `Task<StorageManagerEstimate>` | Returns a Promise that resolves to an object containing usage and quota numbers for your origin. |
| `GetDirectory()` | `Task<FileSystemDirectoryHandle>` | The getDirectory() method of the StorageManager interface is used to obtain a reference to a FileSystemDirectoryHandle object allowing access to a directory and its contents, stored in the origin private file system (OPFS). |

