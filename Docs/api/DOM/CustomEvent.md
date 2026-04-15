# CustomEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/DOM/CustomEvent.cs`  

> The CustomEvent interface represents events initialized by an application for any purpose.

## Constructors

| Signature | Description |
|---|---|
| `CustomEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `CustomEvent(string type)` | The CustomEvent() constructor creates a new CustomEvent object. A string providing the name of the event. Event names are case-sensitive. |
| `CustomEvent(string type, CustomEventOptions options)` | The CustomEvent() constructor creates a new CustomEvent object. A string providing the name of the event. Event names are case-sensitive. An object that, in addition of the properties defined in Event(), can have the following properties: |
| `CustomEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `CustomEvent(string type)` | The CustomEvent() constructor creates a new CustomEvent object. |
| `CustomEvent(string type, CustomEventOptions<TDetail> options)` | The CustomEvent() constructor creates a new CustomEvent object. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Detail` | `JSObject?` | get | Returns any data passed when initializing the event. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `DetailAs()` | `T` | Returns any data passed when initializing the event. |

