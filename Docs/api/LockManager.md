# LockManager

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/LockManager.cs`  
**MDN Reference:** [LockManager on MDN](https://developer.mozilla.org/en-US/docs/Web/API/LockManager)

> The LockManager interface of the Web Locks API provides methods for requesting a new Lock object and querying for an existing Lock object. To get an instance of LockManager, call navigator.locks. https://developer.mozilla.org/en-US/docs/Web/API/LockManager

## Constructors

| Signature | Description |
|---|---|
| `LockManager(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IsSupported` | `bool` | get | Returns true if navigator.locks is defined |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Request(string lockName, Func<Lock, Task> callback)` | `Task` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, Func<Lock, Task<TResult>> callback)` | `Task<TResult>` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, Func<Task> callback)` | `Task` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, Func<Task<TResult>> callback)` | `Task<TResult>` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, LockRequestOptions options, Func<Lock?, Task> callback)` | `Task` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, LockRequestOptions options, Func<Lock?, Task<TResult>> callback)` | `Task<TResult>` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, LockRequestOptions options, Func<Task> callback)` | `Task` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, LockRequestOptions options, Func<Task<TResult>> callback)` | `Task<TResult>` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, Action<Lock> callback)` | `Task` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, Func<Lock, TResult> callback)` | `Task<TResult>` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, Action callback)` | `Task` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, Func<TResult> callback)` | `Task<TResult>` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, LockRequestOptions options, Action<Lock?> callback)` | `Task` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, LockRequestOptions options, Func<Lock?, TResult> callback)` | `Task<TResult>` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, LockRequestOptions options, Action callback)` | `Task` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Request(string lockName, LockRequestOptions options, Func<TResult> callback)` | `Task<TResult>` | The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted. |
| `Query()` | `Task<LockManagerState>` | The query() method of the LockManager interface returns a Promise that resolves with an object containing information about held and pending locks. |

