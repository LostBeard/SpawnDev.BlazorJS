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
| `AdoptedStyleSheets` | `Array<CSSStyleSheet>` | get | Add an array of constructed stylesheets to be used by the shadow DOM subtree. These may be shared with other DOM subtrees that share the same parent Document node, and the document itself. |
| `Clonable` | `bool` | get | A boolean that indicates whether the shadow root is clonable. |
| `CustomElementRegistry` | `CustomElementRegistry?` | get | Returns the CustomElementRegistry object associated with this shadow root, or null if one has not been set. |
| `FullscreenElement` | `Element?` | get | The Document.fullscreenElement read-only property returns the Element that is currently being presented in fullscreen mode in this document, or null if fullscreen mode is not currently in use. |
| `PictureInPictureElement` | `Element?` | get | The Document.pictureInPictureElement read-only property returns the Element that is currently being presented in picture-in-picture mode in this document, or null if picture-in-picture mode is not currently in use. |
| `PointerLockElement` | `Element?` | get | The read-only pointerLockElement property of the Document interface provides the element set as the target for mouse events while the pointer is locked. It is null if lock is pending, pointer is unlocked, or the target is in another document. |

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

