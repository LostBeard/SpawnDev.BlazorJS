# NodeList<T>

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject where T : Node`  
**Source:** `JSObjects/DOM/NodeList.cs`  
**MDN Reference:** [NodeList<T> on MDN](https://developer.mozilla.org/en-US/docs/Web/API/NodeList)

> NodeList objects are collections of nodes, usually returned by properties such as Node.childNodes and methods such as document.querySelectorAll(). https://developer.mozilla.org/en-US/docs/Web/API/NodeList

## Constructors

| Signature | Description |
|---|---|
| `NodeList(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `NodeList(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | The number of nodes in the NodeList. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Item(int index)` | `T` | Returns an item in the list by its index, or null if the index is out-of-bounds. |
| `ForEach(Action<T> fn)` | `void` | Executes a provided function once per NodeList element, passing the element as an argument to the function. |
| `Values()` | `Iterator<T>` | Returns an iterator allowing code to go through all values (nodes) of the key/value pairs contained in the collection. |
| `ToList()` | `List<T>` | Returns the list as a list |
| `ToArray()` | `T[]` | Returns the list as a list |
| `ForEach(Action<Node> fn)` | `void` | Executes a provided function once per NodeList element, passing the element as an argument to the function. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<NodeList>(...)` or constructor `new NodeList(...)`

```js
for (let i = 0; i < myNodeList.length; i++) {
  let item = myNodeList[i];
}
```

```js
const list = document.querySelectorAll("input[type=checkbox]");
for (const checkbox of list) {
  checkbox.checked = true;
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/NodeList)*

