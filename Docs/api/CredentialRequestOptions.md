# CredentialRequestOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/CredentialRequestOptions.cs`  

> Options for requesting a credential via navigator.credentials.get() https://w3c.github.io/webappsec-credential-management/#dictdef-credentialrequestoptions

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `CredentialRequestOptions` | `class` | get | Options for requesting a credential via navigator.credentials.get() https://w3c.github.io/webappsec-credential-management/#dictdef-credentialrequestoptions |
| `Password` | `bool?` | get |  |
| `Signal` | `AbortSignal?` | get |  |
| `Federated` | `FederatedCredentialRequestOptions?` | get |  |
| `PublicKey` | `PublicKeyCredentialRequestOptions?` | get |  |
| `Unmediated` | `bool?` | get |  |
| `FederatedCredentialRequestOptions` | `class` | get | Options for requesting federated credentials |
| `Protocols` | `string[]?` | get |  |
| `CredentialMediationRequirement` | `class` | get | Constants for valid mediation requirement values in CredentialRequestOptions |
| `CredentialRequestOptionsExtensions` | `class` | get | Extension methods for CredentialRequestOptions |
| `PublicKeyCredentialRequestOptions` | `class` | get | The PublicKeyCredentialRequestOptions dictionary supplies get() with the data it needs to generate an assertion. https://www.w3.org/TR/webauthn-2/#dictdef-publickeycredentialrequestoptions |
| `Timeout` | `ulong?` | get |  |
| `RpId` | `string?` | get |  |
| `AllowCredentials` | `PublicKeyCredentialDescriptor[]?` | get |  |
| `UserVerification` | `string?` | get |  |
| `Extensions` | `AuthenticationExtensionsClientInputs?` | get |  |
| `PublicKeyCredentialDescriptor` | `class` | get | Contains the attributes that are specified by a caller when referring to a public key credential. |
| `Id` | `byte[]` | get |  |
| `Transports` | `string[]?` | get |  |
| `AuthenticationExtensionsClientInputs` | `class` | get | Contains the client extension input values for authentication extensions. |
| `UserVerificationRequirement` | `class` | get | Constants for user verification requirement values |
| `AuthenticatorTransport` | `class` | get | Constants for authenticator transport values |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `WithSilentMediation(this CredentialRequestOptions options)` | `CredentialRequestOptions` | Creates a new CredentialRequestOptions with silent mediation |
| `WithPasswordCredentials(this CredentialRequestOptions options)` | `CredentialRequestOptions` | Creates a new CredentialRequestOptions configured for password credentials |
| `WithProviders(this CredentialRequestOptions options, params string[] providers)` | `CredentialRequestOptions` | Adds federated credential providers to the options |
| `WithProtocols(this CredentialRequestOptions options, params string[] protocols)` | `CredentialRequestOptions` | Adds federated credential protocols to the options |

