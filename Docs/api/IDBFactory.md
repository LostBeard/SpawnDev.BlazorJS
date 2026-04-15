# IDBFactory

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/IDBFactory.cs`  
**MDN Reference:** [IDBFactory on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBFactory)

> The IDBFactory interface of the IndexedDB API lets applications asynchronously access the indexed databases. The object that implements the interface is window.indexedDB. You open - that is, create and access - and delete a database with this object, and not directly with IDBFactory. https://developer.mozilla.org/en-US/docs/Web/API/IDBFactory

## Constructors

| Signature | Description |
|---|---|
| `IDBFactory(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `IDBFactory()` | Returns the global instance indexedDB |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Open(string dbName, long dbVersion)` | `IDBOpenDBRequest` | The current method to request opening a connection to a database. |
| `Open(string dbName)` | `IDBOpenDBRequest` | The current method to request opening a connection to a database. |
| `OpenAsync(string dbName, Action<IDBVersionChangeEvent>? onUpgradeNeeded)` | `Task<IDBDatabase>` | The current async method to request opening a connection to a database. |
| `OpenAsync(string dbName, long dbVersion, Action<IDBVersionChangeEvent>? onUpgradeNeeded)` | `Task<IDBDatabase>` | The current async method to request opening a connection to a database. |
| `DeleteDatabase(string dbName)` | `IDBOpenDBRequest` | A method to request the deletion of a database. |
| `DeleteDatabaseAsync(string dbName)` | `Task` | A method to request the deletion of a database. |
| `Databases()` | `Task<List<IDBDatabaseInfo>>` | A method that returns a list of all available databases, including their names and versions. |
| `Cmp(TKey first, TKey second)` | `int` | The cmp() method of the IDBFactory interface compares two values as keys to determine equality and ordering for IndexedDB operations, such as storing and iterating. The first key to compare. The second key to compare. An integer that indicates the result of the comparison: -1 - 1st key is less than the 2nd key 0 - 1st key is equal to the 2nd key 1 - 1st key is greater than the 2nd key |

## Example

```csharp
// Open (or create) a database with a typed object store using the async convenience API.
// The onUpgradeNeeded callback runs when the database is first created or the version increases.
using var db = await IDBDatabase.OpenAsync("MyAppDB", 1, (IDBVersionChangeEvent e) =>
{
    // Get the database from the request's result
    using var request = e.Target;
    using var upgradeDb = request.Result;
    // Create a typed object store with string keys and dictionary values
    using var store = upgradeDb.CreateObjectStore<string, Dictionary<string, object>>(
        "settings",
        new IDBObjectStoreCreateOptions { KeyPath = "key" }
    );
    e.Dispose();
});

Console.WriteLine($"Database: {db.Name}, Version: {db.Version}");
Console.WriteLine($"Object stores: {string.Join(", ", db.ObjectStoreNames)}");

// Write data using a readwrite transaction
using var writeTx = db.Transaction("settings", true);
using var writeStore = writeTx.ObjectStore<string, Dictionary<string, object>>("settings");
await writeStore.PutAsync(new Dictionary<string, object>
{
    { "key", "theme" },
    { "value", "dark" }
});

// Read data back
using var readTx = db.Transaction("settings");
using var readStore = readTx.ObjectStore<string, Dictionary<string, object>>("settings");
var result = await readStore.GetAsync("theme");
Console.WriteLine($"Theme: {result?["value"]}");

// Count records
var count = await readStore.CountAsync();
Console.WriteLine($"Total records: {count}");

// List all available databases
using var factory = new IDBFactory();
var databases = await factory.Databases();
foreach (var dbInfo in databases)
{
    Console.WriteLine($"  {dbInfo.Name} v{dbInfo.Version}");
}

// Delete a database
await factory.DeleteDatabaseAsync("OldDatabase");

// Close the database when done
db.Close();
```

