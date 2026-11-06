# IDBObjectStoreCreateOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/IDBObjectStoreCreateOptions.cs`  

> Options for IDBDatabase.CreateObjectStore

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IDBObjectStoreCreateOptions` | `class` | get | Options for IDBDatabase.CreateObjectStore |
| `AutoIncrement` | `bool?` | get |  |
| `KeyPath` | `Union<string, string[]>?` | get/set | The key path to be used by the new object store. If empty or not specified, the object store is created without a key path and uses out-of-line keys. You can also pass in an array as a keyPath. A valid key path can include one of the following: an empty string, a JavaScript identifier, or multiple JavaScript identifiers separated by periods or an array containing any of those. It cannot include spaces. |

