# Function

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Function.cs`  
**MDN Reference:** [Function on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Function)

> The Function object provides methods for functions. In JavaScript, every function is actually a Function object. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Function

## Constructors

| Signature | Description |
|---|---|
| `Function(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Function(params string[] args)` | Syntax: new Function (arg1, arg2, ...argN, functionBody) where arg1 - argN are the parameter names used in the function body and functionBody is the function body |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `string?` | get | The name of the function. |
| `Length` | `int` | get | Specifies the number of arguments expected by the function. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `NewApply(object?[]? args)` | `T` | Creates a new instance of the function object. The type of the new instance. Arguments to pass to the constructor. The new instance. |
| `New()` | `T` | Creates a new instance of the function object. The type of the new instance. The new instance. |
| `New(object arg0)` | `T` | Creates a new instance of the function object. |
| `New(object arg0, object arg1)` | `T` | Creates a new instance of the function object. |
| `New(object arg0, object arg1, object arg2)` | `T` | Creates a new instance of the function object. |
| `New(object arg0, object arg1, object arg2, object arg3)` | `T` | Creates a new instance of the function object. |
| `New(object arg0, object arg1, object arg2, object arg3, object arg4)` | `T` | Creates a new instance of the function object. |
| `New(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5)` | `T` | Creates a new instance of the function object. |
| `New(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6)` | `T` | Creates a new instance of the function object. |
| `New(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7)` | `T` | Creates a new instance of the function object. |
| `New(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8)` | `T` | Creates a new instance of the function object. |
| `New(object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, object arg9)` | `T` | Creates a new instance of the function object. |
| `Apply(object? thisObj, object?[]? args)` | `T` | Calls the function with a given this value and arguments provided as an array (or an array-like object). The return type. The value of this provided for the call to the function. Note that this may not be the actual value seen by the method: if the method is a function in non-strict mode code, null and undefined will be replaced with the global object, and primitive values will be boxed. This argument is required. An array-like object, specifying the arguments with which func should be called, or null or undefined if no arguments should be provided to the function. The result of calling the function with the specified this value and arguments. |
| `ApplyAsync(object? thisObj, object?[]? args)` | `Task<T>` | Calls the function with a given this value and arguments provided as an array (or an array-like object). The return type. The value of this provided for the call to the function. An array-like object, specifying the arguments with which func should be called. A Task that resolves to the result of calling the function. |
| `ApplyVoid(object? thisObj, object?[]? args)` | `void` | Calls the function with a given this value and arguments provided as an array (or an array-like object). The value of this provided for the call to the function. An array-like object, specifying the arguments with which func should be called. |
| `Call(object? thisObj, params object?[] args)` | `T` | Calls the function with a given this value and arguments provided individually. The return type. The value of this provided for the call to the function. Arguments for the function. The result of calling the function. |
| `CallAsync(object? thisObj, params object?[] args)` | `Task<T>` | Calls the function with a given this value and arguments provided individually. The return type. The value of this provided for the call to the function. Arguments for the function. A Task that resolves to the result of calling the function. |
| `CallVoid(object? thisObj, params object?[] args)` | `void` | Calls the function with a given this value and arguments provided individually. The value of this provided for the call to the function. Arguments for the function. |
| `ToAction()` | `Action` | Converts the Function to an Action. An Action that calls the function. |
| `ToFunc()` | `Func<TResult>` | Converts the Function to a Func&lt;TResult&gt;. The return type of the function. A Func&lt;TResult&gt; that calls the function. |

