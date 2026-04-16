# FileReader

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/FileReader.cs`  
**MDN Reference:** [FileReader on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FileReader)

> The FileReader object lets web applications asynchronously read the contents of files (or raw data buffers) stored on the user's computer, using File or Blob objects to specify the file or data to read. https://developer.mozilla.org/en-US/docs/Web/API/FileReader

## Constructors

| Signature | Description |
|---|---|
| `FileReader(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `FileReader()` | The FileReader() constructor creates a new FileReader. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Result` | `JSObject?` | get | The file's contents. This property is only valid after the read operation is complete, and the format of the data depends on which of the methods was used to initiate the read operation. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ResultAs()` | `T` | The file's contents. This property is only valid after the read operation is complete, and the format of the data depends on which of the methods was used to initiate the read operation. |
| `ReadAsDataURL(Blob blob)` | `void` | Starts reading the contents of the specified Blob, once finished, the result attribute contains a data: URL representing the file's data. |
| `ReadAsArrayBuffer(Blob blob)` | `void` | Starts reading the contents of the specified Blob, once finished, the result attribute contains an ArrayBuffer representing the file's data. |
| `ReadAsText(Blob blob)` | `void` | Starts reading the contents of the specified Blob, once finished, the result attribute contains the contents of the file as a text string. An optional encoding name can be specified. |
| `ReadAsDataURLAsync(Blob blob)` | `Task<string?>` | Starts reading the contents of the specified Blob, once finished, the result attribute contains a data: URL representing the file's data. |
| `ReadAsTextAsync(Blob blob)` | `Task<string?>` | Starts reading the contents of the specified Blob, once finished, the result attribute contains the contents of the file as a text string. An optional encoding name can be specified. |
| `ReadAsArrayBufferAsync(Blob blob)` | `Task<ArrayBuffer?>` | Starts reading the contents of the specified Blob, once finished, the result attribute contains an ArrayBuffer representing the file's data. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAbort` | `ActionEvent<ProgressEvent>` | Fired when a read has been aborted, for example because the program called FileReader.abort(). |
| `OnError` | `ActionEvent<ProgressEvent>` | Fired when the read failed due to an error. |
| `OnLoad` | `ActionEvent<ProgressEvent>` | Fired when a read has completed successfully. |
| `OnLoadStart` | `ActionEvent<ProgressEvent>` | Fired when a read has started. |
| `OnLoadEnd` | `ActionEvent<ProgressEvent>` | Fired when a read has completed, successfully or not. |
| `OnProgress` | `ActionEvent<ProgressEvent>` | Fired periodically as data is read. |

## Example

```csharp
// Use the convenient static async methods (recommended)

// Read a Blob as a data URL string
string? dataUrl = await FileReader.ReadAsDataURLAsync(blob);

// Read a Blob as text
string? text = await FileReader.ReadAsTextAsync(blob);

// Read a Blob as an ArrayBuffer
using var buffer = await FileReader.ReadAsArrayBufferAsync(blob);

// Or use the instance-based event-driven approach for progress tracking
using var reader = new FileReader();

// Subscribe to events using named methods (required for proper cleanup)
reader.OnLoad += Reader_OnLoad;
reader.OnError += Reader_OnError;
reader.OnProgress += Reader_OnProgress;

// Start reading (triggers OnLoad/OnError when done)
reader.ReadAsText(blob);
// reader.ReadAsDataURL(blob);
// reader.ReadAsArrayBuffer(blob);

// Unsubscribe before disposing - every += must have a matching -=
reader.OnLoad -= Reader_OnLoad;
reader.OnError -= Reader_OnError;
reader.OnProgress -= Reader_OnProgress;

void Reader_OnLoad(ProgressEvent e)
{
    string result = reader.ResultAs<string>();
    Console.WriteLine($"Read complete: {result.Length} chars");
}

void Reader_OnError(ProgressEvent e) => Console.WriteLine("Error reading file");

void Reader_OnProgress(ProgressEvent e)
{
    if (e.LengthComputable)
    {
        double percent = (double)e.Loaded / e.Total * 100;
        Console.WriteLine($"Progress: {percent:F1}%");
    }
}
```

