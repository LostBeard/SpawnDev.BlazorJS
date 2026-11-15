# PublicKeyCredential

**Namespace:** `SpawnDev.BlazorJS.JSObjects`
**Inherits:** `Credential`
**Source:** `JSObjects/PublicKeyCredential.cs`

> The PublicKeyCredential interface provides information about a public key / private key pair, which is a credential for logging in to a service using an un-phishable and data-breach resistant asymmetric key pair instead of a password. It inherits from Credential, and is part of the Web Authentication API extension to the Credential Management API.

The non-generic class holds the members that do not depend on the response type, including the WebAuthn JSON converters, which exchange options and responses with a relying party server as the standard base64url JSON (Fido2NetLib, SimpleWebAuthn, py_webauthn ...) without any ArrayBuffer crossing into .NET. `PublicKeyCredential<TResponse>` derives from it and adds `Response`.

## Constructors

| Signature | Description |
|---|---|
| `PublicKeyCredential(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RawId` | `ArrayBuffer` | get | An ArrayBuffer that holds the globally unique identifier for this PublicKeyCredential. This identifier can be used to look up credentials for future calls to navigator.credentials.get(). |
| `AuthenticatorAttachment` | `string` | get | A string that indicates the mechanism by which the WebAuthn implementation is attached to the authenticator at the time the associated navigator.credentials.create() or navigator.credentials.get() call completes. |
| `IsJSONSupported` | `bool` | get (static) | True when the browser has parseCreationOptionsFromJSON(), parseRequestOptionsFromJSON() and toJSON() (Chrome / Edge 129+, Firefox 119+, Safari 18.4+). |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ToJSON()` | `JSObject` | The JSON-type representation of this credential (RegistrationResponseJSON after create(), AuthenticationResponseJSON after get()), binary members as base64url strings. |
| `ToJSONString()` | `string` | `ToJSON()` as a JSON string, the body to POST to a relying party server. |
| `IsUserVerifyingPlatformAuthenticatorAvailable()` | `Task<bool>` | Returns a Promise which resolves to true if an authenticator bound to the platform is capable of verifying the user. |
| `IsConditionalMediationAvailable()` | `Task<bool>` | Returns a Promise which resolves to true if conditional mediation is available. |
| `ParseCreationOptionsFromJSON(string json)` | `ParsedPublicKeyCredentialCreationOptions` | (static) The server's PublicKeyCredentialCreationOptions JSON as the options object create() takes (challenge, user.id, excludeCredentials[].id become ArrayBuffers). |
| `ParseCreationOptionsFromJSON(JSObject optionsJSON)` | `ParsedPublicKeyCredentialCreationOptions` | (static) The same from an already parsed JSON object. |
| `ParseRequestOptionsFromJSON(string json)` | `ParsedPublicKeyCredentialRequestOptions` | (static) The server's PublicKeyCredentialRequestOptions JSON as the options object get() takes (challenge, allowCredentials[].id become ArrayBuffers). |
| `ParseRequestOptionsFromJSON(JSObject optionsJSON)` | `ParsedPublicKeyCredentialRequestOptions` | (static) The same from an already parsed JSON object. |

## Example

```csharp
using var credentials = CredentialsContainer.GetDefaultCredentialsContainer();
// registration: the server's options JSON in, the response JSON out
using var creationOptions = PublicKeyCredential.ParseCreationOptionsFromJSON(serverCreationOptionsJson);
using var created = await credentials.Create(creationOptions);
string registrationJson = created.ToJSONString(); // POST to the server
// sign-in
using var requestOptions = PublicKeyCredential.ParseRequestOptionsFromJSON(serverRequestOptionsJson);
using var asserted = await credentials.Get(requestOptions);
string authenticationJson = asserted!.ToJSONString(); // POST to the server
```

# PublicKeyCredential<TResponse>

**Inherits:** `PublicKeyCredential where TResponse : AuthenticatorResponse`

## Constructors

| Signature | Description |
|---|---|
| `PublicKeyCredential(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Response` | `TResponse` | get | An instance of an AuthenticatorResponse object. It is either of type AuthenticatorAttestationResponse if the PublicKeyCredential was the results of a navigator.credentials.create() call, or of type AuthenticatorAssertionResponse if the PublicKeyCredential was the result of a navigator.credentials.get() call. |
