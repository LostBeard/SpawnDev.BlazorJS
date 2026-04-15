# SharedArrayBuffer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/SharedArrayBuffer.cs`  
**MDN Reference:** [SharedArrayBuffer on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/SharedArrayBuffer)

> The SharedArrayBuffer object is used to represent a generic raw binary data buffer, similar to the ArrayBuffer object, but in a way that they can be used to create views on shared memory. A SharedArrayBuffer is not a Transferable Object, unlike an ArrayBuffer which is transferable. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/SharedArrayBuffer

## Constructors

| Signature | Description |
|---|---|
| `SharedArrayBuffer(long length)` | The SharedArrayBuffer() constructor creates SharedArrayBuffer objects. The size, in bytes, of the array buffer to create. |
| `SharedArrayBuffer(long length, SharedArrayBufferOptions options)` | The SharedArrayBuffer() constructor creates SharedArrayBuffer objects. |
| `SharedArrayBuffer(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IsSharedArrayBuffer` | `bool` | get | Returns true if the Javascript object is a SharedArrayBuffer, This property aids in using a SharedArrayBuffer as an ArrayBuffer for APIs that may only have methods for ArrayBuffer but can use a SharedArrayBuffer. |
| `IsArrayBuffer` | `bool` | get | Returns true if the Javascript object is an ArrayBuffer. This property aids in using a SharedArrayBuffer as an ArrayBuffer for APIs that may only have methods for ArrayBuffer but can use a SharedArrayBuffer. |
| `Supported` | `bool` | get | Returns true if SharedArrayBuffer appears to be supported |
| `ByteLength` | `long` | get | The size, in bytes, of the array. This is established when the array is constructed and can only be changed using the SharedArrayBuffer.prototype.grow() method if the SharedArrayBuffer is growable. |
| `MaxByteLength` | `long` | get | The read-only maximum length, in bytes, that the SharedArrayBuffer can be grown to. This is established when the array is constructed and cannot be changed. |
| `Growable` | `bool` | get | Read-only. Returns true if the SharedArrayBuffer can be grown, or false if not. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ArrayBuffer(SharedArrayBuffer sharedArrayBuffer)` | `explicit operator` | Allows quick casting a SharedArrayBuffer to an ArrayBuffer for APIs that may not have methods that take SharedArrayBuffer but will work with them anyways because they are mostly compatible. |
| `Grow(long newLength)` | `void` | Grows the SharedArrayBuffer to the specified size, in bytes. |
| `Slice()` | `SharedArrayBuffer` | Returns a new SharedArrayBuffer whose contents are a copy of this SharedArrayBuffer's bytes from begin, inclusive, up to end, exclusive. If either begin or end is negative, it refers to an index from the end of the array, as opposed to from the beginning. SharedArrayBuffer |
| `Slice(long begin)` | `SharedArrayBuffer` | Returns a new SharedArrayBuffer whose contents are a copy of this SharedArrayBuffer's bytes from begin, inclusive, up to end, exclusive. If either begin or end is negative, it refers to an index from the end of the array, as opposed to from the beginning. Zero-based index at which to begin extraction. A negative index can be used, indicating an offset from the end of the sequence.slice(-2) extracts the last two elements in the sequence. If begin is undefined, slice begins from index 0 |
| `Slice(long begin, long end)` | `SharedArrayBuffer` | Returns a new SharedArrayBuffer whose contents are a copy of this SharedArrayBuffer's bytes from begin, inclusive, up to end, exclusive. If either begin or end is negative, it refers to an index from the end of the array, as opposed to from the beginning. Zero-based index at which to begin extraction. A negative index can be used, indicating an offset from the end of the sequence.slice(-2) extracts the last two elements in the sequence. If begin is undefined, slice begins from index 0 Zero-based index before which to end extraction. slice extracts up to but not including end. For example, slice(1, 4) extracts the second element through the fourth element(elements indexed 1, 2, and 3). A negative index can be used, indicating an offset from the end of the sequence.slice(2,-1) extracts the third element through the second-to-last element in the sequence. If end is omitted, slice extracts through the end of the sequence (sab.byteLength). |
| `Create(T[] data, long offset)` | `SharedArrayBuffer` | Returns a copy of the struct array as a new SharedArrayBuffer |
| `Create(T[] data, long offset, long length)` | `SharedArrayBuffer` | Returns a copy of the struct array as a new SharedArrayBuffer |
| `Create(string data, long offset, long length)` | `SharedArrayBuffer` | Returns a copy of the string as a new SharedArrayBuffer |
| `Create(string data, long offset)` | `SharedArrayBuffer` | Returns a copy of the string as a new SharedArrayBuffer |

