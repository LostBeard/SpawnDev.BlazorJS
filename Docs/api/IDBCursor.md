# IDBCursor<TKey, TPrimaryKey, TValue>

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/IDBCursor.cs`  
**MDN Reference:** [IDBCursor<TKey, TPrimaryKey, TValue> on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBCursor)

> The IDBCursor interface of the IndexedDB API represents a cursor for traversing or iterating over multiple records in a database. The cursor has a source that indicates which index or object store it is iterating over. It has a position within the range, and moves in a direction that is increasing or decreasing in the order of record keys. The cursor enables an application to asynchronously process all the records in the cursor's range. You can have an unlimited number of cursors at the same time. You always get the same IDBCursor object representing a given cursor. Operations are performed on the underlying index or object store. https://developer.mozilla.org/en-US/docs/Web/API/IDBCursor

## Constructors

| Signature | Description |
|---|---|
| `IDBCursor(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Source` | `Union<IDBObjectStore<TPrimaryKey, TValue>, IDBIndex<TKey, TPrimaryKey, TValue>>` | get | Returns the IDBObjectStore or IDBIndex that the cursor is iterating. This function never returns null or throws an exception, even if the cursor is currently being iterated, has iterated past its end, or its transaction is not active. |
| `Direction` | `string` | get/set | Returns the direction of traversal of the cursor. |
| `Key` | `TKey?` | get/set | Returns the key for the record at the cursor's position. If the cursor is outside its range, this is set to undefined. The cursor's key can be any data type. |
| `PrimaryKey` | `TPrimaryKey?` | get | Returns the cursor's current effective primary key. If the cursor is currently being iterated or has iterated outside its range, this is set to undefined. The cursor's primary key can be any data type. |
| `Request` | `IDBRequest<IDBCursor<TKey, TPrimaryKey, TValue>>` | get | Returns the IDBRequest that was used to obtain the cursor. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `KeyAs()` | `TKeyAlt` | Returns the key for the record at the cursor's position. If the cursor is outside its range, this is set to undefined. The cursor's key can be any data type. |
| `PrimaryKeyAs()` | `TPrimaryKeyAlt` | Returns the cursor's current effective primary key. If the cursor is currently being iterated or has iterated outside its range, this is set to undefined. The cursor's primary key can be any data type. |
| `CanContinue()` | `Task<bool>` | Returns a Task the returns true if (and when) the cursor can continue (Request != null and Request has a result). (non-spec) |
| `Advance(int count)` | `void` | Sets the number of times a cursor should move its position forward. The number of times to move the cursor forward. |
| `AdvanceAsync(int count)` | `Task<bool>` | Sets the number of times a cursor should move its position forward. |
| `Continue(TKey key)` | `void` | Advances the cursor to the next position along its direction, to the item whose key matches the optional key parameter. The key to position the cursor at. |
| `ContinueAsync(TKey key)` | `Task<bool>` | Advances the cursor to the next position along its direction, to the item whose key matches the optional key parameter. |
| `Continue()` | `void` | Advances the cursor to the next position along its direction, to the item whose key matches the optional key parameter. |
| `ContinueAsync()` | `Task<bool>` | Advances the cursor to the next position along its direction, to the item whose key matches the optional key parameter. returns true if there is data |
| `ContinuePrimaryKey(TKey key, TKey primaryKey)` | `void` | Sets the cursor to the given index key and primary key given as arguments. The key to position the cursor at. The primary key to position the cursor at. |
| `ContinuePrimaryKeyAsync(TKey key, TKey primaryKey)` | `Task<bool>` | Sets the cursor to the given index key and primary key given as arguments. |
| `Delete()` | `IDBRequest` | Returns an IDBRequest object, and, in a separate thread, deletes the record at the cursor's position, without changing the cursor's position. This can be used to delete specific records. |
| `DeleteAsync()` | `Task` | Deletes the record at the cursor's position, without changing the cursor's position. This can be used to delete specific records. |
| `Update(TValue value)` | `IDBRequest<TKey>` | Returns an IDBRequest object, and, in a separate thread, updates the value at the current position of the cursor in the object store. This can be used to update specific records. The new value to be stored at the current position. An IDBRequest object on which subsequent events related to this operation are fired. |
| `UpdateAsync(TValue value)` | `Task<TKey>` | Updates the value at the current position of the cursor in the object store. This can be used to update specific records. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<IDBCursor>(...)` or constructor `new IDBCursor(...)`

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

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBCursor)*

