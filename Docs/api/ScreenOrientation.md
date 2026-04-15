# ScreenOrientation

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/ScreenOrientation.cs`  
**MDN Reference:** [ScreenOrientation on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ScreenOrientation)

> The ScreenOrientation interface of the Screen Orientation API provides information about the current orientation of the document. A ScreenOrientation instance object can be retrieved using the screen.orientation property. https://developer.mozilla.org/en-US/docs/Web/API/ScreenOrientation

## Constructors

| Signature | Description |
|---|---|
| `ScreenOrientation(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Type` | `string` | get | Returns the document's current orientation type, one of: portrait-primary portrait-secondary landscape-primary landscape-secondary |
| `Angle` | `double` | get | Returns the document's current orientation angle. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Lock(string orientation)` | `Task` | Locks the orientation of the containing document to its default orientation and returns a Promise. An orientation lock type. One of the following: "any" - Any of portrait-primary, portrait-secondary, landscape-primary or landscape-secondary. "natural" - The natural orientation of the screen from the underlying operating system: either portrait-primary or landscape-primary. "landscape" - An orientation where screen width is greater than the screen height. Depending on the platform convention, this may be landscape-primary, landscape-secondary, or both. "portrait" - An orientation where screen height is greater than the screen width. Depending on the platform convention, this may be portrait-primary, portrait-secondary, or both. "portrait-primary" - The "primary" portrait mode. If the natural orientation is a portrait mode (screen height is greater than width), this will be the same as the natural orientation, and correspond to an angle of 0 degrees. If the natural orientation is a landscape mode, then the user agent can choose either portrait orientation as the portrait-primary and portrait-secondary; one of those will be assigned the angle of 90 degrees and the other will have an angle of 270 degrees. "portrait-secondary" - The secondary portrait orientation. If the natural orientation is a portrait mode, this will have an angle of 180 degrees (in other words, the device is upside down relative to its natural orientation). If the natural orientation is a landscape mode, this can be either orientation as selected by the user agent: whichever was not selected for portrait-primary. "landscape-primary" - The "primary" landscape mode. If the natural orientation is a landscape mode (screen width is greater than height), this will be the same as the natural orientation, and correspond to an angle of 0 degrees. If the natural orientation is a portrait mode, then the user agent can choose either landscape orientation as the landscape-primary with an angle of either 90 or 270 degrees (landscape-secondary will be the other orientation and angle). "landscape-secondary" - The secondary landscape mode. If the natural orientation is a landscape mode, this orientation is upside down relative to the natural orientation, and will have an angle of 180 degrees. If the natural orientation is a portrait mode, this can be either orientation as selected by the user agent: whichever was not selected for landscape-primary. A Promise that resolves after locking succeeds. |
| `Unlock()` | `void` | Unlocks the orientation of the containing document from its default orientation. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnChange` | `ActionEvent<Event>` | Fired whenever the screen changes orientation. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ScreenOrientation>(...)` or constructor `new ScreenOrientation(...)`

```js
screen.orientation.addEventListener("change", (event) => {
  const type = event.target.type;
  const angle = event.target.angle;
  console.log(`ScreenOrientation change: ${type}, ${angle} degrees.`);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ScreenOrientation)*

