# CaptureStartFocusBehavior

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/CaptureStartFocusBehavior.cs`  

> Describes whether an application invoking setFocusBehavior() would like the user agent to focus the display surface associated with that CaptureController's capture-session. https://www.w3.org/TR/screen-capture/#dom-capturestartfocusbehavior

## Values

| Name | JSON Value | Description |
|---|---|---|
| `FocusCapturingApplication` | `"focus-capturing-application"` | The application prefers to be focused. |
| `FocusCapturedSurface` | `"focus-captured-surface"` | The application prefers that the display surface associated with this CaptureController's capture-session be focused. |
| `NoFocusChange` | `"no-focus-change"` | The application prefers that the user agent not change focus, leaving focus with whichever surface last had focus following the user's interaction with the user agent and/or operating system. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `CaptureStartFocusBehavior` | `enum` | get | Describes whether an application invoking setFocusBehavior() would like the user agent to focus the display surface associated with that CaptureController's capture-session. https://www.w3.org/TR/screen-capture/#dom-capturestartfocusbehavior |

