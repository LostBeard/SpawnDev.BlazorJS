# TrustedScriptURL

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/TrustedTypes/TrustedScriptURL.cs`  

> An immutable, policy-approved URL string for loading a script. Produced by CreateScriptURL and accepted by script-URL injection sinks (e.g. `HTMLScriptElement.src`, `Worker` URL) on a page whose CSP enforces `require-trusted-types-for 'script'`. https://developer.mozilla.org/en-US/docs/Web/API/TrustedScriptURL

## Constructors

| Signature | Description |
|---|---|
| `TrustedScriptURL(IJSInProcessObjectReference _ref)` | Deserialization constructor. Instances are produced by a policy, never constructed directly. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ToString()` | `string` | Returns the underlying sanitized URL string. |
