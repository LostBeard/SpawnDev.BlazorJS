# HTMLSlotElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLElement`  
**Source:** `JSObjects/DOM/HTMLSlotElement.cs`  
**MDN Reference:** [HTMLSlotElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLSlotElement)

> The HTMLSlotElement interface of the Shadow DOM API enables access to the name and assigned nodes of an HTML slot element. https://developer.mozilla.org/en-US/docs/Web/API/HTMLSlotElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLSlotElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLSlotElement(ElementReference elementReference)` | Get an instance from an ElementReference |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `string` | get | A string used to get and set the slot's name. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<HTMLSlotElement>(...)` or constructor `new HTMLSlotElement(...)`

```js
let slots = this.shadowRoot.querySelectorAll("slot");
slots[1].addEventListener("slotchange", (e) => {
  let nodes = slots[1].assignedNodes();
  console.log(
    `Element in Slot "${slots[1].name}" changed to "${nodes[0].outerHTML}".`,
  );
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLSlotElement)*

