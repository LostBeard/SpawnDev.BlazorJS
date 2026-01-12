using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLSourceElement interface provides special properties (beyond the regular HTMLElement object interface it also has available to it by inheritance) for manipulating &lt;source> elements.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLSourceElement
    /// </summary>
    public class HTMLSourceElement : HTMLElement
    {
        /// <summary>
        /// Explicit conversion from ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLSourceElement?(ElementReference elementReference) => elementReference.Context == null || string.IsNullOrEmpty(elementReference.Id) ? null : new HTMLSourceElement(elementReference);

        /// <summary>
        /// Explicit conversion from ElementReference?
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLSourceElement?(ElementReference? elementReference) => elementReference == null || elementReference.Value.Context == null || string.IsNullOrEmpty(elementReference.Value.Id) ? null : new HTMLSourceElement(elementReference.Value);

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLSourceElement(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Constructor for ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLSourceElement(ElementReference elementReference) : base(JS.ToJSRef(elementReference)) { }

        /// <summary>
        /// A DOMString reflecting the src attribute, containing the URL for the media resource.
        /// </summary>
        public string? Src
        {
            get => JSRef!.Get<string?>("src");
            set => JSRef!.Set("src", value);
        }

        /// <summary>
        /// A DOMString reflecting the type attribute, containing the type of media resource.
        /// </summary>
        public string? Type
        {
            get => JSRef!.Get<string?>("type");
            set => JSRef!.Set("type", value);
        }

        /// <summary>
        /// A DOMString reflecting the media attribute, containing the intended media type of the media resource.
        /// </summary>
        public string? Media
        {
            get => JSRef!.Get<string?>("media");
            set => JSRef!.Set("media", value);
        }

        /// <summary>
        /// A DOMString reflecting the sizes attribute, containing the sizes of the icons for visual media.
        /// </summary>
        public string? Sizes
        {
            get => JSRef!.Get<string?>("sizes");
            set => JSRef!.Set("sizes", value);
        }

        /// <summary>
        /// A DOMString reflecting the srcset attribute, containing a list of one or more strings separated by commas indicating a set of possible image sources for the user agent to use.
        /// </summary>
        public string? SrcSet
        {
            get => JSRef!.Get<string?>("srcset");
            set => JSRef!.Set("srcset", value);
        }

        /// <summary>
        /// A DOMString reflecting the width attribute, containing the horizontal size of the image resource.
        /// </summary>
        public string? Width
        {
            get => JSRef!.Get<string?>("width");
            set => JSRef!.Set("width", value);
        }

        /// <summary>
        /// A DOMString reflecting the height attribute, containing the vertical size of the image resource.
        /// </summary>
        public string? Height
        {
            get => JSRef!.Get<string?>("height");
            set => JSRef!.Set("height", value);
        }
    }
}
