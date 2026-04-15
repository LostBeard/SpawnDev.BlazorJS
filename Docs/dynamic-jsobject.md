# DynamicJSObject

`DynamicJSObject` wraps a `JSObject` and provides `dynamic` access to JavaScript objects, allowing property access and method calls without pre-defined typed wrappers. It works like JavaScript's own dynamic property access.

**Namespace:** `SpawnDev.BlazorJS`

---

## Overview

`DynamicJSObject` extends `System.Dynamic.DynamicObject` and uses `TryGetMember`, `TrySetMember`, and `TryInvokeMember` to forward all operations to the underlying JavaScript object. Results from property access and method calls are automatically wrapped in new `DynamicJSObject` instances (or returned as null).

Use `DynamicJSObject` when:

- You need to quickly explore a JavaScript object without writing a full typed wrapper
- You are working with a JS object whose shape is not known at compile time
- You want JavaScript-like dynamic access from C#

Prefer typed `JSObject` wrappers for production code - they provide compile-time type safety, better IntelliSense, and more predictable behavior.

---

## Creating a DynamicJSObject

### From a JSObject

```csharp
using var jsObj = JS.Get<JSObject>("someObject");
dynamic dyn = (DynamicJSObject)jsObj;
```

### From an IJSInProcessObjectReference

```csharp
var rawRef = JS.Get<IJSInProcessObjectReference>("someObject");
dynamic dyn = new DynamicJSObject(rawRef);
```

---

## Property Access

Getting and setting properties works like JavaScript:

```csharp
using var jsObj = JS.Get<JSObject>("navigator");
dynamic nav = (DynamicJSObject)jsObj;

// Get properties - returns DynamicJSObject or null
dynamic ua = nav.userAgent;
dynamic langs = nav.languages;
```

---

## Method Calls

```csharp
using var jsObj = JS.Get<JSObject>("document");
dynamic doc = (DynamicJSObject)jsObj;

// Call methods - returns DynamicJSObject or null
dynamic el = doc.getElementById("myId");
```

---

## The \_As Postfix for Typed Access

To extract a concrete .NET type from a `DynamicJSObject`, use the `_As` postfix convention:

### \_As\<T\>() - Convert the Object Itself

```csharp
dynamic dyn = (DynamicJSObject)jsObj;

// Convert the DynamicJSObject itself to a typed value
string value = dyn._As<string>();
int count = dyn._As<int>();
HTMLElement element = dyn._As<HTMLElement>();
```

### propertyName\_As\<T\>() - Convert a Property

```csharp
dynamic dyn = (DynamicJSObject)jsObj;

// Get a property as a specific type
int height = dyn.innerHeight_As<int>();
string title = dyn.title_As<string>();
```

### \_As(Type) - Runtime Type

```csharp
dynamic dyn = (DynamicJSObject)jsObj;
object value = dyn._As(typeof(string));
```

---

## Listing Properties

`GetDynamicMemberNames()` returns the property names of the underlying JavaScript object:

```csharp
var dyn = new DynamicJSObject(jsObj);
var names = dyn.GetDynamicMemberNames();
foreach (var name in names)
{
    Console.WriteLine(name);
}
```

---

## Disposal

`DynamicJSObject` implements `IDisposable`. Disposing it disposes the underlying `JSObject`:

```csharp
var dyn = new DynamicJSObject(jsObj);
// ... use dyn ...
dyn.Dispose();
```

Or with `using`:

```csharp
using var dyn = new DynamicJSObject(jsObj);
dynamic d = dyn;
// ...
```

---

## How It Works Internally

- **TryGetMember** - calls `JSRef.Get<JSObject?>` on the property name, wraps result in `DynamicJSObject`
- **TrySetMember** - calls `JSRef.Set` on the property name
- **TryInvokeMember** - calls the method on the JS object, wraps result in `DynamicJSObject`
- **TryInvoke** - calls `Reflect.apply` for direct invocation

The `_As` postfix is detected in `TryInvokeMember` - when a method name ends with `_As`, it extracts the type argument and returns the property or object as that type instead of wrapping in `DynamicJSObject`.

---

## Limitations

1. **No IntelliSense** - dynamic access means no compile-time help
2. **No type safety** - errors are runtime, not compile-time
3. **Every access creates a new DynamicJSObject** - more object allocations than typed wrappers
4. **No event support** - `ActionEvent` patterns require typed wrappers

---

## When to Use vs Typed Wrappers

| Scenario | Recommendation |
|---|---|
| Quick prototyping / exploration | `DynamicJSObject` |
| Production code | Typed `JSObject` wrapper |
| Unknown object shape | `DynamicJSObject` |
| Frequently accessed API | Typed `JSObject` wrapper |
| One-off access to a JS property | `DynamicJSObject` or `JS.Get<T>()` |

---

## See Also

- [JSObject](jsobject.md) - Typed wrapper base class
- [BlazorJSRuntime](blazorjsruntime.md) - Direct property/method access without wrappers
- [Custom JSObject Wrappers](custom-jsobjects.md) - Building typed wrappers
