# DocumentFragment

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Node`  
**Source:** `JSObjects/DOM/DocumentFragment.cs`  
**MDN Reference:** [DocumentFragment on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DocumentFragment)

> The DocumentFragment interface represents a minimal document object that has no parent. https://developer.mozilla.org/en-US/docs/Web/API/DocumentFragment

## Constructors

| Signature | Description |
|---|---|
| `DocumentFragment(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `DocumentFragment()` | The DocumentFragment() constructor returns a new, empty DocumentFragment object. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ChildElementCount` | `int` | get/set | Returns the amount of child elements the DocumentFragment has. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Append(params Union<string, Node>[] nodes)` | `void` | Inserts a set of Node objects or string objects after the last child of the document fragment. |
| `Prepend(params Union<string, Node>[] nodes)` | `void` | Inserts a set of Node objects or string objects before the first child of the document fragment. |
| `ReplaceChildren(params Union<string, Node>[] nodes)` | `void` | Replaces the existing children of a DocumentFragment with a specified new set of children. |
| `QuerySelectorAll(string selector)` | `NodeList` | Returns a NodeList of all the Element nodes within the DocumentFragment that match the specified selectors. |
| `QuerySelector(string selector)` | `Element?` | Returns the first Element node within the DocumentFragment, in document order, that matches the specified selectors. |
| `GetElementById(string id)` | `Element?` | Returns the first Element node within the DocumentFragment, in document order, that matches the specified ID. Functionally equivalent to Document.getElementById(). |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<DocumentFragment>(...)` or constructor `new DocumentFragment(...)`

### JavaScript

```js
const ul = document.querySelector("ul");
const fruits = ["Apple", "Orange", "Banana", "Melon"];

const fragment = new DocumentFragment();

for (const fruit of fruits) {
  const li = document.createElement("li");
  li.textContent = fruit;
  fragment.append(li);
}

ul.append(fragment);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DocumentFragment)*

