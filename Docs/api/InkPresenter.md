# InkPresenter

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/InkPresenter.cs`  
**MDN Reference:** [InkPresenter on MDN](https://developer.mozilla.org/en-US/docs/Web/API/InkPresenter)

> The InkPresenter interface of the Ink API provides the ability to instruct the OS-level compositor to render ink strokes between pointer event dispatches. https://developer.mozilla.org/en-US/docs/Web/API/InkPresenter

## Constructors

| Signature | Description |
|---|---|
| `InkPresenter(IJSInProcessObjectReference _ref)` | Creates a new instance of `InkPresenter`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ExpectedImprovement` | `float` | get | Returns a value, in milliseconds, indicating the latency improvement that can be expected using this presenter. |
| `PresentationArea` | `Element` | get | Returns the Element inside which rendering of ink strokes is confined. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `UpdateInkTrailStartPoint(PointerEvent pointerEvent, InkPresenterStyle style)` | `void` | Passes the PointerEvent that was used as the last rendering point for the current frame, allowing the OS-level compositor to render a delegated ink trail ahead of the next pointer event being dispatched. |

