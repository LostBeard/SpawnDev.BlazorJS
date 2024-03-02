using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for Element.AttachShadowRoot calls
    /// </summary>
    public class AttachShadowRootOptions
    {
        /// <summary>
        /// A string specifying the encapsulation mode for the shadow DOM tree. This can be one of:<br />
        /// open - Elements of the shadow root are accessible from JavaScript outside the root.<br />
        /// closed - Denies access to the node(s) of a closed shadow root from JavaScript outside it.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Mode { get; set; }
        /// <summary>
        /// A boolean that specifies whether the shadow root is clonable: when set to true, the shadow host cloned with Node.cloneNode() or Document.importNode() will include shadow root in the copy. Its default value is false, unless the shadow root is created via declarative shadow DOM.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Clonable { get; set; }
        /// <summary>
        /// A boolean that, when set to true, specifies behavior that mitigates custom element issues around focusability. When a non-focusable part of the shadow DOM is clicked, the first focusable part is given focus, and the shadow host is given any available :focus styling. Its default value is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DelegateFocus { get; set; }
        /// <summary>
        /// A string specifying the slot assignment mode for the shadow DOM tree. This can be one of:<br />
        /// named - Elements are automatically assigned to slot elements within this shadow root. Any descendants of the host with a slot attribute which matches the name attribute of a slot within this shadow root will be assigned to that slot. Any top-level children of the host with no slot attribute will be assigned to a slot with no name attribute (the "default slot") if one is present.<br />
        /// manual - Elements are not automatically assigned to slot elements. Instead, they must be manually assigned with HTMLSlotElement.assign(). Its default value is named.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SlotAssignment { get; set; }
    }
}