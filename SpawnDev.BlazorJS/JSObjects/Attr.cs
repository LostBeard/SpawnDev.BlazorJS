using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Attr : Node
    {
        #region Constructors
        public Attr(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        public string LocalName => JSRef.Get<string>("localName");
        public string Name => JSRef.Get<string>("name");
        public string NamespaceURI => JSRef.Get<string>("namespaceURI");
        public HTMLAnchorElement OwnerElement => JSRef.Get<HTMLAnchorElement>("ownerElement");
        public string Prefix => JSRef.Get<string>("prefix");
        public bool Specified => JSRef.Get<bool>("specified");
        public string Value => JSRef.Get<string>("value");
        #endregion
    }
}
