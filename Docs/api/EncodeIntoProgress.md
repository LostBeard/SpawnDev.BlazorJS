# EncodeIntoProgress

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/EncodeIntoProgress.cs`  

> Returned fro ma call to TextEncoder.EncodeInto

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `EncodeIntoProgress` | `class` | get | Returned fro ma call to TextEncoder.EncodeInto |
| `Wrtitten` | `int` | get | The number of bytes modified in the destination Uint8Array. The bytes written are guaranteed to form complete UTF-8 byte sequences. |
| `Read` | `int` | get/set | The number of UTF-16 units of code from the source that has been converted over to UTF-8. This may be less than string.length if uint8Array did not have enough space. |

