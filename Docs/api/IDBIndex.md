# IDBIndex<TIndexKey, TPrimaryKey, TValue>

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/IDBIndex.cs`  
**MDN Reference:** [IDBIndex<TIndexKey, TPrimaryKey, TValue> on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBIndex)

> IDBIndex interface of the IndexedDB API provides asynchronous access to an index in a database. An index is a kind of object store for looking up records in another object store, called the referenced object store. You use this interface to retrieve data. https://developer.mozilla.org/en-US/docs/Web/API/IDBIndex https://w3c.github.io/IndexedDB/#index-interface The key type for this index The key path type of the object store referenced by this index The object store value type

## Constructors

| Signature | Description |
|---|---|
| `IDBIndex(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `string` | get | The name of this index. |
| `ObjectStore` | `IDBObjectStore<TPrimaryKey, TValue>` | get | The ObjectStore referenced by this index. |
| `KeyPath` | `Union<string, string[]>?` | get | The key path of this index. If null, this index is not auto-populated. |
| `MultiEntry` | `bool` | get | Affects how the index behaves when the result of evaluating the index's key path yields an array. If true, there is one record in the index for each item in an array of keys. If false, then there is one record for each key that is an array. |
| `Unique` | `bool` | get | If true, this index does not allow duplicate values for a key. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Count(Union<IDBKeyRange<TIndexKey>, TIndexKey>? key)` | `IDBRequest<int>` | Returns an IDBRequest object, and in a separate thread, returns the number of records within a key range. The key or key range that identifies the record to be counted. A IDBRequest object on which subsequent events related to this operation are fired. |
| `CountAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? key)` | `Task<int>` | returns the number of records within a key range. |
| `Get(Union<IDBKeyRange<TIndexKey>, TIndexKey> key)` | `IDBRequest<TValue>` | Returns an IDBRequest object, and, in a separate thread, finds either the value in the referenced object store that corresponds to the given key or the first corresponding value, if key is an IDBKeyRange. A key or IDBKeyRange that identifies the record to be retrieved. If this value is null or missing, the browser will use an unbound key range. An IDBRequest object on which subsequent events related to this operation are fired. |
| `GetAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey> key)` | `Task<TValue>` | Returns the IDBRequest result of the get request throws an exception if not found |
| `GetAll(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query, int count)` | `IDBRequest<Array<TValue>>` | Returns an IDBRequest object, in a separate thread, finds all matching values in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange. A key or an IDBKeyRange identifying the records to retrieve. If this value is null or missing, the browser will use an unbound key range. The number of records to return. If this value exceeds the number of records in the query, the browser will only retrieve the queried records. If it is lower than 0 or greater than 2^32 - 1 a TypeError exception will be thrown. An IDBRequest object on which subsequent events related to this operation are fired. |
| `GetAllAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query, int count)` | `Task<Array<TValue>>` | Returns all matching values in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange. |
| `GetAll(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query)` | `IDBRequest<Array<TValue>>` | Returns an IDBRequest object, in a separate thread, finds all matching values in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange. A key or an IDBKeyRange identifying the records to retrieve. If this value is null or missing, the browser will use an unbound key range. |
| `GetAllAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query)` | `Task<Array<TValue>>` | Returns all matching values in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange. |
| `GetKey(Union<IDBKeyRange<TIndexKey>, TIndexKey>? key)` | `IDBRequest<TIndexKey>` | Returns an IDBRequest object, and, in a separate thread, finds either the given key or the primary key, if key is an IDBKeyRange. A key or IDBKeyRange that identifies a record to be retrieved. If this value is null or missing, the browser will use an unbound key range. An IDBRequest object on which subsequent events related to this operation are fired. |
| `GetKeyAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? key)` | `Task<TIndexKey>` | Returns either the given key or the primary key, if key is an IDBKeyRange. |
| `GetAllKeys(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query, int count)` | `IDBRequest<Array<TIndexKey>>` | Returns an IDBRequest object, in a separate thread, finds all matching keys in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange. A key or an IDBKeyRange identifying the keys to retrieve. If this value is null or missing, the browser will use an unbound key range. The number records to return. If this value exceeds the number of records in the query, the browser will only retrieve the first item. If it is lower than 0 or greater than 2^32 - 1 a TypeError exception will be thrown. An IDBRequest object on which subsequent events related to this operation are fired. |
| `GetAllKeysAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query, int count)` | `Task<Array<TIndexKey>>` | Returns all matching keys in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange. |
| `GetAllKeys(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query)` | `IDBRequest<Array<TIndexKey>>` | Returns an IDBRequest object, in a separate thread, finds all matching keys in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange. A key or an IDBKeyRange identifying the keys to retrieve. If this value is null or missing, the browser will use an unbound key range. An IDBRequest object on which subsequent events related to this operation are fired. |
| `GetAllKeysAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query)` | `Task<Array<TIndexKey>>` | Returns all matching keys in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange. |
| `OpenCursor()` | `IDBRequest<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range. |
| `OpenCursorAsync()` | `Task<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>>` | Creates a cursor over the specified key range. |
| `OpenCursor(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range)` | `IDBRequest<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range. A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store. |
| `OpenCursorAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range)` | `Task<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>>` | Creates a cursor over the specified key range. |
| `OpenCursor(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range, string direction)` | `IDBRequest<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range. A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store. A string telling the cursor which direction to travel. The default is next. Valid values are: "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys. "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys. "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys. "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys. |
| `OpenCursorAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range, string direction)` | `Task<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>>` | Creates a cursor over the specified key range. A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store. A string telling the cursor which direction to travel. The default is next. Valid values are: "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys. "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys. "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys. "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys. |
| `OpenKeyCursor(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range, string direction)` | `IDBRequest<IDBCursor<TIndexKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index. A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store. A string telling the cursor which direction to travel. The default is next. Valid values are: "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys. "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys. "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys. "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys. |
| `OpenKeyCursorAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range, string direction)` | `Task<IDBCursor<TIndexKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index. A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store. A string telling the cursor which direction to travel. The default is next. Valid values are: "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys. "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys. "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys. "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys. |
| `OpenKeyCursor(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range)` | `IDBRequest<IDBCursor<TIndexKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index. A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store. |
| `OpenKeyCursorAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range)` | `Task<IDBCursor<TIndexKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index. A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store. |
| `OpenKeyCursor()` | `IDBRequest<IDBCursor<TIndexKey, TPrimaryKey, TValue>>` | A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store. |
| `OpenKeyCursorAsync()` | `Task<IDBCursor<TIndexKey, TPrimaryKey, TValue>>` | Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<IDBIndex>(...)` or constructor `new IDBIndex(...)`

```js
function displayDataByIndex() {
  tableEntry.textContent = "";
  const transaction = db.transaction(["contactsList"], "readonly");
  const objectStore = transaction.objectStore("contactsList");

  const myIndex = objectStore.index("lName");
  myIndex.openCursor().onsuccess = (event) => {
    const cursor = event.target.result;
    if (cursor) {
      const tableRow = document.createElement("tr");
      for (const cell of [
        cursor.value.id,
        cursor.value.lName,
        cursor.value.fName,
        cursor.value.jTitle,
        cursor.value.company,
        cursor.value.eMail,
        cursor.value.phone,
        cursor.value.age,
      ]) {
        const tableCell = document.createElement("td");
        tableCell.textContent = cell;
        tableRow.appendChild(tableCell);
      }
      tableEntry.appendChild(tableRow);

      cursor.continue();
    } else {
      console.log("Entries all displayed.");
    }
  };
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBIndex)*

