using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class BigUint64Array : TypedArray
    {
        public BigUint64Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public BigUint64Array(long length) : base(JS.New(nameof(BigUint64Array), length)) { }
    }
}