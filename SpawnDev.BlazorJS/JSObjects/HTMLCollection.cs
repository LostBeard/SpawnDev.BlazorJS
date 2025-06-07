using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLCollection interface represents a generic collection (array-like object similar to arguments) of elements (in document order) and offers methods and properties for selecting from the list.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLCollection
    /// </summary>
    public class HTMLCollection : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLCollection(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the number of items in the collection.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">The position of the Element to be returned. Elements appear in an HTMLCollection in the same order in which they appear in the document's source.</param>
        /// <returns>The Element at the specified index, or null if index is less than zero or greater than or equal to the length property.</returns>
        public T? Item<T>(int index) where T : Element =>  JSRef!.Call<T?>("item", index);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">The position of the Element to be returned. Elements appear in an HTMLCollection in the same order in which they appear in the document's source.</param>
        /// <returns>The Element at the specified index, or null if index is less than zero or greater than or equal to the length property.</returns>
        public Element? Item(int index) => JSRef!.Call<Element?>("item", index);
        /// <summary>
        /// Returns the specific node whose ID or, as a fallback, name matches the string specified by name. Matching by name is only done as a last resort, only in HTML, and only if the referenced element supports the name attribute. Returns null if no node exists by the given name.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Element? NamedItem(string index) => JSRef!.Call<Element?>("namedItem", index);
        /// <summary>
        /// Returns the specific node whose ID or, as a fallback, name matches the string specified by name. Matching by name is only done as a last resort, only in HTML, and only if the referenced element supports the name attribute. Returns null if no node exists by the given name.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T? NamedItem<T>(string index) where T : Element => JSRef!.Call<T?>("namedItem", index);
        /// <summary>
        /// Returns undefined when i is out-of-bounds
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public Element this[int index] => JSRef!.Get<Element>(index);
        /// <summary>
        /// Returns undefined when i is out-of-bounds
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public Element this[string key] => JSRef!.Get<Element>(key);
        /// <summary>
        /// Returns the list as a list
        /// </summary>
        /// <returns></returns>
        public List<Element> ToList()
        {
            var ret = new List<Element>();
            for (int i = 0; i < Length; i++)
            {
                ret.Add(Item(i));
            }
            return ret;
        }
        /// <summary>
        /// Returns the list as a list
        /// </summary>
        /// <returns></returns>
        public Element[] ToArray() => ToList().ToArray();
        /// <summary>
        /// Returns the list as a list
        /// </summary>
        /// <returns></returns>
        public List<T> ToList<T>() where T : Element
        {
            var ret = new List<T>();
            for (int i = 0; i < Length; i++)
            {
                ret.Add(Item<T>(i));
            }
            return ret;
        }
        /// <summary>
        /// Returns the list as a list
        /// </summary>
        /// <returns></returns>
        public T[] ToArray<T>() where T : Element => ToList<T>().ToArray();
    }
}
