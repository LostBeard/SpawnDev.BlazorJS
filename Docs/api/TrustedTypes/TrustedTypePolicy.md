# TrustedTypePolicy

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/TrustedTypes/TrustedTypePolicy.cs`  

> A Trusted Type policy created via CreatePolicy. Its `Create*` methods turn an input string into the matching Trusted Type by running it through the policy's callback, which the browser then accepts at an injection sink (innerHTML, DOMParser.parseFromString, script src, ...) where a plain string is refused under a `require-trusted-types-for 'script'` CSP. https://developer.mozilla.org/en-US/docs/Web/API/TrustedTypePolicy

## Constructors

| Signature | Description |
|---|---|
| `TrustedTypePolicy(IJSInProcessObjectReference _ref)` | Deserialization constructor. Instances are produced by the factory, never constructed directly. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `string` | get | The name this policy was created with. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateHTML(string input)` | `TrustedHTML` | Runs input through this policy's `createHTML` callback and returns the resulting TrustedHTML. Throws if the policy was created without a `createHTML` callback. |
| `CreateScript(string input)` | `TrustedScript` | Runs input through this policy's `createScript` callback and returns the resulting TrustedScript. |
| `CreateScriptURL(string input)` | `TrustedScriptURL` | Runs input through this policy's `createScriptURL` callback and returns the resulting TrustedScriptURL. |
