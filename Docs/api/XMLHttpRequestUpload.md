# XMLHttpRequestUpload

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/XMLHttpRequestUpload.cs`  
**MDN Reference:** [XMLHttpRequestUpload on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequestUpload)

> The XMLHttpRequestUpload interface represents the upload process for a specific XMLHttpRequest. It is an opaque object that represents the underlying, browser-dependent, upload process. It is an XMLHttpRequestEventTarget and can be obtained by calling XMLHttpRequest.upload. https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequestUpload

## Constructors

| Signature | Description |
|---|---|
| `XMLHttpRequestUpload(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAbort` | `ActionEvent<ProgressEvent>` | Fired when a request has been aborted, for example because the program called XMLHttpRequest.abort(). Also available via the onabort event handler property. |
| `OnError` | `ActionEvent<ProgressEvent>` | Fired when the request encountered an error. Also available via the onerror event handler property. |
| `OnLoad` | `ActionEvent<ProgressEvent>` | Fired when a request transaction completes successfully. Also available via the onload event handler property. |
| `OnLoadEnd` | `ActionEvent<ProgressEvent>` | Fired when a request has completed, whether successfully (after load) or unsuccessfully (after abort or error). Also available via the onloadend event handler property. |
| `OnLoadStart` | `ActionEvent<ProgressEvent>` | Fired when a request has started to load data. Also available via the onloadstart event handler property. |
| `OnProgress` | `ActionEvent<ProgressEvent>` | Fired periodically when a request receives more data. Also available via the onprogress event handler property. |
| `OnTimeout` | `ActionEvent<ProgressEvent>` | Fired when progress is terminated due to preset time expiring. Also available via the ontimeout event handler property. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XMLHttpRequestUpload>(...)` or constructor `new XMLHttpRequestUpload(...)`

### Uploading a file with a timeout

```js
const fileInput = document.getElementById("file");
const progressBar = document.querySelector("progress");
const log = document.querySelector("output");
const abortButton = document.getElementById("abort");

fileInput.addEventListener("change", () => {
  const xhr = new XMLHttpRequest();
  xhr.timeout = 2000; // 2 seconds

  // Link abort button
  abortButton.addEventListener(
    "click",
    () => {
      xhr.abort();
    },
    { once: true },
  );

  // When the upload starts, we display the progress bar
  xhr.upload.addEventListener("loadstart", (event) => {
    progressBar.classList.add("visible");
    progressBar.value = 0;
    progressBar.max = event.total;
    log.textContent = "Uploading (0%)…";
    abortButton.disabled = false;
  });

  // Each time a progress event is received, we update the bar
  xhr.upload.addEventListener("progress", (event) => {
    progressBar.value = event.loaded;
    log.textContent = `Uploading (${(
      (event.loaded / event.total) *
      100
    ).toFixed(2)}%)…`;
  });

  // When the upload is finished, we hide the progress bar.
  xhr.upload.addEventListener("loadend", (event) => {
    progressBar.classList.remove("visible");
    if (event.loaded !== 0) {
      log.textContent = "Upload finished.";
    }
    abortButton.disabled = true;
  });

  // In case of an error, an abort, or a timeout, we hide the progress bar
  // Note that these events can be listened to on the xhr object too
  function errorAction(event) {
    progressBar.classList.remove("visible");
    log.textContent = `Upload failed: ${event.type}`;
  }
  xhr.upload.addEventListener("error", errorAction);
  xhr.upload.addEventListener("abort", errorAction);
  xhr.upload.addEventListener("timeout", errorAction);

  // Build the payload
  const fileData = new FormData();
  fileData.append("file", fileInput.files[0]);

  // Theoretically, event listeners could be set after the open() call
  // but browsers are buggy here
  xhr.open("POST", "upload_test.php", true);

  // Note that the event listener must be set before sending (as it is a preflighted request)
  xhr.send(fileData);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequestUpload)*

