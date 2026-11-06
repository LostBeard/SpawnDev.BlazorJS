# IScreen

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/IScreen.cs`  

> The IScreen interface of the Screen API represents a screen, usually the one on which the current window is being rendered.

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IScreen` | `interface` | get | The IScreen interface of the Screen API represents a screen, usually the one on which the current window is being rendered. |
| `AvailHeight` | `int` | get | Specifies the height of the screen, in pixels, minus permanent or semipermanent user interface features displayed by the operating system, such as the Taskbar on Windows. |
| `AvailLeft` | `int` | get | Returns the first available pixel available from the left side of the screen. |
| `AvailTop` | `int` | get | Specifies the y-coordinate of the first pixel that is not allocated to permanent or semipermanent user interface features. |
| `AvailWidth` | `int` | get | Specifies the width of the screen, in pixels, minus permanent or semipermanent user interface features, such as the Taskbar on Windows. |
| `ColorDepth` | `int` | get | Returns the color depth of the screen. |
| `DevicePixelRatio` | `double` | get | Returns the ratio of physical pixels to device independent pixels for the screen. |
| `Height` | `int` | get | Returns the height of the screen in pixels. |
| `IsExtended` | `bool` | get | Returns true if the user's device has multiple screens. |
| `Orientation` | `ScreenOrientation` | get | Returns the ScreenOrientation instance associated with this screen. |
| `PixelDepth` | `int` | get | Gets the bit depth of the screen. |
| `Width` | `int` | get | Returns the width of the screen. |

