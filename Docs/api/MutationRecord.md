# MutationRecord

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/MutationRecord.cs`  
**MDN Reference:** [MutationRecord on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MutationRecord)

> The MutationRecord is a read-only interface that represents an individual DOM mutation observed by a MutationObserver. It is the object inside the array passed to the callback of a MutationObserver. https://developer.mozilla.org/en-US/docs/Web/API/MutationRecord

## Constructors

| Signature | Description |
|---|---|
| `MutationRecord(IJSInProcessObjectReference _ref)` | Creates a new instance of `MutationRecord`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AddedNodes` | `NodeList` | get | The nodes added by a mutation. Will be an empty NodeList if no nodes were added. |
| `AttributeName` | `string?` | get | The name of the changed attribute as a string, or null. |
| `AttributeNamespace` | `string?` | get | The namespace of the changed attribute as a string, or null. |
| `NextSibling` | `Node?` | get | The next sibling of the added or removed nodes, or null. |
| `OldValue` | `string?` | get | The value depends on the MutationRecord.type: For attributes, it is the value of the changed attribute before the change. For characterData, it is the data of the changed node before the change. For childList, it is null. |
| `PreviousSibling` | `Node?` | get | The previous sibling of the added or removed nodes, or null. |
| `RemovedNodes` | `NodeList` | get | The nodes removed by a mutation. Will be an empty NodeList if no nodes were removed. |
| `Target` | `Node` | get | The node the mutation affected, depending on the MutationRecord.type. For attributes, it is the element whose attribute changed. For characterData, it is the CharacterData node. For childList, it is the node whose children changed. |
| `Type` | `string` | get | A string representing the type of mutation: attributes if the mutation was an attribute mutation, characterData if it was a mutation to a CharacterData node, and childList if it was a mutation to the tree of nodes. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Disconnect()` | `void` | Stops the MutationObserver instance from receiving further notifications until and unless observe() is called again. |
| `Observe(Node target, MutationObserveOptions options)` | `void` | Configures the MutationObserver to begin receiving notifications through its callback function when DOM changes matching the given options occur. A DOM Node (which may be an Element) within the DOM tree to watch for changes, or to be the root of a subtree of nodes to be watched. An object providing options that describe which DOM mutations should be reported to mutationObserver's callback. At a minimum, one of childList, attributes, and/or characterData must be true when you call observe(). Otherwise, a TypeError exception will be thrown. |
| `TakeRecords()` | `MutationRecord[]` | Removes all pending notifications from the MutationObserver's notification queue and returns them in a new Array of MutationRecord objects. |

