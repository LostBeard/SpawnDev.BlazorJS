# StorageEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/StorageEvent.cs`  

> The StorageEvent interface is implemented by the storage event, which is sent to a window when a storage area it has access to is changed within the context of another document.

## Constructors

| Signature | Description |
|---|---|
| `StorageEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Key` | `string` | get | Returns a string representing the key of the storage item which was changed. The key property is null when the change is caused by the storage clear() method. |
| `OldValue` | `string` | get | Returns a string representing the old value of the key which was changed. This is null when a new item is added. |
| `NewValue` | `string` | get | Returns a string representing the new value of the key which was changed. This value is null when an item is removed. |
| `Url` | `string` | get | Returns a string representing the URL of the document whose key was changed. |
| `StorageArea` | `Storage` | get | Returns a Storage object representing the storage area that was affected. |

