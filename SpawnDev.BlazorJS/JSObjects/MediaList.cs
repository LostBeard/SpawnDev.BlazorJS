using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaList interface represents the media queries of a stylesheet, e.g. those set using a @media rule, or when using the media attribute in a link element or an HTMLStyleElement.<br/><br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaList
    /// </summary>
    public class MediaList: JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MediaList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A getter that returns a string representing a media query as text, given the media query's index value inside the MediaList. This method can also be called using the bracket ([]) syntax.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string? Item(int index) => JSRef!.Call<string?>("item", index);
        /// <summary>
        /// Adds a media query to the MediaList.
        /// </summary>
        /// <param name="medium">A string containing the media query to add.</param>
        public void AppendMedium(string medium) => JSRef!.CallVoid("appendMedium", medium);
        /// <summary>
        /// Removes a media query from the MediaList.
        /// </summary>
        /// <param name="medium">A string containing the media query to remove from the list.</param>
        public void DeleteMedium(string medium) => JSRef!.CallVoid("deleteMedium", medium);
        /// <summary>
        /// Returns the number of media queries in the MediaList.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// A stringifier that returns a string representing the MediaList as text, and also allows you to set a new MediaList.
        /// </summary>
        public string MediaText { get => JSRef!.Get<string>("mediaText"); set => JSRef!.Set("mediaText", value); }
        /// <summary>
        /// Returns the array item at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>CSSStyleSheet</returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public string? this[int index]
        {
            get => JSRef!.Get<string?>(index);
        }
        /// <summary>
        /// Returns a string representation of this media list in the same format as the object's MediaList.mediaText property.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => MediaText;
        /// <summary>
        /// Returns as a list
        /// </summary>
        /// <returns></returns>
        public List<string> ToList()
        {
            var ret = new List<string>();
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
        public string[] ToArray() => ToList().ToArray();
    }

}
