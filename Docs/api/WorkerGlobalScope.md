# WorkerGlobalScope

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WorkerGlobalScope.cs`  
**MDN Reference:** [WorkerGlobalScope on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WorkerGlobalScope)

> The WorkerGlobalScope interface of the Web Workers API is an interface representing the scope of any worker. Workers have no browsing context; this scope contains the information usually conveyed by Window objects - in this case event handlers, the console or the associated WorkerNavigator object. Each WorkerGlobalScope has its own event loop. https://developer.mozilla.org/en-US/docs/Web/API/WorkerGlobalScope

## Constructors

| Signature | Description |
|---|---|
| `WorkerGlobalScope(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Caches` | `CacheStorage` | get | Returns the CacheStorage object associated with the current context. This object enables functionality such as storing assets for offline use, and generating custom responses to requests |
| `IndexedDB` | `IDBFactory` | get | Provides a mechanism for applications to asynchronously access capabilities of indexed databases; returns an IDBFactory object. |
| `IsSecureContext` | `bool` | get | Returns a boolean indicating whether the current context is secure (true) or not (false) |
| `Location` | `WorkerLocation` | get | Returns the WorkerLocation associated with the worker. It is a specific location object, mostly a subset of the Location for browsing scopes, but adapted to workers |
| `Navigator` | `WorkerNavigator` | get | Returns the WorkerNavigator associated with the worker. It is a specific navigator object, mostly a subset of the Navigator for browsing scopes, but adapted to workers. |
| `Origin` | `string` | get | Returns the global object's origin, serialized as a string. |
| `CrossOriginIsolated` | `bool?` | get | Returns true if the website is in a cross-origin isolation state. Returns null if the browser does not support cross-origin isolation detection. |
| `Crypto` | `Crypto` | get | Returns the browser crypto object. |
| `Performance` | `Performance` | get | The global performance property returns a Performance object, which can be used to gather performance information about the context it is called in (window or worker). |
| `Self` | `virtual WorkerGlobalScope` | get | Returns a reference to the WorkerGlobalScope itself. Most of the time it is a specific scope like DedicatedWorkerGlobalScope, SharedWorkerGlobalScope or ServiceWorkerGlobalScope. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ImportScripts(params string[] scripts)` | `void` | The importScripts() method of the WorkerGlobalScope interface synchronously imports one or more scripts into the worker's scope. |
| `Fetch(Request resource)` | `Task<Response>` | Calls fetch |
| `Fetch(string resource)` | `Task<Response>` | Calls fetch |
| `Fetch(string resource, FetchOptions options)` | `Task<Response>` | Calls fetch |
| `StructuredClone(object value, StructuredCloneOptions options)` | `T` | The structuredClone() method of the Window interface creates a deep clone of a given value using the structured clone algorithm. The method also allows transferable objects in the original value to be transferred rather than cloned to the new object. Transferred objects are detached from the original object and attached to the new object; they are no longer accessible in the original object. The object to be cloned. This can be any structured-cloneable type. |
| `StructuredClone(object value)` | `T` | The structuredClone() method of the Window interface creates a deep clone of a given value using the structured clone algorithm. The method also allows transferable objects in the original value to be transferred rather than cloned to the new object. Transferred objects are detached from the original object and attached to the new object; they are no longer accessible in the original object. The object to be cloned. This can be any structured-cloneable type. |
| `SetTimeout(Callback callback, double delay)` | `long` | Schedules a function to execute in a given amount of time. |
| `SetTimeout(Action callback, double delay)` | `long` | Schedules a function to execute in a given amount of time. |
| `SetTimeout(Func<Task> callback, double delay)` | `long` | Schedules a function to execute in a given amount of time. |
| `SetInterval(Callback callback, double delay)` | `long` | The setInterval() method of the Window interface repeatedly calls a function or executes a code snippet, with a fixed time delay between each call. This method returns an interval ID which uniquely identifies the interval, so you can remove it later by calling clearInterval(). |
| `ClearInterval(long requestId)` | `void` | Cancels the delayed execution set using setInterval(). |
| `ClearTimeout(long requestId)` | `void` | Cancels the delayed execution set using setTimeout(). |
| `CreateImageBitmap(ImageBitmapSource image, int sx, int sy, int sw, int sh, ImageBitmapOptions options)` | `Task<ImageBitmap>` | The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap. An image source The x coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted. The y coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted. The width of the rectangle from which the ImageBitmap will be extracted. This value can be negative. The height of the rectangle from which the ImageBitmap will be extracted. This value can be negative. An object that sets options for the image's extraction. A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle. |
| `CreateImageBitmap(ImageBitmapSource image, ImageBitmapOptions options)` | `Task<ImageBitmap>` | The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap. An image source An object that sets options for the image's extraction. A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle. |
| `CreateImageBitmap(ImageBitmapSource image)` | `Task<ImageBitmap>` | The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap. An image source A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle. |
| `CreateImageBitmap(ImageBitmapSource image, int sx, int sy, int sw, int sh)` | `Task<ImageBitmap>` | The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap. An image source The x coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted. The y coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted. The width of the rectangle from which the ImageBitmap will be extracted. This value can be negative. The height of the rectangle from which the ImageBitmap will be extracted. This value can be negative. A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnError` | `ActionEvent<ErrorEvent>` | Fired when an error occurred. |
| `OnLanguageChange` | `ActionEvent<Event>` | Fired at the global/worker scope object when the user's preferred languages change. |
| `OnOffline` | `ActionEvent<Event>` | Fired when the browser has lost access to the network and the value of navigator.onLine switched to false. |
| `OnOnline` | `ActionEvent<Event>` | Fired when the browser has gained access to the network and the value of navigator.onLine switched to true. |
| `OnRejectionHandled` | `ActionEvent<PromiseRejectionEvent>` | Fired on handled Promise rejection events. |
| `OnSecurityPolicyViolation` | `ActionEvent<SecurityPolicyViolationEvent>` | Fired when a Content Security Policy is violated. |
| `OnUnhandledRejection` | `ActionEvent<PromiseRejectionEvent>` | Fired on unhandled Promise rejection events. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WorkerGlobalScope>(...)` or constructor `new WorkerGlobalScope(...)`

```js
importScripts("foo.js");
console.log(navigator);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WorkerGlobalScope)*

