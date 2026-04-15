# DynamicJSObject

**Namespace:** `SpawnDev.BlazorJS`  
**Inheritance:** DynamicObject -> DynamicJSObject  
**Implements:** `IDisposable`  
**Source:** `SpawnDev.BlazorJS/DynamicJSObject.cs`

> DynamicJSObject wraps a JSObject and exposes it as a C# `dynamic` object, enabling JavaScript-like property access and method invocation syntax. Property reads return nested DynamicJSObjects (or null), method calls invoke the underlying JS methods, and property writes set JS properties - all through the `dynamic` keyword. This is useful for quick prototyping or working with untyped JS objects.

## Properties

| Property | Type | Description |
|---|---|---|
| `JSObjectRef` | `JSObject` | The underlying JSObject being wrapped. |

## Constructors

```csharp
new DynamicJSObject(JSObject obj)
new DynamicJSObject(IJSInProcessObjectReference _ref)
```

## Explicit Cast

```csharp
DynamicJSObject dyn = (DynamicJSObject)myJSObject;
```

## Dynamic Operations

| Operation | Description |
|---|---|
| Property get | Returns a DynamicJSObject wrapping the JS property value, or null if undefined/null. |
| Property set | Sets the JS property to the provided value. |
| Method call | Invokes the JS method. Returns DynamicJSObject or null. |
| Method call with type arg | `obj.method<ReturnType>(args)` invokes and returns as the specified type. |
| `__As<T>()` / `__As(Type)` | Unwrap the DynamicJSObject as the specified type. |
| `prop__As<T>()` | Get a property as the specified type. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetDynamicMemberNames()` | `IEnumerable<string>` | Returns all property keys on the wrapped JS object. |
| `Dispose()` | `void` | Disposes the underlying JSObject reference. |

## Example - Dynamic Property Access

```csharp
dynamic window = new DynamicJSObject(JS.Get<JSObject>("window"));

// Property access returns DynamicJSObject
dynamic doc = window.document;
dynamic body = doc.body;

// Get typed values using __As postfix
int height = window.innerHeight__As<int>();
string title = doc.title__As<string>();

// Set properties
window.myCustomProp = 42;

// Dispose when done
((IDisposable)window).Dispose();
```

## Example - Dynamic Method Calls

```csharp
dynamic console = new DynamicJSObject(JS.Get<JSObject>("console"));

// Method calls
console.log("Hello from dynamic!");
console.warn("Warning!");

// Method call with typed return
dynamic json = new DynamicJSObject(JS.Get<JSObject>("JSON"));
string result = json.stringify__As<string>(new { name = "test" });
```

## Important Notes

- DynamicJSObject is primarily for prototyping and exploration. For production code, prefer typed JSObject wrappers with strongly-typed properties and methods.
- Each property access creates a new DynamicJSObject that wraps a new JSRef - dispose them when done to avoid reference leaks.
- The `__As` postfix convention is a DynamicJSObject feature, not a general SpawnDev.BlazorJS feature.
