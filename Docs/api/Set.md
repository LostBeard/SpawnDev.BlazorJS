# Set

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Set.cs`  
**MDN Reference:** [Set on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Set)

> https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Set

## Constructors

| Signature | Description |
|---|---|
| `Set()` | Creates a new instance |
| `Set(Array iterable)` | Creates a new instance |
| `Set()` | Creates a new instance |
| `Set(Array iterable)` | Creates a new instance |
| `Set(Array<TValue> iterable)` | Creates a new instance |
| `Set(IEnumerable<TValue> iterable)` | Creates a new instance |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Size` | `int` | get | The size accessor property of Set instances returns the number of (unique) elements in this set. |
| `ReadOnly` | `bool` | get/set | Returns true if the clear method is not found indicating this is a read-only Set. Read-only Set-like objects have the property size, and the methods: entries(), forEach(), has(), keys(), values(), and Symbol.iterator(). Writeable Set-like objects additionally have the methods: clear(), delete(), and add(). |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Clear()` | `void` | The clear() method of Set instances removes all elements from this set. |
| `Add(TValue value)` | `Set<TValue>` | The add() method of Set instances inserts a new element with a specified value in to this set, if there isn't an element with the same value already in this set |
| `Delete(TValue value)` | `bool` | The delete() method of Set instances removes a specified value from this set, if it is in the set. |
| `Entries()` | `Iterator<Array<TValue>>` | Returns a new iterator object that contains an array of [value, value] for each element in the Set object, in insertion order. This is similar to the Map object, so that each entry's key is the same as its value for a Set. |
| `ForEach(ActionCallback<TValue, TValue, Set<TValue>> callbackFn)` | `void` | Calls callbackFn once for each value present in the Set object, in insertion order. If a thisArg parameter is provided, it will be used as the this value for each invocation of callbackFn. |
| `ForEach(ActionCallback<TValue, TValue, Set<TValue>> callbackFn, JSObject thisArg)` | `void` | Calls callbackFn once for each value present in the Set object, in insertion order. If a thisArg parameter is provided, it will be used as the this value for each invocation of callbackFn. |
| `Has(TValue value)` | `bool` | Returns a boolean asserting whether an element is present with the given value in the Set object or not. |
| `Keys()` | `Iterator<TValue>` | An alias for Set.prototype.values(). |
| `Values()` | `Iterator<TValue>` | Returns a new iterator object that yields the values for each element in the Set object in insertion order. |
| `Difference(Set other)` | `Set<TValue>` | The difference() method of Set instances takes a set and returns a new set containing elements in this set but not in the given set. A new Set object containing elements in this set but not in the other set. |
| `Intersection(Set other)` | `Set<TValue>` | The intersection() method of Set instances takes a set and returns a new set containing elements in both this set and the given set. |
| `SymmetricDifference(Set other)` | `Set<TValue>` | The symmetricDifference() method of Set instances takes a set and returns a new set containing elements which are in either this set or the given set, but not in both. |
| `Union(Set other)` | `Set<TValue>` | The union() method of Set instances takes a set and returns a new set containing elements which are in either or both of this set and the given set. |
| `IsDisjointedFrom(Set other)` | `bool` | The isDisjointFrom() method of Set instances takes a set and returns a boolean indicating if this set has no elements in common with the given set. |
| `IsSubsetOf(Set other)` | `bool` | The isSubsetOf() method of Set instances takes a set and returns a boolean indicating if all elements of this set are in the given set. |
| `IsSupersetOf(Set other)` | `bool` | The isSupersetOf() method of Set instances takes a set and returns a boolean indicating if all elements of the given set are in this set. |

