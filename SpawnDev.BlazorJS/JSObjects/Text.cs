using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Text interface represents a text node in a DOM tree.
    /// </summary>
    public class Text : CharacterData
    {
        #region Constructors
        public Text() : base(JS.New(nameof(Text))) { }
        public Text(string text) : base(JS.New(nameof(Text), text)) { }
        public Text(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        public HTMLSlotElement? AssignedSlot => JSRef.Get<HTMLSlotElement?>("assignedSlot");
        public string WholeText => JSRef.Get<string>("wholeText");
        #endregion

        #region Methods
        /// <summary>
        /// The splitText() method of the Text interface breaks the Text node into two nodes at the specified offset, keeping both nodes in the tree as siblings.
        /// </summary>
        /// <param name="offset">The index immediately before which to break the text node.</param>
        /// <returns>Returns the newly created Text node that contains the text after the specified offset point.</returns>
        public Text SplitText(int offset) => JSRef.Call<Text>("splitText", offset);
        #endregion
    }
}
