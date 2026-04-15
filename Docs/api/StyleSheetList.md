# StyleSheetList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/StyleSheetList.cs`  
**MDN Reference:** [StyleSheetList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/StyleSheetList)

> The StyleSheetList interface represents a list of CSSStyleSheet objects. An instance of this object can be returned by Document.styleSheets. https://developer.mozilla.org/en-US/docs/Web/API/StyleSheetList

## Constructors

| Signature | Description |
|---|---|
| `StyleSheetList(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | The number of nodes in the StyleSheetList. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Item(int index)` | `CSSStyleSheet` | Returns an item in the list by its index, or null if the index is out-of-bounds. |
| `ToList()` | `List<CSSStyleSheet>` | Returns as a list |
| `ToArray()` | `CSSStyleSheet[]` | Returns as an array |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<StyleSheetList>(...)` or constructor `new StyleSheetList(...)`

### Get CSSStyleSheet objects with for loop

```js
for (const styleSheet of document.styleSheets) {
  console.log(styleSheet); // A CSSStyleSheet object
}
```

### Get all CSS rules for the document using Array methods

```js
const allCSS = [...document.styleSheets]
  .map((styleSheet) => {
    try {
      return [...styleSheet.cssRules].map((rule) => rule.cssText).join("");
    } catch (e) {
      console.log(
        "Access to stylesheet %s is denied. Ignoring…",
        styleSheet.href,
      );
      return undefined;
    }
  })
  .filter(Boolean)
  .join("\n");
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/StyleSheetList)*

