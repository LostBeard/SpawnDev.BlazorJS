# IndexedDB

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**MDN Reference:** [IndexedDB API](https://developer.mozilla.org/en-US/docs/Web/API/IndexedDB_API)

> The IndexedDB API provides a persistent, structured data store in the browser. SpawnDev.BlazorJS wraps the full IndexedDB API surface with strongly-typed generics for keys and values. The main classes are `IDBFactory`, `IDBDatabase`, `IDBTransaction`, `IDBObjectStore<TKey, TValue>`, `IDBIndex<TIndexKey, TPrimaryKey, TValue>`, `IDBCursor<TKey, TPrimaryKey, TValue>`, `IDBCursorWithValue<TKey, TPrimaryKey, TValue>`, `IDBKeyRange<TKey>`, `IDBRequest`, and `IDBOpenDBRequest`. All request-based operations have both synchronous (`IDBRequest`-returning) and async (`Task`-returning) variants.

---

## IDBFactory

**Inheritance:** `JSObject` -> `IDBFactory`  
**MDN Reference:** [IDBFactory](https://developer.mozilla.org/en-US/docs/Web/API/IDBFactory)

> Entry point for IndexedDB operations. Accessed globally via `indexedDB`.

### Constructors

| Signature | Description |
|-----------|-------------|
| `IDBFactory()` | Gets the global `indexedDB` instance. |
| `IDBFactory(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

### Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Open(string dbName)` | `IDBOpenDBRequest` | Opens a database connection (latest version). |
| `Open(string dbName, long dbVersion)` | `IDBOpenDBRequest` | Opens a database at a specific version. |
| `OpenAsync(string dbName, Action<IDBVersionChangeEvent>? onUpgradeNeeded = null)` | `Task<IDBDatabase>` | Async open with optional upgrade callback. |
| `OpenAsync(string dbName, long dbVersion, Action<IDBVersionChangeEvent>? onUpgradeNeeded = null)` | `Task<IDBDatabase>` | Async open at specific version with optional upgrade callback. |
| `DeleteDatabase(string dbName)` | `IDBOpenDBRequest` | Deletes a database. |
| `DeleteDatabaseAsync(string dbName)` | `Task` | Async database deletion. |
| `Databases()` | `Task<List<IDBDatabaseInfo>>` | Lists all available databases with names and versions. |
| `Cmp<TKey>(TKey first, TKey second)` | `int` | Compares two keys. Returns -1, 0, or 1. |

---

## IDBDatabase

**Inheritance:** `JSObject` -> `EventTarget` -> `IDBDatabase`  
**MDN Reference:** [IDBDatabase](https://developer.mozilla.org/en-US/docs/Web/API/IDBDatabase)

> Represents a connection to a database.

### Static Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsSupported` | `bool` | `true` if `indexedDB` is available in the current context. |

### Static Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Open(string dbName)` | `IDBOpenDBRequest` | Opens a database using the global `indexedDB`. |
| `Open(string dbName, long dbVersion)` | `IDBOpenDBRequest` | Opens at a specific version. |
| `OpenAsync(string dbName, ...)` | `Task<IDBDatabase>` | Async open variants matching `IDBFactory`. |

### Instance Properties

| Property | Type | Description |
|----------|------|-------------|
| `Name` | `string` | The database name. |
| `Version` | `long` | The database version number. |
| `ObjectStoreNames` | `string[]` | Names of all object stores in the database. |

### Instance Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Close()` | `void` | Closes the connection. |
| `CreateObjectStore<TKey, TValue>(string storeName, IDBObjectStoreCreateOptions? options = null)` | `IDBObjectStore<TKey, TValue>` | Creates a new object store (only during upgrade). |
| `DeleteObjectStore(string storeName)` | `void` | Deletes an object store (only during upgrade). |
| `Transaction(Union<string, IEnumerable<string>> storeNames)` | `IDBTransaction` | Opens a readonly transaction. |
| `Transaction(Union<string, IEnumerable<string>> storeNames, string mode)` | `IDBTransaction` | Opens a transaction with specified mode (`"readonly"`, `"readwrite"`). |
| `Transaction(Union<string, IEnumerable<string>> storeNames, bool readWrite)` | `IDBTransaction` | Opens a transaction - `true` for readwrite, `false` for readonly. |

### Events

| Event | Type | Description |
|-------|------|-------------|
| `OnClose` | `ActionEvent<Event>` | Fired when the connection is unexpectedly closed. |
| `OnVersionChange` | `ActionEvent<Event>` | Fired when a version change is requested. |

---

## IDBTransaction

**Inheritance:** `JSObject` -> `EventTarget` -> `IDBTransaction`  
**MDN Reference:** [IDBTransaction](https://developer.mozilla.org/en-US/docs/Web/API/IDBTransaction)

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Db` | `IDBDatabase` | The database connection for this transaction. |
| `Durability` | `string` | The durability hint (`"strict"`, `"relaxed"`, `"default"`). |
| `Error` | `DOMException?` | The error for a failed transaction, or `null`. |
| `Mode` | `string` | The access mode (`"readonly"`, `"readwrite"`, `"versionchange"`). |
| `ObjectStoreNames` | `string[]` | Names of object stores in this transaction's scope. |

### Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `ObjectStore<TKey, TValue>(string storeName)` | `IDBObjectStore<TKey, TValue>` | Gets an object store in this transaction's scope. |
| `Abort()` | `void` | Rolls back all changes in this transaction. |
| `Commit()` | `void` | Explicitly commits the transaction. |

### Events

| Event | Type | Description |
|-------|------|-------------|
| `OnAbort` | `ActionEvent<Event>` | Fired when the transaction is aborted. |
| `OnComplete` | `ActionEvent<Event>` | Fired when the transaction completes successfully. |
| `OnError` | `ActionEvent<Event>` | Fired when a request error occurs. |

---

## IDBObjectStore\<TPrimaryKey, TValue\>

**Inheritance:** `JSObject` -> `IDBObjectStore<TPrimaryKey, TValue>`  
**MDN Reference:** [IDBObjectStore](https://developer.mozilla.org/en-US/docs/Web/API/IDBObjectStore)

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IndexNames` | `string[]` | Names of indexes on this object store. |
| `KeyPath` | `Union<string, string[]>?` | The key path, or `null` for out-of-line keys. |
| `Name` | `string` | The object store name (read/write during upgrade). |
| `Transaction` | `IDBTransaction` | The parent transaction. |
| `AutoIncrement` | `bool` | Whether the auto-increment flag is set. |

### Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Add(TValue value)` / `AddAsync(TValue value)` | `IDBRequest` / `Task` | Adds a new record (in-line key). |
| `Add(TValue value, TPrimaryKey key)` / `AddAsync(...)` | `IDBRequest` / `Task` | Adds a new record with explicit key. |
| `Put(TValue value)` / `PutAsync(TValue value)` | `IDBRequest` / `Task` | Adds or updates a record (in-line key). |
| `Put(TValue value, TPrimaryKey key)` / `PutAsync(...)` | `IDBRequest` / `Task` | Adds or updates with explicit key. |
| `Get(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey> key)` / `GetAsync(...)` | `IDBRequest<TValue>` / `Task<TValue>` | Retrieves a record by key. |
| `GetAll()` / `GetAllAsync()` | `IDBRequest<Array<TValue>>` / `Task<Array<TValue>>` | Retrieves all records. |
| `GetKey(...)` / `GetKeyAsync(...)` | `IDBRequest<TPrimaryKey>` / `Task<TPrimaryKey>` | Retrieves a key. |
| `GetAllKeys()` / `GetAllKeysAsync()` | `IDBRequest<Array<TPrimaryKey>>` / `Task<Array<TPrimaryKey>>` | Retrieves all keys. |
| `Delete(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey> key)` / `DeleteAsync(...)` | `IDBRequest` / `Task` | Deletes a record by key. |
| `Clear()` / `ClearAsync()` | `IDBRequest` / `Task` | Deletes all records. |
| `Count()` / `CountAsync()` | `IDBRequest<int>` / `Task<int>` | Counts all records. |
| `Count(Union<...> key)` / `CountAsync(...)` | `IDBRequest<int>` / `Task<int>` | Counts records matching a key/range. |
| `Index<TIndexKey>(string name)` | `IDBIndex<TIndexKey, TPrimaryKey, TValue>` | Opens an index for lookups. |
| `CreateIndex<TIndexKey>(string indexName, ...)` | `IDBIndex<TIndexKey, TPrimaryKey, TValue>` | Creates an index (upgrade only). |
| `DeleteIndex(string indexName)` | `void` | Deletes an index (upgrade only). |
| `OpenCursor(...)` / `OpenCursorAsync(...)` | `IDBRequest<IDBCursorWithValue<...>>` / `Task<...>` | Opens a cursor over the store. |
| `OpenKeyCursor(...)` / `OpenKeyCursorAsync(...)` | `IDBRequest<IDBCursor<...>>` / `Task<...>` | Opens a key-only cursor. |

---

## IDBIndex\<TIndexKey, TPrimaryKey, TValue\>

**Inheritance:** `JSObject` -> `EventTarget` -> `IDBIndex<TIndexKey, TPrimaryKey, TValue>`  
**MDN Reference:** [IDBIndex](https://developer.mozilla.org/en-US/docs/Web/API/IDBIndex)

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Name` | `string` | The index name (read/write during upgrade). |
| `ObjectStore` | `IDBObjectStore<TPrimaryKey, TValue>` | The referenced object store. |
| `KeyPath` | `Union<string, string[]>?` | The index key path. |
| `MultiEntry` | `bool` | Whether array keys create one record per item. |
| `Unique` | `bool` | Whether duplicate keys are disallowed. |

### Methods

Same query methods as `IDBObjectStore` (`Get`, `GetAll`, `GetKey`, `GetAllKeys`, `Count`, `OpenCursor`, `OpenKeyCursor`) with their async variants, but keyed on `TIndexKey`.

---

## IDBKeyRange\<TKey\>

**Inheritance:** `JSObject` -> `IDBKeyRange<TKey>`  
**MDN Reference:** [IDBKeyRange](https://developer.mozilla.org/en-US/docs/Web/API/IDBKeyRange)

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Lower` | `TKey` | Lower bound of the key range. |
| `Upper` | `TKey` | Upper bound of the key range. |
| `LowerOpen` | `bool` | `true` if the lower bound excludes the endpoint. |
| `UpperOpen` | `bool` | `true` if the upper bound excludes the endpoint. |

### Instance Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Includes(TKey? key)` | `bool` | Checks if a key falls within the range. |

### Static Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Bound(TKey lower, TKey upper, bool lowerOpen = false, bool upperOpen = false)` | `IDBKeyRange<TKey>` | Creates a bounded range. |
| `Only(TKey value)` | `IDBKeyRange<TKey>` | Creates a range containing a single value. |
| `LowerBound(TKey lower, bool open = false)` | `IDBKeyRange<TKey>` | Creates a range with only a lower bound. |
| `UpperBound(TKey upper, bool open = false)` | `IDBKeyRange<TKey>` | Creates a range with only an upper bound. |

---

## IDBCursor\<TKey, TPrimaryKey, TValue\>

**Inheritance:** `JSObject` -> `IDBCursor<TKey, TPrimaryKey, TValue>`  
**MDN Reference:** [IDBCursor](https://developer.mozilla.org/en-US/docs/Web/API/IDBCursor)

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Source` | `Union<IDBObjectStore<...>, IDBIndex<...>>` | The source object store or index. |
| `Direction` | `string` | Traversal direction (`"next"`, `"nextunique"`, `"prev"`, `"prevunique"`). |
| `Key` | `TKey?` | The key at the cursor's current position. |
| `PrimaryKey` | `TPrimaryKey?` | The primary key at the cursor's current position. |
| `Request` | `IDBRequest<IDBCursor<...>>` | The `IDBRequest` used to obtain the cursor. |

### Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Advance(int count)` / `AdvanceAsync(int count)` | `void` / `Task<bool>` | Moves the cursor forward by `count` positions. |
| `Continue()` / `ContinueAsync()` | `void` / `Task<bool>` | Advances to the next position. Async returns `true` if data is available. |
| `Continue(TKey key)` / `ContinueAsync(TKey key)` | `void` / `Task<bool>` | Advances to the position matching the given key. |
| `ContinuePrimaryKey(TKey key, TKey primaryKey)` | `void` | Sets the cursor to the given index key and primary key. |
| `Delete()` / `DeleteAsync()` | `IDBRequest` / `Task` | Deletes the record at the cursor's position. |
| `Update(TValue value)` / `UpdateAsync(TValue value)` | `IDBRequest<TKey>` / `Task<TKey>` | Updates the record at the cursor's position. |
| `CanContinue()` | `Task<bool>` | Non-standard - returns `true` if the cursor can continue. |

---

## Complete Example

```csharp
@inject BlazorJSRuntime JS

// Define a record type
public class FruitRecord
{
    public string? Name { get; set; }
    public string? Color { get; set; }
    public int Calories { get; set; }
}

// Open database with schema creation
using var db = await IDBDatabase.OpenAsync("FruitDB", 1, evt =>
{
    using var upgradeDb = evt.Target.JSRef!.Get<IDBDatabase>("result");

    // Create object store with auto-increment key
    using var store = upgradeDb.CreateObjectStore<int, FruitRecord>("fruits",
        new IDBObjectStoreCreateOptions
        {
            KeyPath = "name",
            AutoIncrement = false
        });

    // Create an index on color
    using var colorIndex = store.CreateIndex<string>("colorIndex", "color");
});

// Write data
using var tx = db.Transaction("fruits", "readwrite");
using var store = tx.ObjectStore<string, FruitRecord>("fruits");
await store.PutAsync(new FruitRecord { Name = "apple", Color = "red", Calories = 95 });
await store.PutAsync(new FruitRecord { Name = "banana", Color = "yellow", Calories = 105 });
await store.PutAsync(new FruitRecord { Name = "cherry", Color = "red", Calories = 50 });

// Read a single record
using var readTx = db.Transaction("fruits");
using var readStore = readTx.ObjectStore<string, FruitRecord>("fruits");
var apple = await readStore.GetAsync("apple");
Console.WriteLine($"{apple.Name}: {apple.Calories} cal");

// Query by index
using var colorIndex = readStore.Index<string>("colorIndex");
using var redFruits = await colorIndex.GetAllAsync("red");
// redFruits contains apple and cherry

// Count records
int count = await readStore.CountAsync();
Console.WriteLine($"Total fruits: {count}");

// Use a key range
using var range = IDBKeyRange<string>.Bound("a", "c");
using var rangedResults = await readStore.GetAllAsync();

// Cursor iteration
using var cursorTx = db.Transaction("fruits");
using var cursorStore = cursorTx.ObjectStore<string, FruitRecord>("fruits");
using var cursor = await cursorStore.OpenCursorAsync();
if (cursor != null)
{
    do
    {
        Console.WriteLine($"Cursor at: {cursor.Key}");
    } while (await cursor.ContinueAsync());
}

// Delete the database
await IDBFactory.DeleteDatabaseAsync("FruitDB");
```

## Tuple Keys Example

SpawnDev.BlazorJS supports compound (Tuple) keys for IndexedDB, matching how JavaScript arrays work as composite keys:

```csharp
// Object store with compound key path
using var db = await IDBDatabase.OpenAsync("CompoundDB", 1, evt =>
{
    using var upgradeDb = evt.Target.JSRef!.Get<IDBDatabase>("result");
    using var store = upgradeDb.CreateObjectStore<(string, string), MyRecord>("records",
        new IDBObjectStoreCreateOptions
        {
            KeyPath = new string[] { "category", "id" }
        });
});

// Query with tuple keys
using var tx = db.Transaction("records");
using var store = tx.ObjectStore<(string, string), MyRecord>("records");
var record = await store.GetAsync(("electronics", "phone-001"));
```
