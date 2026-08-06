// <auto-ported> from SpawnDev.BlazorJS by Tools/PortJSObjects.cs - do not hand edit
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CSSImportRule interface represents an @import at-rule.
    /// </summary>
    public class CSSImportRule : CSSRule
    {
        /// <inheritdoc/>
        public CSSImportRule(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the URL specified by the @import rule.
        /// </summary>
        public string Href => JSRef!.Get<string>("href");
        /// <summary>
        /// Returns the name of the cascade layer declared in the @import rule, the empty string if the layer is anonymous, the or null if the rule doesn't declare any.
        /// </summary>
        public string? LayerName => JSRef!.Get<string?>("layerName");
        /// <summary>
        /// Returns the value of the media attribute of the associated stylesheet.
        /// </summary>
        public MediaList Media => JSRef!.Get<MediaList>("media");
        /// <summary>
        /// Returns the associated stylesheet.
        /// </summary>
        public CSSStyleSheet StyleSheet => JSRef!.Get<CSSStyleSheet>("styleSheet");
        /// <summary>
        /// Returns the supports condition specified by the @import rule.
        /// </summary>
        public string? SupportsText => JSRef!.Get<string?>("supportsText");
    }
}
