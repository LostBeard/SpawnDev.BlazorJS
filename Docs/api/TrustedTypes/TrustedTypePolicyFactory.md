# TrustedTypePolicyFactory

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/TrustedTypes/TrustedTypePolicyFactory.cs`  

> `window.trustedTypes` - creates Trusted Type policies and inspects Trusted Type values. The global exists only when the browser supports Trusted Types; on other browsers it is `undefined`, so read it as a nullable and treat null as "Trusted Types not present / not enforced": var tt = JS.Get<TrustedTypePolicyFactory?>("trustedTypes"); https://developer.mozilla.org/en-US/docs/Web/API/TrustedTypePolicyFactory

## Constructors

| Signature | Description |
|---|---|
| `TrustedTypePolicyFactory(IJSInProcessObjectReference _ref)` | Deserialization constructor. Obtain the factory from `globalThis.trustedTypes` rather than constructing it. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DefaultPolicy` | `TrustedTypePolicy?` | get | The default policy, or null if none has been created. |
| `EmptyHTML` | `TrustedHTML` | get | A zero-length TrustedHTML - a convenient way to safely clear HTML. |
| `EmptyScript` | `TrustedScript` | get | A zero-length TrustedScript. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreatePolicy(string policyName, TrustedTypePolicyOptions? options = null)` | `TrustedTypePolicy` | Creates a TrustedTypePolicy with the given name and callbacks. If the page's CSP restricts the `trusted-types` directive to an allowlist, creating a policy whose name is not on that allowlist throws a `TypeError`; a name of `"default"` installs the special default policy that the platform calls for every otherwise-unsafe assignment, so avoid it unless that is intended. |
| `IsHTML(object? value)` | `bool` | Returns true if value is a TrustedHTML from any policy in this document. |
| `IsScript(object? value)` | `bool` | Returns true if value is a TrustedScript. |
| `IsScriptURL(object? value)` | `bool` | Returns true if value is a TrustedScriptURL. |
