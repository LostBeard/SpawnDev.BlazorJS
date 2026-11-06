# TrustedTypePolicyOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/TrustedTypes/TrustedTypePolicyOptions.cs`  

> Callbacks passed to CreatePolicy. Each receives the untrusted input string (and any extra arguments) and returns the approved string used to build the matching Trusted Type. A callback left null means the policy does not produce that type, and calling the corresponding `Create*` on the policy will throw. Provide a Callback (e.g. `Callback.Create<string, string>(s => s)`) rather than building a JS function with `new Function(...)`: a page enforcing Trusted Types typically also blocks `unsafe-eval`, so an eval-built function would be refused, whereas a Callback is a pre-registered function and is not. https://developer.mozilla.org/en-US/docs/Web/API/TrustedTypePolicyFactory/createPolicy#policyoptions

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `CreateHTML` | `Callback?` | get/set | Callback that builds a TrustedHTML: takes the input string, returns a string. |
| `CreateScript` | `Callback?` | get/set | Callback that builds a TrustedScript: takes the input string, returns a string. |
| `CreateScriptURL` | `Callback?` | get/set | Callback that builds a TrustedScriptURL: takes the input string, returns a string. |
