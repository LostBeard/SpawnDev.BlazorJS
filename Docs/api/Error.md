# JSException

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Exception`  
**Source:** `JSObjects/Error.cs`  

> A .Net exception that represents a Javascript Error and makes the Error information available if needed

## Constructors

| Signature | Description |
|---|---|
| `JSException(Error error)` | Creates a new Exception to represent a Javascript Error |
| `JSException(string message, string? name)` | Creates a new Exception to represent a Javascript Error |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Message` | `override string` | get | Returns the error message |
| `Name` | `string` | get | Returns the Error type name |
| `Error` | `Error?` | get | The Javascript Error this exception represents |
| `Stack` | `string?` | get | A non-standard property for a stack trace. |
| `Cause` | `Error?` | get | Error cause indicating the reason why the current error is thrown - usually another caught error. For user-created Error objects, this is the value provided as the cause property of the constructor's second argument. |
| `ColumnNumber` | `int?` | get | A non-standard Mozilla property for the column number in the line that raised this error. |
| `FileName` | `string?` | get | A non-standard Mozilla property for the path to the file that raised this error. |
| `LineNumber` | `int?` | get | A non-standard Mozilla property for the line number in the file that raised this error. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ToString()` | `string` | Returns the Error toString() value |
| `ToException()` | `JSException` | Creates a new .Net exception to represent the error |

