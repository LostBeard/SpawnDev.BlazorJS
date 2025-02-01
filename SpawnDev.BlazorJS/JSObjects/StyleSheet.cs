using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object implementing the StyleSheet interface represents a single style sheet. CSS style sheets will further implement the more specialized CSSStyleSheet interface.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/StyleSheet
    /// </summary>
    public class StyleSheet : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public StyleSheet(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns a Boolean flag indicating whether the stylesheet is disabled or not.
        /// </summary>
        public bool Disabled
        {
            get => JSRef!.Get<bool>("disabled");
            set => JSRef!.Set("disabled", value);
        }

        /// <summary>
        /// Returns the URL of the stylesheet.
        /// </summary>
        public string Href
        {
            get => JSRef!.Get<string>("href");
        }

        /// <summary>
        /// Returns the media attribute of the stylesheet.
        /// </summary>
        public MediaList Media
        {
            get => JSRef!.Get<MediaList>("media");
        }

        /// <summary>
        /// Returns the owner node of the stylesheet.
        /// </summary>
        public Node OwnerNode
        {
            get => JSRef!.Get<Node>("ownerNode");
        }

        /// <summary>
        /// Returns the parent stylesheet, if any.
        /// </summary>
        public StyleSheet? ParentStyleSheet
        {
            get => JSRef!.Get<StyleSheet?>("parentStyleSheet");
        }

        /// <summary>
        /// Returns the type of the stylesheet, such as "text/css".
        /// </summary>
        public string Type
        {
            get => JSRef!.Get<string>("type");
        }

        /// <summary>
        /// Returns the title of the stylesheet.
        /// </summary>
        public string Title
        {
            get => JSRef!.Get<string>("title");
        }
    }
}
