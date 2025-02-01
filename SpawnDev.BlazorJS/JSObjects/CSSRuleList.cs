using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A CSSRuleList represents an ordered collection of read-only CSSRule objects.<br/>
    /// While the CSSRuleList object is read-only, and cannot be directly modified, it is considered a live object, as the content can change over time.<br/>
    /// To edit the underlying rules returned by CSSRule objects, use CSSStyleSheet.insertRule() and CSSStyleSheet.deleteRule(), which are methods of CSSStyleSheet.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CSSRuleList
    /// </summary>
    public class CSSRuleList : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CSSRuleList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Gets a single CSSRule.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CSSRule? Item(int index) => JSRef!.Call<CSSRule?>("item", index);
        /// <summary>
        /// Returns an integer representing the number of CSSRule objects in the collection.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// Returns the array item at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>CSSStyleSheet</returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public CSSRule? this[int index]
        {
            get => JSRef!.Get<CSSRule?>(index);
        }
        /// <summary>
        /// Returns as a list
        /// </summary>
        /// <returns></returns>
        public List<CSSRule> ToList()
        {
            var ret = new List<CSSRule>();
            for (int i = 0; i < Length; i++)
            {
                ret.Add(Item(i)!);
            }
            return ret;
        }
        /// <summary>
        /// Returns as an array
        /// </summary>
        /// <returns></returns>
        public CSSRule[] ToArray() => ToList().ToArray();
    }

}
