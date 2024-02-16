using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLElement interface represents any HTML element. Some elements directly implement this interface, while others implement it via an interface that inherits it.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement
    /// </summary>
    public class HTMLElement : Element
    {
        public static explicit operator HTMLElement(ElementReference elRef) => new HTMLElement(elRef);

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Constructor for ElementReference
        /// </summary>
        /// <param name="elRef"></param>
        public HTMLElement(ElementReference elRef) : base(JS.ReturnMe<IJSInProcessObjectReference>(elRef)) { }


        #region Properties
        /// <summary>
        /// A string representing the access key assigned to the element.
        /// </summary>
        public string? AccessKey { get => JSRef.Get<string?>("accessKey"); set => JSRef.Set("accessKey", value); }
        /// <summary>
        /// Returns a string containing the element's assigned access key.
        /// </summary>
        public string? AccessKeyLabel => JSRef.Get<string?>("accessKeyLabel");
        /// <summary>
        /// A boolean value reflecting the autofocus HTML global attribute, which indicates whether the control should be focused when the page loads, or when dialog or popover become shown if specified in an element inside <dialog> elements or elements whose popover attribute is set.
        /// </summary>
        public bool AutoFocus { get => JSRef.Get<bool>("autoFocus"); set => JSRef.Set("autoFocus", value); }
        /// <summary>
        /// A string, where a value of true means the element is editable and a value of false means it isn't.
        /// </summary>
        public string ContentEditable { get => JSRef.Get<string>("contentEditable"); set => JSRef.Set("contentEditable", value); }
        /// <summary>
        /// A string, reflecting the dir global attribute, representing the directionality of the element. Possible values are "ltr", "rtl", and "auto".
        /// </summary>
        public string Dir { get => JSRef.Get<string>("dir"); set => JSRef.Set("dir", value); }
        /// <summary>
        /// A boolean value indicating if the element can be dragged.
        /// </summary>
        public bool Draggable { get => JSRef.Get<bool>("draggable"); set => JSRef.Set("draggable", value); }
        /// <summary>
        /// A string defining what action label (or icon) to present for the enter key on virtual keyboards.
        /// </summary>
        public string EnterKeyHint { get => JSRef.Get<string>("enterKeyHint"); set => JSRef.Set("enterKeyHint", value); }
        /// <summary>
        /// A string or boolean value reflecting the value of the element's hidden attribute.
        /// </summary>
        public bool Hidden { get => JSRef.Get<bool>("hidden"); set => JSRef.Set("hidden", value); }
        /// <summary>
        /// Represents the rendered text content of a node and its descendants. As a getter, it approximates the text the user would get if they highlighted the contents of the element with the cursor and then copied it to the clipboard. As a setter, it replaces the content inside the selected element, converting any line breaks into br elements.
        /// </summary>
        public string InnerText { get => JSRef.Get<string>("innerText"); set => JSRef.Set("innerText", value); }
        /// <summary>
        /// A string value reflecting the value of the element's inputmode attribute.
        /// </summary>
        public string InputMode { get => JSRef.Get<string>("inputMode"); set => JSRef.Set("inputMode", value); }
        /// <summary>
        /// Returns a boolean value indicating whether or not the content of the element can be edited.
        /// </summary>
        public bool IsContentEditable => JSRef.Get<bool>("isContentEditable");
        /// <summary>
        /// A string representing the language of an element's attributes, text, and element contents.
        /// </summary>
        public string Lang { get => JSRef.Get<string>("lang"); set => JSRef.Set("lang", value); }
        /// <summary>
        /// Returns a double containing the height of an element, relative to the layout.
        /// </summary>
        public double OffsetHeight => JSRef.Get<double>("offsetHeight");
        /// <summary>
        /// Returns a double, the distance from this element's left border to its offsetParent's left border.
        /// </summary>
        public double OffsetLeft => JSRef.Get<double>("offsetLeft");
        /// <summary>
        /// An Element that is the element from which all offset calculations are currently computed.
        /// </summary>
        public Element? OffsetParent => JSRef.Get<Element?>("offsetParent");
        /// <summary>
        /// Returns a double, the distance from this element's top border to its offsetParent's top border.
        /// </summary>
        public double OffsetTop => JSRef.Get<double>("offsetTop");
        /// <summary>
        /// Returns a double containing the width of an element, relative to the layout.
        /// </summary>
        public double OffsetWidth => JSRef.Get<double>("offsetWidth");
        /// <summary>
        /// Represents the rendered text content of a node and its descendants. As a getter, it is the same as HTMLElement.innerText (it represents the rendered text content of an element and its descendants). As a setter, it replaces the selected node and its contents with the given value, converting any line breaks into <br> elements.
        /// </summary>
        public string OuterText { get => JSRef.Get<string>("outerText"); set => JSRef.Set("outerText", value); }
        /// <summary>
        /// Gets and sets an element's popover state via JavaScript ("auto" or "manual"), and can be used for feature detection. Reflects the value of the popover global HTML attribute.
        /// </summary>
        public string Popover { get => JSRef.Get<string>("popover"); set => JSRef.Set("popover", value); }
        /// <summary>
        /// A boolean value that controls the spell-checking hint. It is available on all HTML elements, though it doesn't affect all of them.
        /// </summary>
        public bool SpellCheck { get => JSRef.Get<bool>("spellcheck"); set => JSRef.Set("spellcheck", value); }
        /// <summary>
        /// A CSSStyleDeclaration representing the declarations of the element's style attribute.
        /// </summary>
        public CSSStyleDeclaration Style { get => JSRef.Get<CSSStyleDeclaration>("style"); set => JSRef.Set("style", value); }
        /// <summary>
        /// A long representing the position of the element in the tabbing order.
        /// </summary>
        public long TabIndex { get => JSRef.Get<long>("tabIndex"); set => JSRef.Set("tabIndex", value); }
        /// <summary>
        /// A string containing the text that appears in a popup box when mouse is over the element.
        /// </summary>
        public string Title { get => JSRef.Get<string>("title"); set => JSRef.Set("title", value); }
        /// <summary>
        /// A boolean value representing the translation.
        /// </summary>
        public bool Translate { get => JSRef.Get<bool>("translate"); set => JSRef.Set("translate", value); }
        #endregion

        #region Methods
        /// <summary>
        /// Removes keyboard focus from the currently focused element.
        /// </summary>
        public void Blur() => JSRef.CallVoid("blur");
        /// <summary>
        /// Sends a mouse click event to the element.
        /// </summary>
        public void Click() => JSRef.CallVoid("click");
        /// <summary>
        /// Makes the element the current keyboard focus.
        /// </summary>
        public void Focus(FocusOptions? options = null) { if (options == null) { JSRef.CallVoid("focus"); } else { JSRef.CallVoid("focus", options); } }
        /// <summary>
        /// Hides a popover element by removing it from the top layer and styling it with display: none.
        /// </summary>
        public void HidePopover() => JSRef.CallVoid("hidePopover");
        /// <summary>
        /// Shows a popover element by adding it to the top layer and removing display: none; from its styles.
        /// </summary>
        public void ShowPopover() => JSRef.CallVoid("showPopover");
        /// <summary>
        /// Toggles a popover element between the hidden and showing states.
        /// </summary>
        /// <returns>true if the popup is open after the call, and false otherwise.</returns>
        public bool TogglePopover() => JSRef.Call<bool>("togglePopover");
        /// <summary>
        /// Toggles a popover element between the hidden and showing states.
        /// </summary>
        /// <param name="force"></param>
        /// <returns>true if the popup is open after the call, and false otherwise.</returns>
        public bool TogglePopover(bool force) => JSRef.Call<bool>("togglePopover", force);
        #endregion

        #region Events
        /// <summary>
        /// Fired for input and dialog elements when the user cancels the currently open dialog by closing it with the Esc key.
        /// </summary>
        public JSEventCallback<Event> OnCancel { get => new JSEventCallback<Event>(o => AddEventListener("cancel", o), o => RemoveEventListener("cancel", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fired for input, select, and textarea elements when the user modifies the element's value. 
        /// </summary>
        public JSEventCallback<Event> OnChange { get => new JSEventCallback<Event>(o => AddEventListener("change", o), o => RemoveEventListener("change", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fired on an element when a resource failed to load, or can't be used. 
        /// </summary>
        public JSEventCallback<Event> OnError { get => new JSEventCallback<Event>(o => AddEventListener("error", o), o => RemoveEventListener("error", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fires for elements containing a resource when the resource has successfully loaded.
        /// </summary>
        public JSEventCallback<Event> OnLoad { get => new JSEventCallback<Event>(o => AddEventListener("load", o), o => RemoveEventListener("load", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        #region Clipboard events
        /// <summary>
        /// Fires when the user initiates a copy action through the browser's user interface.
        /// </summary>
        public JSEventCallback<ClipboardEvent> OnCopy { get => new JSEventCallback<ClipboardEvent>(o => AddEventListener("copy", o), o => RemoveEventListener("copy", o)); set { /** required **/ } }
        /// <summary>
        /// Fired when the user has initiated a "cut" action through the browser's user interface.
        /// </summary>
        public JSEventCallback<ClipboardEvent> OnCut { get => new JSEventCallback<ClipboardEvent>(o => AddEventListener("cut", o), o => RemoveEventListener("cut", o)); set { /** required **/ } }
        /// <summary>
        /// Fires when the user initiates a paste action through the browser's user interface.
        /// </summary>
        public JSEventCallback<ClipboardEvent> OnPaste { get => new JSEventCallback<ClipboardEvent>(o => AddEventListener("paste", o), o => RemoveEventListener("paste", o)); set { /** required **/ } }
        #endregion
        #region Drag & drop events
        /// <summary>
        /// Fired every few hundred milliseconds as an element or text selection is being dragged by the user.
        /// </summary>
        public JSEventCallback<DragEvent> OnDrag { get => new JSEventCallback<DragEvent>(o => AddEventListener("drag", o), o => RemoveEventListener("drag", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fired when a drag operation ends (by releasing a mouse button or hitting the escape key).
        /// </summary>
        public JSEventCallback<DragEvent> OnDragEnd { get => new JSEventCallback<DragEvent>(o => AddEventListener("dragend", o), o => RemoveEventListener("dragend", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fired when a dragged element or text selection enters a valid drop target. 
        /// </summary>
        public JSEventCallback<DragEvent> OnDragEnter { get => new JSEventCallback<DragEvent>(o => AddEventListener("dragenter", o), o => RemoveEventListener("dragenter", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fired when a dragged element or text selection leaves a valid drop target.
        /// </summary>
        public JSEventCallback<DragEvent> OnDragLeave { get => new JSEventCallback<DragEvent>(o => AddEventListener("dragleave", o), o => RemoveEventListener("dragleave", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fired when an element or text selection is being dragged over a valid drop target (every few hundred milliseconds).
        /// </summary>
        public JSEventCallback<DragEvent> OnDragOver { get => new JSEventCallback<DragEvent>(o => AddEventListener("dragover", o), o => RemoveEventListener("dragover", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fired when the user starts dragging an element or text selection.
        /// </summary>
        public JSEventCallback<DragEvent> OnDragStart { get => new JSEventCallback<DragEvent>(o => AddEventListener("dragstart", o), o => RemoveEventListener("dragstart", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// Fired when an element or text selection is dropped on a valid drop target. 
        /// </summary>
        public JSEventCallback<DragEvent> OnDrop { get => new JSEventCallback<DragEvent>(o => AddEventListener("drop", o), o => RemoveEventListener("drop", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        #endregion
        #region Popover events
        /// <summary>
        /// Fired when the element is a popover, before it is hidden or shown.
        /// </summary>
        public JSEventCallback<ToggleEvent> OnBeforeToggle { get => new JSEventCallback<ToggleEvent>(o => AddEventListener("beforetoggle", o), o => RemoveEventListener("beforetoggle", o)); set { /** required **/ } }
        /// <summary>
        /// Fired when the element is a popover, just after it is hidden or shown.
        /// </summary>
        public JSEventCallback<ToggleEvent> OnToggle { get => new JSEventCallback<ToggleEvent>(o => AddEventListener("toggle", o), o => RemoveEventListener("toggle", o)); set { /** required **/ } }
        #endregion
        #endregion
    }
}