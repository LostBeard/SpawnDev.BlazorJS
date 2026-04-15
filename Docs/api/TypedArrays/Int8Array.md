# Int8Array

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `TypedArray<sbyte>`  
**Source:** `JSObjects/TypedArrays/Int8Array.cs`  
**MDN Reference:** [Int8Array on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Int8Array)

> The Int8Array typed array represents an array of 32-bit signed integers in the platform byte order. If control over byte order is needed, use DataView instead. The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation). https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Int8Array

## Constructors

| Signature | Description |
|---|---|
| `Int8Array(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Int8Array()` | The Int8Array() constructor creates Int8Array objects. |
| `Int8Array(long length)` | The Int8Array() constructor creates Int8Array objects. The contents are initialized to 0. |
| `Int8Array(TypedArray typedArray)` | The Int8Array() constructor creates Int8Array objects. |
| `Int8Array(ArrayBuffer arrayBuffer)` | The Int8Array() constructor creates Int8Array objects. |
| `Int8Array(ArrayBuffer arrayBuffer, long byteOffset)` | The Int8Array() constructor creates Int8Array objects. |
| `Int8Array(ArrayBuffer arrayBuffer, long byteOffset, long length)` | The Int8Array() constructor creates Int8Array objects. |
| `Int8Array(SharedArrayBuffer sharedArrayBuffer)` | The Int8Array() constructor creates Int8Array objects. |
| `Int8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset)` | The Int8Array() constructor creates Int8Array objects. |
| `Int8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length)` | The Int8Array() constructor creates Int8Array objects. |
| `Int8Array(sbyte[] array)` | The Int8Array() constructor creates Int8Array objects. |
| `Int8Array(Array<sbyte> array)` | The Int8Array() constructor creates Int8Array objects. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `From(IEnumerable<T> values)` | `Int8Array` | The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from(). |
| `Slice()` | `Int8Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start)` | `Int8Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start, long end)` | `Int8Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `SubArray()` | `Int8Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. |
| `SubArray(long start)` | `Int8Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. |
| `SubArray(long start, long end)` | `Int8Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view. |

