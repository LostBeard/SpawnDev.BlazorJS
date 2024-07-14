using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XMLDocument interface represents an XML document. It inherits from the generic Document and does not add any specific methods or properties to it: nevertheless, several algorithms behave differently with the two types of documents.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XMLDocument
    /// </summary>
    public class XMLDocument : Document
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public XMLDocument(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
