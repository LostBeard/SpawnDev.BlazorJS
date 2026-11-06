# PublicKeyCredentialDescriptor

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/CredentialRequestOptions.cs`  

> Contains the attributes that are specified by a caller when referring to a public key credential.

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Type` | `string` | get/set | The type of credential. Must be "public-key". |
| `Id` | `byte[]` | get/set | The credential ID of the public key credential the caller is referring to. |
| `Transports` | `string[]?` | get/set | The transports that the caller is willing to use. |
