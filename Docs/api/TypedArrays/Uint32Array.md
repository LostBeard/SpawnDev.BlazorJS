# Uint32Array

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `TypedArray<uint>`  
**Source:** `JSObjects/TypedArrays/Uint32Array.cs`  
**MDN Reference:** [Uint32Array on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint32Array)

> The Uint32Array typed array represents an array of 32-bit unsigned integers in the platform byte order. If control over byte order is needed, use DataView instead. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation). https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint32Array

## Constructors

| Signature | Description |
|---|---|
| `Uint32Array(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Uint32Array()` | The Uint32Array() constructor creates Uint32Array objects. |
| `Uint32Array(long length)` | The Uint32Array() constructor creates Uint32Array objects. |
| `Uint32Array(TypedArray typedArray)` | The Uint32Array() constructor creates Uint32Array objects. |
| `Uint32Array(ArrayBuffer arrayBuffer)` | The Uint32Array() constructor creates Uint32Array objects. |
| `Uint32Array(ArrayBuffer arrayBuffer, long byteOffset)` | The Uint32Array() constructor creates Uint32Array objects. |
| `Uint32Array(ArrayBuffer arrayBuffer, long byteOffset, long length)` | The Uint32Array() constructor creates Uint32Array objects. |
| `Uint32Array(SharedArrayBuffer sharedArrayBuffer)` | The Uint32Array() constructor creates Uint32Array objects. |
| `Uint32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset)` | The Uint32Array() constructor creates Uint32Array objects. |
| `Uint32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length)` | The Uint32Array() constructor creates Uint32Array objects. |
| `Uint32Array(uint[] array)` | The Uint32Array() constructor creates Uint32Array objects. |
| `Uint32Array(Array<uint> array)` | The Uint32Array() constructor creates Uint32Array objects. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `From(IEnumerable<T> values)` | `Uint32Array` | The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from(). |
| `Slice()` | `Uint32Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start)` | `Uint32Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start, long end)` | `Uint32Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `SubArray()` | `Uint32Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. |
| `SubArray(long start)` | `Uint32Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. |
| `SubArray(long start, long end)` | `Uint32Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view. |

