# PublicKeyCredentialRequestOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/CredentialRequestOptions.cs`  

> The PublicKeyCredentialRequestOptions dictionary supplies get() with the data it needs to generate an assertion. https://www.w3.org/TR/webauthn-2/#dictdef-publickeycredentialrequestoptions

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Challenge` | `byte[]?` | get/set | A challenge that the authenticator signs, along with other data, when producing an authentication assertion. Must be a cryptographically random buffer of at least 16 bytes. |
| `Timeout` | `ulong?` | get/set | Specifies a time, in milliseconds, that the caller is willing to wait for the call to complete. This is treated as a hint, and may be overridden by the platform. |
| `RpId` | `string?` | get/set | Identifier for the Relying Party responsible for the request. |
| `AllowCredentials` | `PublicKeyCredentialDescriptor[]?` | get/set | List of credentials acceptable to the caller, in order of the caller's preference. |
| `UserVerification` | `string?` | get/set | The caller's requirements regarding user verification. |
| `Extensions` | `AuthenticationExtensionsClientInputs?` | get/set | Additional extensions the caller wishes to process or generate. |
