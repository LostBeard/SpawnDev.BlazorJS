# Float16Array

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `TypedArray<Half>`  
**Source:** `JSObjects/TypedArrays/Float16Array.cs`  
**MDN Reference:** [Float16Array on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Float16Array)

> The Float16Array typed array represents an array of 16-bit floating point numbers in the platform byte order. If control over byte order is needed, use DataView instead. The contents are initialized to 0 unless initialization data is explicitly provided. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation). NOTE - As of 2025-02-17 this feature has narrow support and should be tested for before using. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Float16Array

## Constructors

| Signature | Description |
|---|---|
| `Float16Array(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Float16Array()` | The Float16Array() constructor creates Float16Array objects. |
| `Float16Array(long length)` | The Float16Array() constructor creates Float16Array objects. |
| `Float16Array(TypedArray typedArray)` | The Float16Array() constructor creates Float16Array objects. |
| `Float16Array(ArrayBuffer arrayBuffer)` | The Float16Array() constructor creates Float16Array objects. |
| `Float16Array(ArrayBuffer arrayBuffer, long byteOffset)` | The Float16Array() constructor creates Float16Array objects. |
| `Float16Array(ArrayBuffer arrayBuffer, long byteOffset, long length)` | The Float16Array() constructor creates Float16Array objects. |
| `Float16Array(SharedArrayBuffer sharedArrayBuffer)` | The Float16Array() constructor creates Float16Array objects. |
| `Float16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset)` | The Float16Array() constructor creates Float16Array objects. |
| `Float16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length)` | The Float16Array() constructor creates Float16Array objects. |
| `Float16Array(Half[] array)` | The Float16Array() constructor creates Float16Array objects. |
| `Float16Array(Array<Half> array)` | The Float16Array() constructor creates Float16Array objects. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `From(IEnumerable<T> values)` | `Float16Array` | The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from(). |
| `Slice()` | `Float16Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start)` | `Float16Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start, long end)` | `Float16Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `SubArray()` | `Float16Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. |
| `SubArray(long start)` | `Float16Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. |
| `SubArray(long start, long end)` | `Float16Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view. |

