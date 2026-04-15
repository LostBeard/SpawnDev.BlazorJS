# StringPrimitive

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/StringPrimitive.cs`  
**MDN Reference:** [StringPrimitive on MDN](https://developer.mozilla.org/en-US/docs/Glossary/Primitive)

> https://developer.mozilla.org/en-US/docs/Glossary/Primitive

## Constructors

| Signature | Description |
|---|---|
| `StringPrimitive(object thing)` | The StringPrimitive() constructor calls the String function to create a new string primitive. Anything to be converted to a string. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `long` | get | Returns the string's length |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `string(StringPrimitive stringPrimitive)` | `explicit operator` | Explicit cast from StringPrimitive to .Net string StringPrimitive |
| `Create(Uint8Array stringBytes, string label)` | `StringPrimitive` | Create a new from a Uint8Array |
| `Create(byte[] stringBytes, string label)` | `StringPrimitive` | Create a new from a byte[] |
| `Create(string source)` | `StringPrimitive` | Create a new from a string |
| `ToString()` | `string` | Returns the primitive string as a .Net string |

