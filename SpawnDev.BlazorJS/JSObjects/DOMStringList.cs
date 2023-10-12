using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class DOMStringList : JSObject
    {
        public string this[int i] => JSRef.Call<string>("item", i);
        public DOMStringList(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int Length => JSRef.Get<int>("length");
        public bool Contains(string value) => JSRef.Call<bool>("contains", value);
        public string[] ToArray() => Enumerable.Range(0, Length).Select(i => JSRef.Call<string>("item", i)).ToArray();
    }
}
