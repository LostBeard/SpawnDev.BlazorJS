# LaunchParams

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/LaunchParams.cs`  

> The LaunchParams interface of the Launch Handler API is used when implementing custom launch navigation handling in a PWA. When window.launchQueue.setConsumer() is invoked to set up the launch navigation handling functionality, the callback function inside setConsumer() is passed a LaunchParams object instance. Such custom navigation handling is initiated via Window.launchQueue when a PWA has been launched with a launch_handler client_mode value of focus-existing, navigate-new, or navigate-existing

## Constructors

| Signature | Description |
|---|---|
| `LaunchParams(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Files` | `FileSystemHandle[]` | get | Returns a read-only array of FileSystemHandle objects representing any files passed along with the launch navigation via the POST method |
| `TargetURL` | `string` | get | Returns the target URL of the launch. |

