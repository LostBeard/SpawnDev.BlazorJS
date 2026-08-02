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
        /// Add an array of constructed stylesheets to be used by the shadow DOM subtree. These may be shared with other DOM subtrees that share the same parent Document node, and the document itself.
        /// </summary>
        public Array<CSSStyleSheet> AdoptedStyleSheets
        {
            get => JSRef!.Get<Array<CSSStyleSheet>>("adoptedStyleSheets");
        }

        /// <summary>
        /// A boolean that indicates whether the shadow root is clonable.
        /// </summary>
        public bool Clonable
        {
            get => JSRef!.Get<bool>("clonable");
        }

        /// <summary>
        /// Returns the CustomElementRegistry object associated with this shadow root, or null if one has not been set.
        /// </summary>
        public CustomElementRegistry? CustomElementRegistry
        {
            get => JSRef!.Get<CustomElementRegistry>("customElementRegistry");
        }

        /// <summary>
        /// The Document.fullscreenElement read-only property returns the Element that is currently being presented in fullscreen mode in this document, or null if fullscreen mode is not currently in use.
        /// </summary>
        public Element? FullscreenElement => JSRef!.Get<Element?>("fullscreenElement");

        /// <summary>
        /// The Document.pictureInPictureElement read-only property returns the Element that is currently being presented in picture-in-picture mode in this document, or null if picture-in-picture mode is not currently in use.
        /// </summary>
        public Element? PictureInPictureElement => JSRef!.Get<Element?>("pictureInPictureElement");

        /// <summary>
        /// The read-only pointerLockElement property of the Document interface provides the element set as the target for mouse events while the pointer is locked. It is null if lock is pending, pointer is unlocked, or the target is in another document.
        /// </summary>
        public Element? PointerLockElement => JSRef!.Get<Element?>("pointerLockElement");

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
