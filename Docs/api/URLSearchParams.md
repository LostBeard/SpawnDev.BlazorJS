# URLSearchParams

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/URLSearchParams.cs`  

> The URLSearchParams interface defines utility methods to work with the query string of a URL.

## Constructors

| Signature | Description |
|---|---|
| `URLSearchParams(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `URLSearchParams()` | Returns a URLSearchParams object instance |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Size` | `int` | get | Indicates the total number of search parameter entries. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Append(string name, string value)` | `void` | Appends a specified key/value pair as a new search parameter. |
| `Delete(string name)` | `void` | Deletes search parameters that match a name, and optional value, from the list of all search parameters |
| `Delete(string name, string value)` | `void` | Deletes search parameters that match a name, and optional value, from the list of all search parameters |
| `Entries()` | `Iterator<string[]>` | Returns an iterator allowing iteration through all key/value pairs contained in this object in the same order as they appear in the query string. |
| `ForEach(Action<string, string, URLSearchParams> callback)` | `void` | Allows iteration through all values contained in this object via a callback function. |
| `ForEach(Action<string, string, URLSearchParams> callback, object thisArg)` | `void` | Allows iteration through all values contained in this object via a callback function. |
| `Get(string name)` | `string?` | Returns the first value associated with the given search parameter. |
| `GetAll(string name)` | `List<string>` | Returns all the values associated with a given search parameter. |
| `Has(string name)` | `bool` | Returns a boolean value indicating if a given parameter, or parameter and value pair, exists. |
| `Has(string name, string value)` | `bool` | Returns a boolean value indicating if a given parameter, or parameter and value pair, exists. |
| `Keys()` | `Iterator<string>` | Returns an iterator allowing iteration through all keys of the key/value pairs contained in this object |
| `Set(string name, string value)` | `void` | Sets the value associated with a given search parameter to the given value. If there are several values, the others are deleted. |
| `Sort()` | `void` | Sorts all key/value pairs, if any, by their keys. |
| `ToString()` | `string` | Returns a string containing a query string suitable for use in a URL. |
| `Values()` | `Iterator<string>` | Returns an iterator allowing iteration through all values of the key/value pairs contained in this object. |

