# File

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Blob`  
**Source:** `JSObjects/File.cs`  
**MDN Reference:** [File on MDN](https://developer.mozilla.org/en-US/docs/Web/API/File)

> The File interface provides information about files and allows JavaScript in a web page to access their content. https://developer.mozilla.org/en-US/docs/Web/API/File

## Constructors

| Signature | Description |
|---|---|
| `File(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `File(IEnumerable<Union<ArrayBuffer, TypedArray, DataView, Blob, string, byte[]>> bits, string name)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. |
| `File(IEnumerable<Union<ArrayBuffer, TypedArray, DataView, Blob, string, byte[]>> bits, string name, FileOptions options)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. An options object containing optional attributes for the file |
| `File(IEnumerable<ArrayBuffer> bits, string name)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. |
| `File(IEnumerable<ArrayBuffer> bits, string name, FileOptions options)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. An options object containing optional attributes for the file |
| `File(IEnumerable<TypedArray> bits, string name)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. |
| `File(IEnumerable<TypedArray> bits, string name, FileOptions options)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. An options object containing optional attributes for the file |
| `File(IEnumerable<DataView> bits, string name)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. |
| `File(IEnumerable<DataView> bits, string name, FileOptions options)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. An options object containing optional attributes for the file |
| `File(IEnumerable<Blob> bits, string name)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. |
| `File(IEnumerable<Blob> bits, string name, FileOptions options)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. An options object containing optional attributes for the file |
| `File(IEnumerable<string> bits, string name)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. |
| `File(IEnumerable<string> bits, string name, FileOptions options)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. An options object containing optional attributes for the file |
| `File(IEnumerable<byte[]> bits, string name)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. |
| `File(IEnumerable<byte[]> bits, string name, FileOptions options)` | The File() constructor creates a new File object instance. An iterable object such as an Array, having ArrayBuffers, TypedArrays, DataViews, Blobs, strings, or a mix of any of such elements, that will be put inside the File. Note that strings here are encoded as UTF-8, unlike the usual JavaScript UTF-16 strings. A string representing the file name or the path to the file. An options object containing optional attributes for the file |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `string` | get | Returns the name of the file referenced by the File object. |
| `LastModified` | `long` | get | Returns the last modified time of the file, in millisecond since the UNIX epoch (January 1st, 1970 at Midnight). |
| `WebkitRelativePath` | `string?` | get | Returns the path the URL of the File is relative to. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `StartDownload()` | `Task` | Start downloading the File using the File.Name |

## Example

```csharp
// Create a File from string content using the Union-based constructor
var parts = new List<Union<ArrayBuffer, TypedArray, DataView, Blob, string, byte[]>>
{
    (Union<ArrayBuffer, TypedArray, DataView, Blob, string, byte[]>)"Hello, World!"
};
using var file = new File(parts, "greeting.txt", new FileOptions { Type = "text/plain" });

// Read file metadata
Console.WriteLine($"Name: {file.Name}");
Console.WriteLine($"Size: {file.Size} bytes");
Console.WriteLine($"Type: {file.Type}");
Console.WriteLine($"Last Modified: {file.LastModified}");

// Read the file content as text (inherited from Blob)
var content = await file.Text();
Console.WriteLine($"Content: {content}");

// Read the file content as binary (inherited from Blob)
using var buffer = await file.ArrayBuffer();
byte[] bytes = buffer.ReadBytes();

// Create a File from string parts (simpler constructor)
using var textFile = new File(new[] { "Line 1\n", "Line 2\n" }, "notes.txt");

// Create a File from byte arrays
using var binaryFile = new File(
    new[] { new byte[] { 0xFF, 0xD8, 0xFF } },
    "image.jpg",
    new FileOptions { Type = "image/jpeg" }
);

// Trigger a download using the file's own name
await file.StartDownload();
```

