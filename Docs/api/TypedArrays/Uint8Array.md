# Uint8Array

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `TypedArray<byte>`  
**Source:** `JSObjects/TypedArrays/Uint8Array.cs`  
**MDN Reference:** [Uint8Array on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint8Array)

> The Uint8Array typed array represents an array of 8-bit unsigned integers. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation). https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint8Array

## Constructors

| Signature | Description |
|---|---|
| `Uint8Array(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Uint8Array()` | The Uint8Array() constructor creates Uint8Array objects. |
| `Uint8Array(long length)` | The Uint8Array() constructor creates Uint8Array objects. The contents are initialized to 0. |
| `Uint8Array(TypedArray typedArray)` | The Uint8Array() constructor creates Uint8Array objects. |
| `Uint8Array(ArrayBuffer arrayBuffer)` | The Uint8Array() constructor creates Uint8Array objects. |
| `Uint8Array(ArrayBuffer arrayBuffer, long byteOffset)` | The Uint8Array() constructor creates Uint8Array objects. |
| `Uint8Array(ArrayBuffer arrayBuffer, long byteOffset, long length)` | The Uint8Array() constructor creates Uint8Array objects. |
| `Uint8Array(SharedArrayBuffer sharedArrayBuffer)` | The Uint8Array() constructor creates Uint8Array objects. |
| `Uint8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset)` | The Uint8Array() constructor creates Uint8Array objects. |
| `Uint8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length)` | The Uint8Array() constructor creates Uint8Array objects. |
| `Uint8Array(byte[] sourceBytes)` | The Uint8Array() constructor creates Uint8Array objects. |
| `Uint8Array(Array<byte> array)` | The Uint8Array() constructor creates Uint8Array objects. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `From(IEnumerable<T> values)` | `Uint8Array` | The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from(). |
| `Slice()` | `Uint8Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start)` | `Uint8Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start, long end)` | `Uint8Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `SubArray()` | `Uint8Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. |
| `SubArray(long start)` | `Uint8Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. |
| `SubArray(long start, long end)` | `Uint8Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view. |
| `Fill(byte value)` | `Uint8Array` | Fills all the elements of an array from a start index to an end index with a static value. |
| `Create(T[] data, long offset)` | `Uint8Array` | Returns a copy of the struct array as a new Uint8Array |
| `Create(T[] data, long offset, long length)` | `Uint8Array` | Returns a copy of the struct array as a new Uint8Array |
| `Create(string data, long offset, long length)` | `Uint8Array` | Returns a copy of the string as a new Uint8Array |
| `Create(string data, long offset)` | `Uint8Array` | Returns a copy of string as a new Uint8Array |

