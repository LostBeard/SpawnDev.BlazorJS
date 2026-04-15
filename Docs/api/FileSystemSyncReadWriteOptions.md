# FileSystemSyncReadWriteOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/FileSystemSyncReadWriteOptions.cs`  
**MDN Reference:** [FileSystemSyncReadWriteOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemSyncAccessHandle/read#options)

> https://developer.mozilla.org/en-US/docs/Web/API/FileSystemSyncAccessHandle/read#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `FileSystemSyncReadWriteOptions` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/FileSystemSyncAccessHandle/read#options |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<FileSystemSyncReadWriteOptions>(...)` or constructor `new FileSystemSyncReadWriteOptions(...)`

```js
onmessage = async (e) => {
  // Retrieve message sent to work from main script
  const message = e.data;

  // Get handle to draft file
  const root = await navigator.storage.getDirectory();
  const draftHandle = await root.getFileHandle("draft.txt", { create: true });
  // Get sync access handle
  const accessHandle = await draftHandle.createSyncAccessHandle();

  // Get size of the file.
  const fileSize = accessHandle.getSize();
  // Read file content to a buffer.
  const buffer = new DataView(new ArrayBuffer(fileSize));
  const readBuffer = accessHandle.read(buffer, { at: 0 });

  // Write the message to the end of the file.
  const encoder = new TextEncoder();
  const encodedMessage = encoder.encode(message);
  const writeBuffer = accessHandle.write(encodedMessage, { at: readBuffer });

  // Persist changes to disk.
  accessHandle.flush();

  // Always close FileSystemSyncAccessHandle if done.
  accessHandle.close();
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemSyncAccessHandle/read)*

