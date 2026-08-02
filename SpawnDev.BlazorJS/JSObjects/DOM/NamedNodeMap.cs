using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The NamedNodeMap interface represents a collection of Attr objects. Objects inside a NamedNodeMap are not in any particular order, unlike NodeList, although they may be accessed by an index as in an array.<br/>
    /// A NamedNodeMap object is live and will thus be auto-updated if changes are made to its contents internally or elsewhere.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/NamedNodeMap
    /// </summary>
    public class NamedNodeMap : JSObject
    {
        /// <inheritdoc/>
        public NamedNodeMap(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the amount of objects in the map.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// The getNamedItem() method of the NamedNodeMap interface returns the Attr corresponding to the given name, or null if there is no corresponding attribute.
        /// </summary>
        /// <param name="name">A string with the name of the desired attribute.</param>
        /// <returns>An Attr corresponding to the name given in parameter, or null if none has been found.</returns>
        public Attr? GetNamedItem(string name) => JSRef!.Call<Attr>("getNamedItem", name);
        /// <summary>
        /// The setNamedItem() method of the NamedNodeMap interface puts the Attr identified by its name in the map. If there is already an Attr with the same name in the map, it is replaced.
        /// </summary>
        /// <param name="attr">the attribute to insert in the map.</param>
        /// <returns>Returns the old attribute if replaced, or null if the attribute is new.</returns>
        public Attr? SetNamedItem(Attr attr) => JSRef!.Call<Attr>("setNamedItem", attr);
        /// <summary>
        /// The removeNamedItem() method of the NamedNodeMap interface removes the Attr corresponding to the given name from the map.
        /// </summary>
        /// <param name="name">The name of the attribute to remove from the map.</param>
        /// <returns>The removed Attr.</returns>
        public Attr? RemoveNamedItem(string name) => JSRef!.Call<Attr>("removeNamedItem", name);
        /// <summary>
        /// The item() method of the NamedNodeMap interface returns the item in the map matching the index.
        /// </summary>
        /// <param name="index">A number representing the index of the item you want to return.</param>
        /// <returns>An Attr or null if the number is greater than or equal to the length of the map.</returns>
        public Attr? Item(int index) => JSRef!.Call<Attr>("item", index);
        /// <summary>
        /// Returns the item in the map matching the index.
        /// </summary>
        /// <param name="index">A number representing the index of the item you want to return.</param>
        /// <returns>An Attr or null if the number is greater than or equal to the length of the map.</returns>
        [System.Runtime.CompilerServices.IndexerName("AttrAt")]
        public Attr? this[int index] => Item(index);
        /// <summary>
        /// The getNamedItemNS() method of the NamedNodeMap interface returns the Attr corresponding to the given local name in the given namespace, or null if there is no corresponding attribute.
        /// </summary>
        /// <param name="nameSpace">A string with the namespace URI of the desired attribute.<br/>
        /// Warning: namespace is the URI of the namespace, not the prefix.</param>
        /// <param name="localName">A string with the localName of the desired attribute.</param>
        /// <returns>An Attr corresponding to the namespace and local name given in parameters, or null if none has been found.</returns>
        public Attr? GetNamedItemNS(string nameSpace, string localName) => JSRef!.Call<Attr>("getNamedItemNS", nameSpace, localName);
        /// <summary>
        /// The setNamedItemNS() method of the NamedNodeMap interface puts the Attr identified by its name in the map. If there was already an Attr with the same name in the map, it is replaced.
        /// </summary>
        /// <param name="attr">The attribute to insert in the map.</param>
        /// <returns>Returns the old attribute if replaced, or null if the attribute is new.</returns>
        public Attr? SetNamedItemNS(Attr attr) => JSRef!.Call<Attr>("setNamedItemNS", attr);
        /// <summary>
        /// The removeNamedItemNS() method of the NamedNodeMap interface removes the Attr corresponding to the given namespace and local name from the map.
        /// </summary>
        /// <param name="nameSpace">The namespace of the attribute to remove from the map.<br/>
        /// Warning: namespace is the URI of the namespace, not the prefix.</param>
        /// <param name="localName">The local name of the attribute to remove from the map.</param>
        /// <returns>The removed Attr.</returns>
        public Attr? RemoveNamedItemNS(string nameSpace, string localName) => JSRef!.Call<Attr>("removeNamedItemNS", nameSpace, localName);
        /// <summary>
        /// Returns the list as a list
        /// </summary>
        /// <returns></returns>
        public List<Attr> ToList()
        {
            var ret = new List<Attr>();
            for (int i = 0; i < Length; i++)
            {
                ret.Add(Item(i)!);
            }
            return ret;
        }
        /// <summary>
        /// Returns the list as a list
        /// </summary>
        /// <returns></returns>
        public Attr[] ToArray()
        {
            var ret = new Attr[Length];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = Item(i)!;
            }
            return ret;
        }
    }
}