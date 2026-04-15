# IDBTransaction

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/IDBTransaction.cs`  
**MDN Reference:** [IDBTransaction on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBTransaction)

> The IDBTransaction interface of the IndexedDB API provides a static, asynchronous transaction on a database using event handler attributes. All reading and writing of data is done within transactions. You use IDBDatabase to start transactions, IDBTransaction to set the mode of the transaction (e.g. is it readonly or readwrite), and you access an IDBObjectStore to make a request. You can also use an IDBTransaction object to abort transactions. https://developer.mozilla.org/en-US/docs/Web/API/IDBTransaction

## Constructors

| Signature | Description |
|---|---|
| `IDBTransaction(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Db` | `IDBDatabase` | get | The database connection with which this transaction is associated. |
| `Durability` | `string` | get | Returns the durability hint the transaction was created with. Any of the following literal strings: "strict" "relaxed" "default" |
| `Error` | `DOMException?` | get | Returns a DOMException indicating the type of error that occurred when there is an unsuccessful transaction. This property is null if the transaction is not finished, is finished and successfully committed, or was aborted with the IDBTransaction.abort() function. |
| `Mode` | `string` | get | An string defining the mode for isolating access to data in the current object stores: A string defining the mode for isolating access to data in the current object stores. The following values are available: "readonly" - Allows data to be read but not changed. "readwrite" - Allows reading and writing of data in existing data stores to be changed. "versionchange" - Allows any operation, including ones that delete and create object stores and indexes. This mode is for updating the version number of transactions if the need is detected when calling IDBFactory.open(). Transactions of this mode cannot run concurrently with other transactions. Transactions in this mode are known as upgrade transactions. |
| `ObjectStoreNames` | `string[]` | get | Returns a string[] of the names of IDBObjectStore objects associated with the transaction. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ObjectStore(string storeName)` | `IDBObjectStore<TKey, TValue>` | Returns an IDBObjectStore object representing an object store that is part of the scope of this transaction. The name of the requested object store. An IDBObjectStore object for accessing an object store. |
| `Abort()` | `void` | Rolls back all the changes to objects in the database associated with this transaction. If this transaction has been aborted or completed, this method fires an error event. |
| `Commit()` | `void` | For an active transaction, commits the transaction. Note that this doesn't normally have to be called - a transaction will automatically commit when all outstanding requests have been satisfied and no new requests have been made. commit() can be used to start the commit process without waiting for events from outstanding requests to be dispatched. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAbort` | `ActionEvent<Event>` | An event fired when the IndexedDB transaction is aborted. Also available via the onabort property; this event bubbles to IDBDatabase. |
| `OnComplete` | `ActionEvent<Event>` | An event fired when the transaction successfully completes. Also available via the oncomplete property. |
| `OnError` | `ActionEvent<Event>` | An event fired when a request returns an error and the event bubbles up to the connection object (IDBDatabase). Also available via the onerror property. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<IDBTransaction>(...)` or constructor `new IDBTransaction(...)`

```js
const note = document.getElementById("notifications");

// an instance of a db object for us to store the IDB data in
let db;

// Let us open our database
const DBOpenRequest = window.indexedDB.open("toDoList", 4);

DBOpenRequest.onsuccess = (event) => {
  note.appendChild(document.createElement("li")).textContent =
    "Database initialized.";

  // store the result of opening the database in the db
  // variable. This is used a lot below
  db = DBOpenRequest.result;

  // Add the data to the database
  addData();
};

function addData() {
  // Create a new object to insert into the IDB
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

  // open a read/write db transaction, ready to add data
  const transaction = db.transaction(["toDoList"], "readwrite");

  // report on the success of opening the transaction
  transaction.oncomplete = (event) => {
    note.appendChild(document.createElement("li")).textContent =
      "Transaction completed: database modification finished.";
  };

  transaction.onerror = (event) => {
    note.appendChild(document.createElement("li")).textContent =
      "Transaction not opened due to error. Duplicate items not allowed.";
  };

  // create an object store on the transaction
  const objectStore = transaction.objectStore("toDoList");

  // add our newItem object to the object store
  const objectStoreRequest = objectStore.add(newItem[0]);

  objectStoreRequest.onsuccess = (event) => {
    // report the success of the request (this does not mean the item
    // has been stored successfully in the DB - for that you need transaction.oncomplete)
    note.appendChild(document.createElement("li")).textContent =
      "Request successful.";
  };
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBTransaction)*

