# ParsedPublicKeyCredentialCreationOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`
**Inherits:** `JSObject`
**Source:** `JSObjects/ParsedPublicKeyCredentialOptions.cs`

> A PublicKeyCredentialCreationOptions object made by the browser from its JSON form (`PublicKeyCredential.ParseCreationOptionsFromJSON`): challenge, user.id and excludeCredentials[].id are ArrayBuffers that stay in Javascript. Pass it to `CredentialsContainer.Create`. https://developer.mozilla.org/en-US/docs/Web/API/PublicKeyCredentialCreationOptions

## Constructors

| Signature | Description |
|---|---|
| `ParsedPublicKeyCredentialCreationOptions(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Challenge` | `ArrayBuffer` | get | The challenge (decoded from base64url). |
