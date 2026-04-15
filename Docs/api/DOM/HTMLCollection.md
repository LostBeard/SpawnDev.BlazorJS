# HTMLCollection

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DOM/HTMLCollection.cs`  
**MDN Reference:** [HTMLCollection on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLCollection)

> The HTMLCollection interface represents a generic collection (array-like object similar to arguments) of elements (in document order) and offers methods and properties for selecting from the list. https://developer.mozilla.org/en-US/docs/Web/API/HTMLCollection

## Constructors

| Signature | Description |
|---|---|
| `HTMLCollection(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | Returns the number of items in the collection. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Item(int index)` | `T?` | The position of the Element to be returned. Elements appear in an HTMLCollection in the same order in which they appear in the document's source. The Element at the specified index, or null if index is less than zero or greater than or equal to the length property. |
| `NamedItem(string index)` | `Element?` | Returns the specific node whose ID or, as a fallback, name matches the string specified by name. Matching by name is only done as a last resort, only in HTML, and only if the referenced element supports the name attribute. Returns null if no node exists by the given name. |
| `ToList()` | `List<Element>` | Returns the list as a list |
| `ToArray()` | `Element[]` | Returns the list as a list |

