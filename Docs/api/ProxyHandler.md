# ProxyHandler

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `IDisposable`  
**Source:** `JSObjects/ProxyHandler.cs`  

> An object whose properties are functions that define the behavior of the proxy when an operation is performed on it.

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Apply` | `Func<JSObject, JSObject, Array<JSObject?>, object?>?` | get |  |
| `ApplyCallback` | `FuncCallback<JSObject, JSObject, Array<JSObject?>, object?>?` | get |  |
| `Get` | `Func<JSObject, JSObject, JSObject, object?>?` | get |  |
| `GetCallback` | `FuncCallback<JSObject, JSObject, JSObject, object?>?` | get |  |
| `Construct` | `Func<JSObject, Array<JSObject?>, JSObject, object?>?` | get |  |
| `ConstructCallback` | `FuncCallback<JSObject, Array<JSObject?>, JSObject, object?>?` | get |  |
| `Set` | `Func<JSObject, JSObject, JSObject, bool>?` | get/set |  |
| `SetCallback` | `FuncCallback<JSObject, JSObject, JSObject, bool>?` | get |  |
| `Has` | `Func<JSObject, JSObject, bool>?` | get |  |
| `HasCallback` | `FuncCallback<JSObject, JSObject, bool>?` | get |  |
| `OwnKeys` | `Func<JSObject, IEnumerable<Union<Symbol, string>>>?` | get |  |
| `OwnKeysCallback` | `FuncCallback<JSObject, IEnumerable<Union<Symbol, string>>>?` | get |  |
| `DeleteProperty` | `Func<JSObject, JSObject, bool>?` | get |  |
| `DeletePropertyCallback` | `FuncCallback<JSObject, JSObject, bool>?` | get |  |

