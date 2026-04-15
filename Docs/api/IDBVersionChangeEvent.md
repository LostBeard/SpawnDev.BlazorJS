# IDBVersionChangeEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event<IDBOpenDBRequest>`  
**Source:** `JSObjects/IDBVersionChangeEvent.cs`  
**MDN Reference:** [IDBVersionChangeEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBVersionChangeEvent)

> The IDBVersionChangeEvent interface of the IndexedDB API indicates that the version of the database has changed, as the result of an onupgradeneeded event handler function. https://developer.mozilla.org/en-US/docs/Web/API/IDBVersionChangeEvent

## Constructors

| Signature | Description |
|---|---|
| `IDBVersionChangeEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `OldVersion` | `long` | get | The oldVersion read-only property of the IDBVersionChangeEvent interface returns the old version number of the database. A number containing a 64-bit integer. |
| `NewVersion` | `long?` | get | The newVersion read-only property of the IDBVersionChangeEvent interface returns the new version number of the database. A number that is a 64-bit integer or null if the database is being deleted. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<IDBVersionChangeEvent>(...)` or constructor `new IDBVersionChangeEvent(...)`

```js
const note = document.querySelector("ul");

// Let us open version 4 of our database
const DBOpenRequest = window.indexedDB.open("toDoList", 4);

// these two event handlers act on the database being opened successfully, or not
DBOpenRequest.onerror = (event) => {
  note.appendChild(document.createElement("li")).textContent =
    "Error loading database.";
};

DBOpenRequest.onsuccess = (event) => {
  note.appendChild(document.createElement("li")).textContent =
    "Database initialized.";

  // store the result of opening the database in the db variable. This is used a lot later on, for opening transactions and suchlike.
  const db = DBOpenRequest.result;
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBVersionChangeEvent)*

