# EnumString\<T\>

`EnumString<T>` provides bidirectional conversion between C# enums and JavaScript string constants. Many JavaScript APIs use string values where C# would use enums (e.g., `"readwrite"`, `"arraybuffer"`, `"blob"`). EnumString bridges this gap with automatic JSON serialization.

**Namespace:** `SpawnDev.BlazorJS`

---

## How It Works

`EnumString<T>` wraps a C# enum type `T` and maps each enum member to a JavaScript string value using `[JsonPropertyName]` attributes. When serialized to JSON (for JavaScript interop), it outputs the string value. When deserialized, it converts the string back to the enum member.

---

## Defining an Enum for EnumString

Use `[JsonPropertyName]` on each enum member to specify the JavaScript string value:

```csharp
using System.Text.Json.Serialization;

public enum BinaryType
{
    [JsonPropertyName("blob")]
    Blob,

    [JsonPropertyName("arraybuffer")]
    ArrayBuffer,
}
```

---

## Using EnumString

### Implicit Conversions

`EnumString<T>` supports implicit conversion from the enum type `T`, from a `string`, and back:

```csharp
// From enum
EnumString<BinaryType> type = BinaryType.ArrayBuffer;
// Serializes as "arraybuffer" in JS

// From string
EnumString<BinaryType> type2 = "blob";
// Maps to BinaryType.Blob

// To string
string jsValue = type.String;  // "arraybuffer"

// To enum
BinaryType? enumValue = type.Enum;  // BinaryType.ArrayBuffer
```

### In JSObject Properties

```csharp
public class WebSocket : EventTarget
{
    public WebSocket(IJSInProcessObjectReference _ref) : base(_ref) { }

    // EnumString property
    public EnumString<BinaryType> BinaryType
    {
        get => JSRef!.Get<EnumString<BinaryType>>("binaryType");
        set => JSRef!.Set("binaryType", value);
    }
}

// Usage:
using var ws = new WebSocket("wss://example.com");
ws.BinaryType = BinaryType.ArrayBuffer;  // Sets "arraybuffer" in JS
```

### In Method Parameters

```csharp
public IDBTransaction Transaction(string storeName, EnumString<IDBTransactionMode> mode)
    => JSRef!.Call<IDBTransaction>("transaction", storeName, mode);

// Usage:
using var tx = db.Transaction("myStore", IDBTransactionMode.ReadWrite);
// Passes "readwrite" to JavaScript
```

---

## EnumString Properties

| Property | Type | Description |
|---|---|---|
| `Enum` | `T?` | The enum value, or null if the string is not a defined enum member |
| `String` | `string?` | The JavaScript string value |
| `IsDefined` | `bool` | True if the string maps to a defined enum member |

---

## Handling Unknown String Values

If JavaScript returns a string that does not map to any defined enum member, `EnumString` still holds the string value, but `Enum` is `null` and `IsDefined` is `false`:

```csharp
EnumString<BinaryType> unknown = "somethingNew";
// unknown.Enum == null
// unknown.String == "somethingNew"
// unknown.IsDefined == false
```

This allows forward compatibility - your code won't crash when a browser adds new values to an API.

---

## JSON Serialization

`EnumString<T>` uses a custom JSON converter (`EnumStringConverterFactory`). When serialized:

- If the value is `null`, JSON `null` is written
- Otherwise, the `String` property value is written as a JSON string

When deserialized:

- JSON `null` becomes a null `EnumString<T>`
- A JSON string is mapped to the matching enum member (or stored as an undefined string if no match)

---

## Real-World Examples

### WebGPU Texture Format

```csharp
public enum GPUTextureFormat
{
    [JsonPropertyName("rgba8unorm")]
    RGBA8Unorm,

    [JsonPropertyName("rgba8snorm")]
    RGBA8Snorm,

    [JsonPropertyName("bgra8unorm")]
    BGRA8Unorm,

    [JsonPropertyName("rgba16float")]
    RGBA16Float,

    [JsonPropertyName("rgba32float")]
    RGBA32Float,

    // ... many more formats
}

// Used in WebGPU API:
public class GPUTexture : JSObject
{
    public GPUTexture(IJSInProcessObjectReference _ref) : base(_ref) { }

    public EnumString<GPUTextureFormat> Format
        => JSRef!.Get<EnumString<GPUTextureFormat>>("format");
}
```

### WebRTC ICE Connection State

```csharp
public enum RTCIceConnectionState
{
    [JsonPropertyName("new")]
    New,

    [JsonPropertyName("checking")]
    Checking,

    [JsonPropertyName("connected")]
    Connected,

    [JsonPropertyName("completed")]
    Completed,

    [JsonPropertyName("disconnected")]
    Disconnected,

    [JsonPropertyName("failed")]
    Failed,

    [JsonPropertyName("closed")]
    Closed,
}
```

### ReadableStream State

```csharp
public enum ReadableStreamState
{
    [JsonPropertyName("readable")]
    Readable,

    [JsonPropertyName("closed")]
    Closed,

    [JsonPropertyName("errored")]
    Errored,
}
```

---

## ToString()

`EnumString<T>.ToString()` returns the string value (same as `String` property):

```csharp
EnumString<BinaryType> type = BinaryType.Blob;
Console.WriteLine(type);  // "blob"
```

---

## See Also

- [Union Types](union-types.md) - Multi-type values
- [JSObject](jsobject.md) - Base wrapper class
