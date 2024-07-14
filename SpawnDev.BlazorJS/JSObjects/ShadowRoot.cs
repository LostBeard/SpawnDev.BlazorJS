using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ShadowRoot interface of the Shadow DOM API is the root node of a DOM subtree that is rendered separately from a document's main DOM tree.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ShadowRoot
    /// </summary>
    public class ShadowRoot : DocumentFragment
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ShadowRoot(IJSInProcessObjectReference _ref) : base(_ref) { }



    }
}
