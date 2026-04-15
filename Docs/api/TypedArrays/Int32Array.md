# Int32Array

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `TypedArray<int>`  
**Source:** `JSObjects/TypedArrays/Int32Array.cs`  
**MDN Reference:** [Int32Array on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Int32Array)

> The Int32Array typed array represents an array of 32-bit signed integers in the platform byte order. If control over byte order is needed, use DataView instead. The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation). https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Int32Array

## Constructors

| Signature | Description |
|---|---|
| `Int32Array(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Int32Array()` | The Int32Array() constructor creates Int32Array objects. |
| `Int32Array(long length)` | The Int32Array() constructor creates Int32Array objects. The contents are initialized to 0. |
| `Int32Array(TypedArray typedArray)` | The Int32Array() constructor creates Int32Array objects. |
| `Int32Array(ArrayBuffer arrayBuffer)` | The Int32Array() constructor creates Int32Array objects. |
| `Int32Array(ArrayBuffer arrayBuffer, long byteOffset)` | The Int32Array() constructor creates Int32Array objects. |
| `Int32Array(ArrayBuffer arrayBuffer, long byteOffset, long length)` | The Int32Array() constructor creates Int32Array objects. |
| `Int32Array(SharedArrayBuffer sharedArrayBuffer)` | The Int32Array() constructor creates Int32Array objects. |
| `Int32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset)` | The Int32Array() constructor creates Int32Array objects. |
| `Int32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length)` | The Int32Array() constructor creates Int32Array objects. |
| `Int32Array(int[] array)` | The Int32Array() constructor creates Int32Array objects. |
| `Int32Array(Array<int> array)` | The Int32Array() constructor creates Int32Array objects. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `From(IEnumerable<T> values)` | `Int32Array` | The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from(). |
| `Slice()` | `Int32Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start)` | `Int32Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start, long end)` | `Int32Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `SubArray()` | `Int32Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. |
| `SubArray(long start)` | `Int32Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. |
| `SubArray(long start, long end)` | `Int32Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view. |

