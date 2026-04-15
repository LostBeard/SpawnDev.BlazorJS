# Uint8ClampedArray

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `TypedArray<byte>`  
**Source:** `JSObjects/TypedArrays/Uint8ClampedArray.cs`  
**MDN Reference:** [Uint8ClampedArray on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint8ClampedArray)

> The Uint8ClampedArray typed array represents an array of 8-bit unsigned integers clamped to 0-255. The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation). https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint8ClampedArray

## Constructors

| Signature | Description |
|---|---|
| `Uint8ClampedArray(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Uint8ClampedArray()` | The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. |
| `Uint8ClampedArray(long length)` | The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. |
| `Uint8ClampedArray(TypedArray typedArray)` | The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. |
| `Uint8ClampedArray(ArrayBuffer arrayBuffer)` | The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. |
| `Uint8ClampedArray(ArrayBuffer arrayBuffer, long byteOffset)` | The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. |
| `Uint8ClampedArray(ArrayBuffer arrayBuffer, long byteOffset, long length)` | The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. |
| `Uint8ClampedArray(SharedArrayBuffer sharedArrayBuffer)` | The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. |
| `Uint8ClampedArray(SharedArrayBuffer sharedArrayBuffer, long byteOffset)` | The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. |
| `Uint8ClampedArray(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length)` | The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. |
| `Uint8ClampedArray(byte[] array)` | The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. |
| `Uint8ClampedArray(Array<byte> array)` | The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `From(IEnumerable<T> values)` | `Uint8ClampedArray` | The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from(). |
| `Slice()` | `Uint8ClampedArray` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start)` | `Uint8ClampedArray` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start, long end)` | `Uint8ClampedArray` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `SubArray()` | `Uint8ClampedArray` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. |
| `SubArray(long start)` | `Uint8ClampedArray` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. |
| `SubArray(long start, long end)` | `Uint8ClampedArray` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view. |

