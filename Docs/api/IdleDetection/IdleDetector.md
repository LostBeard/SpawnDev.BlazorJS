# IdleDetector

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/IdleDetection/IdleDetector.cs`  

> The IdleDetector interface of the Idle Detection API provides methods and events for detecting user idle state.

## Constructors

| Signature | Description |
|---|---|
| `IdleDetector(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `IdleDetector()` | Creates a new IdleDetector. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `UserState` | `string?` | get | Returns the user's idle state. |
| `ScreenState` | `string?` | get | Returns the screen's idle state. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestPermission()` | `Task<string>` | Request permission to use the Idle Detection API. |
| `Start(IdleOptions? options)` | `Task` | Starts detecting idle changes. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnChange` | `ActionEvent<Event>` | Fired when the idle state of the user or screen changes. |

