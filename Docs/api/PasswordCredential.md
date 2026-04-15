# PasswordCredential

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Credential`  
**Source:** `JSObjects/PasswordCredential.cs`  

> The PasswordCredential interface of the Credential Management API provides information about a username/password pair.

## Constructors

| Signature | Description |
|---|---|
| `PasswordCredential(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `PasswordCredential(PasswordCredentialData data)` | The PasswordCredential() constructor creates a new PasswordCredential object. |
| `PasswordCredential(HTMLFormElement data)` | The PasswordCredential() constructor creates a new PasswordCredential object. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IconURL` | `string?` | get | Returns a string containing a URL of an image for a user's avatar. |
| `Name` | `string?` | get | Returns a string containing the name used to display the user's name when sign-in or sign-up is in progress. |
| `Password` | `string?` | get | Returns a string containing the user's password. |

