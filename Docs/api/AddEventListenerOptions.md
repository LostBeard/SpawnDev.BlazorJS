# AddEventListenerOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/AddEventListenerOptions.cs`  
**MDN Reference:** [AddEventListenerOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/EventTarget/addEventListener#options)

> An object that specifies characteristics about the event listener https://developer.mozilla.org/en-US/docs/Web/API/EventTarget/addEventListener#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AddEventListenerOptions` | `class` | get | An object that specifies characteristics about the event listener https://developer.mozilla.org/en-US/docs/Web/API/EventTarget/addEventListener#options |
| `Once` | `bool?` | get |  |
| `Passive` | `bool?` | get |  |
| `Signal` | `AbortSignal?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AddEventListenerOptions>(...)` or constructor `new AddEventListenerOptions(...)`

### Add a simple listener

```js
// Function to change the content of t2
function modifyText() {
  const t2 = document.getElementById("t2");
  const isNodeThree = t2.firstChild.nodeValue === "three";
  t2.firstChild.nodeValue = isNodeThree ? "two" : "three";
}

// Add event listener to table
const el = document.getElementById("outside");
el.addEventListener("click", modifyText);
```

### Add an abortable listener

```js
// Add an abortable event listener to table
const controller = new AbortController();
const el = document.getElementById("outside");
el.addEventListener("click", modifyText, { signal: controller.signal });

// Function to change the content of t2
function modifyText() {
  const t2 = document.getElementById("t2");
  if (t2.firstChild.nodeValue === "three") {
    t2.firstChild.nodeValue = "two";
  } else {
    t2.firstChild.nodeValue = "three";
    controller.abort(); // remove listener after value reaches "three"
  }
}
```

### Event listener with anonymous function

```js
// Function to change the content of t2
function modifyText(newText) {
  const t2 = document.getElementById("t2");
  t2.firstChild.nodeValue = newText;
}

// Function to add event listener to table
const el = document.getElementById("outside");
el.addEventListener("click", function () {
  modifyText("four");
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/EventTarget/addEventListener)*

