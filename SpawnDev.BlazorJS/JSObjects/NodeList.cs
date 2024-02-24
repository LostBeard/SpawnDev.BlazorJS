using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// NodeList objects are collections of nodes, usually returned by properties such as Node.childNodes and methods such as document.querySelectorAll().<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/NodeList
    /// </summary>
    public class NodeList : JSObject
    {
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
