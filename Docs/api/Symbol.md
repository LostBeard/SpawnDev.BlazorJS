# Symbol

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Symbol.cs`  
**MDN Reference:** [Symbol on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Symbol)

> Symbol is a built-in object whose constructor returns a symbol primitive - also called a Symbol value or just a Symbol - that's guaranteed to be unique. Symbols are often used to add unique property keys to an object that won't collide with keys any other code might add to the object, and which are hidden from any mechanisms other code will typically use to access the object. That enables a form of weak encapsulation, or a weak form of information hiding. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Symbol

## Constructors

| Signature | Description |
|---|---|
| `Symbol(string description)` | This is a non-standard implementation of the Symbol constructor which in Javascript will throw an exception. Call Symbol(description) A string. A description of the symbol which can be used for debugging but not to access the symbol itself. |
| `Symbol()` | This is a non-standard implementation of the Symbol constructor which in Javascript will throw an exception. Calls Symbol() |
| `Symbol(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Description` | `string?` | get | The description accessor property of Symbol values returns a string containing the description of this symbol, or undefined if the symbol has no description. |
| `IsConcatSpreadable` | `Symbol` | get | The Symbol.isConcatSpreadable static data property represents the well-known symbol @@isConcatSpreadable. The Array.prototype.concat() method looks up this symbol on each object being concatenated to determine if it should be treated as an array-like object and flattened to its array elements. Do not dispose. |
| `Iterator` | `Symbol` | get | The Symbol.iterator static data property represents the well-known symbol @@iterator. The iterable protocol looks up this symbol for the method that returns the iterator for an object. In order for an object to be iterable, it must have an @@iterator key. Do not dispose. |
| `AsyncIterator` | `Symbol` | get | The Symbol.asyncIterator static data property represents the well-known symbol @@asyncIterator. The async iterable protocol looks up this symbol for the method that returns the async iterator for an object. In order for an object to be async iterable, it must have an @@asyncIterator key. Do not dispose. |
| `HasInstance` | `Symbol` | get | The Symbol.hasInstance static data property represents the well-known symbol @@hasInstance. The instanceof operator looks up this symbol on its right-hand operand for the method used to determine if the constructor object recognizes an object as its instance. Do not dispose. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `For(string key)` | `Symbol` | The Symbol.for() static method searches for existing symbols in a runtime-wide symbol registry with the given key and returns it if found. Otherwise a new symbol gets created in the global symbol registry with this key. String, required. The key for the symbol (and also used for the description of the symbol). |
| `KeyFor(Symbol sym)` | `string?` | The Symbol.keyFor() static method retrieves a shared symbol key from the global symbol registry for the given symbol. Symbol, required. The symbol to find a key for. |

