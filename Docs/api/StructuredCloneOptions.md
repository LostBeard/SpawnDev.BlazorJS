# StructuredCloneOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/StructuredCloneOptions.cs`  
**MDN Reference:** [StructuredCloneOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Window/structuredClone#options)

> https://developer.mozilla.org/en-US/docs/Web/API/Window/structuredClone#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `StructuredCloneOptions` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/Window/structuredClone#options |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<StructuredCloneOptions>(...)` or constructor `new StructuredCloneOptions(...)`

### Cloning an object

```js
const mushrooms1 = {
  amanita: ["muscaria", "virosa"],
};

const mushrooms2 = structuredClone(mushrooms1);

mushrooms2.amanita.push("pantherina");
mushrooms1.amanita.pop();

console.log(mushrooms2.amanita); // ["muscaria", "virosa", "pantherina"]
console.log(mushrooms1.amanita); // ["muscaria"]
```

### Transferring an object

```js
// Create an ArrayBuffer with a size in bytes
const buffer = new ArrayBuffer(16);

const object1 = {
  buffer,
};

// Clone the object containing the buffer, and transfer it
const object2 = structuredClone(object1, { transfer: [buffer] });

// Create an array from the cloned buffer
const int32View2 = new Int32Array(object2.buffer);
int32View2[0] = 42;
console.log(int32View2[0]);

// Creating an array from the original buffer throws a TypeError
const int32View1 = new Int32Array(object1.buffer);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Window/structuredClone)*

