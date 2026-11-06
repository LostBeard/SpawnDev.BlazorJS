# ECJWKPublic

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JWK`  
**Source:** `JSObjects/JWK.cs`  

> Contains public key

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Crv` | `string?` | get |  |
| `Dp` | `string?` | get |  |
| `Dq` | `string?` | get |  |
| `Qi` | `string?` | get |  |
| `JWK` | `class` | get | JSON Web Key (JWK) Format https://datatracker.ietf.org/doc/html/rfc7517#section-4 |
| `Use` | `string?` | get |  |
| `KeyOps` | `string[]?` | get |  |
| `Alg` | `string?` | get/set |  |
| `KId` | `string?` | get |  |
| `X5u` | `string?` | get |  |
| `X5c` | `string[]?` | get |  |
| `X5t` | `string[]?` | get |  |
| `KeyType` | `string` | get/set | "kty" (Key Type) Parameter The "kty" (key type) parameter identifies the cryptographic algorithm family used with the key, such as "RSA" or "EC". "kty" values should either be registered in the IANA "JSON Web Key Types" registry established by [JWA] or be a value that contains a Collision- Resistant Name. The "kty" value is a case-sensitive string. This member MUST be present in a JWK. |

