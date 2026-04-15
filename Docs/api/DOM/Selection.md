# Selection

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DOM/Selection.cs`  
**MDN Reference:** [Selection on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Selection)

> A Selection object represents the range of text selected by the user or the current position of the caret. To obtain a Selection object for examination or manipulation, call window.getSelection(). https://developer.mozilla.org/en-US/docs/Web/API/Selection TODO - finish

## Constructors

| Signature | Description |
|---|---|
| `Selection(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AnchorNode` | `Node` | get | Returns the Node in which the selection begins. Can return null if selection never existed in the document (e.g., an iframe that was never clicked on). |
| `AnchorOffset` | `int` | get | Returns a number representing the offset of the selection's anchor within the anchorNode. If anchorNode is a text node, this is the number of characters within anchorNode preceding the anchor. If anchorNode is an element, this is the number of child nodes of the anchorNode preceding the anchor. |
| `BaseNode` | `Node` | get | Returns the Node in which the selection begins. |
| `BaseOffset` | `int` | get | Returns a number representing the offset of the selection's anchor within the baseNode. |
| `ExtentNode` | `Node` | get | Returns the Node in which the selection ends. |
| `ExtentOffset` | `int` | get | Returns a number representing the offset of the selection's anchor within the extentNode. |
| `FocusNode` | `Node` | get | Returns the Node in which the selection ends. Can return null if selection never existed in the document (for example, in an iframe that was never clicked on). |
| `FocusOffset` | `int` | get | Returns a number representing the offset of the selection's anchor within the focusNode. If focusNode is a text node, this is the number of characters within focusNode preceding the focus. If focusNode is an element, this is the number of child nodes of the focusNode preceding the focus. |
| `IsCollapsed` | `bool` | get | Returns a Boolean indicating whether the selection's start and end points are at the same position. |
| `RangeCount` | `int` | get | Returns the number of ranges in the selection. |
| `Type` | `string` | get | Returns a string describing the type of the current selection. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `AddRange()` | `void` |  |
| `Collapse()` | `void` |  |
| `CollapseToEnd()` | `void` |  |
| `CollapseToStart()` | `void` |  |
| `ContainsNode()` | `void` |  |
| `DeleteFromDocument()` | `void` |  |
| `Empty()` | `void` |  |
| `Extend()` | `void` |  |
| `GetRangeAt()` | `void` |  |
| `Modify()` | `void` |  |
| `RemoveAllRanges()` | `void` |  |
| `RemoveRange()` | `void` |  |
| `SelectAllChildren()` | `void` |  |
| `SetBaseAndExtent()` | `void` |  |
| `SetPosition()` | `void` |  |
| `ToString()` | `string` | Returns a string representation of the selection. |

