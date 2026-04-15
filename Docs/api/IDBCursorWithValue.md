# IDBCursorWithValue<TKey, TPrimaryKey, TValue>

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `IDBCursor<TKey`, `TPrimaryKey`, `TValue>`  
**Source:** `JSObjects/IDBCursorWithValue.cs`  
**MDN Reference:** [IDBCursorWithValue<TKey, TPrimaryKey, TValue> on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBCursorWithValue)

> The IDBCursorWithValue interface of the IndexedDB API represents a cursor for traversing or iterating over multiple records in a database. It is the same as the IDBCursor, except that it includes the value property. https://developer.mozilla.org/en-US/docs/Web/API/IDBCursorWithValue

## Constructors

| Signature | Description |
|---|---|
| `IDBCursorWithValue(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Value` | `TValue` | get | Returns the value of the current cursor. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ValueAs()` | `TValueAlt` | Returns the value of the current cursor. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<IDBCursorWithValue>(...)` or constructor `new IDBCursorWithValue(...)`

```js
function displayData() {
  const transaction = db.transaction(["rushAlbumList"], "readonly");
  const objectStore = transaction.objectStore("rushAlbumList");

  objectStore.openCursor().onsuccess = (event) => {
    const cursor = event.target.result;
    if (cursor) {
      const listItem = document.createElement("li");
      listItem.textContent = `${cursor.value.albumTitle}, ${cursor.value.year}`;
      list.appendChild(listItem);

      cursor.continue();
    } else {
      console.log("Entries all displayed.");
    }
  };
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBCursorWithValue)*

