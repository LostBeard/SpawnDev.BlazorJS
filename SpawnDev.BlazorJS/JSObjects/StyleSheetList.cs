using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The StyleSheetList interface represents a list of CSSStyleSheet objects. An instance of this object can be returned by Document.styleSheets.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/StyleSheetList
    /// </summary>
    public class StyleSheetList : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public StyleSheetList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an item in the list by its index, or null if the index is out-of-bounds.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CSSStyleSheet Item(int index) => JSRef!.Call<CSSStyleSheet>("item", index);
        /// <summary>
        /// The number of nodes in the StyleSheetList.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// Returns the array item at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>CSSStyleSheet</returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public CSSStyleSheet this[int index]
        {
            get => JSRef!.Get<CSSStyleSheet>(index);
        }
        /// <summary>
        /// Returns as a list
        /// </summary>
        /// <returns></returns>
        public List<CSSStyleSheet> ToList()
        {
            var ret = new List<CSSStyleSheet>();
            for (int i = 0; i < Length; i++)
            {
                ret.Add(Item(i));
            }
            return ret;
        }
        /// <summary>
        /// Returns as an array
        /// </summary>
        /// <returns></returns>
        public CSSStyleSheet[] ToArray() => ToList().ToArray();
    }
}
