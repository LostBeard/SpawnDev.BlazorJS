# AbortSignal

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/AbortSignal.cs`  
**MDN Reference:** [AbortSignal on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AbortSignal)

> The AbortSignal interface represents a signal object that allows you to communicate with a DOM request (such as a fetch request) and abort it if required via an AbortController object. https://developer.mozilla.org/en-US/docs/Web/API/AbortSignal

## Constructors

| Signature | Description |
|---|---|
| `AbortSignal(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Aborted` | `bool` | get | A Boolean that indicates whether the request(s) the signal is communicating with is/are aborted (true) or not (false). |
| `Reason` | `JSObject?` | get | A JavaScript value providing the abort reason, once the signal has aborted. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetReason()` | `T` | A JavaScript value providing the abort reason, once the signal has aborted. Type to read the property reason as |
| `ThrowIfAborted()` | `void` | Throws the signal's abort reason if the signal has been aborted; otherwise it does nothing. |
| `Abort()` | `AbortSignal` | The AbortSignal.abort() static method returns an AbortSignal that is already set as aborted (and which does not trigger an abort event). |
| `Abort(object reason)` | `AbortSignal` | The AbortSignal.abort() static method returns an AbortSignal that is already set as aborted (and which does not trigger an abort event). The reason why the operation was aborted, which can be any JavaScript value. If not specified, the reason is set to "AbortError" DOMException. |
| `Timeout(float time)` | `AbortSignal` | The AbortSignal.timeout() static method returns an AbortSignal that will automatically abort after a specified time. The "active" time in milliseconds before the returned AbortSignal will abort. An AbortSignal. |
| `Any(Array<AbortSignal> signals)` | `AbortSignal` | Returns an AbortSignal that aborts when any of the given abort signals abort. An AbortSignal that is: - Already aborted, if any of the abort signals given is already aborted. The returned AbortSignal's reason will be already set to the reason of the first abort signal that was already aborted. - Asynchronously aborted, when any abort signal in iterable aborts. The reason will be set to the reason of the first abort signal that is aborted. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAbort` | `ActionEvent<Event>` | Invoked when the asynchronous operations the signal is communicating with is/are aborted. Also available via the onabort property. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AbortSignal>(...)` or constructor `new AbortSignal(...)`

### Aborting a fetch operation using an explicit signal

```js
let controller;
const url = "video.mp4";

const downloadBtn = document.querySelector(".download");
const abortBtn = document.querySelector(".abort");

downloadBtn.addEventListener("click", fetchVideo);

abortBtn.addEventListener("click", () => {
  if (controller) {
    controller.abort();
    console.log("Download aborted");
  }
});

async function fetchVideo() {
  controller = new AbortController();
  const signal = controller.signal;

  try {
    const response = await fetch(url, { signal });
    console.log("Download complete", response);
    // process response further
  } catch (err) {
    console.error(`Download error: ${err.message}`);
  }
}
```

### Aborting a fetch operation using an explicit signal

```js
async function get() {
  const controller = new AbortController();
  const request = new Request("https://example.org/get", {
    signal: controller.signal,
  });

  const response = await fetch(request);
  controller.abort();
  // The next line will throw `AbortError`
  const text = await response.text();
  console.log(text);
}
```

### Aborting a fetch operation with a timeout

```js
const url = "video.mp4";

try {
  const res = await fetch(url, { signal: AbortSignal.timeout(5000) });
  const result = await res.blob();
  // …
} catch (err) {
  if (err.name === "TimeoutError") {
    console.error("Timeout: It took more than 5 seconds to get the result!");
  } else if (err.name === "AbortError") {
    console.error(
      "Fetch aborted by user action (browser stop button, closing tab, etc.)",
    );
  } else {
    // A network error, or some other problem.
    console.error(`Error: type: ${err.name}, message: ${err.message}`);
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AbortSignal)*

