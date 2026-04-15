# ScreenDetails

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/ScreenDetails.cs`  
**MDN Reference:** [ScreenDetails on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ScreenDetails)

> The ScreenDetails interface of the Window Management API represents the details of all the screens available to the user's device. https://developer.mozilla.org/en-US/docs/Web/API/ScreenDetails

## Constructors

| Signature | Description |
|---|---|
| `ScreenDetails(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `CurrentScreen` | `ScreenDetailed` | get | A single ScreenDetailed object representing detailed information about the screen that the current browser window is displayed in. |
| `Screens` | `Array<ScreenDetailed>` | get | An array of ScreenDetailed objects, each one representing detailed information about one specific screen available to the user's device. Note: screens only includes "extended" displays, not those that mirror another display. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnCurrentScreenChange` | `ActionEvent<Event>` | Fired when the window's current screen changes in some way - for example available width or height, or orientation. |
| `OnScreenChange` | `ActionEvent<Event>` | Fired when screens are connected to or disconnected from the system. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ScreenDetails>(...)` or constructor `new ScreenDetails(...)`

### Basic screen information access

```js
const screenDetails = await window.getScreenDetails();

// Open a window on each screen of the device
for (const screen of screenDetails.screens) {
  openWindow(
    screen.availLeft,
    screen.availTop,
    screen.availWidth,
    screen.availHeight,
    url,
  );
}
```

### Responding to changes in available screens

```js
const screenDetails = await window.getScreenDetails();

// Return the number of screens
let noOfScreens = screenDetails.screens.length;

screenDetails.addEventListener("screenschange", () => {
  // If the new number of screens is different to the old number of screens,
  // report the difference
  if (screenDetails.screens.length !== noOfScreens) {
    console.log(
      `The screen count changed from ${noOfScreens} to ${screenDetails.screens.length}`,
    );

    // Update noOfScreens value
    noOfScreens = screenDetails.screens.length;
  }

  // Open, close, or rearrange windows as needed,
  // to fit the new screen configuration
  updateWindows();
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ScreenDetails)*

