# Float64Array

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `TypedArray<double>`  
**Source:** `JSObjects/TypedArrays/Float64Array.cs`  
**MDN Reference:** [Float64Array on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Float64Array)

> The Float64Array typed array represents an array of 32-bit unsigned integers in the platform byte order. If control over byte order is needed, use DataView instead. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation). https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Float64Array

## Constructors

| Signature | Description |
|---|---|
| `Float64Array(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Float64Array()` | The Float64Array() constructor creates Float64Array objects. |
| `Float64Array(long length)` | The Float64Array() constructor creates Float64Array objects. |
| `Float64Array(TypedArray typedArray)` | The Float64Array() constructor creates Float64Array objects. |
| `Float64Array(ArrayBuffer arrayBuffer)` | The Float64Array() constructor creates Float64Array objects. |
| `Float64Array(ArrayBuffer arrayBuffer, long byteOffset)` | The Float64Array() constructor creates Float64Array objects. |
| `Float64Array(ArrayBuffer arrayBuffer, long byteOffset, long length)` | The Float64Array() constructor creates Float64Array objects. |
| `Float64Array(SharedArrayBuffer sharedArrayBuffer)` | The Float64Array() constructor creates Float64Array objects. |
| `Float64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset)` | The Float64Array() constructor creates Float64Array objects. |
| `Float64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length)` | The Float64Array() constructor creates Float64Array objects. |
| `Float64Array(double[] array)` | The Float64Array() constructor creates Float64Array objects. |
| `Float64Array(Array<double> array)` | The Float64Array() constructor creates Float64Array objects. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `From(IEnumerable<T> values)` | `Float64Array` | The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from(). |
| `Slice()` | `Float64Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start)` | `Float64Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start, long end)` | `Float64Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `SubArray()` | `Float64Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. |
| `SubArray(long start)` | `Float64Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. |
| `SubArray(long start, long end)` | `Float64Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view. |

