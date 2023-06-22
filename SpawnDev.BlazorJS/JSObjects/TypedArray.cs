using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/TypedArray
    public abstract class TypedArray : JSObject
    {
        public TypedArray(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
