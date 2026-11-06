# TrustedHTML

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/TrustedTypes/TrustedHTML.cs`  

> An immutable, policy-approved HTML string. Produced by CreateHTML and accepted by HTML injection sinks (Element.innerHTML/outerHTML, DOMParser.parseFromString, ...) on a page whose CSP enforces `require-trusted-types-for 'script'`, where a plain string is refused. https://developer.mozilla.org/en-US/docs/Web/API/TrustedHTML

## Constructors

| Signature | Description |
|---|---|
| `TrustedHTML(IJSInProcessObjectReference _ref)` | Deserialization constructor. Instances are produced by a policy, never constructed directly. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ToString()` | `string` | Returns the underlying sanitized HTML string. |
