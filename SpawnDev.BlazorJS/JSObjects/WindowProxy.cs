using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A WindowProxy object is a wrapper for a Window object. A WindowProxy object exists in every browsing context. All operations performed on a WindowProxy object will also be applied to the underlying Window object it currently wraps. Therefore, interacting with a WindowProxy object is almost identical to directly interacting with a Window object. When a browsing context is navigated, the Window object its WindowProxy wraps is changed.<br />
    /// https://developer.mozilla.org/en-US/docs/Glossary/WindowProxy
    /// </summary>
    public class WindowProxy : Window
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WindowProxy(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
