using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

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
        #endregion

        #region Properties
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
        /// Fired when the document view or an element has been scrolled.
        /// </summary>
        public JSEventCallback<Event> OnScroll { get => new JSEventCallback<Event>(o => AddEventListener("scroll", o), o => RemoveEventListener("scroll", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fires when the document view has completed scrolling.
        /// </summary>
        public JSEventCallback<Event> OnScrollEnd { get => new JSEventCallback<Event>(o => AddEventListener("scrollend", o), o => RemoveEventListener("scrollend", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        #endregion
    }
}