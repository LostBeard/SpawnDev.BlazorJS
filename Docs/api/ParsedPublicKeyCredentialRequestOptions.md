# ParsedPublicKeyCredentialRequestOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`
**Inherits:** `JSObject`
**Source:** `JSObjects/ParsedPublicKeyCredentialOptions.cs`

> A PublicKeyCredentialRequestOptions object made by the browser from its JSON form (`PublicKeyCredential.ParseRequestOptionsFromJSON`): challenge and allowCredentials[].id are ArrayBuffers that stay in Javascript. Pass it to `CredentialsContainer.Get`. https://developer.mozilla.org/en-US/docs/Web/API/PublicKeyCredentialRequestOptions

## Constructors

| Signature | Description |
|---|---|
| `ParsedPublicKeyCredentialRequestOptions(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Challenge` | `ArrayBuffer` | get | The challenge (decoded from base64url). |
