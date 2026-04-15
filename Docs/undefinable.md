# Undefinable\<T\>

JavaScript has both `null` and `undefined`, but C# only has `null`. When interoperating with JavaScript APIs where the distinction matters, `Undefinable<T>` lets you explicitly pass `undefined` to JavaScript.

**Namespace:** `SpawnDev.BlazorJS`

---

## The Problem

In standard .NET-to-JS interop, passing a C# `null` value to JavaScript results in `null` on the JS side. But some JavaScript APIs behave differently depending on whether a parameter is `null` versus `undefined`:

```javascript
// These do different things in many JS APIs:
someApi.configure({ timeout: null });      // explicitly set timeout to null
someApi.configure({ timeout: undefined }); // use default timeout (key omitted)
```

`Undefinable<T>` gives you control over this distinction.

---

## Creating Values

### From a Value (implicit conversion)

```csharp
Undefinable<bool?> value = false;   // Will serialize as false in JS
Undefinable<string?> name = "test"; // Will serialize as "test" in JS
```

### Null

By default, passing `null` for an `Undefinable<T>` parameter results in `undefined` in JavaScript. To explicitly send `null`, use `Undefinable<T>.Null`:

```csharp
// Sends undefined to JS (default behavior for null)
Undefinable<bool?> undef = null;

// Sends null to JS (explicit null)
Undefinable<bool?> nul = Undefinable<bool?>.Null;
```

### Undefined (explicit)

```csharp
// Explicit undefined
Undefinable<bool?> undef = Undefinable<bool?>.Undefined;
```

---

## Complete Example

```csharp
void MethodWithUndefinableParams(string varName, Undefinable<bool?>? window)
{
    JS.Set(varName, window);
}

// Pass a normal value
bool? w = false;
MethodWithUndefinableParams("_willBeDefined", w);
bool? r = JS.Get<bool?>("_willBeDefined");
// r == false

// Pass null -> becomes undefined in JS
w = null;
MethodWithUndefinableParams("_willBeUndefined", w);
bool isUndef = JS.IsUndefined("_willBeUndefined");
// isUndef == true

// Explicitly pass null (not undefined)
MethodWithUndefinableParams("_willBeNull", Undefinable<bool?>.Null);
bool isUndef2 = JS.IsUndefined("_willBeNull");
// isUndef2 == false (it's null, not undefined)

// Explicitly pass undefined
MethodWithUndefinableParams("_willBeUndefined2", Undefinable<bool?>.Undefined);
bool isUndef3 = JS.IsUndefined("_willBeUndefined2");
// isUndef3 == true
```

---

## JSObject.Undefined\<T\>()

For JSObject types, you can create an instance that serializes as `undefined` in JavaScript:

```csharp
// Create an undefined Window instance
var undefinedWindow = JSObject.Undefined<Window>();

JS.Set("_undefinedWindow", undefinedWindow);
var isUndef = JS.IsUndefined("_undefinedWindow");
// isUndef == true
```

This is useful when a JS API expects a JSObject parameter but you want to pass `undefined` to use the default behavior.

---

## How It Works Internally

`Undefinable<T>` uses a special JSON serialization scheme:

- Normal values serialize as their regular JSON representation
- `Undefined` serializes using a special `__undefinedref__` marker that the interop layer recognizes and converts to JavaScript `undefined`
- `Null` serializes as JSON `null`

The custom `UndefinableConverterFactory` handles this conversion during serialization and deserialization.

---

## Type Constraints

The `T` in `Undefinable<T>` must be a nullable type. This means:

- `Undefinable<bool?>` - OK
- `Undefinable<int?>` - OK
- `Undefinable<string?>` - OK
- `Undefinable<Window?>` - OK

---

## Summary Table

| C# Value | JavaScript Result |
|---|---|
| `Undefinable<T> x = someValue` | The value |
| `Undefinable<T> x = null` | `undefined` |
| `Undefinable<T>.Null` | `null` |
| `Undefinable<T>.Undefined` | `undefined` |
| `JSObject.Undefined<Window>()` | `undefined` |

---

## See Also

- [Union Types](union-types.md) - Multi-type values
- [JSObject](jsobject.md) - Base wrapper class (Undefined static method)
- [BlazorJSRuntime](blazorjsruntime.md) - IsUndefined method
