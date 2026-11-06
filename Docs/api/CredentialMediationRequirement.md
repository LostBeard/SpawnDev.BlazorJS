# CredentialMediationRequirement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/CredentialRequestOptions.cs`  

> Constants for valid mediation requirement values in CredentialRequestOptions

## Constants

| Name | Value | Description |
|---|---|---|
| `Silent` | `"silent"` | The user agent will not show any user interface. If a credential cannot be returned without user interface, the operation will fail. |
| `Optional` | `"optional"` | The user agent may show user interface if it would be helpful. |
| `Required` | `"required"` | The user agent will always show some user interface. |
| `Conditional` | `"conditional"` | The user agent will only show user interface if certain requirements are met. |
