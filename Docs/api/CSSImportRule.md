# CSSImportRule

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `CSSRule`  
**Source:** `JSObjects/CSSImportRule.cs`  

> The CSSImportRule interface represents an @import at-rule.

## Constructors

| Signature | Description |
|---|---|
| `CSSImportRule(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Href` | `string` | get | Returns the URL specified by the @import rule. |
| `LayerName` | `string?` | get | Returns the name of the cascade layer declared in the @import rule, the empty string if the layer is anonymous, the or null if the rule doesn't declare any. |
| `Media` | `MediaList` | get | Returns the value of the media attribute of the associated stylesheet. |
| `StyleSheet` | `CSSStyleSheet` | get | Returns the associated stylesheet. |
| `SupportsText` | `string?` | get | Returns the supports condition specified by the @import rule. |
