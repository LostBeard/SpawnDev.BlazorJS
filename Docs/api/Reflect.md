# Reflect

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** Static class  
**MDN Reference:** [Reflect - MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Reflect)

> Wraps the JavaScript `Reflect` built-in object. Provides static methods for interceptable JavaScript operations - the same operations targeted by Proxy handler traps. Unlike `Object` methods, `Reflect` methods return booleans for success/failure instead of throwing. Target parameters accept `Union<JSObject, IJSInProcessObjectReference>` for maximum flexibility.

## Static Methods

### Property Access

| Method | Return Type | Description |
|---|---|---|
| `Get<T>(target, string propertyKey)` | `T` | Gets a property value by string key. Like `target[propertyKey]`. |
| `Get<T>(target, int propertyKey)` | `T` | Gets a property value by integer key. Like `target[index]`. |
| `Get<T>(target, string propertyKey, receiver)` | `T` | Gets a property with a custom `this` receiver for getters. |
| `Get<T>(target, int propertyKey, receiver)` | `T` | Gets a property by integer key with a custom receiver. |
| `Set(target, string propertyKey, object value)` | `bool` | Sets a property. Returns `true` if successful. |
| `Set(target, string propertyKey, object value, receiver)` | `bool` | Sets a property with a custom receiver for setters. |
| `Has(target, string propertyKey)` | `bool` | Returns `true` if the property exists (like `in` operator). |

### Property Definition / Deletion

| Method | Return Type | Description |
|---|---|---|
| `DefineProperty(target, string propertyKey, object attributes)` | `bool` | Defines a property with the given descriptor. Returns `true` if successful. |
| `DeleteProperty(target, string propertyKey)` | `bool` | Deletes a property by string key. Returns `true` if successful. |
| `DeleteProperty(target, int propertyKey)` | `bool` | Deletes a property by integer key. |
| `GetOwnPropertyDescriptor(target, string propertyKey)` | `PropertyDescriptor?` | Returns the property descriptor, or `null` if not found. |

### Function Invocation

| Method | Return Type | Description |
|---|---|---|
| `Apply<T>(Function target, object? thisArgument, object[] argumentList)` | `T` | Calls the function with the given `this` and arguments array. |
| `ApplyVoid(Function target, object? thisArgument, object[] argumentList)` | `void` | Calls the function with no return value. |
| `Construct<T>(Function target, object[] argumentList)` | `T` | Calls the function as a constructor (like `new target(...args)`). |
| `Construct<T>(Function target, object[] argumentList, Function newTarget)` | `T` | Calls the function as a constructor with a custom `new.target`. |

### Prototype / Extension

| Method | Return Type | Description |
|---|---|---|
| `GetPrototypeOf(target)` | `JSObject?` | Returns the prototype of the target object, or `null`. |
| `SetPrototypeOf(target, prototype)` | `bool` | Sets the prototype. Returns `true` if successful. |
| `IsExtensible(target)` | `bool` | Returns `true` if new properties can be added to the target. |
| `PreventExtensions(target)` | `bool` | Prevents new properties from being added. Returns `true` if successful. |

### Key Enumeration

| Method | Return Type | Description |
|---|---|---|
| `OwnKeys(target)` | `Array` | Returns an `Array` of the target's own property keys (strings and symbols). Ordered: non-negative integer indexes first, then string keys, then symbol keys. |

## Example

```csharp
using var obj = JS.Call<JSObject>("Object.create", null);

// Set and get properties
Reflect.Set(obj, "name", "SpawnDev");
string name = Reflect.Get<string>(obj, "name");  // "SpawnDev"

// Check property existence
bool has = Reflect.Has(obj, "name");  // true

// Delete a property
bool deleted = Reflect.DeleteProperty(obj, "name");  // true

// Get own property keys
using var keyed = JS.Call<JSObject>("Object.create", null);
Reflect.Set(keyed, "a", 1);
Reflect.Set(keyed, "b", 2);
using var keys = Reflect.OwnKeys(keyed);
Console.WriteLine($"Keys: {keys.Length}");  // 2

// Call a function via Reflect.Apply
using var fn = JS.Get<Function>("Math.max");
int max = Reflect.Apply<int>(fn, null, new object[] { 1, 5, 3 });  // 5

// Construct an object
using var dateCtor = JS.Get<Function>("Date");
using var date = Reflect.Construct<JSObject>(dateCtor, new object[] { });
```
