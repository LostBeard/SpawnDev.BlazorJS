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
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Element(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new Element from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public Element(ElementReference elementReference) : base(JS.ReturnMe<IJSInProcessObjectReference>(elementReference)) { }
        #endregion

        #region Methods
        /// <summary>
        /// The Element method querySelectorAll() returns a static (not live) NodeList representing a list of elements matching the specified group of selectors which are descendants of the element on which the method was called.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public NodeList<Element> QuerySelectorAll(string selector) => JSRef.Call<NodeList<Element>>("querySelectorAll", selector);
        /// <summary>
        /// The Element method querySelectorAll() returns a static (not live) NodeList representing a list of elements matching the specified group of selectors which are descendants of the element on which the method was called.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public NodeList<T> QuerySelectorAll<T>(string selector) where T : Element => JSRef.Call<NodeList<T>>("querySelectorAll", selector);
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
        /// The closest() method of the Element interface traverses the element and its parents (heading toward the document root) until it finds a node that matches the specified CSS selector.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public TElement? Closest<TElement>(string selector) where TElement : Element => JSRef.Call<TElement?>("closest", selector);
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
        public void After(params Union<Node, string>[] nodes) => JSRef.CallApplyVoid("after", nodes);
        /// <summary>
        /// The Element.append() method inserts a set of Node objects or string objects after the last child of the Element. String objects are inserted as equivalent Text nodes.
        /// </summary>
        /// <param name="nodes"></param>
        public void Append(params Union<Node, string>[] nodes) => JSRef.CallApplyVoid("append", nodes);
        /// <summary>
        /// Inserts a set of Node objects or strings before the first child of the element.
        /// </summary>
        /// <param name="nodes"></param>
        public void Prepend(params Union<Node, string>[] nodes) => JSRef.CallApplyVoid("prepend", nodes);
        /// <summary>
        /// The Element.before() method inserts a set of Node or string objects in the children list of this Element's parent, just before this Element. String objects are inserted as equivalent Text nodes.
        /// </summary>
        /// <param name="nodes"></param>
        public void Before(params Union<Node, string>[] nodes) => JSRef.CallApplyVoid("before", nodes);
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
        /// Fires on any element with content-visibility: auto set on it when it starts or stops being relevant to the user and skipping its contents.
        /// </summary>
        public JSEventCallback<ContentVisibilityAutoStateChangeEvent> OnContentVisibilityAutoStateChange { get => new JSEventCallback<ContentVisibilityAutoStateChangeEvent>("contentvisibilityautostatechange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the document view or an element has been scrolled.
        /// </summary>
        public JSEventCallback<Event> OnScroll { get => new JSEventCallback<Event>("scroll", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fires when the document view has completed scrolling.
        /// </summary>
        public JSEventCallback<Event> OnScrollEnd { get => new JSEventCallback<Event>("scrollend", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the user rotates a wheel button on a pointing device (typically a mouse).
        /// </summary>
        public JSEventCallback<WheelEvent> OnWheel { get => new JSEventCallback<WheelEvent>("wheel", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fires when the value of an input, select, or textarea element has been changed as a direct result of a user action (such as typing in a textbox or checking a checkbox).
        /// </summary>
        public JSEventCallback<InputEvent> OnInput { get => new JSEventCallback<InputEvent>("input", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fires when the value of an input or textarea element is about to be modified.
        /// </summary>
        public JSEventCallback<InputEvent> OnBeforeInput { get => new JSEventCallback<InputEvent>("beforeinput", AddEventListener, RemoveEventListener); set { } }
        #region Fullscreen events
        /// <summary>
        /// Sent to an Element when it transitions into or out of fullscreen mode.
        /// </summary>
        public JSEventCallback<Event> OnFullscreenChange { get => new JSEventCallback<Event>("fullscreenchange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Sent to an Element if an error occurs while attempting to switch it into or out of fullscreen mode.
        /// </summary>
        public JSEventCallback<Event> OnFullscreenError { get => new JSEventCallback<Event>("fullscreenerror", AddEventListener, RemoveEventListener); set { } }
        #endregion
        #region Clipboard events
        /// <summary>
        /// Fires when the user initiates a copy action through the browser's user interface.
        /// </summary>
        public JSEventCallback<ClipboardEvent> OnCopy { get => new JSEventCallback<ClipboardEvent>("copy", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the user has initiated a "cut" action through the browser's user interface.
        /// </summary>
        public JSEventCallback<ClipboardEvent> OnCut { get => new JSEventCallback<ClipboardEvent>("cut", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fires when the user initiates a paste action through the browser's user interface.
        /// </summary>
        public JSEventCallback<ClipboardEvent> OnPaste { get => new JSEventCallback<ClipboardEvent>("paste", AddEventListener, RemoveEventListener); set { } }
        #endregion
        #region Mouse events
        /// <summary>
        /// Fired when a non-primary pointing device button (e.g., any mouse button other than the left button) has been pressed and released on an element.
        /// </summary>
        public JSEventCallback<PointerEvent> OnAuxClick { get => new JSEventCallback<PointerEvent>("auxclick", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointing device button (e.g., a mouse's primary button) is pressed and released on a single element.
        /// </summary>
        public JSEventCallback<PointerEvent> OnClick { get => new JSEventCallback<PointerEvent>("click", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the user attempts to open a context menu.
        /// </summary>
        public JSEventCallback<PointerEvent> OnContextMenu { get => new JSEventCallback<PointerEvent>("contextmenu", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointing device button (e.g., a mouse's primary button) is clicked twice on a single element.
        /// </summary>
        public JSEventCallback<MouseEvent> OnDblClick { get => new JSEventCallback<MouseEvent>("dblclick", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointing device button is pressed on an element.
        /// </summary>
        public JSEventCallback<MouseEvent> OnMouseDown { get => new JSEventCallback<MouseEvent>("mousedown", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointing device (usually a mouse) is moved over the element that has the listener attached.
        /// </summary>
        public JSEventCallback<MouseEvent> OnMouseEnter { get => new JSEventCallback<MouseEvent>("mouseenter", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the pointer of a pointing device (usually a mouse) is moved out of an element that has the listener attached to it.
        /// </summary>
        public JSEventCallback<MouseEvent> OnMouseLeave { get => new JSEventCallback<MouseEvent>("mouseleave", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointing device (usually a mouse) is moved while over an element.
        /// </summary>
        public JSEventCallback<MouseEvent> OnMouseMove { get => new JSEventCallback<MouseEvent>("mousemove", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointing device (usually a mouse) is moved off the element to which the listener is attached or off one of its children.
        /// </summary>
        public JSEventCallback<MouseEvent> OnMouseOut { get => new JSEventCallback<MouseEvent>("mouseout", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointing device is moved onto the element to which the listener is attached or onto one of its children.
        /// </summary>
        public JSEventCallback<MouseEvent> OnMouseOver { get => new JSEventCallback<MouseEvent>("mouseover", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointing device button is released on an element.
        /// </summary>
        public JSEventCallback<MouseEvent> OnMouseUp { get => new JSEventCallback<MouseEvent>("mouseup", AddEventListener, RemoveEventListener); set { } }
        #endregion
        #region Focus events
        /// <summary>
        /// Fired when an element has lost focus.
        /// </summary>
        public JSEventCallback<FocusEvent> OnBlur { get => new JSEventCallback<FocusEvent>("blur", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when an element has gained focus.
        /// </summary>
        public JSEventCallback<FocusEvent> OnFocus { get => new JSEventCallback<FocusEvent>("focus", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when an element has gained focus, after focus.
        /// </summary>
        public JSEventCallback<FocusEvent> OnFocusIn { get => new JSEventCallback<FocusEvent>("focusin", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when an element has lost focus, after blur.
        /// </summary>
        public JSEventCallback<FocusEvent> OnFocusOut { get => new JSEventCallback<FocusEvent>("focusout", AddEventListener, RemoveEventListener); set { } }
        #endregion
        #region Keyboard events
        /// <summary>
        /// The keydown event is fired when a key is pressed.
        /// </summary>
        public JSEventCallback<KeyboardEvent> OnKeyDown { get => new JSEventCallback<KeyboardEvent>("keydown", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The keyup event is fired when a key is released.
        /// </summary>
        public JSEventCallback<KeyboardEvent> OnKeyUp { get => new JSEventCallback<KeyboardEvent>("keyup", AddEventListener, RemoveEventListener); set { } }
        #endregion
        #region Pointer events
        /// <summary>
        /// Fired when an element captures a pointer using setPointerCapture().
        /// </summary>
        public JSEventCallback<PointerEvent> OnGotPointerCapture { get => new JSEventCallback<PointerEvent>("gotpointercapture", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a captured pointer is released.
        /// </summary>
        public JSEventCallback<PointerEvent> OnLostPointerCapture { get => new JSEventCallback<PointerEvent>("lostpointercapture", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointer event is canceled.
        /// </summary>
        public JSEventCallback<PointerEvent> OnPointerCancel { get => new JSEventCallback<PointerEvent>("pointercancel", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointer becomes active.
        /// </summary>
        public JSEventCallback<PointerEvent> OnPointerDown { get => new JSEventCallback<PointerEvent>("pointerdown", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointer is moved into the hit test boundaries of an element or one of its descendants.
        /// </summary>
        public JSEventCallback<PointerEvent> OnPointerCenter { get => new JSEventCallback<PointerEvent>("pointercenter", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointer is moved out of the hit test boundaries of an element.
        /// </summary>
        public JSEventCallback<PointerEvent> OnPointerLeave { get => new JSEventCallback<PointerEvent>("pointerleave", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointer changes coordinates.
        /// </summary>
        public JSEventCallback<PointerEvent> OnPointerMove { get => new JSEventCallback<PointerEvent>("pointermove", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointer is moved out of the hit test boundaries of an element (among other reasons).
        /// </summary>
        public JSEventCallback<PointerEvent> OnPointerOut { get => new JSEventCallback<PointerEvent>("pointerout", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointer is moved into an element's hit test boundaries.
        /// </summary>
        public JSEventCallback<PointerEvent> OnPointerOver { get => new JSEventCallback<PointerEvent>("pointerover", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointer changes any properties that don't fire pointerdown or pointerup events.
        /// </summary>
        public JSEventCallback<PointerEvent> OnPointerRawUpdate { get => new JSEventCallback<PointerEvent>("pointerrawupdate", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a pointer is no longer active.
        /// </summary>
        public JSEventCallback<PointerEvent> OnPointerUp { get => new JSEventCallback<PointerEvent>("pointerup", AddEventListener, RemoveEventListener); set { } }
        #endregion
        #region Touch events
        /// <summary>
        /// Fired when digits move during a touch gesture.
        /// </summary>
        public JSEventCallback<GestureEvent> OnGestureChange { get => new JSEventCallback<GestureEvent>("gesturechange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when there are no longer multiple fingers contacting the touch surface, thus ending the gesture.
        /// </summary>
        public JSEventCallback<GestureEvent> OnGestureEnd { get => new JSEventCallback<GestureEvent>("gestureend", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when multiple fingers contact the touch surface, thus starting a new gesture.
        /// </summary>
        public JSEventCallback<GestureEvent> OnGestureStart { get => new JSEventCallback<GestureEvent>("gesturestart", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when one or more touch points have been disrupted in an implementation-specific manner (for example, too many touch points are created).
        /// </summary>
        public JSEventCallback<TouchEvent> OnTouchCancel { get => new JSEventCallback<TouchEvent>("touchcancel", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when one or more touch points are removed from the touch surface.
        /// </summary>
        public JSEventCallback<TouchEvent> OnTouchEnd { get => new JSEventCallback<TouchEvent>("touchend", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when one or more touch points are moved along the touch surface.
        /// </summary>
        public JSEventCallback<TouchEvent> OnTouchMove { get => new JSEventCallback<TouchEvent>("touchmove", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when one or more touch points are placed on the touch surface.
        /// </summary>
        public JSEventCallback<TouchEvent> OnTouchStart { get => new JSEventCallback<TouchEvent>("touchstart", AddEventListener, RemoveEventListener); set { } }
        #endregion
        #endregion
    }
}