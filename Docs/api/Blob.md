# Blob

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Blob.cs`  
**MDN Reference:** [Blob on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Blob)

> The Blob object represents a blob, which is a file-like object of immutable, raw data; they can be read as text or binary data, or converted into a ReadableStream so its methods can be used for processing the data. https://developer.mozilla.org/en-US/docs/Web/API/Blob

## Constructors

| Signature | Description |
|---|---|
| `Blob(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Blob()` | New Blob constructor |
| `Blob(IEnumerable<ArrayBuffer> buffers, BlobOptions? options)` | Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor. |
| `Blob(IEnumerable<string> buffers, BlobOptions? options)` | Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor. |
| `Blob(IEnumerable<Blob> blobs, BlobOptions? options)` | Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor. |
| `Blob(IEnumerable<byte[]> blobs, BlobOptions? options)` | Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor. |
| `Blob(IEnumerable<TypedArray> typedArrays, BlobOptions? options)` | Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor. |
| `Blob(IEnumerable<DataView> dataViews, BlobOptions? options)` | Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor. |
| `Blob(IEnumerable<Union<ArrayBuffer, TypedArray, DataView, Blob, string>> data, BlobOptions? options)` | Returns a newly created Blob object which contains a concatenation of all of the data in the array passed into the constructor. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Size` | `long` | get | The size, in bytes, of the data contained in the Blob object. |
| `Type` | `string` | get | A string indicating the MIME type of the data contained in the Blob. If the type is unknown, this string is empty. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Text()` | `Task<string>` | Returns a promise that resolves with a string containing the entire contents of the Blob interpreted as UTF-8 text. |
| `ArrayBuffer()` | `Task<ArrayBuffer>` | Returns a promise that resolves with an ArrayBuffer containing the entire contents of the Blob as binary data. |
| `Slice(long startPos, long endPos, string contentType)` | `Blob` | The Blob interface's slice() method creates and returns a new Blob object which contains data from a subset of the blob on which it's called. An index into the Blob indicating the first byte to include in the new Blob. If you specify a negative value, it's treated as an offset from the end of the Blob toward the beginning. For example, -10 would be the 10th from last byte in the Blob. The default value is 0. If you specify a value for start that is larger than the size of the source Blob, the returned Blob has size 0 and contains no data. An index into the Blob indicating the first byte that will *not* be included in the new Blob (i.e. the byte exactly at this index is not included). If you specify a negative value, it's treated as an offset from the end of the Blob toward the beginning. For example, -10 would be the 10th from last byte in the Blob. The default value is size. The content type to assign to the new Blob; this will be the value of its type property. The default value is an empty string. |
| `Slice(long startPos, long endPos)` | `Blob` | The Blob interface's slice() method creates and returns a new Blob object which contains data from a subset of the blob on which it's called. An index into the Blob indicating the first byte to include in the new Blob. If you specify a negative value, it's treated as an offset from the end of the Blob toward the beginning. For example, -10 would be the 10th from last byte in the Blob. The default value is 0. If you specify a value for start that is larger than the size of the source Blob, the returned Blob has size 0 and contains no data. An index into the Blob indicating the first byte that will *not* be included in the new Blob (i.e. the byte exactly at this index is not included). If you specify a negative value, it's treated as an offset from the end of the Blob toward the beginning. For example, -10 would be the 10th from last byte in the Blob. The default value is size. |
| `Slice(long startPos)` | `Blob` | The Blob interface's slice() method creates and returns a new Blob object which contains data from a subset of the blob on which it's called. An index into the Blob indicating the first byte to include in the new Blob. If you specify a negative value, it's treated as an offset from the end of the Blob toward the beginning. For example, -10 would be the 10th from last byte in the Blob. The default value is 0. If you specify a value for start that is larger than the size of the source Blob, the returned Blob has size 0 and contains no data. |
| `Stream()` | `ReadableStream` | Returns a ReadableStream that can be used to read the contents of the Blob. |
| `FromDataURL(string dataUrl)` | `Blob` | Creates a new Blob from a data url |
| `ToObjectURL()` | `string` | Returns an ObjectURL created using URL.CreateObjectURL |
| `ToDataURLAsync()` | `Task<string>` | Returns the blob as a data url string |
| `StartDownload(string fileName)` | `Task` | Start download of the blob |

## Example

```csharp
// Create a Blob from string data with a MIME type
using var blob = new Blob(
    new[] { "{\"hello\": \"world\"}" },
    new BlobOptions { Type = "application/json" }
);

// Check size and type
Console.WriteLine($"Size: {blob.Size} bytes");
Console.WriteLine($"Type: {blob.Type}");

// Read the Blob content as text
var text = await blob.Text();
Console.WriteLine($"Content: {text}");

// Read the Blob content as an ArrayBuffer
using var buffer = await blob.ArrayBuffer();
byte[] bytes = buffer.ReadBytes();

// Create a Blob from binary data
using var binaryBlob = new Blob(
    new[] { new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F } },
    new BlobOptions { Type = "application/octet-stream" }
);

// Slice a portion of the Blob
using var sliced = blob.Slice(0, 5, "text/plain");

// Get a ReadableStream from the Blob
using var stream = blob.Stream();

// Create an object URL for use in links or images
var objectUrl = blob.ToObjectURL();
// ... use the URL ...
URL.RevokeObjectURL(objectUrl);

// Convert to a data URL (base64)
var dataUrl = await blob.ToDataURLAsync();

// Trigger a file download from the Blob
await blob.StartDownload("data.json");
```

