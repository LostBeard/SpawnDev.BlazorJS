# IDBOpenDBRequest

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `IDBRequest<IDBDatabase>`  
**Source:** `JSObjects/IDBOpenDBRequest.cs`  
**MDN Reference:** [IDBOpenDBRequest on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBOpenDBRequest)

> The IDBOpenDBRequest interface of the IndexedDB API provides access to the results of requests to open or delete databases (performed using IDBFactory.open and IDBFactory.deleteDatabase), using specific event handler attributes. https://developer.mozilla.org/en-US/docs/Web/API/IDBOpenDBRequest

## Constructors

| Signature | Description |
|---|---|
| `IDBOpenDBRequest(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Events

| Event | Type | Description |
|---|---|---|
| `OnBlocked` | `ActionEvent<IDBVersionChangeEvent>` | The IDBVersionChangeEvent interface of the IndexedDB API indicates that the version of the database has changed, as the result of an onupgradeneeded event handler function. |
| `OnUpgradeNeeded` | `ActionEvent<IDBVersionChangeEvent>` | The upgradeneeded event is fired when an attempt was made to open a database with a version number higher than its current version. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<IDBOpenDBRequest>(...)` or constructor `new IDBOpenDBRequest(...)`

```js
let db;

// Let us open our database
const DBOpenRequest = window.indexedDB.open("toDoList", 4);

// these event handlers act on the database being opened.
DBOpenRequest.onerror = (event) => {
  note.appendChild(document.createElement("li")).textContent =
    "Error loading database.";
};

DBOpenRequest.onsuccess = (event) => {
  note.appendChild(document.createElement("li")).textContent =
    "Database initialized.";

  // store the result of opening the database in the db
  // variable. This is used a lot below
  db = DBOpenRequest.result;

  // Run the displayData() function to populate the task
  // list with all the to-do list data already in the IDB
  displayData();
};

// This event handles the event whereby a new version of
// the database needs to be created Either one has not
// been created before, or a new version number has been
// submitted via the window.indexedDB.open line above
// it is only implemented in recent browsers
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
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBOpenDBRequest)*

