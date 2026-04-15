# Credential

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Credential.cs`  
**MDN Reference:** [Credential on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Credential)

> The Credential interface of the Credential Management API provides information about an entity (usually a user) normally as a prerequisite to a trust decision. Credential objects may be of the following types: FederatedCredential IdentityCredential PasswordCredential PublicKeyCredential OTPCredential https://developer.mozilla.org/en-US/docs/Web/API/Credential

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Id` | `string` | get | Returns a string containing the credential's identifier. This might be any one of a GUID, username, or email address. |
| `Type` | `string` | get | Returns a string containing the credential's type. Valid values are password, federated, public-key, identity and otp. (For PasswordCredential, FederatedCredential, PublicKeyCredential, IdentityCredential and OTPCredential) |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<Credential>(...)` or constructor `new Credential(...)`

```js
const pwdCredential = new PasswordCredential({
  id: "example-username", // Username/ID
  name: "Carina Anand", // Display name
  password: "correct horse battery staple", // Password
});

console.assert(pwdCredential.type === "password");
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Credential)*

