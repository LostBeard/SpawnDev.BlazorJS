# Screen

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Screen.cs`  
**MDN Reference:** [Screen on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Screen)

> The Screen interface represents a screen, usually the one on which the current window is being rendered, and is obtained using window.screen. https://developer.mozilla.org/en-US/docs/Web/API/Screen

## Constructors

| Signature | Description |
|---|---|
| `Screen(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AvailHeight` | `int` | get | Specifies the height of the screen, in pixels, minus permanent or semipermanent user interface features displayed by the operating system, such as the Taskbar on Windows. |
| `AvailLeft` | `int?` | get | A number representing the x-coordinate (left-hand edge) of the available screen area. |
| `AvailTop` | `int?` | get | A number representing the y-coordinate (top edge) of the available screen area. |
| `AvailWidth` | `int` | get | Returns the amount of horizontal space in pixels available to the window. |
| `ColorDepth` | `int` | get | Returns the color depth of the screen. |
| `Height` | `int` | get | Returns the height of the screen in pixels. |
| `IsExtended` | `bool` | get | Returns true if the user's device has multiple screens, and false if not. |
| `Orientation` | `ScreenOrientation?` | get | Returns the ScreenOrientation instance associated with this screen. inconsistent browser support |
| `PixelDepth` | `int` | get | Gets the bit depth of the screen. |
| `Width` | `int` | get | Returns the width of the screen. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnChange` | `ActionEvent<Event>` | Fired on a specific screen when it changes in some way - width or height, available width or height, color depth, or orientation. |
| `OnOrientationChange` | `ActionEvent<Event>` | Fires when the screen orientation changes. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<Screen>(...)` or constructor `new Screen(...)`

```js
if (screen.colorDepth < 8) {
  // use low-color version of page
} else {
  // use regular, colorful page
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Screen)*

