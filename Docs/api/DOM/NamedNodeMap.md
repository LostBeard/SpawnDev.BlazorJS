# NamedNodeMap

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DOM/NamedNodeMap.cs`  

> The NamedNodeMap interface represents a collection of Attr objects. Objects inside a NamedNodeMap are not in any particular order, unlike NodeList, although they may be accessed by an index as in an array. A NamedNodeMap object is live and will thus be auto-updated if changes are made to its contents internally or elsewhere. https://developer.mozilla.org/en-US/docs/Web/API/NamedNodeMap

## Constructors

| Signature | Description |
|---|---|
| `NamedNodeMap(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | Returns the amount of objects in the map. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetNamedItem(string name)` | `Attr?` | The getNamedItem() method of the NamedNodeMap interface returns the Attr corresponding to the given name, or null if there is no corresponding attribute. |
| `SetNamedItem(Attr attr)` | `Attr?` | The setNamedItem() method of the NamedNodeMap interface puts the Attr identified by its name in the map. If there is already an Attr with the same name in the map, it is replaced. |
| `RemoveNamedItem(string name)` | `Attr?` | The removeNamedItem() method of the NamedNodeMap interface removes the Attr corresponding to the given name from the map. |
| `Item(int index)` | `Attr?` | The item() method of the NamedNodeMap interface returns the item in the map matching the index. |
| `GetNamedItemNS(string nameSpace, string localName)` | `Attr?` | The getNamedItemNS() method of the NamedNodeMap interface returns the Attr corresponding to the given local name in the given namespace, or null if there is no corresponding attribute. |
| `SetNamedItemNS(Attr attr)` | `Attr?` | The setNamedItemNS() method of the NamedNodeMap interface puts the Attr identified by its name in the map. If there was already an Attr with the same name in the map, it is replaced. |
| `RemoveNamedItemNS(string nameSpace, string localName)` | `Attr?` | The removeNamedItemNS() method of the NamedNodeMap interface removes the Attr corresponding to the given namespace and local name from the map. |
| `ToList()` | `List<Attr>` | Returns the list as a list |
| `ToArray()` | `Attr[]` | Returns the list as a list |
