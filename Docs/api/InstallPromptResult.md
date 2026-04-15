# InstallPromptResult

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/InstallPromptResult.cs`  

> The InstallPromptResult interface represents the result of the prompt() method of the BeforeInstallPromptEvent.

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `InstallPromptResult` | `class` | get | The InstallPromptResult interface represents the result of the prompt() method of the BeforeInstallPromptEvent. |
| `Platform` | `string?` | get | If the user chose to install the app, this is a string naming the selected platform, which is one of the values from the BeforeInstallPromptEvent.platforms property. If the user chose not to install the app, this is an empty string. |

