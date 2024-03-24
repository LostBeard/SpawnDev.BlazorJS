using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CharacterData abstract interface represents a Node object that contains characters. This is an abstract interface, meaning there aren't any objects of type CharacterData: it is implemented by other interfaces like Text, Comment, CDATASection, or ProcessingInstruction, which aren't abstract.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/CharacterData
    /// </summary>
    public class CharacterData : Node
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CharacterData(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        public string Data => JSRef.Get<string>("data");
        public int Length => JSRef.Get<int>("length");
        public Element? NextElementSibling => JSRef.Get<Element?>("nextElementSibling");
        public Element? PreviousElementSibling => JSRef.Get<Element?>("previousElementSibling");
        #endregion

        #region Methods
        // TODO
        #endregion
    }
}
