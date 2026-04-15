# BigInt64Array

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `TypedArray<long>`  
**Source:** `JSObjects/TypedArrays/BigInt64Array.cs`  
**MDN Reference:** [BigInt64Array on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/BigInt64Array)

> The BigInt64Array typed array represents an array of 64-bit signed integers in the platform byte order. If control over byte order is needed, use DataView instead. The contents are initialized to 0n. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation). https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/BigInt64Array

## Constructors

| Signature | Description |
|---|---|
| `BigInt64Array(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `BigInt64Array()` | Creates a new BigInt64Array object. |
| `BigInt64Array(long length)` | Creates a new BigInt64Array object. |
| `BigInt64Array(BigInt<long>[] array)` | Creates a new BigInt64Array object. |
| `BigInt64Array(Array<BigInt<long>> array)` | Creates a new BigInt64Array object. |
| `BigInt64Array(long[] array)` | Creates a new BigInt64Array object. |
| `BigInt64Array(TypedArray typedArray)` | Creates a new BigInt64Array object. |
| `BigInt64Array(ArrayBuffer arrayBuffer)` | Creates a new BigInt64Array object. |
| `BigInt64Array(ArrayBuffer arrayBuffer, long byteOffset)` | Creates a new BigInt64Array object. |
| `BigInt64Array(ArrayBuffer arrayBuffer, long byteOffset, long length)` | Creates a new BigInt64Array object. |
| `BigInt64Array(SharedArrayBuffer sharedArrayBuffer)` | Creates a new BigInt64Array object. |
| `BigInt64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset)` | Creates a new BigInt64Array object. |
| `BigInt64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length)` | Creates a new BigInt64Array object. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Supported` | `bool` | get | Returns true if BigInt64Array appears to be supported |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `From(IEnumerable<T> values)` | `BigInt64Array` | The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from(). |
| `Slice()` | `BigInt64Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start)` | `BigInt64Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `Slice(long start, long end)` | `BigInt64Array` | Extracts a section of an array and returns a new array. See also Array.prototype.slice(). |
| `SubArray()` | `BigInt64Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. |
| `SubArray(long start)` | `BigInt64Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. |
| `SubArray(long start, long end)` | `BigInt64Array` | The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive. Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified. Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view. |
| `At(long index)` | `long` | Takes an integer value and returns the item at that index. This method allows for negative integers, which count back from the last item. Zero-based index of the typed array element to be returned, converted to an integer. Negative index counts back from the end of the typed array - if index &lt; 0, index + array.length is accessed. The element in the typed array matching the given index. Always returns undefined if index &lt; -array.length or index &gt;= array.length without attempting to access the corresponding property. |

