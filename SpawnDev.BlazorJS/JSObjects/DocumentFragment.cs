using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DocumentFragment interface represents a minimal document object that has no parent.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/DocumentFragment
    /// </summary>
    public class DocumentFragment : Node
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DocumentFragment(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The DocumentFragment() constructor returns a new, empty DocumentFragment object.
        /// </summary>
        public DocumentFragment() : base(JS.New(nameof(DocumentFragment))) { }

        #region Properties
        /// <summary>
        /// Returns the amount of child elements the DocumentFragment has.
        /// </summary>
        public int ChildElementCount => JSRef!.Get<int>("childElementCount");
        #endregion

        #region Methods
        /// <summary>
        /// Inserts a set of Node objects or string objects after the last child of the document fragment.
        /// </summary>
        /// <param name="nodes"></param>
        public void Append(params Union<string, Node>[] nodes) => JSRef!.CallApplyVoid("append", nodes);
        /// <summary>
        /// Inserts a set of Node objects or string objects before the first child of the document fragment.
        /// </summary>
        /// <param name="nodes"></param>
        public void Prepend(params Union<string, Node>[] nodes) => JSRef!.CallApplyVoid("prepend", nodes);
        /// <summary>
        /// Replaces the existing children of a DocumentFragment with a specified new set of children.
        /// </summary>
        /// <param name="nodes"></param>
        public void ReplaceChildren(params Union<string, Node>[] nodes) => JSRef!.CallApplyVoid("replaceChildren", nodes);
        /// <summary>
        /// Returns a NodeList of all the Element nodes within the DocumentFragment that match the specified selectors.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public NodeList QuerySelectorAll(string selector) => JSRef!.Call<NodeList>("querySelectorAll", selector);
        /// <summary>
        /// Returns the first Element node within the DocumentFragment, in document order, that matches the specified selectors.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public Element? QuerySelector(string selector) => JSRef!.Call<Element?>("querySelector", selector);
        /// <summary>
        /// Returns the first Element node within the DocumentFragment, in document order, that matches the specified selectors.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public TElement? QuerySelector<TElement>(string selector) where TElement : Element => JSRef!.Call<TElement?>("querySelector", selector);
        /// <summary>
        /// Returns the first Element node within the DocumentFragment, in document order, that matches the specified ID. Functionally equivalent to Document.getElementById().
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Element? GetElementById(string id) => JSRef!.Call<Element?>("getElementById", id);
        /// <summary>
        /// Returns the first Element node within the DocumentFragment, in document order, that matches the specified ID. Functionally equivalent to Document.getElementById().
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public TElement? GetElementById<TElement>(string id) where TElement : Element => JSRef!.Call<TElement?>("getElementById", id);
        #endregion
    }
}
