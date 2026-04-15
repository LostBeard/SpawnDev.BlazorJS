# Uint16Array

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `TypedArray<ushort>`  
**Source:** `JSObjects/TypedArrays/Uint16Array.cs`  
**MDN Reference:** [Uint16Array on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint16Array)

> The Uint16Array typed array represents an array of 32-bit unsigned integers in the platform byte order. If control over byte order is needed, use DataView instead. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation). https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint16Array

## Constructors

| Signature | Description |
|---|---|
| `Uint16Array(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Uint16Array()` | The Uint16Array() constructor creates Uint16Array objects. |
| `Uint16Array(long length)` | The Uint16Array() constructor creates Uint16Array objects. |
| `Uint16Array(TypedArray typedArray)` | The Uint16Array() constructor creates Uint16Array objects. |
| `Uint16Array(ArrayBuffer arrayBuffer)` | The Uint16Array() constructor creates Uint16Array objects. |
| `Uint16Array(ArrayBuffer arrayBuffer, long byteOffset)` | The Uint16Array() constructor creates Uint16Array objects. |
| `Uint16Array(ArrayBuffer arrayBuffer, long byteOffset, long length)` | The Uint16Array() constructor creates Uint16Array objects. |
| `Uint16Array(SharedArrayBuffer sharedArrayBuffer)` | The Uint16Array() constructor creates Uint16Array objects. |
| `Uint16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset)` | The Uint16Array() constructor creates Uint16Array objects. |
| `Uint16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length)` | The Uint16Array() constructor creates Uint16Array objects. |
| `Uint16Array(ushort[] array)` | The Uint16Array() constructor creates Uint16Array objects. |
| `Uint16Array(Array<ushort> array)` | The Uint16Array() constructor creates Uint16Array objects. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `From(IEnumerable<T> values)` | `Uint16Array` | The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from(). |
| `Slice()` | `Uint16Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start)` | `Uint16Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start, long end)` | `Uint16Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `SubArray()` | `Uint16Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. |
| `SubArray(long start)` | `Uint16Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. |
| `SubArray(long start, long end)` | `Uint16Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view. |

