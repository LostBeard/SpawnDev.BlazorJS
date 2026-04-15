# EyeDropper

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/EyeDropper/EyeDropper.cs`  
**MDN Reference:** [EyeDropper on MDN](https://developer.mozilla.org/en-US/docs/Web/API/EyeDropper)

> The EyeDropper interface of the EyeDropper API provides a mechanism for creating an eyedropper tool. Using the eyedropper, users can select colors from their screens, including outside of the browser window. https://developer.mozilla.org/en-US/docs/Web/API/EyeDropper

## Constructors

| Signature | Description |
|---|---|
| `EyeDropper(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `EyeDropper()` | Creates a new EyeDropper object. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Open()` | `Task<ColorSelectionResult>` | The open() method of the EyeDropper interface opens the eyedropper and waits for the user to select a color. It returns a Promise that resolves to a ColorSelectionResult object once the user has selected a color. |
| `Open(EyeDropperOptions options)` | `Task<ColorSelectionResult>` | The open() method of the EyeDropper interface opens the eyedropper and waits for the user to select a color. It returns a Promise that resolves to a ColorSelectionResult object once the user has selected a color. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<EyeDropper>(...)` or constructor `new EyeDropper(...)`

### Opening the eyedropper tool and sampling a color

```js
document.getElementById("start-button").addEventListener("click", () => {
  const resultElement = document.getElementById("result");

  if (!window.EyeDropper) {
    resultElement.textContent =
      "Your browser does not support the EyeDropper API";
    return;
  }

  const eyeDropper = new EyeDropper();

  eyeDropper
    .open()
    .then((result) => {
      resultElement.textContent = result.sRGBHex;
      resultElement.style.backgroundColor = result.sRGBHex;
    })
    .catch((e) => {
      resultElement.textContent = e;
    });
});
```

### Aborting the eyedropper mode

```js
document.getElementById("start-button").addEventListener("click", () => {
  const resultElement = document.getElementById("result");

  if (!window.EyeDropper) {
    resultElement.textContent =
      "Your browser does not support the EyeDropper API";
    return;
  }

  const eyeDropper = new EyeDropper();
  const abortController = new AbortController();

  eyeDropper
    .open({ signal: abortController.signal })
    .then((result) => {
      resultElement.textContent = result.sRGBHex;
      resultElement.style.backgroundColor = result.sRGBHex;
    })
    .catch((e) => {
      resultElement.textContent = e;
    });

  setTimeout(() => {
    abortController.abort();
  }, 2000);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/EyeDropper)*

