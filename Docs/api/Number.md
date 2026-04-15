# Number

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Number.cs`  
**MDN Reference:** [Number on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Number)

> Number values represent floating-point numbers like 37 or -9.25. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Number

## Constructors

| Signature | Description |
|---|---|
| `Number(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Number(Union<int, uint, float, double, long, ulong, byte, short, ushort> value)` | Creates a new Number |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `POSITIVE_INFINITY` | `Number` | get | The Number.POSITIVE_INFINITY static data property represents the positive Infinity value. |
| `NEGATIVE_INFINITY` | `Number` | get | The Number.NEGATIVE_INFINITY static data property represents the negative Infinity value. |
| `NaN` | `Number` | get | The Number.NaN static data property represents Not-A-Number, which is equivalent to NaN. For more information about the behaviors of NaN, see the description for the global property. |
| `MIN_VALUE` | `Number` | get | The Number.MIN_VALUE static data property represents the smallest positive numeric value representable in JavaScript. |
| `MAX_VALUE` | `Number` | get | The Number.MAX_VALUE static data property represents the maximum numeric value representable in JavaScript. |
| `MAX_SAFE_INTEGER` | `long` | get | The Number.MAX_SAFE_INTEGER static data property represents the maximum safe integer in JavaScript (253 - 1). |
| `MIN_SAFE_INTEGER` | `long` | get | The Number.MIN_SAFE_INTEGER static data property represents the minimum safe integer in JavaScript, or -(253 - 1). |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ValueOfFloat()` | `float` | Returns the value of the object as a float |
| `ValueOfDouble()` | `double` | Returns the value of the object as a double |
| `ValueOfInt32()` | `int` | Returns the value of the object as an int |
| `ValueOfUint32()` | `uint` | Returns the value of the object as a uint |
| `ValueOfInt16()` | `short` | Returns the value of the object as a short |
| `ValueOfUint16()` | `ushort` | Returns the value of the object as a ushort |
| `ValueOfInt64()` | `long` | Returns the value of the object as a long |
| `ValueOfUint64()` | `ulong` | Returns the value of the object as a ulong |
| `ValueOfByte()` | `byte` | Returns the value of the object as a byte |
| `long(Number number)` | `implicit operator` | Implicit conversion to long |
| `ulong(Number number)` | `implicit operator` | Implicit conversion to ulong |
| `float(Number number)` | `implicit operator` | Implicit conversion to float |
| `double(Number number)` | `implicit operator` | Implicit conversion to double |
| `short(Number number)` | `implicit operator` | Implicit conversion to short |
| `ushort(Number number)` | `implicit operator` | Implicit conversion to ushort |
| `byte(Number number)` | `implicit operator` | Implicit conversion to byte |
| `int(Number number)` | `implicit operator` | Implicit conversion to int |
| `uint(Number number)` | `implicit operator` | Implicit conversion to uint |
| `IsNaN(object value)` | `bool` | The Number.isNaN() static method determines whether the passed value is the number value NaN, and returns false if the input is not of the Number type. It is a more robust version of the original, global isNaN() function. |
| `IsInteger(object value)` | `bool` | The Number.isInteger() static method determines whether the passed value is an integer. |
| `IsSafeInteger(object value)` | `bool` | The Number.isSafeInteger() static method determines whether the provided value is a number that is a safe integer. |
| `IsFinite(object value)` | `bool` | The Number.isFinite() static method determines whether the passed value is a finite number - that is, it checks that a given value is a number, and the number is neither positive Infinity, negative Infinity, nor NaN. |

