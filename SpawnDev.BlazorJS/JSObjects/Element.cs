using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    // TODO - finish
    /// <summary>
    /// Element is the most general base class from which all element objects (i.e. objects that represent elements) in a Document inherit. It only has methods and properties common to all kinds of elements. More specific classes inherit from Element.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Element
    /// </summary>
    public class Element : Node
    {
        #region Constructors
        /// <summary>
        /// Creates a new Element from an ElementReference
        /// </summary>
        /// <param name="elRef"></param>
        public Element(ElementReference elRef) : base(JS.ReturnMe<IJSInProcessObjectReference>(elRef)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Element(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Methods
        /// <summary>
        /// The Element method querySelectorAll() returns a static (not live) NodeList representing a list of elements matching the specified group of selectors which are descendants of the element on which the method was called.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public NodeList QuerySelectorAll(string selector) => JSRef.Call<NodeList>("querySelectorAll", selector);
        /// <summary>
        /// The querySelector() method of the Element interface returns the first element that is a descendant of the element on which it is invoked that matches the specified group of selectors.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public Element? QuerySelector(string selector) => JSRef.Call<Element?>("querySelector", selector);
        /// <summary>
        /// The querySelector() method of the Element interface returns the first element that is a descendant of the element on which it is invoked that matches the specified group of selectors.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public TElement? QuerySelector<TElement>(string selector) where TElement : Element => JSRef.Call<TElement?>("querySelector", selector);
        /// <summary>
        /// The checkVisibility() method of the Element interface checks whether the element is visible.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool CheckVisibility(CheckVisibilityOptions? options = null) => options == null ? JSRef.Call<bool>("checkVisibility") : JSRef.Call<bool>("checkVisibility", options);
        /// <summary>
        /// Returns the size of an element and its position relative to the viewport.
        /// </summary>
        /// <returns></returns>
        public DOMRect GetBoundingClientRect() => JSRef.Call<DOMRect>("getBoundingClientRect");
        /// <summary>
        /// Asynchronously asks the browser to make the element fullscreen.
        /// </summary>
        /// <returns></returns>
        public Task RequestFullscreen() => JSRef.CallVoidAsync("requestFullscreen");
        /// <summary>
        /// Asynchronously asks the browser to make the element fullscreen.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task RequestFullscreen(RequestFullscreenOptions options) => JSRef.CallVoidAsync("requestFullscreen", options);
        /// <summary>
        /// Retrieves the value of the named attribute from the current node and returns it as a string.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string? GetAttribute(string name) => JSRef.Call<string?>("getAttribute", name);
        /// <summary>
        /// Removes the named attribute from the current node.
        /// </summary>
        /// <param name="name"></param>
        public void RemoveAttribute(string name) => JSRef.CallVoid("removeAttribute", name);
        /// <summary>
        /// Sets the value of a named attribute of the current node.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetAttribute(string name, string value) => JSRef.CallVoid("setAttribute", name, value);
        /// <summary>
        /// Inserts a set of Node objects or strings in the children list of the Element's parent, just after the Element.
        /// </summary>
        /// <param name="nodes"></param>
        public void After(params Node[] nodes) => JSRef.CallApplyVoid("after", nodes);
        /// <summary>
        /// Removes the element from the children list of its parent.
        /// </summary>
        public void Remove() => JSRef.CallVoid("remove");
        /// <summary>
        /// The Element.attachShadow() method attaches a shadow DOM tree to the specified element and returns a reference to its ShadowRoot.<br />
        /// Note that you can't attach a shadow root to every type of element. There are some that can't have a shadow DOM for security reasons (for example a element).
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public ShadowRoot AttachShadow(AttachShadowRootOptions options) => JSRef.Call<ShadowRoot>("attachShadow", options);
        #endregion

        #region Properties
        /// <summary>
        /// The Element.shadowRoot read-only property represents the shadow root hosted by the element.<br />
        /// Use Element.attachShadow() to add a shadow root to an existing element.
        /// </summary>
        public ShadowRoot ShadowRoot => JSRef.Get<ShadowRoot>("shadowRoot");
        /// <summary>
        /// Returns a DOMTokenList containing the list of class attributes.
        /// </summary>
        public DOMTokenList ClassList => JSRef.Get<DOMTokenList>("classList");
        /// <summary>
        /// A string representing the class of the element.
        /// </summary>
        public string ClassName { get => JSRef.Get<string>("className"); set => JSRef.Set("className", value); }
        /// <summary>
        /// Returns ClassNames from ClassName split on spaces
        /// </summary>
        public string[] ClassNames => ClassName.Split(' ').ToArray();
        /// <summary>
        /// The id property of the Element interface represents the element's identifier, reflecting the id global attribute.
        /// </summary>
        public string Id { get => JSRef.Get<string>("id"); set => JSRef.Set("id", value); }
        /// <summary>
        /// Returns a number representing the scroll view height of an element.
        /// </summary>
        public float ScrollHeight => JSRef.Get<float>("scrollHeight");
        /// <summary>
        /// Returns a number representing the scroll view width of the element.
        /// </summary>
        public float ScrollWidth => JSRef.Get<float>("scrollWidth");
        /// <summary>
        /// A number representing number of pixels the top of the element is scrolled vertically.
        /// </summary>
        public float ScrollTop { get => JSRef.Get<float>("scrollTop"); set => JSRef.Set("scrollTop", value); }
        /// <summary>
        /// Returns a number representing the inner height of the element.
        /// </summary>
        public float ClientHeight => JSRef.Get<float>("clientHeight");
        /// <summary>
        /// Returns a number representing the inner width of the element.
        /// </summary>
        public float ClientWidth => JSRef.Get<float>("clientWidth");
        #endregion

        #region Events
        /// <summary>
        /// Fires when the value of an input, select, or textarea element has been changed as a direct result of a user action (such as typing in a textbox or checking a checkbox).
        /// </summary>
        public JSEventCallback<InputEvent> OnInput { get => new JSEventCallback<InputEvent>(o => AddEventListener("input", o), o => RemoveEventListener("input", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fires when the value of an input or textarea element is about to be modified.
        /// </summary>
        public JSEventCallback<InputEvent> OnBeforeInput { get => new JSEventCallback<InputEvent>(o => AddEventListener("beforeinput", o), o => RemoveEventListener("beforeinput", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fired when the document view or an element has been scrolled.
        /// </summary>
        public JSEventCallback<Event> OnScroll { get => new JSEventCallback<Event>(o => AddEventListener("scroll", o), o => RemoveEventListener("scroll", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fires when the document view has completed scrolling.
        /// </summary>
        public JSEventCallback<Event> OnScrollEnd { get => new JSEventCallback<Event>(o => AddEventListener("scrollend", o), o => RemoveEventListener("scrollend", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fired when a non-primary pointing device button (e.g., any mouse button other than the left button) has been pressed and released on an element.
        /// </summary>
        public JSEventCallback<PointerEvent> OnAuxClick { get => new JSEventCallback<PointerEvent>(o => AddEventListener("auxclick", o), o => RemoveEventListener("auxclick", o)); set { /** required **/ } }
        /// <summary>
        /// Fired when a pointing device button (e.g., a mouse's primary button) is pressed and released on a single element.
        /// </summary>
        public JSEventCallback<PointerEvent> OnClick { get => new JSEventCallback<PointerEvent>(o => AddEventListener("click", o), o => RemoveEventListener("click", o)); set { /** required **/ } }
        /// <summary>
        /// Fired when the user attempts to open a context menu.
        /// </summary>
        public JSEventCallback<PointerEvent> OnContextMenu { get => new JSEventCallback<PointerEvent>(o => AddEventListener("contextmenu", o), o => RemoveEventListener("contextmenu", o)); set { /** required **/ } }
        /// <summary>
        /// Fired when a pointing device button (e.g., a mouse's primary button) is clicked twice on a single element.
        /// </summary>
        public JSEventCallback<PointerEvent> OnDblClick { get => new JSEventCallback<PointerEvent>(o => AddEventListener("dblclick", o), o => RemoveEventListener("dblclick", o)); set { /** required **/ } }
        /// <summary>
        /// Fired when an element has lost focus.
        /// </summary>
        public JSEventCallback<FocusEvent> OnBlur { get => new JSEventCallback<FocusEvent>(o => AddEventListener("blur", o), o => RemoveEventListener("blur", o)); set { /** required **/ } }

        #endregion
    }
}