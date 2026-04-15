# SharedWorkerGlobalScope

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `WorkerGlobalScope`  
**Source:** `JSObjects/SharedWorkerGlobalScope.cs`  
**MDN Reference:** [SharedWorkerGlobalScope on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SharedWorkerGlobalScope)

> The SharedWorkerGlobalScope object (the SharedWorker global scope) is accessible through the self keyword. Some additional global functions, namespaces objects, and constructors, not typically associated with the worker global scope, but available on it, are listed in the JavaScript Reference. See the complete list of functions available to workers. https://developer.mozilla.org/en-US/docs/Web/API/SharedWorkerGlobalScope

## Constructors

| Signature | Description |
|---|---|
| `SharedWorkerGlobalScope(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `string` | get | The name that the SharedWorker was (optionally) given when it was created using the SharedWorker() constructor. This is mainly useful for debugging purposes. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Close()` | `void` | Discards any tasks queued in the WorkerGlobalScope's event loop, effectively closing this particular scope. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnConnect` | `ActionEvent<MessageEvent>` | Fired on shared workers when a new client connects. |

