using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLAnchorElement interface represents hyperlink elements and provides special properties and methods (beyond those of the regular HTMLElement object interface that they inherit from) for manipulating the layout and presentation of such elements. This interface corresponds to a element; not to be confused with link, which is represented by HTMLLinkElement)<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLAnchorElement
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
        /// <summary>
        /// A string indicating that the linked resource is intended to be downloaded rather than displayed in the browser. The value represent the proposed name of the file. If the name is not a valid filename of the underlying OS, browser will adapt it.
        /// </summary>
        public string Download { get => JSRef.Get<string>("download"); set => JSRef.Set("download", value); }
        /// <summary>
        /// A string representing the fragment identifier, including the leading hash mark ('#'), if any, in the referenced URL.
        /// </summary>
        public string Hash { get => JSRef.Get<string>("hash"); set => JSRef.Set("hash", value); }
        /// <summary>
        /// A string representing the hostname and port (if it's not the default port) in the referenced URL.
        /// </summary>
        public string Host { get => JSRef.Get<string>("host"); set => JSRef.Set("host", value); }
        /// <summary>
        /// A string representing the hostname in the referenced URL.
        /// </summary>
        public string Hostname { get => JSRef.Get<string>("hostname"); set => JSRef.Set("hostname", value); }
        /// <summary>
        /// A string that is the result of parsing the href HTML attribute relative to the document, containing a valid URL of a linked resource.
        /// </summary>
        public string Href { get => JSRef.Get<string>("href"); set => JSRef.Set("href", value); }
        /// <summary>
        /// A string that reflects the hreflang HTML attribute, indicating the language of the linked resource.
        /// </summary>
        public string Hreflang { get => JSRef.Get<string>("hreflang"); set => JSRef.Set("hreflang", value); }
        /// <summary>
        /// Returns a string containing the origin of the URL, that is its scheme, its domain and its port.
        /// </summary>
        public string Origin => JSRef.Get<string>("origin");
        /// <summary>
        /// A string containing the password specified before the domain name.
        /// </summary>
        public string Password { get => JSRef.Get<string>("password"); set => JSRef.Set("password", value); }
        /// <summary>
        /// A string containing an initial '/' followed by the path of the URL, not including the query string or fragment.
        /// </summary>
        public string Pathname { get => JSRef.Get<string>("pathname"); set => JSRef.Set("pathname", value); }
        /// <summary>
        /// A space-separated list of URLs. When the link is followed, the browser will send POST requests with the body PING to the URLs.
        /// </summary>
        public string Ping { get => JSRef.Get<string>("ping"); set => JSRef.Set("ping", value); }
        /// <summary>
        /// A string representing the port component, if any, of the referenced URL.
        /// </summary>
        public string Port { get => JSRef.Get<string>("port"); set => JSRef.Set("port", value); }
        /// <summary>
        /// A string representing the protocol component, including trailing colon (':'), of the referenced URL.
        /// </summary>
        public string Protocol { get => JSRef.Get<string>("protocol"); set => JSRef.Set("protocol", value); }
        /// <summary>
        /// A string that reflects the referrerpolicy HTML attribute indicating which referrer to use.
        /// </summary>
        public string ReferrerPolicy { get => JSRef.Get<string>("referrerPolicy"); set => JSRef.Set("referrerPolicy", value); }
        /// <summary>
        /// A string that reflects the rel HTML attribute, specifying the relationship of the target object to the linked object.
        /// </summary>
        public string Rel { get => JSRef.Get<string>("rel"); set => JSRef.Set("rel", value); }
        /// <summary>
        /// Returns a DOMTokenList that reflects the rel HTML attribute, as a list of tokens.
        /// </summary>
        public DOMTokenList RelList => JSRef.Get<DOMTokenList>("relList");
        /// <summary>
        /// A string representing the search element, including leading question mark ('?'), if any, of the referenced URL.
        /// </summary>
        public string Search { get => JSRef.Get<string>("search"); set => JSRef.Set("search", value); }
        /// <summary>
        /// A string that reflects the target HTML attribute, indicating where to display the linked resource.
        /// </summary>
        public string Target { get => JSRef.Get<string>("target"); set => JSRef.Set("target", value); }
        /// <summary>
        /// A string being a synonym for the Node.textContent property.
        /// </summary>
        public string Text { get => JSRef.Get<string>("text"); set => JSRef.Set("text", value); }
        /// <summary>
        /// A string that reflects the type HTML attribute, indicating the MIME type of the linked resource.
        /// </summary>
        public string Type { get => JSRef.Get<string>("type"); set => JSRef.Set("type", value); }
        /// <summary>
        /// A string containing the username specified before the domain name.
        /// </summary>
        public string Username { get => JSRef.Get<string>("username"); set => JSRef.Set("username", value); }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a string containing the whole URL. It is a synonym for HTMLAnchorElement.href, though it can't be used to modify the value.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JSRef.Call<string>("toString");
        #endregion
    }
}
