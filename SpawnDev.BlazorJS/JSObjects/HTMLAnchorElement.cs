using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLAnchorElement interface represents hyperlink elements and provides special properties and methods (beyond those of the regular HTMLElement object interface that they inherit from) for manipulating the layout and presentation of such elements. This interface corresponds to <a> element; not to be confused with <link>, which is represented by HTMLLinkElement)
    /// </summary>
    public class HTMLAnchorElement : HTMLElement
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLAnchorElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLAnchorElement(ElementReference elementReference) : base(elementReference) { }
        #endregion

        #region Properties
        public string Charset => JSRef.Get<string>("charset");
        public string Coords => JSRef.Get<string>("coords");
        public string Download => JSRef.Get<string>("download");
        public string Hash => JSRef.Get<string>("hash");
        public string Host => JSRef.Get<string>("host");
        public string Hostname => JSRef.Get<string>("hostname");
        public string Href => JSRef.Get<string>("href");
        public string Hreflang => JSRef.Get<string>("hreflang");
        public string HrefTranslate => JSRef.Get<string>("hrefTranslate");
        public string Name => JSRef.Get<string>("name");
        public string Origin => JSRef.Get<string>("origin");
        public string Password => JSRef.Get<string>("password");
        public string Pathname => JSRef.Get<string>("pathname");
        public string Ping => JSRef.Get<string>("ping");
        public string Port => JSRef.Get<string>("port");
        public string Protocol => JSRef.Get<string>("protocol");
        public string ReferrerPolicy => JSRef.Get<string>("referrerPolicy");
        public string Rel => JSRef.Get<string>("rel");
        public DOMTokenList RelList => JSRef.Get<DOMTokenList>("relList");
        public string Rev => JSRef.Get<string>("rev");
        public string Search => JSRef.Get<string>("search");
        public string Shape => JSRef.Get<string>("shape");
        public string Target => JSRef.Get<string>("target");
        public string Text => JSRef.Get<string>("text");
        public string Type => JSRef.Get<string>("type");
        public string Username => JSRef.Get<string>("username");
        #endregion

        #region Methods
        public string ToString() => JSRef.Call<string>("toString");
        #endregion
    }
}
