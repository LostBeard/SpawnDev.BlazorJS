# BeforeUnloadEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/BeforeUnloadEvent.cs`  
**MDN Reference:** [BeforeUnloadEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BeforeUnloadEvent)

> The BeforeUnloadEvent interface represents the event object for the beforeunload event, which is fired when the current window, contained document, and associated resources are about to be unloaded. https://developer.mozilla.org/en-US/docs/Web/API/BeforeUnloadEvent NOTE: WebKit-derived browsers don't follow the spec for the dialog box. (quoted from MDN page.)

## Constructors

| Signature | Description |
|---|---|
| `BeforeUnloadEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ReturnValue` | `string?` | get | When set to a truthy value, triggers a browser-controlled confirmation dialog asking users to confirm if they want to leave the page when they try to close or reload it. This is a legacy feature, and best practice is to trigger the dialog by invoking event.preventDefault(), while also setting returnValue to support legacy cases. DEPRACATED |

