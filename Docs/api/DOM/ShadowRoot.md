# ShadowRoot

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `DocumentFragment`  
**Source:** `JSObjects/DOM/ShadowRoot.cs`  
**MDN Reference:** [ShadowRoot on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ShadowRoot)

> The ShadowRoot interface of the Shadow DOM API is the root node of a DOM subtree that is rendered separately from a document's main DOM tree. https://developer.mozilla.org/en-US/docs/Web/API/ShadowRoot

## Constructors

| Signature | Description |
|---|---|
| `ShadowRoot(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Mode` | `string` | get | Returns the mode of the ShadowRoot, either "open" or "closed". |
| `Host` | `Element` | get | Returns the Element that is the host of the ShadowRoot. |
| `DelegatesFocus` | `bool` | get | Returns a boolean indicating whether the ShadowRoot's delegatesFocus attribute is true or false. |
| `SlotAssignment` | `string` | get | Returns the slot assignment mode of the ShadowRoot, either "manual" or "named". |
| `Slots` | `NodeList<Element>` | get | Returns a NodeList of the slot elements in the ShadowRoot. |
| `IsActive` | `bool` | get | Returns a boolean indicating whether the ShadowRoot is in a state where it can be used. |
| `InnerHTML` | `string` | get | Returns the inner HTML of the ShadowRoot. |
| `StyleSheets` | `StyleSheetList` | get | Returns the style sheets associated with the ShadowRoot. |
| `ShadowRootMode` | `string` | get | Returns the shadow root's mode, either "open" or "closed". |
| `ShadowHost` | `Element` | get | Returns the shadow root's host element. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ShadowRoot>(...)` or constructor `new ShadowRoot(...)`

```js
class Square extends HTMLElement {
  // …
  connectedCallback() {
    console.log("Custom square element added to page.");
    updateStyle(this);
  }

  attributeChangedCallback(name, oldValue, newValue) {
    console.log("Custom square element attributes changed.");
    updateStyle(this);
  }
  // …
}
```

```js
function updateStyle(elem) {
  const shadow = elem.shadowRoot;
  const childNodes = shadow.childNodes;
  for (const node of childNodes) {
    if (node.nodeName === "STYLE") {
      node.textContent = `
div {
  width: ${elem.getAttribute("l")}px;
  height: ${elem.getAttribute("l")}px;
  background-color: ${elem.getAttribute("c")};
}
      `;
    }
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ShadowRoot)*

