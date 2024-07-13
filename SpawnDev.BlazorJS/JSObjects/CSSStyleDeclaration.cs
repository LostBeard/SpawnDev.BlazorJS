using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CSSStyleDeclaration interface represents an object that is a CSS declaration block, and exposes style information and various style-related methods and properties.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/CSSStyleDeclaration
    /// </summary>
    public class CSSStyleDeclaration : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CSSStyleDeclaration(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Textual representation of the declaration block, if and only if it is exposed via HTMLElement.style. Setting this attribute changes the inline style. If you want a text representation of a computed declaration block, you can get it with JSON.stringify().
        /// </summary>
        public string CSSText { get => JSRef!.Get<string>("cssText"); set => JSRef!.Set("cssText", value); }
        /// <summary>
        /// The number of properties. See the item() method below.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// The containing CSSRule.
        /// </summary>
        public CSSRule? ParentRule => JSRef!.Get<CSSRule?>("parentRule");
        /// <summary>
        /// Removes a property from the CSS declaration block.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public string RemoveProperty(string property) => JSRef!.Call<string>("removeProperty", property);
        /// <summary>
        /// Modifies an existing CSS property or creates a new CSS property in the declaration block.
        /// </summary>
        /// <param name="property">A string representing the CSS property name (hyphen case) to be modified.</param>
        /// <param name="value">A string allowing the "important" CSS priority to be set. If not specified, treated as the empty string. The following values are accepted: "", "!important"</param>
        /// <param name="priority">A string containing the new property value. If not specified, treated as the empty string.</param>
        public void SetProperty(string property, string value = "", string priority = "") => JSRef!.CallVoid("setProperty", property, value, priority);
        /// <summary>
        /// Returns the property value given a property name.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public string GetPropertyValue(string property) => JSRef!.Call<string>("getPropertyValue", property);
        /// <summary>
        /// Returns a CSS property name by its index, or the empty string if the index is out-of-bounds.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string Item(int index) => JSRef!.Call<string>("item", index);
        /// <summary>
        /// Returns the optional priority, "important".
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public string GetPropertyPriority(string property) => JSRef!.Call<string>("getPropertyPriority", property);
    }
}
