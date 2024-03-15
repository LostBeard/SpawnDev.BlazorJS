using Microsoft.JSInterop;
using System.Collections;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// NodeList objects are collections of nodes, usually returned by properties such as Node.childNodes and methods such as document.querySelectorAll().<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/NodeList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NodeList<T> : JSObject, IEnumerable<T> where T : Node
    {
        #region Enable IEnumerable
        public IEnumerator GetEnumerator()
        {
            return new ArrayEnumerator<T>(this);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new ArrayEnumerator<T>(this);
        }
        private class ArrayEnumerator<TNode> : IEnumerator<TNode> where TNode : Node
        {
            int position = -1;
            NodeList<TNode> array;
            //constructor
            public ArrayEnumerator(NodeList<TNode> array)
            {
                this.array = array;
            }
            //IEnumerator
            public bool MoveNext()
            {
                position++;
                return (position < array.Length);
            }
            //IEnumerator
            public void Reset()
            {
                position = -1;
            }
            public void Dispose() { }
            //IEnumerator
            public object? Current
            {
                get
                {
                    try
                    {
                        return array.Item(position);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            TNode IEnumerator<TNode>.Current
            {
                get
                {
                    try
                    {
                        return array.Item(position);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
        #endregion

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
        public Array<T> Values() => JSRef!.Call<Array<T>>("values");
    }
    /// <summary>
    /// NodeList objects are collections of nodes, usually returned by properties such as Node.childNodes and methods such as document.querySelectorAll().<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/NodeList
    /// </summary>
    public class NodeList : JSObject, IEnumerable<Node>
    {
        #region Enable IEnumerable
        public IEnumerator GetEnumerator()
        {
            return new ArrayEnumerator(this);
        }
        IEnumerator<Node> IEnumerable<Node>.GetEnumerator()
        {
            return new ArrayEnumerator(this);
        }
        private class ArrayEnumerator : IEnumerator<Node>
        {
            int position = -1;
            NodeList array;
            //constructor
            public ArrayEnumerator(NodeList array)
            {
                this.array = array;
            }
            //IEnumerator
            public bool MoveNext()
            {
                position++;
                return (position < array.Length);
            }
            //IEnumerator
            public void Reset()
            {
                position = -1;
            }
            public void Dispose() { }
            //IEnumerator
            public object Current
            {
                get
                {
                    try
                    {
                        return array.Item(position);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            Node IEnumerator<Node>.Current
            {
                get
                {
                    try
                    {
                        return array.Item<Node>(position);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
        #endregion

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
        public Array<Node> Values() => JSRef!.Call<Array<Node>>("values");
        /// <summary>
        /// Returns an iterator allowing code to go through all values (nodes) of the key/value pairs contained in the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Array<T> Values<T>() where T : Node => JSRef!.Call<Array<T>>("values");
    }
}
