# JSON

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** Static class  
**MDN Reference:** [JSON - MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/JSON)

> Wraps the JavaScript `JSON` object. Provides static methods for parsing and stringifying JSON using the browser's native JSON engine.

## Static Methods

| Method | Return Type | Description |
|---|---|---|
| `Parse<T>(string json)` | `T` | Parses a JSON string and returns the result as type `T`. |
| `Stringify(object value)` | `string` | Converts a value to a JSON string. |
| `Stringify(object value, object replacer, int space)` | `string` | Stringifies with formatting options. |

## Example

```csharp
// Parse JSON
string json = "{\"name\":\"TJ\",\"age\":42}";
using var obj = JSON.Parse<JSObject>(json);

// Stringify
string output = JSON.Stringify(obj);
Console.WriteLine(output);
```
