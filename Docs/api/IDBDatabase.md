# IDBDatabase

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/IDBDatabase.cs`  
**MDN Reference:** [IDBDatabase on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBDatabase)

> The IDBDatabase interface of the IndexedDB API provides a connection to a database; you can use an IDBDatabase object to open a transaction on your database then create, manipulate, and delete objects (data) in that database. The interface provides the only way to get and manage versions of the database. https://developer.mozilla.org/en-US/docs/Web/API/IDBDatabase W3C spec: https://w3c.github.io/IndexedDB/#introduction

## Constructors

| Signature | Description |
|---|---|
| `IDBDatabase(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IsSupported` | `bool` | get | True is indexedDB global object is found |
| `Name` | `string` | get | A string that contains the name of the connected database. |
| `Version` | `long` | get | A 64-bit integer that contains the version of the connected database. When a database is first created, this attribute is an empty string. |
| `ObjectStoreNames` | `string[]` | get | A DOMStringList that contains a list of the names of the object stores currently in the connected database. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Open(string dbName)` | `IDBOpenDBRequest` | Opens a connection to a database. |
| `Open(string dbName, long dbVersion)` | `IDBOpenDBRequest` | Opens a connection to a database. |
| `OpenAsync(string dbName, Action<IDBVersionChangeEvent>? onUpgradeNeeded)` | `Task<IDBDatabase>` | Opens a connection to a database asynchronously. |
| `OpenAsync(string dbName, long dbVersion, Action<IDBVersionChangeEvent>? onUpgradeNeeded)` | `Task<IDBDatabase>` | Opens a connection to a database asynchronously. |
| `Close()` | `void` | Returns immediately and closes the connection to a database in a separate thread. |
| `CreateObjectStore(string storeName, IDBObjectStoreCreateOptions? options)` | `IDBObjectStore<TKey, TValue>` | Creates and returns a new object store or index. The type of the value found at TValue[options.KeyPath] The value of the type that is stored The name of the new object store to be created. Note that it is possible to create an object store with an empty name. An options object whose attributes are optional parameters to the method A new IDBObjectStore. |
| `DeleteObjectStore(string storeName)` | `void` | Destroys the object store with the given name in the connected database, along with any indexes that reference it. The name of the object store you want to delete. Names are case sensitive. |
| `Transaction(Union<string, IEnumerable<string>> storeNames)` | `IDBTransaction` | Immediately returns a transaction object (IDBTransaction) containing the IDBTransaction.objectStore method, which you can use to access your object store. Runs in a separate thread. The names of object stores that are in the scope of the new transaction, declared as an array of strings. Specify only the object stores that you need to access. If you need to access only one object store, you can specify its name as a string. Therefore the following lines are equivalent: IDBTransaction |
| `Transaction(Union<string, IEnumerable<string>> storeNames, string mode)` | `IDBTransaction` | Immediately returns a transaction object (IDBTransaction) containing the IDBTransaction.objectStore method, which you can use to access your object store. Runs in a separate thread. The names of object stores that are in the scope of the new transaction, declared as an array of strings. Specify only the object stores that you need to access. If you need to access only one object store, you can specify its name as a string. Therefore the following lines are equivalent: The types of access that can be performed in the transaction. Transactions are opened in one of three modes: - readonly (default) - readwrite - readwriteflush (non-standard, Firefox-only.) If you don't provide the parameter, the default access mode is readonly. To avoid slowing things down, don't open a readwrite transaction unless you actually need to write into the database. IDBTransaction |
| `Transaction(Union<string, IEnumerable<string>> storeNames, bool readWrite)` | `IDBTransaction` | Immediately returns a transaction object (IDBTransaction) containing the IDBTransaction.objectStore method, which you can use to access your object store. Runs in a separate thread. The names of object stores that are in the scope of the new transaction, declared as an array of strings. Specify only the object stores that you need to access. If you need to access only one object store, you can specify its name as a string. Therefore the following lines are equivalent: If true, "readwrite" mode will be used. Otherwise "readonly mode will be used." IDBTransaction |
| `Transaction(Union<string, IEnumerable<string>> storeNames, string mode, IDBDatabaseTransactionOptions options)` | `IDBTransaction` | Immediately returns a transaction object (IDBTransaction) containing the IDBTransaction.objectStore method, which you can use to access your object store. Runs in a separate thread. The names of object stores that are in the scope of the new transaction, declared as an array of strings. Specify only the object stores that you need to access. If you need to access only one object store, you can specify its name as a string. Therefore the following lines are equivalent: The types of access that can be performed in the transaction. Transactions are opened in one of three modes: - readonly (default) - readwrite - readwriteflush (non-standard, Firefox-only.) If you don't provide the parameter, the default access mode is readonly. To avoid slowing things down, don't open a readwrite transaction unless you actually need to write into the database. Additional options IDBTransaction |
| `Transaction(Union<string, IEnumerable<string>> storeNames, bool readWrite, IDBDatabaseTransactionOptions options)` | `IDBTransaction` | Immediately returns a transaction object (IDBTransaction) containing the IDBTransaction.objectStore method, which you can use to access your object store. Runs in a separate thread. The names of object stores that are in the scope of the new transaction, declared as an array of strings. Specify only the object stores that you need to access. If you need to access only one object store, you can specify its name as a string. Therefore the following lines are equivalent: If true, "readwrite" mode will be used. Otherwise "readonly mode will be used." Additional options IDBTransaction |

## Events

| Event | Type | Description |
|---|---|---|
| `OnClose` | `ActionEvent<Event>` | An event fired when the database connection is unexpectedly closed. |
| `OnVersionChange` | `ActionEvent<Event>` | An event fired when a database structure change was requested. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<IDBDatabase>(...)` or constructor `new IDBDatabase(...)`

```js
// Let us open our database
const DBOpenRequest = window.indexedDB.open("toDoList", 4);

// these two event handlers act on the IDBDatabase object,
// when the database is opened successfully, or not
DBOpenRequest.onerror = (event) => {
  note.appendChild(document.createElement("li")).textContent =
    "Error loading database.";
};

DBOpenRequest.onsuccess = (event) => {
  node.appendChild(document.createElement("li")).textContent =
    "Database initialized.";

  // store the result of opening the database in the db
  // variable. This is used a lot later on
  db = DBOpenRequest.result;

  // Run the displayData() function to populate the task
  // list with all the to-do list data already in the IDB
  displayData();
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

  // Create an objectStore for this database using
  // IDBDatabase.createObjectStore

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
```

```js
const objectStore = db
  .transaction("toDoList", "readwrite")
  .objectStore("toDoList");
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBDatabase)*

