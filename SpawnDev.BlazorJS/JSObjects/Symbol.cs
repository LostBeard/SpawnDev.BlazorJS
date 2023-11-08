using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Symbol : JSObject
    {
        public Symbol(IJSInProcessObjectReference _ref) : base(_ref) { }
        static Lazy<Symbol> _AsyncIterator = new Lazy<Symbol>(() => JS.Get<Symbol>("Symbol.asyncIterator"));
        public static Symbol AsyncIterator => _AsyncIterator.Value;
    }
}
