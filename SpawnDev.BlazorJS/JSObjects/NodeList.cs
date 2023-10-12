using Microsoft.JSInterop;
using System;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class NodeList : JSObject
    {
        public Element this[int index] => JSRef.Get<Element>(index);
        public NodeList(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int Length => JSRef.Get<int>("length");
        public void ForEach(Action<Element> fn)
        {
            using var cb = Callback.Create(fn);
            JSRef.CallVoid("forEach", cb);
        }
        public Array<Element> Values() => JSRef.Call<Array<Element>>("values");
        public Array<T> Values<T>() where T : Element => JSRef.Call<Array<T>>("values");
        public T[] ToArray<T>() where T : Element => JS.ReturnMe<T[]>(JSRef);
    }
}
