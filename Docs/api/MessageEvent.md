# MessageEvent<TData>

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `MessageEvent`  
**Source:** `JSObjects/MessageEvent.cs`  
**MDN Reference:** [MessageEvent<TData> on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MessageEvent)

> The MessageEvent interface represents a message received by a target object. https://developer.mozilla.org/en-US/docs/Web/API/MessageEvent

## Constructors

| Signature | Description |
|---|---|
| `MessageEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `MessageEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Data` | `TData` | get | Message data as type TData |
| `TypeOfData` | `string?` | get | non-standard method returns the typeof this.data returns "String", "Blob", or "ArrayBuffer" (could also return "Object", "Boolean", "Number", other?) |
| `Origin` | `string` | get | A string representing the origin of the message emitter. |
| `LastEventId` | `string` | get | A string representing a unique ID for the event. |
| `Ports` | `Array<MessagePort>` | get | An array of MessagePort objects representing the ports associated with the channel the message is being sent through (where appropriate, e.g. in channel messaging or when sending a message to a shared worker). |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetData()` | `T` | The data sent by the message emitter. (data property with TValue typed get accessor) Type to get property as |
| `GetSource()` | `T` | A MessageEventSource (which can be a WindowProxy, MessagePort, or ServiceWorker object) representing the message emitter. (source property with TValue typed get accessor) Type to get property as |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MessageEvent>(...)` or constructor `new MessageEvent(...)`

```js
const myWorker = new SharedWorker("worker.js");
```

```js
myWorker.port.start();
```

```js
[first, second].forEach((input) => {
  input.onchange = () => {
    myWorker.port.postMessage([first.value, second.value]);
    console.log("Message posted to worker");
  };
});

myWorker.port.onmessage = (e) => {
  result1.textContent = e.data;
  console.log("Message received from worker");
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MessageEvent)*

