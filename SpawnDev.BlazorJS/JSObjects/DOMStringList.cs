using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOMStringList interface is a legacy type returned by some APIs and represents a non-modifiable list of strings (DOMString). Modern APIs use Array objects (in WebIDL: sequence DOMString) instead.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/DOMStringList
    /// </summary>
    public class DOMStringList : JSObject
    {
        /// <summary>
        /// Implicit conversion to string[]
        /// </summary>
        /// <param name="domStringList"></param>
        public static implicit operator string[]?(DOMStringList? domStringList) => domStringList?.ToArray();
        /// <summary>
        /// Implicit conversion to a string List 
        /// </summary>
        /// <param name="domStringList"></param>
        public static implicit operator List<string>?(DOMStringList? domStringList) => domStringList?.ToList();
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DOMStringList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the size of the list.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// Returns a string from the list with the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string Item(int index) => JSRef!.Call<string>("item", index);
        /// <summary>
        /// Returns a boolean indicating whether the given string is in the list.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(string value) => JSRef!.Call<bool>("contains", value);
        #region Enumerable like
        /// <summary>
        /// Indexer property
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public string this[int i] => Item(i);
        /// <summary>
        /// Returns first or default
        /// </summary>
        /// <returns></returns>
        public string? FirstOrDefault() => Length > 0 ? Item(0) : null;
        /// <summary>
        /// Returns last or default
        /// </summary>
        /// <returns></returns>
        public string? LastOrDefault() => Length > 0 ? Item(Length - 1) : null;
        /// <summary>
        /// Returns the string list as a .Net string array
        /// </summary>
        /// <returns></returns>
        public string[] ToArray() => Enumerable.Range(0, Length).Select(Item).ToArray();
        /// <summary>
        /// Returns the string list as a .Net string List
        /// </summary>
        /// <returns></returns>
        public List<string> ToList() => Enumerable.Range(0, Length).Select(Item).ToList();
        #endregion
    }
}
