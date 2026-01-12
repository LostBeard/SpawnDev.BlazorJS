using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLIFrameElement interface provides special properties and methods (beyond those of the HTMLElement interface it also has available to it by inheritance) for manipulating the layout and presentation of inline frame elements.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLIFrameElement
    /// </summary>
    public class HTMLIFrameElement : HTMLElement
    {
        /// <summary>
        /// Explicit conversion from ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLIFrameElement?(ElementReference elementReference) => elementReference.Context == null || string.IsNullOrEmpty(elementReference.Id) ? null : new HTMLIFrameElement(elementReference);
        /// <summary>
        /// Explicit conversion from ElementReference?
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLIFrameElement?(ElementReference? elementReference) => elementReference == null || elementReference.Value.Context == null || string.IsNullOrEmpty(elementReference.Value.Id) ? null : new HTMLIFrameElement(elementReference.Value);
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLIFrameElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLIFrameElement(ElementReference elementReference) : base(elementReference) { }
        #endregion

        #region Properties
        /// <summary>
        /// A string that reflects the src HTML attribute, containing the address of the content to be embedded. Note that programmatically removing an iframe's src attribute (e.g. via Element.removeAttribute()) causes about:blank to be loaded in the frame in Firefox (from version 65), Chromium-based browsers, and Safari/iOS.
        /// </summary>
        public string Src { get => JSRef!.Get<string>("src"); set => JSRef!.Set("src", value); }
        /// <summary>
        /// A boolean value indicating whether the inline frame is willing to be placed into full screen mode. See Using fullscreen mode for details.
        /// </summary>
        public bool AllowFullscreen { get => JSRef!.Get<bool>("allowFullscreen"); set => JSRef!.Set("allowFullscreen", value); }
        /// <summary>
        /// Returns a Document, the active document in the inline frame's nested browsing context.
        /// </summary>
        public Document ContentDocument => JSRef!.Get<Document>("contentDocument");
        /// <summary>
        /// Returns a WindowProxy, the window proxy for the nested browsing context.
        /// </summary>
        public Window ContentWindow => JSRef!.Get<Window>("contentWindow");
        /// <summary>
        /// A boolean value indicating whether the <iframe> is credentialless, meaning that its content is loaded in a new, ephemeral context. This context does not have access to the parent context's shared storage and credentials. In return, the Cross-Origin-Embedder-Policy (COEP) embedding rules can be lifted, so documents with COEP set can embed third-party documents that do not. See IFrame credentialless for a deeper explanation.
        /// </summary>
        public bool Credentialless { get => JSRef!.Get<bool>("credentialless"); set => JSRef!.Set("credentialless", value); }
        /// <summary>
        /// Specifies the Content Security Policy that an embedded document must agree to enforce upon itself.
        /// </summary>
        public string Csp { get => JSRef!.Get<string>("csp"); set => JSRef!.Set("csp", value); }
        /// <summary>
        /// A string that reflects the height HTML attribute, indicating the height of the frame.
        /// </summary>
        public string Height { get => JSRef!.Get<string>("height"); set => JSRef!.Set("height", value); }
        /// <summary>
        /// A string providing a hint to the browser that the iframe should be loaded immediately (eager) or on an as-needed basis (lazy). This reflects the loading HTML attribute.
        /// </summary>
        public string Loading { get => JSRef!.Get<string>("loading"); set => JSRef!.Set("loading", value); }
        /// <summary>
        /// A string that reflects the name HTML attribute, containing a name by which to refer to the frame.
        /// </summary>
        public string Name { get => JSRef!.Get<string>("name"); set => JSRef!.Set("name", value); }
        /// <summary>
        /// A string that reflects the referrerPolicy HTML attribute indicating which referrer to use when fetching the linked resource.
        /// </summary>
        public string ReferrerPolicy { get => JSRef!.Get<string>("referrerPolicy"); set => JSRef!.Set("referrerPolicy", value); }
        /// <summary>
        /// A string that represents the content to display in the frame.
        /// </summary>
        public string SrcDoc { get => JSRef!.Get<string>("srcdoc"); set => JSRef!.Set("srcdoc", value); }
        /// <summary>
        /// A string that reflects the width HTML attribute, indicating the width of the frame.
        /// </summary>
        public string Width { get => JSRef!.Get<string>("width"); set => JSRef!.Set("width", value); }
        #endregion
    }
}
