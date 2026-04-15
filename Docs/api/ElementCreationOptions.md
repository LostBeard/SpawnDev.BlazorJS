# ElementCreationOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/ElementCreationOptions.cs`  
**MDN Reference:** [ElementCreationOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Document/createElement#options)

> https://developer.mozilla.org/en-US/docs/Web/API/Document/createElement#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ElementCreationOptions` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/Document/createElement#options |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ElementCreationOptions>(...)` or constructor `new ElementCreationOptions(...)`

### Basic example

```js
function addElement() {
  // create a new div element
  const newDiv = document.createElement("div");

  // and give it some content
  const newContent = document.createTextNode("Hi there and greetings!");

  // add the text node to the newly created div
  newDiv.appendChild(newContent);

  // add the newly created element and its content into the DOM
  const currentDiv = document.getElementById("div1");
  document.body.insertBefore(newDiv, currentDiv);
}

addElement();
```

### Web component example

```js
// Create a class for the element
class ExpandingList extends HTMLUListElement {
  constructor() {
    // Always call super first in constructor
    super();

    // constructor definition left out for brevity
    // …
  }
}

// Define the new element
customElements.define("expanding-list", ExpandingList, { extends: "ul" });
```

### Web component example

```js
let expandingList = document.createElement("ul", { is: "expanding-list" });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Document/createElement)*

