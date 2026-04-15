# IDBKeyRange<TKey>

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/IDBKeyRange.cs`  
**MDN Reference:** [IDBKeyRange<TKey> on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBKeyRange)

> The IDBKeyRange interface of the IndexedDB API represents a continuous interval over some data type that is used for keys. Records can be retrieved from IDBObjectStore and IDBIndex objects using keys or a range of keys. You can limit the range using lower and upper bounds. For example, you can iterate over all values of a key in the value range A-Z. https://developer.mozilla.org/en-US/docs/Web/API/IDBKeyRange

## Constructors

| Signature | Description |
|---|---|
| `IDBKeyRange(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Lower` | `TKey` | get | Lower bound of the key range. |
| `Upper` | `TKey` | get | Upper bound of the key range. |
| `UpperOpen` | `bool` | get | Returns false if the upper-bound value is included in the key range. |
| `LowerOpen` | `bool` | get | Returns false if the lower-bound value is included in the key range. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Includes(TKey? key)` | `bool` | Returns a boolean indicating whether a specified key is inside the key range. The key you want to check for in your key range. This can be any type. IDBKeyRange: The newly created key range. |
| `Bound(TKey lower, TKey upper, bool lowerOpen, bool upperOpen)` | `IDBKeyRange<TKey>` | Creates a new key range with upper and lower bounds. specifies the lower bound of the new key range. specifies the upper bound of the new key range. indicates whether the lower bound excludes the endpoint value. The default is false. Indicates whether the upper bound excludes the endpoint value. The default is false. IDBKeyRange: The newly created key range. |
| `Only(TKey value)` | `IDBKeyRange<TKey>` | Creates a new key range containing a single value. The value for the new key range. |
| `LowerBound(TKey lower, bool open)` | `IDBKeyRange<TKey>` | Creates a new key range with only a lower bound. Specifies the lower bound of the new key range. Indicates whether the lower bound excludes the endpoint value. The default is false. IDBKeyRange: The newly created key range. |
| `UpperBound(TKey upper, bool open)` | `IDBKeyRange<TKey>` | Creates a new upper-bound key range. Specifies the upper bound of the new key range. Indicates whether the upper bound excludes the endpoint value. The default is false. IDBKeyRange: The newly created key range. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<IDBKeyRange>(...)` or constructor `new IDBKeyRange(...)`

```js
function displayData() {
  const keyRangeValue = IDBKeyRange.bound("A", "F");

  const transaction = db.transaction(["fThings"], "readonly");
  const objectStore = transaction.objectStore("fThings");

  objectStore.openCursor(keyRangeValue).onsuccess = (event) => {
    const cursor = event.target.result;
    if (cursor) {
      const listItem = document.createElement("li");
      listItem.textContent = `${cursor.value.fThing}, ${cursor.value.fRating}`;
      list.appendChild(listItem);

      cursor.continue();
    } else {
      console.log("Entries all displayed.");
    }
  };
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IDBKeyRange)*

