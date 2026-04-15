# DOMTokenList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DOM/DOMTokenList.cs`  
**MDN Reference:** [DOMTokenList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DOMTokenList)

> The DOMTokenList interface represents a set of space-separated tokens. Such a set is returned by Element.classList or HTMLLinkElement.relList, and many others. https://developer.mozilla.org/en-US/docs/Web/API/DOMTokenList

## Constructors

| Signature | Description |
|---|---|
| `DOMTokenList(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | An integer representing the number of objects stored in the object. |
| `Value` | `string` | get | A stringifier property that returns the value of the list as a string. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Item(int index)` | `string?` | Returns the item in the list by its index, or null if the index is greater than or equal to the list's length. |
| `Contains(string token)` | `bool` | Returns true if the list contains the given token, otherwise false. |
| `Add(params string[] tokens)` | `void` | Adds the specified tokens to the list. |
| `Remove(params string[] tokens)` | `void` | Removes the specified tokens from the list. |
| `Replace(string oldToken, string newToken)` | `bool` | The replace() method of the DOMTokenList interface replaces an existing token with a new token. If the first token doesn't exist, replace() returns false immediately, without adding the new token to the token list. A string representing the token you want to replace. A string representing the token you want to replace oldToken with. A boolean value, which is true if oldToken was successfully replaced, or false if not. |
| `Supports(string token)` | `bool` | Returns true if the given token is in the associated attribute's supported tokens. |
| `Toggle(string token, bool force)` | `bool` | The toggle() method of the DOMTokenList interface removes an existing token from the list and returns false. If the token doesn't exist it's added and the function returns true. A string representing the token you want to toggle. If included, turns the toggle into a one way-only operation. If set to false, then token will only be removed, but not added. If set to true, then token will only be added, but not removed. |
| `Toggle(string token)` | `bool` | The toggle() method of the DOMTokenList interface removes an existing token from the list and returns false. If the token doesn't exist it's added and the function returns true. A string representing the token you want to toggle. |
| `Keys()` | `List<int>` | Returns an iterator, allowing you to go through all keys of the key/value pairs contained in this object. |
| `Values()` | `List<string>` | Returns an iterator, allowing you to go through all values of the key/value pairs contained in this object. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<DOMTokenList>(...)` or constructor `new DOMTokenList(...)`

```js
let para = document.querySelector("p");
let classes = para.classList;
para.classList.add("d");
para.textContent = `paragraph classList is "${classes}"`;
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DOMTokenList)*

