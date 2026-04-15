# Undefinable

**Namespace:** `SpawnDev.BlazorJS`  
**Source:** `SpawnDev.BlazorJS/Undefinable.cs`

> Undefinable&lt;T&gt; distinguishes between JavaScript `null` and `undefined` in C# - something that standard .NET nullable types cannot do. In JavaScript, `null` and `undefined` are distinct values with different semantics. When calling JS APIs that differentiate between "not set" (undefined) and "explicitly null" (null), Undefinable lets you express that distinction. The serialization uses a `__undefinedref__` JSON property to signal undefined to the interop layer.

## Classes

### Undefinable (non-generic base)

| Property | Type | Description |
|---|---|---|
| `Value` | `object?` | The boxed value. |
| `IsUndefinedIfNull` | `bool` | If true (default), null values are treated as undefined. If false, null is null. |
| `IsUndefined` | `bool` | Returns true if Value is null and IsUndefinedIfNull is true. Serialized as `__undefinedref__`. |
| `Null` | `Undefinable` | Static property returning an Undefinable representing JS null. |
| `Undefined` | `Undefinable` | Static property returning an Undefinable representing JS undefined. |

### Undefinable&lt;T&gt; (generic)

| Property | Type | Description |
|---|---|---|
| `Value` | `T?` | The typed value. |
| `IsUndefinedIfNull` | `bool` | If true (default), null values are treated as undefined. |
| `IsUndefined` | `bool` | Returns true if Value is null and IsUndefinedIfNull is true. |
| `Null` | `Undefinable<T>` | Static property for JS null. |
| `Undefined` | `Undefinable<T>` | Static property for JS undefined. |

**Note:** T must be a nullable type (reference type or Nullable&lt;T&gt;). A runtime check throws if default(T) is not null.

## Constructors

```csharp
// Default - undefined
new Undefinable<string>()

// With value
new Undefinable<string>("hello")

// With explicit null/undefined control
new Undefinable<string>(null, isUndefinedIfNull: false)  // JS null
new Undefinable<string>(null, isUndefinedIfNull: true)   // JS undefined (default)
```

## Implicit Conversions

```csharp
// T -> Undefinable<T>
Undefinable<string> u = "hello";  // Wraps the value

// Undefinable<T> -> T (explicit cast)
string? s = (string?)u;  // Extracts the value
```

## Example - Distinguishing null from undefined

```csharp
// JS API: someMethod(options?: { timeout?: number })
// - omitting timeout = undefined (use default)
// - passing null = explicitly no timeout

// undefined - property not set, JS uses its default
Undefinable<int?> timeout = Undefinable<int?>.Undefined;

// null - explicitly set to null
Undefinable<int?> noTimeout = Undefinable<int?>.Null;

// actual value
Undefinable<int?> fiveSeconds = 5000;

JS.CallVoid("someMethod", new { timeout = timeout });       // timeout is undefined
JS.CallVoid("someMethod", new { timeout = noTimeout });     // timeout is null
JS.CallVoid("someMethod", new { timeout = fiveSeconds });   // timeout is 5000
```

## Example - Optional Parameters in Wrappers

```csharp
public class MyOptions
{
    public string? Name { get; set; }
    public Undefinable<int?> MaxRetries { get; set; } = Undefinable<int?>.Undefined;
    public Undefinable<string?> Label { get; set; } = Undefinable<string?>.Undefined;
}

var opts = new MyOptions
{
    Name = "test",
    // MaxRetries left as Undefined - won't appear in JS object
    Label = Undefinable<string?>.Null // explicitly null in JS
};
```

## JSON Serialization

When `IsUndefined` is true, serializes as:
```json
{ "__undefinedref__": true }
```

The interop layer reads this sentinel and converts it to actual JS `undefined`. When `IsUndefined` is false and Value is null, it serializes as JSON `null`.
