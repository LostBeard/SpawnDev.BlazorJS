# Node

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> EventTarget -> Node  
**MDN Reference:** [Node on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Node)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/Node.cs`

> Node is the abstract base class for all DOM nodes. Document, Element, Text, Comment, and DocumentFragment all inherit from Node. It provides tree traversal properties and child manipulation methods.

## Constructor

```csharp
public Node(IJSInProcessObjectReference _ref)
```

## Node Type Constants

| Constant | Value | Description |
|---|---|---|
| `ELEMENT_NODE` | 1 | An Element node (div, p, span, etc.). |
| `ATTRIBUTE_NODE` | 2 | An Attribute of an Element. |
| `TEXT_NODE` | 3 | Text inside an Element or Attr. |
| `CDATA_SECTION_NODE` | 4 | A CDATASection. |
| `PROCESSING_INSTRUCTION_NODE` | 7 | A ProcessingInstruction of an XML document. |
| `COMMENT_NODE` | 8 | A Comment node. |
| `DOCUMENT_NODE` | 9 | A Document node. |
| `DOCUMENT_TYPE_NODE` | 10 | A DocumentType node. |
| `DOCUMENT_FRAGMENT_NODE` | 11 | A DocumentFragment node. |

## Properties

| Property | Type | Description |
|---|---|---|
| `BaseURI` | `string` | The base URL of the document containing the Node. |
| `ChildNodes` | `NodeList` | Live NodeList of all child nodes. |
| `FirstChild` | `Node?` | The first direct child node, or null. |
| `IsConnected` | `bool` | Whether the Node is connected to the DOM tree. |
| `LastChild` | `Node?` | The last direct child node, or null. |
| `NextSibling` | `Node?` | The next node in the tree, or null. |
| `NodeName` | `string` | The name of the Node (tag name, "#text", "#document", etc.). |
| `NodeType` | `ushort` | The node type constant (see table above). |
| `OwnerDocument` | `Document?` | The Document this node belongs to. Null if the node is a Document. |
| `ParentNode` | `Node?` | The parent node, or null if top of tree. |
| `ParentElement` | `Element?` | The parent Element, or null if parent is not an Element. |
| `PreviousSibling` | `Node?` | The previous node in the tree, or null. |
| `TextContent` | `string` | Get/set the textual content of the node and all descendants. |

## Typed Property Accessors

| Method | Return Type | Description |
|---|---|---|
| `FirstChildAs<TNode>()` | `TNode?` | Get FirstChild as a specific Node subclass. |
| `LastChildAs<TNode>()` | `TNode?` | Get LastChild as a specific Node subclass. |
| `NextSiblingAs<TNode>()` | `TNode?` | Get NextSibling as a specific Node subclass. |
| `PreviousSiblingAs<TNode>()` | `TNode?` | Get PreviousSibling as a specific Node subclass. |
| `ParentNodeAs<TNode>()` | `TNode?` | Get ParentNode as a specific Node subclass. |
| `ParentElementAs<TElement>()` | `TElement?` | Get ParentElement as a specific Element subclass. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `AppendChild<TNode>(TNode node)` | `TNode` | Add a node to the end of the child list. Returns the appended node. |
| `RemoveChild<TNode>(TNode child)` | `TNode` | Remove a child node. Returns the removed node. |
| `ReplaceChild<TNode>(Node newChild, TNode oldChild)` | `TNode` | Replace a child. Returns the old child. |
| `InsertBefore<TNode>(TNode newNode, Node? referenceNode)` | `TNode` | Insert before a reference node. Returns the inserted node. |
| `CloneNode()` | `Node` | Shallow clone of the node. |
| `CloneNode(bool deep)` | `Node` | Clone with optional deep copy of subtree. |
| `CloneNode<TNode>()` | `TNode` | Typed shallow clone. |
| `CloneNode<TNode>(bool deep)` | `TNode` | Typed clone with optional deep copy. |
| `Contains(Node node)` | `bool` | Whether the node is a descendant. |
| `HasChildNodes()` | `bool` | Whether the node has any children. |
| `GetRootNode()` | `Node` | Get the root of the tree. |
| `GetRootNode<TNode>()` | `TNode` | Get the typed root. |
| `GetRootNode(GetRootNodeOptions options)` | `Node` | Get root, optionally including shadow root. |
| `IsSameNode(Node otherNode)` | `bool` | Whether two nodes reference the same object. |
| `Normalize()` | `void` | Merge adjacent text nodes and remove empty ones. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnSelectStart` | `ActionEvent<Event>` | Fired when a user starts a new selection. |

## Example

```csharp
using var doc = JS.Get<Document>("document");
using var list = doc.QuerySelector<Element>("ul#items");

// Create and append
using var li = doc.CreateElement<Element>("li");
li.TextContent = "New item";
list!.AppendChild(li);

// Traverse children
using var children = list.ChildNodes;
for (int i = 0; i < children.Length; i++)
{
    using var child = children[i];
    Console.WriteLine($"Node: {child.NodeName}, Type: {child.NodeType}");
}

// Clone
using var clone = list.CloneNode<Element>(deep: true);
doc.Body.AppendChild(clone);
```
