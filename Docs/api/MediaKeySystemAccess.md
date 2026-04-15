# MediaKeySystemAccess

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/MediaKeySystemAccess.cs`  
**MDN Reference:** [MediaKeySystemAccess on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaKeySystemAccess)

> The MediaKeySystemAccess interface of the Encrypted Media Extensions API provides access to a Key System for decryption and/or a content protection provider. You can request an instance of this object using the Navigator.requestMediaKeySystemAccess() method. https://developer.mozilla.org/en-US/docs/Web/API/MediaKeySystemAccess

## Constructors

| Signature | Description |
|---|---|
| `MediaKeySystemAccess(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `KeySystem` | `string` | get | Returns a string identifying the key system being used. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateMediaKeys()` | `Task<MediaKeys>` | Returns a Promise that resolves to a new MediaKeys object. |
| `GetConfiguration()` | `Task<MediaKeySystemAccessConfig>` | Returns an object with the supported combination of configuration options. |

