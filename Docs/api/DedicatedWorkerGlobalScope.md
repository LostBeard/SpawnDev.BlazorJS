# DedicatedWorkerGlobalScope

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `WorkerGlobalScope`, `IMessagePort`  
**Source:** `JSObjects/DedicatedWorkerGlobalScope.cs`  
**MDN Reference:** [DedicatedWorkerGlobalScope on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DedicatedWorkerGlobalScope)

> The DedicatedWorkerGlobalScope object (the Worker global scope) is accessible through the self keyword. Some additional global functions, namespaces objects, and constructors, not typically associated with the worker global scope, but available on it, are listed in the JavaScript Reference. See also: Functions available to workers. https://developer.mozilla.org/en-US/docs/Web/API/DedicatedWorkerGlobalScope

## Constructors

| Signature | Description |
|---|---|
| `DedicatedWorkerGlobalScope(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `string` | get | The name that the SharedWorker was (optionally) given when it was created using the SharedWorker() constructor. This is mainly useful for debugging purposes. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Close()` | `void` | Discards any tasks queued in the WorkerGlobalScope's event loop, effectively closing this particular scope. |
| `PostMessage(object message)` | `void` | Sends a message from the port, and optionally, transfers ownership of objects to other browsing contexts. |
| `PostMessage(object message, object[] transfer)` | `void` | Sends a message from the port, and optionally, transfers ownership of objects to other browsing contexts. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnMessage` | `ActionEvent<MessageEvent>` | Fired when the worker receives a message from its parent. |
| `OnMessageError` | `ActionEvent<MessageEvent>` | Fired when a worker receives a message that can't be deserialized. |

