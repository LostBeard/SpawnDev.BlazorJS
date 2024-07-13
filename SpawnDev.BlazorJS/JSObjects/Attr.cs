using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Attr interface represents one of an element's attributes as an object. In most situations, you will directly retrieve the attribute value as a string (e.g., Element.getAttribute()), but some cases may require interacting with Attr instances (e.g., Element.getAttributeNode()).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Attr
    /// </summary>
    public class Attr : Node
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Attr(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
        #region Properties
        /// <summary>
        /// A string representing the local part of the qualified name of the attribute.
        /// </summary>
        public string LocalName => JSRef!.Get<string>("localName");
        /// <summary>
        /// The attribute's qualified name. If the attribute is not in a namespace, it will be the same as localName property.
        /// </summary>
        public string Name => JSRef!.Get<string>("name");
        /// <summary>
        /// A string representing the URI of the namespace of the attribute, or null if there is no namespace.
        /// </summary>
        public string NamespaceURI => JSRef!.Get<string>("namespaceURI");
        /// <summary>
        /// The Element the attribute belongs to.
        /// </summary>
        public HTMLAnchorElement OwnerElement => JSRef!.Get<HTMLAnchorElement>("ownerElement");
        /// <summary>
        /// A string representing the namespace prefix of the attribute, or null if a namespace without prefix or no namespace are specified.
        /// </summary>
        public string Prefix => JSRef!.Get<string>("prefix");
        /// <summary>
        /// The attribute's value, a string that can be set and get using this property.
        /// </summary>
        public string Value => JSRef!.Get<string>("value");
        #endregion
    }
}
