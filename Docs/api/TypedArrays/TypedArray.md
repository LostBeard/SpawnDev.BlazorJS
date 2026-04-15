# TypedArray<TElement>

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `TypedArray where TElement : struct`  
**Source:** `JSObjects/TypedArrays/TypedArray.cs`  
**MDN Reference:** [TypedArray<TElement> on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/TypedArray)

> A TypedArray object describes an array-like view of an underlying binary data buffer. There is no global property named TypedArray, nor is there a directly visible TypedArray constructor. Instead, there are a number of different global properties, whose values are typed array constructors for specific element types, listed below. On the following pages you will find common properties and methods that can be used with any typed array containing elements of any type. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/TypedArray The TypedArray element .Net type

## Constructors

| Signature | Description |
|---|---|
| `TypedArray(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `TypedArray(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ElementType` | `Type` | get | The TypedArray element type .Net Type |
| `BYTES_PER_ELEMENT` | `int` | get | Returns a number value of the element size. |
| `Buffer` | `ArrayBuffer` | get | Returns the ArrayBuffer referenced by the typed array. |
| `ByteLength` | `long` | get | Returns the length (in bytes) of the typed array. |
| `Length` | `long` | get | Returns the number of elements held in the typed array. |
| `ByteOffset` | `long` | get | Returns the offset (in bytes) of the typed array from the start of its ArrayBuffer. |
| `IsPartialView` | `bool` | get | Returns true if the underlying ArrayBuffer is not the same size as the TypedArray. Non-standard property |
| `IsSharedArrayBuffer` | `bool` | get | Returns true if the buffer object is a SharedArrayBuffer, This property aids in using a SharedArrayBuffer as an ArrayBuffer for APIs that may only have methods for ArrayBuffer but can use a SharedArrayBuffer. |
| `IsArrayBuffer` | `bool` | get/set | Returns true if the buffer object is an ArrayBuffer. This property aids in using a SharedArrayBuffer as an ArrayBuffer for APIs that may only have methods for ArrayBuffer but can use a SharedArrayBuffer. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `At(long index)` | `TElement` | Takes an integer value and returns the item at that index. This method allows for negative integers, which count back from the last item. Zero-based index of the typed array element to be returned, converted to an integer. Negative index counts back from the end of the typed array - if index &lt; 0, index + array.length is accessed. The element in the typed array matching the given index. Always returns undefined if index &lt; -array.length or index &gt;= array.length without attempting to access the corresponding property. |
| `ToArray(long start)` | `TElement[]` | Returns an array of type TElement The TElement index to start at An array of type TElement |
| `ToArray(long start, long length)` | `TElement[]` | Returns an array of type TElement The TElement index to start at The number of TElements to return An array of type TElement |
| `ToArray(long srcOffset, TElement[] dest, long destOffset, long count)` | `long` | Copies elements of type T from this TypedArray tp the destination Source element offset The array to copy the data into Destination offset Count |
| `FromArray(TElement[] srcData, long destOffset)` | `void` | Writes an array of TElement to this TypedArray. This is a direct byte for byte copy with no type conversions. |
| `FromArray(TElement[] srcData, long destOffset, long srcOffset, long length)` | `void` | Writes an array of TElement to this TypedArray. This is a direct byte for byte copy with no type conversions. The destination index to start copying to The source index to start copying from The number of items to copy |
| `Values()` | `Iterator<TElement>` | Returns a value iterator A Span of type TElement |
| `Fill(TElement value)` | `TypedArray` | Fills all the elements of an array from a start index to an end index with a static value. |
| `FillVoid(TElement value)` | `void` | Fills all the elements of an array from a start index to an end index with a static value. |
| `ReCast(Type typedArray, long byteOffset, long length)` | `TypedArray` | Create a new typed array starting at this typed array's ByteOffset + byteOffset, returning length number of items in the resulting typed array |
| `ReCast(Type typedArray)` | `TypedArray` | Create a new typed array starting at this typed array's ByteOffset + byteOffset |
| `ReCast(long byteOffset, long length)` | `TTypedArray` | Create a new typed array starting at this typed array's ByteOffset + byteOffset, returning length number of items in the resulting typed array |
| `ReCast()` | `TTypedArray` | Create a new typed array starting at this typed array's ByteOffset + byteOffset |
| `Set(sbyte[] array, long targetOffset)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(byte[] array, long targetOffset)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(short[] array, long targetOffset)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(ushort[] array, long targetOffset)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(int[] array, long targetOffset)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(uint[] array, long targetOffset)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(long[] array, long targetOffset)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(ulong[] array, long targetOffset)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(Half[] array, long targetOffset)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(float[] array, long targetOffset)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(double[] array, long targetOffset)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(TypedArray typedArray)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(TypedArray typedArray, long targetOffset)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(Array typedArray)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `Set(Array typedArray, long targetOffset)` | `void` | The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array. |
| `ReadBytes(long byteOffset)` | `byte[]` | Read bytes from the underlying ArrayBuffer starting at this TypedArray's byteOffset |
| `ReadBytes(long byteOffset, long byteLength)` | `byte[]` | Read bytes from the underlying ArrayBuffer starting at this TypedArray's byteOffset |
| `WriteBytes(byte[] data, long byteOffset)` | `void` | Write bytes to the underlying ArrayBuffer starting at this TypedArray's byteOffset |
| `Write(T[] srcData, long destByteOffset)` | `void` | Writes an array of struct to this TypedArray. This is a direct byte for byte copy with no type conversions. |
| `Write(T[] srcData, long destByteOffset, long srcOffset, long length)` | `void` | Writes an array of struct to this TypedArray. This is a direct byte for byte copy with no type conversions. |
| `Read(long srcByteOffset, T[] buffer, long offset, long count)` | `long` | Copies an array of type T from this TypedArray |
| `Read(long srcByteOffset, long count)` | `T[]` | Read type T from this TypedArray |
| `Read(long srcByteOffset)` | `T[]` | Read type T from this TypedArray |
| `ToArray(long start, long count)` | `T[]` | Read an array of type T starting at this TypedArray's ByteOffset + byteOffset Element Index to start Number of type T to read Array of type T |
| `ToArray(long srcOffset, T[] dest, long destOffset, long count)` | `long` | Copies elements of type T from this TypedArray tp the destination Source element offset The array to copy the data into Destination offset Count |
| `FromArray(T[] srcData, long destOffset)` | `void` | Writes an array of struct to this TypedArray The destination index to start copying to |
| `FromArray(T[] srcData, long destOffset, long srcOffset, long length)` | `void` | Writes an array of struct to this TypedArray The destination index to start copying to The source index to start copying from The number of items to copy |
| `GetTypeDefaultTypedArrayType()` | `Type?` | Returns the Javascript native array type for the specified struct type |
| `GetTypeDefaultTypedArrayType(Type unmanagedType)` | `Type?` | Returns the Javascript native array type for the specified struct type |
| `GetTypedArrayElementSize()` | `int` | Returns the size of the specified TypedArray type |
| `GetTypedArrayElementSize(Type typedArrayType)` | `int` | Returns the size of the specified TypedArray type |

