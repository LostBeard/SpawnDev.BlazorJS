using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOM Node interface is an abstract base class upon which many other DOM API objects are based, thus letting those object types to be used similarly and often interchangeably. As an abstract class, there is no such thing as a plain Node object. All objects that implement Node functionality are based on one of its subclasses. Most notable are Document, Element, and DocumentFragment.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Node
    /// </summary>
    public class Node : EventTarget
    {
        
        #region NodeType
        /// <summary>
        /// An Element node like p or div.
        /// </summary>
        public const ushort ELEMENT_NODE = 1;
        /// <summary>
        /// An Attribute of an Element.
        /// </summary>
        public const ushort ATTRIBUTE_NODE = 2;
        /// <summary>
        /// The actual Text inside an Element or Attr.
        /// </summary>
        public const ushort TEXT_NODE = 3;
        /// <summary>
        /// A CDATASection
        /// </summary>
        public const ushort CDATA_SECTION_NODE = 4;
        /// <summary>
        /// A ProcessingInstruction of an XML document
        /// </summary>
        public const ushort PROCESSING_INSTRUCTION_NODE = 7;
        /// <summary>
        /// A Comment node
        /// </summary>
        public const ushort COMMENT_NODE = 8;
        /// <summary>
        /// A Document node.
        /// </summary>
        public const ushort DOCUMENT_NODE = 9;
        /// <summary>
        /// A DocumentType node
        /// </summary>
        public const ushort DOCUMENT_TYPE_NODE = 10;
        /// <summary>
        /// A DocumentFragment node.
        /// </summary>
        public const ushort DOCUMENT_FRAGMENT_NODE = 11;
        #endregion

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Node(IJSInProcessObjectReference _ref) : base(_ref) { }

        #region Properties
        /// <summary>
        /// Returns a string representing the base URL of the document containing the Node.
        /// </summary>
        public string BaseURI => JSRef!.Get<string>("baseURI");
        /// <summary>
        /// Returns a live NodeList containing all the children of this node (including elements, text and comments). NodeList being live means that if the children of the Node change, the NodeList object is automatically updated.
        /// </summary>
        public NodeList ChildNodes => JSRef!.Get<NodeList>("childNodes");
        /// <summary>
        /// Returns a Node representing the first direct child node of the node, or null if the node has no child.
        /// </summary>
        public Node? FirstChild => JSRef!.Get<Node?>("firstChild");
        /// <summary>
        /// Returns a Node representing the first direct child node of the node, or null if the node has no child.
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <returns></returns>
        public TNode? FirstChildAs<TNode>() where TNode : Node => JSRef!.Get<TNode?>("firstChild");
        /// <summary>
        /// A boolean indicating whether or not the Node is connected (directly or indirectly) to the context object, e.g. the Document object in the case of the normal DOM, or the ShadowRoot in the case of a shadow DOM.
        /// </summary>
        public bool IsConnected => JSRef!.Get<bool>("isConnected");
        /// <summary>
        /// Returns a Node representing the last direct child node of the node, or null if the node has no child.
        /// </summary>
        public Node? LastChild => JSRef!.Get<Node?>("lastChild");
        /// <summary>
        /// Returns a Node representing the last direct child node of the node, or null if the node has no child.
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <returns></returns>
        public TNode? LastChildAs<TNode>() where TNode : Node => JSRef!.Get<TNode?>("lastChild");
        /// <summary>
        /// Returns a Node representing the next node in the tree, or null if there isn't such node.
        /// </summary>
        public Node? NextSibling => JSRef!.Get<Node?>("nextSibling");
        /// <summary>
        /// Returns a Node representing the next node in the tree, or null if there isn't such node.
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <returns></returns>
        public TNode? NextSiblingAs<TNode>() where TNode : Node => JSRef!.Get<TNode?>("nextSibling");
        /// <summary>
        /// Returns a string containing the name of the Node. The structure of the name will differ with the node type. E.g. An HTMLElement will contain the name of the corresponding tag, like 'audio' for an HTMLAudioElement, a Text node will have the '#text' string, or a Document node will have the '#document' string.
        /// </summary>
        public string NodeName => JSRef!.Get<string>("nodeName");
        /// <summary>
        /// Returns an unsigned short representing the type of the node. Possible values are:
        /// </summary>
        public ushort NodeType => JSRef!.Get<ushort>("nodeType");
        /// <summary>
        /// Returns the Document that this node belongs to. If the node is itself a document, returns null.
        /// </summary>
        public Document? OwnerDocument => JSRef!.Get<Document?>("ownerDocument");
        /// <summary>
        /// Returns a Node that is the parent of this node. If there is no such node, like if this node is the top of the tree or if doesn't participate in a tree, this property returns null.
        /// </summary>
        public Node? ParentNode => JSRef!.Get<Node?>("parentNode");
        /// <summary>
        /// Returns a Node that is the parent of this node. If there is no such node, like if this node is the top of the tree or if doesn't participate in a tree, this property returns null.
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <returns></returns>
        public TNode? ParentNodeAs<TNode>() where TNode : Node => JSRef!.Get<TNode?>("parentNode");
        /// <summary>
        /// Returns an Element that is the parent of this node. If the node has no parent, or if that parent is not an Element, this property returns null.
        /// </summary>
        public Element? ParentElement => JSRef!.Get<Element?>("parentElement");
        /// <summary>
        /// Returns an Element that is the parent of this node. If the node has no parent, or if that parent is not an Element, this property returns null.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public TElement? ParentElementAs<TElement>() where TElement : Element => JSRef!.Get<TElement?>("parentElement");
        /// <summary>
        /// Returns a Node representing the previous node in the tree, or null if there isn't such node.
        /// </summary>
        public Node? PreviousSibling => JSRef!.Get<Node?>("previousSibling");
        /// <summary>
        /// Returns a Node representing the previous node in the tree, or null if there isn't such node.
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <returns></returns>
        public TNode? PreviousSiblingAs<TNode>() where TNode : Node => JSRef!.Get<TNode?>("previousSibling");
        /// <summary>
        /// Returns / Sets the textual content of an element and all its descendants.
        /// </summary>
        public string TextContent { get => JSRef!.Get<string>("textContent"); set => JSRef!.Set("textContent", value); }
        #endregion

        #region Methods
        /// <summary>
        /// The appendChild() method of the Node interface adds a node to the end of the list of children of a specified parent node.<br/>
        /// If the given child is a DocumentFragment, the entire contents of the DocumentFragment are moved into the child list of the specified parent node.<br/>
        /// Note: If the given child is a reference to an existing node in the document, appendChild() moves it from its current position to the new position.
        /// Note: Unlike this method, the Element.append() method supports multiple arguments and appending strings. You can prefer using it if your node is an element.
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <param name="node"></param>
        /// <returns>appendChild() returns the newly appended node, or if the child is a DocumentFragment, the emptied fragment.</returns>
        public TNode AppendChild<TNode>(TNode node) where TNode : Node => JSRef!.Call<TNode>("appendChild", node);
        /// <summary>
        /// The cloneNode() method of the Node interface returns a duplicate of the node on which this method was called. Its parameter controls if the subtree contained in a node is also cloned or not.<br/>
        /// </summary>
        /// <returns></returns>
        public Node CloneNode() => JSRef!.Call<Node>("cloneNode");
        /// <summary>
        /// The cloneNode() method of the Node interface returns a duplicate of the node on which this method was called. 
        /// </summary>
        /// <param name="deep"></param>
        /// <returns></returns>
        public Node CloneNode(bool deep) => JSRef!.Call<Node>("cloneNode", deep);
        /// <summary>
        /// The cloneNode() method of the Node interface returns a duplicate of the node on which this method was called.
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <returns></returns>
        public TNode CloneNode<TNode>() where TNode : Node => JSRef!.Call<TNode>("cloneNode");
        /// <summary>
        /// The cloneNode() method of the Node interface returns a duplicate of the node on which this method was called. Its parameter controls if the subtree contained in a node is also cloned or not.<br/>
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <param name="deep"></param>
        /// <returns></returns>
        public TNode CloneNode<TNode>(bool deep) where TNode : Node => JSRef!.Call<TNode>("cloneNode", deep);
        /// <summary>
        /// Returns true or false value indicating whether or not a node is a descendant of the calling node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Contains(Node node) => JSRef!.Call<bool>("contains", node);
        /// <summary>
        /// The getRootNode() method of the Node interface returns the context object's root, which optionally includes the shadow root if it is available.
        /// </summary>
        /// <returns></returns>
        public Node GetRootNode() => JSRef!.Call<Node>("getRootNode");
        /// <summary>
        /// The getRootNode() method of the Node interface returns the context object's root, which optionally includes the shadow root if it is available.
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <returns></returns>
        public TNode GetRootNode<TNode>() where TNode : Node => JSRef!.Call<TNode>("getRootNode");
        /// <summary>
        /// The getRootNode() method of the Node interface returns the context object's root, which optionally includes the shadow root if it is available.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Node GetRootNode(GetRootNodeOptions options) => JSRef!.Call<Node>("getRootNode", options);
        /// <summary>
        /// The getRootNode() method of the Node interface returns the context object's root, which optionally includes the shadow root if it is available.
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <param name="options"></param>
        /// <returns></returns>
        public TNode GetRootNode<TNode>(GetRootNodeOptions options) where TNode : Node => JSRef!.Call<TNode>("getRootNode", options);
        /// <summary>
        /// Returns a boolean value indicating whether or not the element has any child nodes.
        /// </summary>
        /// <returns></returns>
        public bool HasChildNodes() => JSRef!.Call<bool>("hasChildNodes");
        /// <summary>
        /// The insertBefore() method of the Node interface inserts a node before a reference node as a child of a specified parent node.
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <param name="newNode"></param>
        /// <param name="referenceNode"></param>
        /// <returns></returns>
        public TNode InsertBefore<TNode>(TNode newNode, Node? referenceNode) where TNode : Node => JSRef!.Call<TNode>("insertBefore", newNode, referenceNode);
        /// <summary>
        /// The isSameNode() method of the Node interface is a legacy alias the for the === strict equality operator. That is, it tests whether two nodes are the same (in other words, whether they reference the same object).
        /// </summary>
        /// <param name="otherNode"></param>
        /// <returns></returns>
        public bool IsSameNode(Node otherNode) => JSRef!.Call<bool>("isSameNode", otherNode);
        /// <summary>
        /// The normalize() method of the Node interface puts the specified node and all of its sub-tree into a normalized form. In a normalized sub-tree, no text nodes in the sub-tree are empty and there are no adjacent text nodes.
        /// </summary>
        public void Normalize() => JSRef!.CallVoid("normalize");
        /// <summary>
        /// The removeChild() method of the Node interface removes a child node from the DOM and returns the removed node.
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <param name="child"></param>
        /// <returns></returns>
        public TNode RemoveChild<TNode>(TNode child) where TNode : Node => JSRef!.Call<TNode>("removeChild", child);
        /// <summary>
        /// The replaceChild() method of the Node interface replaces a child node within the given (parent) node.<br/>
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <param name="newChild">The new node to replace oldChild.</param>
        /// <param name="oldChild">The child to be replaced.</param>
        /// <returns>The replaced Node. This is the same node as oldChild.</returns>
        public TNode ReplaceChild<TNode>(Node newChild, TNode oldChild) where TNode : Node => JSRef!.Call<TNode>("replaceChild", newChild, oldChild);
        #endregion

        /// <summary>
        /// The selectstart event of the Selection API is fired when a user starts a new selection.
        /// </summary>
        public JSEventCallback<Event> OnSelectStart { get => new JSEventCallback<Event>("selectstart", AddEventListener, RemoveEventListener); set { } }
    }
}
