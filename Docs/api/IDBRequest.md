# IDBRequest<TResult>

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `IDBRequest`  
**Source:** `JSObjects/IDBRequest.cs`  
**MDN Reference:** [IDBRequest<TResult> on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBRequest)

> The IDBRequest interface of the IndexedDB API provides access to results of asynchronous requests to databases and database objects using event handler attributes. Each reading and writing operation on a database is done using a request. https://developer.mozilla.org/en-US/docs/Web/API/IDBRequest The type to use for the Result property

## Constructors

| Signature | Description |
|---|---|
| `IDBRequest(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `IDBRequest(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Result` | `TResult` | get | Returns the result of the request. If the request is not completed, the result is not available and an InvalidStateError exception is thrown. |
| `Error` | `DOMException` | get | Returns a DOMException in the event of an unsuccessful request, indicating what went wrong. |
| `ReadyState` | `string` | get | The state of the request. Every request starts in the pending state. The state changes to done when the request completes successfully or when an error occurs. |
| `Transaction` | `IDBTransaction?` | get | The transaction for the request. This property can be null for certain requests, for example those returned from IDBFactory.open unless an upgrade is needed. (You're just connecting to a database, so there is no transaction to return). |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `WaitAsync(bool disposeRequest)` | `Task<TResult>` | if (ReadyState == "done" AND Error == null) returns Result as TResult if (ReadyState == "done" AND Error != null) throws Exception else On onsuccess returns Result as TResult On onerror throws Exception If true, this IDBRequest will be disposed after when the call completes Task&lt;TResult&gt; |
| `ResultAs()` | `T` | Returns the result of the request. If the request is not completed, the result is not available and an InvalidStateError exception is thrown. |
| `SourceAs()` | `T` | An object representing the source of the request, such as an IDBIndex, IDBObjectStore or IDBCursor. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnError` | `ActionEvent<Event>` | Fired when an error caused a request to fail. |
| `OnSuccess` | `ActionEvent<Event>` | Fired when an IDBRequest succeeds. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<IDBRequest>(...)` or constructor `new IDBRequest(...)`

```js
let db;

// Let us open our database
const DBOpenRequest = window.indexedDB.open("toDoList", 4);

// these two event handlers act on the database being
// opened successfully, or not
DBOpenRequest.onerror = (event) => {
  note.appendChild(document.createElement("li")).textContent =
    "Error loading database.";
};

DBOpenRequest.onsuccess = (event) => {
  note.appendChild(document.createElement("li")).textContent =
    "Database initialized.";

  // store the result of opening the database.
  db = DBOpenRequest.result;
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBRequest)*

