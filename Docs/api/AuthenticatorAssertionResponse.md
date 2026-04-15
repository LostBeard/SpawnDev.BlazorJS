# AuthenticatorAssertionResponse

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AuthenticatorResponse`  
**Source:** `JSObjects/AuthenticatorAssertionResponse.cs`  
**MDN Reference:** [AuthenticatorAssertionResponse on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AuthenticatorAssertionResponse)

> The AuthenticatorAssertionResponse interface of the Web Authentication API contains a digital signature from the private key of a particular WebAuthn credential. The relying party's server can verify this signature to authenticate a user, for example when they sign in. https://developer.mozilla.org/en-US/docs/Web/API/AuthenticatorAssertionResponse

## Constructors

| Signature | Description |
|---|---|
| `AuthenticatorAssertionResponse(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Signature` | `ArrayBuffer` | get | An assertion signature over AuthenticatorAssertionResponse.authenticatorData and AuthenticatorResponse.clientDataJSON. The assertion signature is created with the private key of the key pair that was created during the originating navigator.credentials.create() call and verified using the public key of that same key pair. |
| `AuthenticatorData` | `ArrayBuffer` | get | An ArrayBuffer containing information from the authenticator such as the Relying Party ID Hash (rpIdHash), a signature counter, test of user presence and user verification flags, and any extensions processed by the authenticator. |
| `UserHandle` | `ArrayBuffer` | get | An ArrayBuffer containing an opaque user identifier, specified as user.id in the options passed to the originating navigator.credentials.create() call. |

