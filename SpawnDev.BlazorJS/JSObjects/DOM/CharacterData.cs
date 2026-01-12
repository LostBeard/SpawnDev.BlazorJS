using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CharacterData abstract interface represents a Node object that contains characters. 
    /// This is an abstract interface, meaning there aren't any objects of type CharacterData: 
    /// it is implemented by other interfaces like Text, Comment, CDATASection, or ProcessingInstruction, which aren't abstract.
    /// https://developer.mozilla.org/en-US/docs/Web/API/CharacterData
    /// </summary>
    public class CharacterData : Node
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref">JavaScript object reference</param>
        public CharacterData(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// A string representing the textual data contained in this object.
        /// </summary>
        public string Data
        {
            get => JSRef!.Get<string>("data");
            set => JSRef!.Set("data", value);
        }

        /// <summary>
        /// Returns a number representing the size of the string contained in the object.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");

        /// <summary>
        /// Returns the next sibling node of the CharacterData object which is a Node of type Element, or null if there isn't one.
        /// </summary>
        public Element? NextElementSibling => JSRef!.Get<Element?>("nextElementSibling");

        /// <summary>
        /// Returns the previous sibling node of the CharacterData object which is a Node of type Element, or null if there isn't one.
        /// </summary>
        public Element? PreviousElementSibling => JSRef!.Get<Element?>("previousElementSibling");
        #endregion

        #region Methods
        /// <summary>
        /// Adds the provided data to the end of the node's current data.
        /// </summary>
        /// <param name="data">The string to append to the node's data</param>
        public void AppendData(string data) => JSRef!.CallVoid("appendData", data);

        /// <summary>
        /// Removes a number of characters from the node's data, starting at the specified offset.
        /// </summary>
        /// <param name="offset">The index of the first character to remove</param>
        /// <param name="count">The number of characters to remove</param>
        public void DeleteData(int offset, int count) => JSRef!.CallVoid("deleteData", offset, count);

        /// <summary>
        /// Inserts the specified characters at the specified position in the node's data.
        /// </summary>
        /// <param name="offset">The index at which to insert</param>
        /// <param name="data">The string to insert</param>
        public void InsertData(int offset, string data) => JSRef!.CallVoid("insertData", offset, data);

        /// <summary>
        /// Replaces the specified amount of characters starting at the specified offset with the specified string.
        /// </summary>
        /// <param name="offset">The index of the first character to replace</param>
        /// <param name="count">The number of characters to replace</param>
        /// <param name="data">The string with which the specified range of characters is to be replaced</param>
        public void ReplaceData(int offset, int count, string data) => JSRef!.CallVoid("replaceData", offset, count, data);

        /// <summary>
        /// Returns a string containing the part of CharacterData.data of the specified length and starting at the specified offset.
        /// </summary>
        /// <param name="offset">The index of the first character to include</param>
        /// <param name="count">The number of characters to return</param>
        /// <returns>A string containing the specified part of the node's data</returns>
        public string SubstringData(int offset, int count) => JSRef!.Call<string>("substringData", offset, count);
        #endregion
    }
}