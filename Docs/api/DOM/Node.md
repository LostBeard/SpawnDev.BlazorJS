# Node

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/DOM/Node.cs`  
**MDN Reference:** [Node on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Node)

> The DOM Node interface is an abstract base class upon which many other DOM API objects are based, thus letting those object types to be used similarly and often interchangeably. As an abstract class, there is no such thing as a plain Node object. All objects that implement Node functionality are based on one of its subclasses. Most notable are Document, Element, and DocumentFragment. https://developer.mozilla.org/en-US/docs/Web/API/Node

## Constructors

| Signature | Description |
|---|---|
| `Node(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BaseURI` | `string` | get | Returns a string representing the base URL of the document containing the Node. |
| `ChildNodes` | `NodeList` | get | Returns a live NodeList containing all the children of this node (including elements, text and comments). NodeList being live means that if the children of the Node change, the NodeList object is automatically updated. |
| `FirstChild` | `Node?` | get | Returns a Node representing the first direct child node of the node, or null if the node has no child. |
| `IsConnected` | `bool` | get | A boolean indicating whether or not the Node is connected (directly or indirectly) to the context object, e.g. the Document object in the case of the normal DOM, or the ShadowRoot in the case of a shadow DOM. |
| `LastChild` | `Node?` | get | Returns a Node representing the last direct child node of the node, or null if the node has no child. |
| `NextSibling` | `Node?` | get | Returns a Node representing the next node in the tree, or null if there isn't such node. |
| `NodeName` | `string` | get | Returns a string containing the name of the Node. The structure of the name will differ with the node type. E.g. An HTMLElement will contain the name of the corresponding tag, like 'audio' for an HTMLAudioElement, a Text node will have the '#text' string, or a Document node will have the '#document' string. |
| `NodeType` | `ushort` | get | Returns an unsigned short representing the type of the node. Possible values are: |
| `OwnerDocument` | `Document?` | get | Returns the Document that this node belongs to. If the node is itself a document, returns null. |
| `ParentNode` | `Node?` | get | Returns a Node that is the parent of this node. If there is no such node, like if this node is the top of the tree or if doesn't participate in a tree, this property returns null. |
| `ParentElement` | `Element?` | get | Returns an Element that is the parent of this node. If the node has no parent, or if that parent is not an Element, this property returns null. |
| `PreviousSibling` | `Node?` | get | Returns a Node representing the previous node in the tree, or null if there isn't such node. |
| `TextContent` | `string` | get | Returns / Sets the textual content of an element and all its descendants. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `FirstChildAs()` | `TNode?` | Returns a Node representing the first direct child node of the node, or null if the node has no child. |
| `LastChildAs()` | `TNode?` | Returns a Node representing the last direct child node of the node, or null if the node has no child. |
| `NextSiblingAs()` | `TNode?` | Returns a Node representing the next node in the tree, or null if there isn't such node. |
| `ParentNodeAs()` | `TNode?` | Returns a Node that is the parent of this node. If there is no such node, like if this node is the top of the tree or if doesn't participate in a tree, this property returns null. |
| `ParentElementAs()` | `TElement?` | Returns an Element that is the parent of this node. If the node has no parent, or if that parent is not an Element, this property returns null. |
| `PreviousSiblingAs()` | `TNode?` | Returns a Node representing the previous node in the tree, or null if there isn't such node. |
| `AppendChild(TNode node)` | `TNode` | The appendChild() method of the Node interface adds a node to the end of the list of children of a specified parent node. If the given child is a DocumentFragment, the entire contents of the DocumentFragment are moved into the child list of the specified parent node. Note: If the given child is a reference to an existing node in the document, appendChild() moves it from its current position to the new position. Note: Unlike this method, the Element.append() method supports multiple arguments and appending strings. You can prefer using it if your node is an element. appendChild() returns the newly appended node, or if the child is a DocumentFragment, the emptied fragment. |
| `CloneNode()` | `Node` | The cloneNode() method of the Node interface returns a duplicate of the node on which this method was called. Its parameter controls if the subtree contained in a node is also cloned or not. |
| `CloneNode(bool deep)` | `Node` | The cloneNode() method of the Node interface returns a duplicate of the node on which this method was called. |
| `Contains(Node node)` | `bool` | Returns true or false value indicating whether or not a node is a descendant of the calling node. |
| `GetRootNode()` | `Node` | The getRootNode() method of the Node interface returns the context object's root, which optionally includes the shadow root if it is available. |
| `GetRootNode(GetRootNodeOptions options)` | `Node` | The getRootNode() method of the Node interface returns the context object's root, which optionally includes the shadow root if it is available. |
| `HasChildNodes()` | `bool` | Returns a boolean value indicating whether or not the element has any child nodes. |
| `InsertBefore(TNode newNode, Node? referenceNode)` | `TNode` | The insertBefore() method of the Node interface inserts a node before a reference node as a child of a specified parent node. |
| `IsSameNode(Node otherNode)` | `bool` | The isSameNode() method of the Node interface is a legacy alias the for the === strict equality operator. That is, it tests whether two nodes are the same (in other words, whether they reference the same object). |
| `Normalize()` | `void` | The normalize() method of the Node interface puts the specified node and all of its sub-tree into a normalized form. In a normalized sub-tree, no text nodes in the sub-tree are empty and there are no adjacent text nodes. |
| `RemoveChild(TNode child)` | `TNode` | The removeChild() method of the Node interface removes a child node from the DOM and returns the removed node. |
| `ReplaceChild(Node newChild, TNode oldChild)` | `TNode` | The replaceChild() method of the Node interface replaces a child node within the given (parent) node. The new node to replace oldChild. The child to be replaced. The replaced Node. This is the same node as oldChild. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnSelectStart` | `ActionEvent<Event>` | The selectstart event of the Selection API is fired when a user starts a new selection. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<Node>(...)` or constructor `new Node(...)`

### Remove all children nested within a node

```js
function removeAllChildren(element) {
  while (element.firstChild) {
    element.removeChild(element.firstChild);
  }
}
```

### Remove all children nested within a node

```js
removeAllChildren(document.body);
```

### Recurse through child nodes

```js
function eachNode(rootNode, callback) {
  if (!callback) {
    const nodes = [];
    eachNode(rootNode, (node) => {
      nodes.push(node);
    });
    return nodes;
  }

  if (callback(rootNode) === false) {
    return false;
  }

  if (rootNode.hasChildNodes()) {
    for (const node of rootNode.childNodes) {
      if (eachNode(node, callback) === false) {
        return;
      }
    }
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Node)*

