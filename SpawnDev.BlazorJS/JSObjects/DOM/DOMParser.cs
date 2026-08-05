// <auto-ported> from SpawnDev.BlazorJS by Tools/PortJSObjects.cs - do not hand edit
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOMParser interface provides the ability to parse XML or HTML source code from a string into a DOM Document.<br/>
    /// You can perform the opposite operation—converting a DOM tree into XML or HTML source—using the XMLSerializer interface.<br/>
    /// In the case of an HTML document, you can also replace portions of the DOM with new DOM trees built from HTML by setting the value of the Element.innerHTML and outerHTML properties.These properties can also be read to fetch HTML fragments corresponding to the corresponding DOM subtree.<br/>
    /// Note that XMLHttpRequest can parse XML and HTML directly from a URL-addressable resource, returning a Document in its response property.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DOMParser
    /// </summary>
    public class DOMParser : JSObject
    {
        #region Constructors
        /// <summary>
        /// The DOMParser() constructor creates a new DOMParser object. This object can be used to parse the text of a document using the parseFromString() method.
        /// </summary>
        public DOMParser() : base(JS.New(nameof(DOMParser))) { }
        /// <inheritdoc/>
        public DOMParser(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
        /// <summary>
        /// The parseFromString() method of the DOMParser interface parses an input containing either HTML or XML, returning a Document with the type given in the contentType property.
        /// </summary>
        /// <param name="input">A TrustedHTML instance or a string defining HTML to be parsed. The markup must contain either an HTML, XML, XHTML, or SVG document.</param>
        /// <param name="mimeType">A string that specifies whether the XML parser or the HTML parser is used to parse the string.<br/>
        /// Allowed values are:<br/>
        /// - text/html<br/>
        /// - text/xml<br/>
        /// - application/xml<br/>
        /// - application/xhtml+xml<br/>
        /// - image/svg+xml</param>
        /// <returns></returns>
        public Document ParseFromString(string input, string mimeType) =>JSRef!.Call<Document>("parseFromString", input, mimeType);
    }
}
