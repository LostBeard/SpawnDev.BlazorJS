# CredentialsContainer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/CredentialsContainer.cs`  
**MDN Reference:** [CredentialsContainer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer)

> The CredentialsContainer interface of the Credential Management API exposes methods to request credentials and notify the user agent when events such as successful sign in or sign out happen. This interface is accessible from Navigator.credentials. https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer

## Constructors

| Signature | Description |
|---|---|
| `CredentialsContainer(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetDefaultCredentialsContainer()` | `CredentialsContainer` | Returns navigator.credentials |
| `Create()` | `Task<Credential>` | Returns a Promise that resolves with a new Credential instance based on the provided options, or null if no Credential object can be created. In exceptional circumstances, the Promise may reject. |
| `Create(CredentialCreateOptions options)` | `Task<T>` | Returns a Promise that resolves with a new Credential instance based on the provided options, or null if no Credential object can be created. In exceptional circumstances, the Promise may reject. |
| `Create(CredentialCreatePublicKeyOptions options)` | `Task<PublicKeyCredential<AuthenticatorAttestationResponse>>` | Returns a Promise that resolves with a new Credential instance based on the provided options, or null if no Credential object can be created. In exceptional circumstances, the Promise may reject. |
| `Get()` | `Task<Credential?>` | Returns a Promise that resolves with the Credential instance that matches the provided parameters. |
| `Get(CredentialGetOptions options)` | `Task<T>` | Returns a Promise that resolves with the Credential instance that matches the provided parameters. |
| `Get(CredentialGetPublicKeyOptions options)` | `Task<PublicKeyCredential<AuthenticatorAssertionResponse>?>` | Returns a Promise that resolves with the PublicKeyCredential or null |
| `PreventSilentAccess()` | `Task` | Sets a flag that specifies whether automatic log in is allowed for future visits to the current origin, then returns an empty Promise. For example, you might call this, after a user signs out of a website to ensure that they aren't automatically signed in on the next site visit. Earlier versions of the spec called this method requireUserMediation(). See Browser compatibility for support details. |
| `Store(Credential credentials)` | `Task` | Stores a set of credentials for a user, inside a provided Credential instance and returns that instance in a Promise. |

