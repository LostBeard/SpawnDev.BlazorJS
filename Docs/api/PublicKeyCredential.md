# PublicKeyCredential<TResponse>

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Credential where TResponse : AuthenticatorResponse`  
**Source:** `JSObjects/PublicKeyCredential.cs`  

> The PublicKeyCredential interface provides information about a public key / private key pair, which is a credential for logging in to a service using an un-phishable and data-breach resistant asymmetric key pair instead of a password. It inherits from Credential, and is part of the Web Authentication API extension to the Credential Management API.

## Constructors

| Signature | Description |
|---|---|
| `PublicKeyCredential(IJSInProcessObjectReference _ref)` | Default deserialize constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RawId` | `ArrayBuffer` | get | An ArrayBuffer that holds the globally unique identifier for this PublicKeyCredential. This identifier can be used to look up credentials for future calls to navigator.credentials.get(). |
| `AuthenticatorAttachment` | `string` | get | A string that indicates the mechanism by which the WebAuthn implementation is attached to the authenticator at the time the associated navigator.credentials.create() or navigator.credentials.get() call completes. |
| `Response` | `TResponse` | get | An instance of an AuthenticatorResponse object. It is either of type AuthenticatorAttestationResponse if the PublicKeyCredential was the results of a navigator.credentials.create() call, or of type AuthenticatorAssertionResponse if the PublicKeyCredential was the result of a navigator.credentials.get() call. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `IsUserVerifyingPlatformAuthenticatorAvailable()` | `Task<bool>` | Returns a Promise which resolves to true if an authenticator bound to the platform is capable of verifying the user. |
| `IsConditionalMediationAvailable()` | `Task<bool>` | Returns a Promise which resolves to true if conditional mediation is available. |

