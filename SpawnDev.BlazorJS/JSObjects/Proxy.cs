using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Proxy object enables you to create a proxy for another object, which can intercept and redefine fundamental operations for that object.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Proxy
    /// </summary>
    public class Proxy : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Proxy(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The Proxy() constructor creates Proxy objects.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="handler"></param>
        public Proxy(JSObject target, ProxyHandler handler) : base(JS.New(nameof(Proxy), target, handler)) { }
        /// <summary>
        /// The Proxy() constructor creates Proxy objects.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="handler"></param>
        public Proxy(IJSInProcessObjectReference target, ProxyHandler handler) : base(JS.New(nameof(Proxy), target, handler)) { }

    }
}
