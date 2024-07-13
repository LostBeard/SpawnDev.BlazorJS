using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Text interface represents a text node in a DOM tree.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Text
    /// </summary>
    public class Text : CharacterData
    {
        #region Constructors
        /// <summary>
        /// The Text() constructor returns a new Text object with the optional string given in parameter as its textual content.
        /// </summary>
        public Text() : base(JS.New(nameof(Text))) { }
        /// <summary>
        /// The Text() constructor returns a new Text object with the optional string given in parameter as its textual content.
        /// </summary>
        /// <param name="text"></param>
        public Text(string text) : base(JS.New(nameof(Text), text)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Text(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns a HTMLSlotElement representing the <slot> the node is inserted in.
        /// </summary>
        public HTMLSlotElement? AssignedSlot => JSRef!.Get<HTMLSlotElement?>("assignedSlot");
        /// <summary>
        /// Returns a string containing the text of all Text nodes logically adjacent to this Node, concatenated in document order.
        /// </summary>
        public string WholeText => JSRef!.Get<string>("wholeText");
        #endregion

        #region Methods
        /// <summary>
        /// The splitText() method of the Text interface breaks the Text node into two nodes at the specified offset, keeping both nodes in the tree as siblings.
        /// </summary>
        /// <param name="offset">The index immediately before which to break the text node.</param>
        /// <returns>Returns the newly created Text node that contains the text after the specified offset point.</returns>
        public Text SplitText(int offset) => JSRef!.Call<Text>("splitText", offset);
        #endregion
    }
}
