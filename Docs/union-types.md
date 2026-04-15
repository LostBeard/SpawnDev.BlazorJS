# Union Types

SpawnDev.BlazorJS provides TypeScript-style discriminated union types via `Union<T1, T2>` through `Union<T1, T2, T3, T4, T5, T6, T7, T8>`. These types allow a single variable to hold one of several unrelated types with full type safety, and they serialize correctly to and from JavaScript.

**Namespace:** `SpawnDev.BlazorJS`

---

## Basic Usage

```csharp
// A Union that can hold a string, int, or bool
Union<string, int, bool> value = "hello";    // implicit conversion from string
Union<string, int, bool> value2 = 42;        // implicit conversion from int
Union<string, int, bool> value3 = true;      // implicit conversion from bool
```

Union types support implicit conversion from each constituent type. The actual type stored is tracked internally.

---

## Match - Exhaustive Pattern Matching

`Match` lets you handle each possible type with a dedicated handler. The correct handler is called based on the actual stored type.

### Action Overload (void return)

```csharp
Union<string, int, bool> value = 42;

value.Match(
    s => Console.WriteLine($"It's a string: {s}"),
    i => Console.WriteLine($"It's an int: {i}"),
    b => Console.WriteLine($"It's a bool: {b}")
);
// Prints: "It's an int: 42"
```

### Func Overload (returns a value)

```csharp
Union<string, int, long> result = 6;

string message = result.Match(
    str => $"String: {str}",
    num => $"Int Number: {num}",
    num => $"Long Number: {num}"
);
// message == "Int Number: 6"
```

---

## Map and MapAsync - Monadic Transformation

`Map` transforms one type within the Union into another type, returning a new Union.

```csharp
Union<string, int, long> result = 6;

// Map int values to ulong, keeping string and long as-is
Union<string, ulong, long> mapped = result
    .Map((string v) => 99)              // transforms string -> int (99), but result holds int so no-op
    .Map<ulong>((int v) => (ulong)(v * 5));  // transforms int -> ulong
```

### MapAsync

```csharp
Union<string, int, long> result = "hello";

Union<string, int, long> mapped = await result.MapAsync(async (string v) => v + " world");
// mapped holds "hello world"

Union<string, int, long> mapped2 = await result.MapAsync(async (int v) => v * 5 + "");
// Not applied because result holds a string, not an int
```

---

## Reduce - Collapsing Types

`Reduce` converts one type into one of the remaining types, reducing the number of possible types by one.

```csharp
Union<string, int, long> result = 6;

// Reduce int to string, then long to string
// Union<string, int, long> -> Union<string, long> -> string
string finalValue = result
    .Reduce((int v) => v.ToString())      // int -> string
    .Reduce((long v) => v.ToString());    // long -> string
// finalValue == "6"
```

---

## Is\<T\> and As\<T\> - Type Testing

```csharp
Union<string, int, bool> value = "hello";

// Test what type is stored
bool isString = value.Is<string>();  // true
bool isInt = value.Is<int>();        // false

// Get the value as a specific type (returns default if wrong type)
string? s = value.As<string>();      // "hello"
int i = value.As<int>();             // 0 (default)
```

---

## Using Union in Method Parameters

Union types are particularly useful for method parameters that accept multiple types, mirroring TypeScript's union type syntax.

```csharp
void SetValue(string varName, Union<bool?, string?>? value)
{
    JS.Set(varName, value);
}

// Call with a string
SetValue("myVar", "Hello world!");

// Call with a bool
SetValue("myVar", true);

// Call with null
SetValue("myVar", null);
```

---

## JSON Serialization

Union types include custom JSON converters that handle serialization and deserialization correctly. When serialized to JavaScript, only the actual held value is written - not a wrapper object.

```csharp
// This serializes to JS as just the string "hello", not { type: "string", value: "hello" }
Union<string, int> value = "hello";
JS.Set("myVar", value);
// In JS: myVar === "hello"
```

When deserializing from JavaScript, the converter attempts each type in order and uses the first one that succeeds.

---

## WebIDL Predefined Union Types

SpawnDev.BlazorJS includes predefined union types that match WebIDL type definitions used across browser APIs:

```csharp
// AllowSharedBufferSource = Union<ArrayBuffer, SharedArrayBuffer, ArrayBufferView>
// Used by APIs that accept either regular or shared buffers

// BufferSource = Union<ArrayBuffer, ArrayBufferView>
// Used by APIs that accept binary data

// CanvasImageSource = Union<HTMLCanvasElement, HTMLImageElement, HTMLVideoElement, ...>
// Used by Canvas APIs that accept various image sources
```

These are used throughout the JSObject wrapper library wherever the Web API accepts multiple types.

---

## Real-World Examples

### File Constructor

The JavaScript `File` constructor accepts an array of `BlobPart` items, where each part can be a string, Blob, ArrayBuffer, or TypedArray:

```csharp
// Create a File from mixed content types
var parts = new Union<string, Blob>[] { "Hello ", "World" };
using var file = new File(parts, "hello.txt");
```

### Method Accepting Multiple Types

```csharp
public void SetConfig(string key, Union<string, int, bool, double> value)
{
    JS.CallVoid("setConfig", key, value);
}

// All valid:
SetConfig("name", "MyApp");
SetConfig("port", 8080);
SetConfig("debug", true);
SetConfig("scale", 1.5);
```

### ONNX Inference Input

```csharp
// An ONNX input that can be a single float or an array
Union<float, float[]> bias = new float[] { 0.485f, 0.456f, 0.406f };

// Or a single value
Union<float, float[]> singleBias = 0.5f;
```

---

## Available Union Sizes

| Type | Parameter Count |
|---|---|
| `Union<T1, T2>` | 2 types |
| `Union<T1, T2, T3>` | 3 types |
| `Union<T1, T2, T3, T4>` | 4 types |
| `Union<T1, T2, T3, T4, T5>` | 5 types |
| `Union<T1, T2, T3, T4, T5, T6>` | 6 types |
| `Union<T1, T2, T3, T4, T5, T6, T7>` | 7 types |
| `Union<T1, T2, T3, T4, T5, T6, T7, T8>` | 8 types |

---

## See Also

- [Undefinable](undefinable.md) - Distinguishing null from undefined
- [EnumString](enumstring.md) - String-to-enum mapping
- [JSObject](jsobject.md) - Base wrapper class
