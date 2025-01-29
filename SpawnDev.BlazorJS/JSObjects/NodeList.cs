using Microsoft.JSInterop;
using System.Collections;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// NodeList objects are collections of nodes, usually returned by properties such as Node.childNodes and methods such as document.querySelectorAll().<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/NodeList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NodeList<T> : JSObject where T : Node
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public NodeList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an item in the list by its index, or null if the index is out-of-bounds.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Item(int index) => JSRef!.Get<T>(index);
        /// <summary>
        /// The number of nodes in the NodeList.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// Executes a provided function once per NodeList element, passing the element as an argument to the function.
        /// </summary>
        /// <param name="fn"></param>
        public void ForEach(Action<T> fn)
        {
            using var cb = Callback.Create(fn);
            JSRef!.CallVoid("forEach", cb);
        }
        /// <summary>
        /// Returns an iterator allowing code to go through all values (nodes) of the key/value pairs contained in the collection.
        /// </summary>
        /// <returns></returns>
        public Iterator<T> Values() => JSRef!.Call<Iterator<T>>("values");
        /// <summary>
        /// Returns the array item at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>CSSStyleSheet</returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public T this[int index]
        {
            get => Item(index);
        }
        /// <summary>
        /// Returns the list as a list
        /// </summary>
        /// <returns></returns>
        public List<T> ToList()
        {
            var ret = new List<T>();
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
        public T[] ToArray() => ToList().ToArray();
    }
    /// <summary>
    /// NodeList objects are collections of nodes, usually returned by properties such as Node.childNodes and methods such as document.querySelectorAll().<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/NodeList
    /// </summary>
    public class NodeList : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public NodeList(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an item in the list by its index, or null if the index is out-of-bounds.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Item<T>(int index) where T : Node => JSRef!.Get<T>(index);
        /// <summary>
        /// Returns an item in the list by its index, or null if the index is out-of-bounds.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Node Item(int index) => JSRef!.Get<Node>(index);
        /// <summary>
        /// The number of nodes in the NodeList.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// Executes a provided function once per NodeList element, passing the element as an argument to the function.
        /// </summary>
        /// <param name="fn"></param>
        public void ForEach(Action<Node> fn)
        {
            using var cb = Callback.Create(fn);
            JSRef!.CallVoid("forEach", cb);
        }
        /// <summary>
        /// Returns an iterator allowing code to go through all values (nodes) of the key/value pairs contained in the collection.
        /// </summary>
        /// <returns></returns>
        public Iterator<Node> Values() => JSRef!.Call<Iterator<Node>>("values");
        /// <summary>
        /// Returns an iterator allowing code to go through all values (nodes) of the key/value pairs contained in the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Iterator<T> Values<T>() where T : Node => JSRef!.Call<Iterator<T>>("values");
        /// <summary>
        /// Returns the array item at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>CSSStyleSheet</returns>
        [System.Runtime.CompilerServices.IndexerName("ElementAt")]
        public Node this[int index]
        {
            get => Item(index);
        }
        /// <summary>
        /// Returns the list as a list
        /// </summary>
        /// <returns></returns>
        public List<Node> ToList()
        {
            var ret = new List<Node>();
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
        public Node[] ToArray() => ToList().ToArray();
        /// <summary>
        /// Returns the list as a list
        /// </summary>
        /// <returns></returns>
        public List<T> ToList<T>() where T : Node
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
        public T[] ToArray<T>() where T : Node => ToList<T>().ToArray();
    }
}
