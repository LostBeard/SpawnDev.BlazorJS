using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CSSStyleSheet interface represents a single CSS stylesheet, and lets you inspect and modify the list of rules contained in the stylesheet. It inherits properties and methods from its parent, StyleSheet.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CSSStyleSheet
    /// </summary>
    public class CSSStyleSheet : StyleSheet
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CSSStyleSheet(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new instance of CSSStyleSheet
        /// </summary>
        public CSSStyleSheet() : base(JS.New("CSSStyleSheet")) { }

        /// <summary>
        /// Creates a new instance of CSSStyleSheet
        /// </summary>
        public CSSStyleSheet(CSSStyleSheetOptions options) : base(JS.New("CSSStyleSheet", options)) { }

        /// <summary>
        /// Returns a live CSSRuleList which maintains an up-to-date list of the CSSRule objects that comprise the stylesheet.
        /// </summary>
        public CSSRuleList CSSRules
        {
            get => JSRef!.Get<CSSRuleList>("cssRules");
        }

        /// <summary>
        /// If this stylesheet is imported into the document using an @import rule, the ownerRule property returns the corresponding CSSImportRule; otherwise, this property's value is null.
        /// </summary>
        public CSSRuleList OwnerRule
        {
            get => JSRef!.Get<CSSRuleList>("ownerRule");
        }

        /// <summary>
        /// Inserts a new rule into the stylesheet.
        /// </summary>
        /// <param name="rule">The rule to be inserted.</param>
        /// <param name="index">The index at which to insert the rule.</param>
        /// <returns>The index within the stylesheet's rule list of the newly inserted rule.</returns>
        public int InsertRule(string rule, int index = 0)
        {
            return JSRef!.Call<int>("insertRule", rule, index);
        }

        /// <summary>
        /// Deletes the rule at the specified index into the stylesheet's rule list.
        /// </summary>
        /// <param name="index">The index of the rule to be deleted.</param>
        public void DeleteRule(int index)
        {
            JSRef!.CallVoid("deleteRule", index);
        }

        /// <summary>
        /// Asynchronously replaces the content of the stylesheet and returns a Promise that resolves with the updated CSSStyleSheet.
        /// </summary>
        /// <param name="text">A string containing the style rules to replace the content of the stylesheet. If the string does not contain a parsable list of rules, then the value will be set to an empty string.</param>
        /// <returns>A Promise that resolves with the CSSStyleSheet.</returns>
        public Task<CSSStyleSheet> Replace(string text) => JSRef!.CallAsync<CSSStyleSheet>("replace", text);

        /// <summary>
        /// Synchronously replaces the content of the stylesheet.
        /// </summary>
        /// <param name="text">A string containing the style rules to replace the content of the stylesheet. If the string does not contain a parsable list of rules, then the value will be set to an empty string.</param>
        public void ReplaceSync(string text) => JSRef!.CallVoid("replaceSync", text);
    }
}
