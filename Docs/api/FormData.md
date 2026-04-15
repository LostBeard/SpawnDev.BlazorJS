# FormData

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/FormData.cs`  
**MDN Reference:** [FormData on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FormData)

> The FormData interface provides a way to construct a set of key/value pairs representing form fields and their values, which can be sent using the fetch(), XMLHttpRequest.send() or navigator.sendBeacon() methods. It uses the same format a form would use if the encoding type were set to "multipart/form-data". https://developer.mozilla.org/en-US/docs/Web/API/FormData

## Constructors

| Signature | Description |
|---|---|
| `FormData()` | The FormData() constructor creates a new FormData object. |
| `FormData(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Append(string name, Union<string, Blob> value)` | `void` | Appends a new value onto an existing key inside a FormData object, or adds the key if it does not already exist. The name of the field whose data is contained in value. The field's value. This can be a string or Blob (including subclasses such as File). If none of these are specified the value is converted to a string. |
| `Append(string name, Union<string, Blob> value, string filename)` | `void` | Appends a new value onto an existing key inside a FormData object, or adds the key if it does not already exist. The name of the field whose data is contained in value. The field's value. This can be a string or Blob (including subclasses such as File). If none of these are specified the value is converted to a string. The filename reported to the server (a string), when a Blob or File is passed as the second parameter. The default filename for Blob objects is "blob". The default filename for File objects is the file's filename. |

## Example

```csharp
// Create a new FormData object
using var formData = new FormData();

// Append string fields
formData.Append("username", "lostbeard");
formData.Append("email", "user@example.com");

// Append a Blob as a file upload
byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes("file content here");
using var blob = new Blob(new BlobPart[] { fileBytes }, new BlobOptions { Type = "text/plain" });
formData.Append("document", blob, "readme.txt");

// Submit the form data with fetch
using var response = await JS.CallAsync<Response>("fetch", "/api/upload", new RequestOptions
{
    Method = "POST",
    Body = formData
});

if (response.Ok)
{
    Console.WriteLine("Upload successful");
}
```

