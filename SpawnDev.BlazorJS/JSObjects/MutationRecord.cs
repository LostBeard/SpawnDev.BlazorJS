using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MutationRecord is a read-only interface that represents an individual DOM mutation observed by a MutationObserver. It is the object inside the array passed to the callback of a MutationObserver.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/MutationRecord
    /// </summary>
    public class MutationRecord : JSObject
    {
        #region Constructors
        public MutationRecord(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// The nodes added by a mutation. Will be an empty NodeList if no nodes were added.
        /// </summary>
        public NodeList AddedNodes => JSRef.Get<NodeList>("addNodes");
        /// <summary>
        /// The name of the changed attribute as a string, or null.
        /// </summary>
        public string? AttributeName => JSRef.Get<string?>("attributeName");
        /// <summary>
        /// The namespace of the changed attribute as a string, or null.
        /// </summary>
        public string? AttributeNamespace => JSRef.Get<string?>("attributeNamespace");
        /// <summary>
        /// The next sibling of the added or removed nodes, or null.
        /// </summary>
        public Node? NextSibling => JSRef.Get<Node?>("nextSibling");
        /// <summary>
        /// The value depends on the MutationRecord.type:<br />
        /// For attributes, it is the value of the changed attribute before the change.<br />
        /// For characterData, it is the data of the changed node before the change.<br />
        /// For childList, it is null.
        /// </summary>
        public string? OldValue => JSRef.Get<string?>("oldValue");
        /// <summary>
        /// The previous sibling of the added or removed nodes, or null.
        /// </summary>
        public Node? PreviousSibling => JSRef.Get<Node?>("previousSibling");
        /// <summary>
        /// The nodes removed by a mutation. Will be an empty NodeList if no nodes were removed.
        /// </summary>
        public NodeList RemovedNodes => JSRef.Get<NodeList>("removedNodes");
        /// <summary>
        /// The node the mutation affected, depending on the MutationRecord.type.<br />
        /// For attributes, it is the element whose attribute changed.<br />
        /// For characterData, it is the CharacterData node.<br />
        /// For childList, it is the node whose children changed.
        /// </summary>
        public Node Target => JSRef.Get<Node>("target");
        /// <summary>
        /// A string representing the type of mutation: attributes if the mutation was an attribute mutation, characterData if it was a mutation to a CharacterData node, and childList if it was a mutation to the tree of nodes.
        /// </summary>
        public string Type => JSRef.Get<string>("type");
        #endregion

        #region Methods
        /// <summary>
        /// Stops the MutationObserver instance from receiving further notifications until and unless observe() is called again.
        /// </summary>
        public void Disconnect() => JSRef.CallVoid("disconnect");
        /// <summary>
        /// Configures the MutationObserver to begin receiving notifications through its callback function when DOM changes matching the given options occur.
        /// </summary>
        /// <param name="target">A DOM Node (which may be an Element) within the DOM tree to watch for changes, or to be the root of a subtree of nodes to be watched.</param>
        /// <param name="options">An object providing options that describe which DOM mutations should be reported to mutationObserver's callback. At a minimum, one of childList, attributes, and/or characterData must be true when you call observe(). Otherwise, a TypeError exception will be thrown.</param>
        public void Observe(Node target, MutationObserveOptions options) => JSRef.CallVoid("observe", target, options);
        /// <summary>
        /// Removes all pending notifications from the MutationObserver's notification queue and returns them in a new Array of MutationRecord objects.
        /// </summary>
        /// <returns></returns>
        public MutationRecord[] TakeRecords() => JSRef.Call<MutationRecord[]>("takeRecords");
        #endregion
    }
}
