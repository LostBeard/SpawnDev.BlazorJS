# Text

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `CharacterData`  
**Source:** `JSObjects/DOM/Text.cs`  
**MDN Reference:** [Text on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Text)

> The Text interface represents a text node in a DOM tree. https://developer.mozilla.org/en-US/docs/Web/API/Text

## Constructors

| Signature | Description |
|---|---|
| `Text()` | The Text() constructor returns a new Text object with the optional string given in parameter as its textual content. |
| `Text(string text)` | The Text() constructor returns a new Text object with the optional string given in parameter as its textual content. |
| `Text(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AssignedSlot` | `HTMLSlotElement?` | get | Returns a HTMLSlotElement representing the &lt;slot&gt; the node is inserted in. |
| `WholeText` | `string` | get | Returns a string containing the text of all Text nodes logically adjacent to this Node, concatenated in document order. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `SplitText(int offset)` | `Text` | The splitText() method of the Text interface breaks the Text node into two nodes at the specified offset, keeping both nodes in the tree as siblings. The index immediately before which to break the text node. Returns the newly created Text node that contains the text after the specified offset point. |

