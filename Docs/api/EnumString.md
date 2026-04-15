# EnumString

**Namespace:** `SpawnDev.BlazorJS`  
**Inheritance:** EnumString (abstract) -> EnumString&lt;T&gt;  
**Source:** `SpawnDev.BlazorJS/EnumString.cs`

> EnumString&lt;T&gt; provides bidirectional conversion between C# enums and JavaScript string values. Many JavaScript APIs use string constants (e.g., "audio", "video", "arraybuffer") where C# would use an enum. EnumString maps between the two using `[JsonPropertyName]` attributes on enum members to define the JS string representation. It supports implicit conversions in both directions.

## Properties

| Property | Type | Description |
|---|---|---|
| `String` | `string?` | The JavaScript string value. Setting this updates Enum and IsDefined. |
| `Enum` | `T?` | The C# enum value. Setting this updates String and IsDefined. |
| `IsDefined` | `bool` | True if the current value maps to a known enum member. |

## Constructors

```csharp
new EnumString<T>()               // Empty
new EnumString<T>(T value)        // From enum value
new EnumString<T>(string value)   // From string value
```

## Implicit Conversions

```csharp
// Enum -> EnumString<T>
EnumString<MediaType> es = MediaType.Audio;

// EnumString<T> -> Enum
MediaType mt = es;

// String -> EnumString<T>
EnumString<MediaType> es2 = "audio";

// EnumString<T> -> String
string s = es2;

// Nullable variants also supported
EnumString<MediaType>? nullable = (MediaType?)null;
MediaType? nullableEnum = (EnumString<MediaType>?)null;
```

## Example - Defining an Enum for JS Strings

```csharp
using System.Text.Json.Serialization;

public enum BinaryType
{
    [JsonPropertyName("blob")]
    Blob,
    [JsonPropertyName("arraybuffer")]
    ArrayBuffer
}

public enum ReadyState
{
    [JsonPropertyName("loading")]
    Loading,
    [JsonPropertyName("interactive")]
    Interactive,
    [JsonPropertyName("complete")]
    Complete
}
```

## Example - Using in a Wrapper

```csharp
public class WebSocket : EventTarget
{
    public WebSocket(IJSInProcessObjectReference _ref) : base(_ref) { }

    // BinaryType is a string in JS: "blob" or "arraybuffer"
    public EnumString<BinaryType> BinaryType
    {
        get => JSRef!.Get<EnumString<BinaryType>>("binaryType");
        set => JSRef!.Set("binaryType", value);
    }
}

// Usage
using var ws = new WebSocket("wss://example.com");
ws.BinaryType = BinaryType.ArrayBuffer;  // Sets "arraybuffer" in JS

// Read back
BinaryType bt = ws.BinaryType;  // Implicit conversion to enum
string btStr = ws.BinaryType;   // Implicit conversion to string: "arraybuffer"
```

## Example - Handling Unknown Values

```csharp
EnumString<ReadyState> state = JS.Get<EnumString<ReadyState>>("document.readyState");

if (state.IsDefined)
{
    ReadyState rs = state; // safe to convert
    switch (rs)
    {
        case ReadyState.Complete:
            Console.WriteLine("Document is loaded");
            break;
    }
}
else
{
    Console.WriteLine($"Unknown readyState: {state.String}");
}
```

## JSON Serialization

EnumString serializes to a plain JSON string using the `[JsonPropertyName]` value:

```json
"arraybuffer"
```

If the EnumString is null, it serializes as JSON `null`.
