# IDBDatabaseTransactionOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/IDBDatabaseTransactionOptions.cs`  

> Options for IDBDatabase.Transaction

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IDBDatabaseTransactionOptions` | `class` | get | Options for IDBDatabase.Transaction |
| `Durability` | `string?` | get/set | "default", "strict", or "relaxed". The default is "default". Using "relaxed" provides better performance, but with fewer guarantees. Web applications are encouraged to use "relaxed" for ephemeral data such as caches or quickly changing records, and "strict" in cases where reducing the risk of data loss outweighs the impact to performance and power. |

