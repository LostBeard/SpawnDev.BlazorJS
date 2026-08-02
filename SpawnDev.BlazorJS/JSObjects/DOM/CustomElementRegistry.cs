using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CustomElementRegistry interface provides methods for registering custom elements and querying registered elements. To get an instance of it, use the window.customElements property. To create a scoped registry, use the CustomElementRegistry() constructor.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CustomElementRegistry
    /// </summary>
    public class CustomElementRegistry : JSObject
    {
        /// <inheritdoc/>
        public CustomElementRegistry(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The define() method of the CustomElementRegistry interface adds a definition for a custom element to the custom element registry, mapping its name to the constructor which will be used to create it.
        /// </summary>
        /// <param name="name">Name for the new custom element. Must be a valid custom element name.</param>
        /// <param name="constructor">Constructor for the new custom element.</param>
        public void Define(string name, object constructor) => JSRef!.CallVoid("define", name, constructor);
        /// <summary>
        /// The define() method of the CustomElementRegistry interface adds a definition for a custom element to the custom element registry, mapping its name to the constructor which will be used to create it.
        /// </summary>
        /// <param name="name">Name for the new custom element. Must be a valid custom element name.</param>
        /// <param name="constructor">Constructor for the new custom element.</param>
        /// <param name="options">Object that controls how the element is defined.</param>
        public void Define(string name, object constructor, CustomElementOptions options) => JSRef!.CallVoid("define", name, constructor, options);
        /// <summary>
        /// The get() method of the CustomElementRegistry interface returns the constructor for a previously-defined custom element.
        /// </summary>
        /// <param name="name">The name of the custom element.</param>
        /// <returns>The constructor for the named custom element, or undefined if there is no custom element defined with the name.</returns>
        public JSObject? Get(string name) => JSRef!.Call<JSObject>("get", name);
        /// <summary>
        /// The getName() method of the CustomElementRegistry interface returns the name for a previously-defined custom element.
        /// </summary>
        /// <param name="constructor">Constructor for the custom element.</param>
        /// <returns>The name for the previously defined custom element, or null if there is no custom element defined with the constructor.</returns>
        public string? Get(object constructor) => JSRef!.Call<string>("getName", constructor);
        /// <summary>
        /// The upgrade() method of the CustomElementRegistry interface upgrades all shadow-containing custom elements in a Node subtree, even before they are connected to the main document.
        /// </summary>
        /// <param name="root">A Node instance with shadow-containing descendant elements to upgrade. If there are no descendant elements that can be upgraded, no error is thrown.</param>
        public void Upgrade(Node root) => JSRef!.CallVoid("upgrade", root);
        /// <summary>
        /// The initialize() method of the CustomElementRegistry interface associates this registry with a DOM subtree, setting the customElementRegistry of each inclusive descendant that doesn't already have one, and attempting to upgrade any custom elements found.
        /// </summary>
        /// <param name="root">A Node object (typically a Document, ShadowRoot, or Element) whose inclusive descendants will be associated with this registry.</param>
        public void Initialize(Node root) => JSRef!.CallVoid("initialize", root);
        /// <summary>
        /// The whenDefined() method of the CustomElementRegistry interface returns a Promise that resolves when the named element is defined.
        /// </summary>
        /// <param name="name">The name of the custom element.</param>
        /// <returns>A Promise that fulfills with the custom element's constructor when a custom element becomes defined with the given name. If a custom element has already been defined with the name, the promise will immediately fulfill.</returns>
        public Task<JSObject> WhenDefined(string name) => JSRef!.CallAsync<JSObject>("whenDevined", name);
    }
}
