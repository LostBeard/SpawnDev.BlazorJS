# VTTRegionList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`, `IEnumerable<VTTRegion>`  
**Source:** `JSObjects/VTTRegionList.cs`  
**MDN Reference:** [VTTRegionList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VTTRegionList)

> The VTTRegionList interface represents a list of VTTRegion objects. https://developer.mozilla.org/en-US/docs/Web/API/VTTRegionList

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | Returns the number of regions in the list. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetEnumerator()` | `IEnumerator<VTTRegion>` |  |
| `Item(int index)` | `VTTRegion` | Returns the VTTRegion object at the specified index. |
| `GetRegionById(string id)` | `VTTRegion?` | Returns the VTTRegion object with the specified ID. |

