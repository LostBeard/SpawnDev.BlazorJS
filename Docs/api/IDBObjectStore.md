# IDBObjectStore<TPrimaryKey, TValue>

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/IDBObjectStore.cs`  
**MDN Reference:** [IDBObjectStore<TPrimaryKey, TValue> on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBObjectStore)

> The IDBObjectStore interface of the IndexedDB API represents an object store in a database. Records within an object store are sorted according to their keys. This sorting enables fast insertion, look-up, and ordered retrieval. https://developer.mozilla.org/en-US/docs/Web/API/IDBObjectStore

## Constructors

| Signature | Description |
|---|---|
| `IDBObjectStore(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IndexNames` | `string[]` | get | A list of the names of indexes on objects in this object store. |
| `KeyPath` | `Union<string, string[]>?` | get | The key path of this object store. If this attribute is null, the application must provide a key for each modification operation. |
| `Name` | `string` | get | The name of this object store. |
| `Transaction` | `IDBTransaction` | get | The IDBTransaction object to which this object store belongs. |
| `AutoIncrement` | `bool` | get | The value of the auto increment flag for this object store. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Index(string name)` | `IDBIndex<TIndexKey, TPrimaryKey, TValue>` | Opens an index from this object store after which it can, for example, be used to return a sequence of records sorted by that index using a cursor. The name of the index to open. An IDBIndex object for accessing the index. |
| `CreateIndex(string indexName, Union<string, string[]> keyPath)` | `IDBIndex<TIndexKey, TPrimaryKey, TValue>` | Creates a new index during a version upgrade, returning a new IDBIndex object in the connected database. The name of the index to create. Note that it is possible to create an index with an empty name. The key path for the index to use. Note that it is possible to create an index with an empty keyPath, and also to pass in a sequence (array) as a keyPath. |
| `CreateIndex(string indexName, string keyPath, IDBObjectStoreCreateIndexOptions options)` | `IDBIndex<TIndexKey, TPrimaryKey, TValue>` | Creates a new index during a version upgrade, returning a new IDBIndex object in the connected database. The name of the index to create. Note that it is possible to create an index with an empty name. The key path for the index to use. Note that it is possible to create an index with an empty keyPath, and also to pass in a sequence (array) as a keyPath. Additional options |
| `Delete(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey> key)` | `IDBRequest` | Returns an IDBRequest object, and, in a separate thread, deletes the store object selected by the specified key. This is for deleting individual records out of an object store. |
| `DeleteAsync(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey> key)` | `Task` | Deletes the store object selected by the specified key. This is for deleting individual records out of an object store. |
| `Clear()` | `IDBRequest` | Creates and immediately returns an IDBRequest object, and clears this object store in a separate thread. This is for deleting all current records out of an object store. |
| `ClearAsync()` | `Task` | This is for deleting all current records out of an object store. |
| `Add(TValue value, TPrimaryKey key)` | `IDBRequest` | Returns an IDBRequest object, and, in a separate thread, creates a structured clone of the value, and stores the cloned value in the object store. This is for adding new records to an object store. |
| `AddAsync(TValue value, TPrimaryKey key)` | `Task` | Creates a structured clone of the value, and stores the cloned value in the object store. This is for adding new records to an object store. |
| `Add(TValue value)` | `IDBRequest` | Returns an IDBRequest object, and, in a separate thread, creates a structured clone of the value, and stores the cloned value in the object store. This is for adding new records to an object store. |
| `AddAsync(TValue value)` | `Task` | Creates a structured clone of the value, and stores the cloned value in the object store. This is for adding new records to an object store. |
| `Put(TValue value, TPrimaryKey key)` | `IDBRequest` | Returns an IDBRequest object, and, in a separate thread, creates a structured clone of the value, and stores the cloned value in the object store. This is for updating existing records in an object store when the transaction's mode is readwrite. |
| `PutAsync(TValue value, TPrimaryKey key)` | `Task` | Creates a structured clone of the value, and stores the cloned value in the object store. This is for updating existing records in an object store when the transaction's mode is readwrite. |
| `Put(TValue value)` | `IDBRequest` | Returns an IDBRequest object, and, in a separate thread, creates a structured clone of the value, and stores the cloned value in the object store. This is for updating existing records in an object store when the transaction's mode is readwrite. |
| `PutAsync(TValue value)` | `Task` | Creates a structured clone of the value, and stores the cloned value in the object store. This is for updating existing records in an object store when the transaction's mode is readwrite. |
| `Count(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey> key)` | `IDBRequest<int>` | Returns an IDBRequest object, and, in a separate thread, returns the total number of records that match the provided key or IDBKeyRange. If no arguments are provided, it returns the total number of records in the store. |
| `CountAsync(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey> key)` | `Task<int>` | Returns a Task that returns the total number of records that match the provided key or IDBKeyRange. If no arguments are provided, it returns the total number of records in the store. |
| `Count()` | `IDBRequest<int>` | Returns an IDBRequest object, and, in a separate thread, returns the total number of records that match the provided key or IDBKeyRange. If no arguments are provided, it returns the total number of records in the store. |
| `CountAsync()` | `Task<int>` | Returns a Task that returns the total number of records that match the provided key or IDBKeyRange. If no arguments are provided, it returns the total number of records in the store. |
| `Get(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey> key)` | `IDBRequest<TValue>` | Returns an IDBRequest object, and, in a separate thread, returns the store object store selected by the specified key. This is for retrieving specific records from an object store. |
| `GetAsync(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey> key)` | `Task<TValue>` | Returns the store object store selected by the specified key. This is for retrieving specific records from an object store. |
| `GetAll()` | `IDBRequest<Array<TValue>>` | Returns an IDBRequest object retrieves all objects in the object store matching the specified parameter or all objects in the store if no parameters are given. |
| `GetAllAsync()` | `Task<Array<TValue>>` | Retrieves all objects in the object store matching the specified parameter or all objects in the store if no parameters are given. |
| `GetKey(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey> key)` | `IDBRequest<TPrimaryKey>` | Returns an IDBRequest object, and, in a separate thread retrieves and returns the record key for the object in the object stored matching the specified parameter. |
| `GetKeyAsync(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey> key)` | `Task<TPrimaryKey>` | Retrieves and returns the record key for the object in the object stored matching the specified parameter. |
| `GetAllKeys()` | `IDBRequest<Array<TPrimaryKey>>` | Returns an IDBRequest object retrieves record keys for all objects in the object store matching the specified parameter or all objects in the store if no parameters are given. |
| `GetAllKeysAsync()` | `Task<Array<TPrimaryKey>>` | Returns record keys for all objects in the object store matching the specified parameter or all objects in the store if no parameters are given. |
| `DeleteIndex(string indexName)` | `void` | Destroys the specified index in the connected database, used during a version upgrade. |
| `OpenCursor()` | `IDBRequest<IDBCursorWithValue<TPrimaryKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor. |
| `OpenCursorAsync()` | `Task<IDBCursorWithValue<TPrimaryKey, TPrimaryKey, TValue>>` | Returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor. |
| `OpenCursor(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey>? query)` | `IDBRequest<IDBCursorWithValue<TPrimaryKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor. A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store. |
| `OpenCursorAsync(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey>? query)` | `Task<IDBCursorWithValue<TPrimaryKey, TPrimaryKey, TValue>>` | Returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor. |
| `OpenCursor(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey>? query, string direction)` | `IDBRequest<IDBCursorWithValue<TPrimaryKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor. A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store. A string telling the cursor which direction to travel. The default is next. Valid values are: "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys. "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys. "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys. "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys. |
| `OpenCursorAsync(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey>? query, string direction)` | `Task<IDBCursorWithValue<TPrimaryKey, TPrimaryKey, TValue>>` | Returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor. A key or IDBKeyRange to be queried. If a single valid key is passed, this will default to a range containing only that key. If nothing is passed, this will default to a key range that selects all the records in this object store. A string telling the cursor which direction to travel. The default is next. Valid values are: "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys. "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys. "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys. "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys. Task&lt;IDBCursorWithValue&gt; |
| `OpenKeyCursor(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey>? range, string direction)` | `IDBRequest<IDBCursor<TPrimaryKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index. A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store. The cursor's direction. See IDBCursor Constants for possible values. |
| `OpenKeyCursorAsync(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey>? range, string direction)` | `Task<IDBCursor<TPrimaryKey, TPrimaryKey, TValue>>` | Creates a cursor over the specified key range, as arranged by this index. |
| `OpenKeyCursor(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey>? range)` | `IDBRequest<IDBCursor<TPrimaryKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index. A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store. |
| `OpenKeyCursorAsync(Union<IDBKeyRange<TPrimaryKey>, TPrimaryKey>? range)` | `Task<IDBCursor<TPrimaryKey, TPrimaryKey, TValue>>` | Creates a cursor over the specified key range, as arranged by this index. |
| `OpenKeyCursor()` | `IDBRequest<IDBCursor<TPrimaryKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index. |
| `OpenKeyCursorAsync()` | `Task<IDBCursor<TPrimaryKey, TPrimaryKey, TValue>>` | Creates a cursor over the specified key range, as arranged by this index. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<IDBObjectStore>(...)` or constructor `new IDBObjectStore(...)`

```js
// Let us open our database
const DBOpenRequest = window.indexedDB.open("toDoList", 4);

DBOpenRequest.onsuccess = (event) => {
  note.appendChild(document.createElement("li")).textContent =
    "Database initialized.";

  // store the result of opening the database in db.
  db = DBOpenRequest.result;
};

// This event handles the event whereby a new version of
// the database needs to be created Either one has not
// been created before, or a new version number has been
// submitted via the window.indexedDB.open line above
DBOpenRequest.onupgradeneeded = (event) => {
  const db = event.target.result;

  db.onerror = (event) => {
    note.appendChild(document.createElement("li")).textContent =
      "Error loading database.";
  };

  // Create an objectStore for this database

  const objectStore = db.createObjectStore("toDoList", {
    keyPath: "taskTitle",
  });

  // define what data items the objectStore will contain

  objectStore.createIndex("hours", "hours", { unique: false });
  objectStore.createIndex("minutes", "minutes", { unique: false });
  objectStore.createIndex("day", "day", { unique: false });
  objectStore.createIndex("month", "month", { unique: false });
  objectStore.createIndex("year", "year", { unique: false });

  objectStore.createIndex("notified", "notified", { unique: false });

  note.appendChild(document.createElement("li")).textContent =
    "Object store created.";
};

// Create a new item to add in to the object store
const newItem = [
  {
    taskTitle: "Walk dog",
    hours: 19,
    minutes: 30,
    day: 24,
    month: "December",
    year: 2013,
    notified: "no",
  },
];

// open a read/write db transaction, ready for adding the data
const transaction = db.transaction(["toDoList"], "readwrite");

// report on the success of the transaction completing, when everything is done
transaction.oncomplete = (event) => {
  note.appendChild(document.createElement("li")).textContent =
    "Transaction completed.";
};

transaction.onerror = (event) => {
  note.appendChild(document.createElement("li")).textContent =
    "Transaction not opened due to error. Duplicate items not allowed.";
};

// create an object store on the transaction
const objectStore = transaction.objectStore("toDoList");
// make a request to add our newItem object to the object store
const objectStoreRequest = objectStore.add(newItem[0]);

objectStoreRequest.onsuccess = (event) => {
  note.appendChild(document.createElement("li")).textContent =
    "Request successful.";
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBObjectStore)*

