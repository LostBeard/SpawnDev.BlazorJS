# Map<TKey, TValue>

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Map where TKey : notnull`  
**Source:** `JSObjects/Map.cs`  
**MDN Reference:** [Map<TKey, TValue> on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Map)

> The Map object holds key-value pairs and remembers the original insertion order of the keys. Any value (both objects and primitive values) may be used as either a key or a value. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Map

## Constructors

| Signature | Description |
|---|---|
| `Map()` | Creates a new instance |
| `Map(IEnumerable<(TKey, TValue)` | Creates a new instance |
| `Map(Dictionary<TKey, TValue> iterable)` | Creates a new instance |
| `Map()` | Creates a new instance |
| `Map(Array iterable)` | Creates a new instance |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Size` | `int` | get | Returns the number of key/value pairs in the Map object. |
| `ReadOnly` | `bool` | get | Returns true if the clear method is not found indicating this is a read-only Map. Read-only Map-like objects have the property size, and the methods: entries(), forEach(), get(), has(), keys(), values(), and Symbol.iterator(). Writeable Map-like objects additionally have the methods: clear(), delete(), and set(). |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Delete(TKey key)` | `bool` | Returns true if an element in the Map object existed and has been removed, or false if the element does not exist. map.has(key) will return false afterwards. |
| `Set(TKey key, TValue value)` | `Map<TKey, TValue>` | Sets the value for the passed key in the Map object. Returns the Map object. |
| `ForEach(ActionCallback<TValue, TKey, Map<TKey, TValue>> callbackFn)` | `void` | Calls callbackFn once for each key-value pair present in the Map object, in insertion order. If a thisArg parameter is provided to forEach, it will be used as the this value for each callback. |
| `Get(TKey key)` | `TValue?` | Returns the value associated to the passed key, or undefined if there is none. |
| `Has(TKey key)` | `bool` | Returns a boolean indicating whether a value has been associated with the passed key in the Map object or not. |
| `Keys()` | `Iterator<TKey>` | Returns a new Iterator object that contains the keys for each element in the Map object in insertion order. |
| `Values()` | `Iterator<TValue>` | Returns a new Iterator object that contains the values for each element in the Map object in insertion order. |
| `Clear()` | `void` | Removes all key-value pairs from the Map object. |

