using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// XMLHttpRequestEventTarget is the interface that describes the event handlers shared on XMLHttpRequest and XMLHttpRequestUpload.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequestEventTarget
    /// </summary>
    public class XMLHttpRequestEventTarget : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public XMLHttpRequestEventTarget(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
