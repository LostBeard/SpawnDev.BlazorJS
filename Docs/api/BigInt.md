# BigInt<T>

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/BigInt.cs`  
**MDN Reference:** [BigInt<T> on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/BigInt)

> BigInt values represent numeric values which are too large to be represented by the number primitive. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/BigInt

## Constructors

| Signature | Description |
|---|---|
| `BigInt()` | Default 0 argument constructor |
| `BigInt(T value)` | Creates a new instance of BigInt |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ValueString` | `string` | get/set |  |
| `Value` | `T` | get |  |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Equals(object? obj)` | `bool` | Returns true if the specified object is equal to the current object. |
| `T(BigInt<T> bigInt)` | `implicit operator` | Implicit conversion to T |
| `GetHashCode()` | `int` |  |

