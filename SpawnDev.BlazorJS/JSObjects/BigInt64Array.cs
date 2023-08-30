using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class BigInt64Array : TypedArray
    {
        public BigInt64Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public BigInt64Array(long length) : base(JS.New(nameof(BigInt64Array), length)) { }
    }
}