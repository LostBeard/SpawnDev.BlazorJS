# IdleDeadline

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/IdleDeadline.cs`  
**MDN Reference:** [IdleDeadline on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IdleDeadline)

> The IdleDeadline interface is used as the data type of the input parameter to idle callbacks established by calling Window.requestIdleCallback(). It offers a method, timeRemaining(), which lets you determine how much longer the user agent estimates it will remain idle and a property, didTimeout, which lets you determine if your callback is executing because its timeout duration expired. https://developer.mozilla.org/en-US/docs/Web/API/IdleDeadline

## Constructors

| Signature | Description |
|---|---|
| `IdleDeadline(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DidTimeout` | `bool` | get | A Boolean whose value is true if the callback is being executed because the timeout specified when the idle callback was installed has expired. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `TimeRemaining()` | `double` | Returns a DOMHighResTimeStamp, which is a floating-point value providing an estimate of the number of milliseconds remaining in the current idle period. If the idle period is over, the value is 0. Your callback can call this repeatedly to see if there's enough time left to do more work before returning. |

