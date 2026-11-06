# TrustedScript

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/TrustedTypes/TrustedScript.cs`  

> An immutable, policy-approved script string. Produced by CreateScript and accepted by script injection sinks (e.g. an inline event handler property, `eval`) on a page whose CSP enforces `require-trusted-types-for 'script'`. https://developer.mozilla.org/en-US/docs/Web/API/TrustedScript

## Constructors

| Signature | Description |
|---|---|
| `TrustedScript(IJSInProcessObjectReference _ref)` | Deserialization constructor. Instances are produced by a policy, never constructed directly. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ToString()` | `string` | Returns the underlying sanitized script string. |
