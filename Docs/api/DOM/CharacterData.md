# CharacterData

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Node`  
**Source:** `JSObjects/DOM/CharacterData.cs`  
**MDN Reference:** [CharacterData on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CharacterData)

> The CharacterData abstract interface represents a Node object that contains characters. This is an abstract interface, meaning there aren't any objects of type CharacterData: it is implemented by other interfaces like Text, Comment, CDATASection, or ProcessingInstruction, which aren't abstract. https://developer.mozilla.org/en-US/docs/Web/API/CharacterData

## Constructors

| Signature | Description |
|---|---|
| `CharacterData(IJSInProcessObjectReference _ref)` | Deserialization constructor JavaScript object reference |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Data` | `string` | get | A string representing the textual data contained in this object. |
| `Length` | `int` | get | Returns a number representing the size of the string contained in the object. |
| `NextElementSibling` | `Element?` | get | Returns the next sibling node of the CharacterData object which is a Node of type Element, or null if there isn't one. |
| `PreviousElementSibling` | `Element?` | get | Returns the previous sibling node of the CharacterData object which is a Node of type Element, or null if there isn't one. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `AppendData(string data)` | `void` | Adds the provided data to the end of the node's current data. The string to append to the node's data |
| `DeleteData(int offset, int count)` | `void` | Removes a number of characters from the node's data, starting at the specified offset. The index of the first character to remove The number of characters to remove |
| `InsertData(int offset, string data)` | `void` | Inserts the specified characters at the specified position in the node's data. The index at which to insert The string to insert |
| `ReplaceData(int offset, int count, string data)` | `void` | Replaces the specified amount of characters starting at the specified offset with the specified string. The index of the first character to replace The number of characters to replace The string with which the specified range of characters is to be replaced |
| `SubstringData(int offset, int count)` | `string` | Returns a string containing the part of CharacterData.data of the specified length and starting at the specified offset. The index of the first character to include The number of characters to return A string containing the specified part of the node's data |

