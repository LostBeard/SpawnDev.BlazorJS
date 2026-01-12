using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ShadowRoot interface of the Shadow DOM API is the root node of a DOM subtree that is rendered separately from a document's main DOM tree.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ShadowRoot
    /// </summary>
    public class ShadowRoot : DocumentFragment
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ShadowRoot(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns the mode of the ShadowRoot, either "open" or "closed".
        /// </summary>
        public string Mode
        {
            get => JSRef!.Get<string>("mode");
        }

        /// <summary>
        /// Returns the Element that is the host of the ShadowRoot.
        /// </summary>
        public Element Host
        {
            get => JSRef!.Get<Element>("host");
        }

        /// <summary>
        /// Returns a boolean indicating whether the ShadowRoot's delegatesFocus attribute is true or false.
        /// </summary>
        public bool DelegatesFocus
        {
            get => JSRef!.Get<bool>("delegatesFocus");
        }

        /// <summary>
        /// Returns the slot assignment mode of the ShadowRoot, either "manual" or "named".
        /// </summary>
        public string SlotAssignment
        {
            get => JSRef!.Get<string>("slotAssignment");
        }

        /// <summary>
        /// Returns a NodeList of the slot elements in the ShadowRoot.
        /// </summary>
        public NodeList<Element> Slots
        {
            get => JSRef!.Get<NodeList<Element>>("slots");
        }

        /// <summary>
        /// Returns a boolean indicating whether the ShadowRoot is in a state where it can be used.
        /// </summary>
        public bool IsActive
        {
            get => JSRef!.Get<bool>("isActive");
        }

        /// <summary>
        /// Returns the inner HTML of the ShadowRoot.
        /// </summary>
        public string InnerHTML
        {
            get => JSRef!.Get<string>("innerHTML");
            set => JSRef!.Set("innerHTML", value);
        }

        /// <summary>
        /// Returns the style sheets associated with the ShadowRoot.
        /// </summary>
        public StyleSheetList StyleSheets
        {
            get => JSRef!.Get<StyleSheetList>("styleSheets");
        }

        /// <summary>
        /// Returns the shadow root's mode, either "open" or "closed".
        /// </summary>
        public string ShadowRootMode
        {
            get => JSRef!.Get<string>("shadowRootMode");
        }

        /// <summary>
        /// Returns the shadow root's host element.
        /// </summary>
        public Element ShadowHost
        {
            get => JSRef!.Get<Element>("shadowHost");
        }

    }
}
