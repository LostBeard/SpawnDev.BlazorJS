using Microsoft.JSInterop;
using System.Collections;

namespace SpawnDev.BlazorJS.JSObjects
{
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
        public T Item<T>(int index) where T : Node => JSRef.Get<T>(index);
        public Node Item(int index) => JSRef.Get<Node>(index);
        public NodeList(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int Length => JSRef.Get<int>("length");
        public void ForEach(Action<Node> fn)
        {
            using var cb = Callback.Create(fn);
            JSRef.CallVoid("forEach", cb);
        }
        public Array<Node> Values() => JSRef.Call<Array<Node>>("values");
        public Array<T> Values<T>() where T : Node => JSRef.Call<Array<T>>("values");
        public T[] ToArray<T>() where T : Node => JS.ReturnMe<T[]>(JSRef);
    }
}
