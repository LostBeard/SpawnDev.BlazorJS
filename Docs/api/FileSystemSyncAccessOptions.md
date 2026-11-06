# FileSystemSyncAccessOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/FileSystemSyncAccessOptions.cs`  
**MDN Reference:** [FileSystemSyncAccessOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemFileHandle/createSyncAccessHandle#options)

> https://developer.mozilla.org/en-US/docs/Web/API/FileSystemFileHandle/createSyncAccessHandle#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `FileSystemSyncAccessOptions` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/FileSystemFileHandle/createSyncAccessHandle#options |
| `Mode` | `string?` | get/set | A string specifying the locking mode for the access handle. The default value is "readwrite". Possible values are: "read-only" - Multiple FileSystemSyncAccessHandle objects can be opened simultaneously on a file (for example when using the same app in multiple tabs), provided they are all opened in "read-only" mode. Once opened, read-like methods can be called on the handles — read(), getSize(), and close(). "readwrite" - Only one FileSystemSyncAccessHandle object can be opened on a file. Attempting to open subsequent handles before the first handle is closed results in a NoModificationAllowedError exception being thrown. Once opened, any available method can be called on the handle. "readwrite-unsafe" - Multiple FileSystemSyncAccessHandle objects can be opened simultaneously on a file, provided they are all opened in "readwrite-unsafe" mode. Once opened, any available method can be called on the handles. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<FileSystemSyncAccessOptions>(...)` or constructor `new FileSystemSyncAccessOptions(...)`

### Basic usage

```js
onmessage = async (e) => {
  // Retrieve message sent to work from main script
  const message = e.data;

  // Get handle to draft file
  const root = await navigator.storage.getDirectory();
  const draftHandle = await root.getFileHandle("draft.txt", { create: true });
  // Get sync access handle
  const accessHandle = await draftHandle.createSyncAccessHandle();

  // …

  // Always close FileSystemSyncAccessHandle if done.
  accessHandle.close();
};
```

### Complete example with `mode` option

```js
const writeBtn = document.querySelector(".write");
const emptyBtn = document.querySelector(".empty");
const fileText = document.querySelector("#file-text");

const opfsWorker = new Worker("worker.js");

function writeToOPFS() {
  opfsWorker.postMessage({
    command: "write",
    content: fileText.value,
  });
  console.log("Main script: Text posted to worker");
  fileText.value = "";
}

function emptyOPFS() {
  opfsWorker.postMessage({
    command: "empty",
  });
}

writeBtn.addEventListener("click", writeToOPFS);
emptyBtn.addEventListener("click", emptyOPFS);
```

### Complete example with `mode` option

```js
let accessHandle;

async function initOPFS() {
  const opfsRoot = await navigator.storage.getDirectory();
  const fileHandle = await opfsRoot.getFileHandle("file.txt", { create: true });
  accessHandle = await fileHandle.createSyncAccessHandle({
    mode: "readwrite-unsafe",
  });
}

initOPFS();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemFileHandle/createSyncAccessHandle)*

