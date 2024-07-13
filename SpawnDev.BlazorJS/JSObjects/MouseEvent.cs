using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MouseEvent interface represents events that occur due to the user interacting with a pointing device (such as a mouse). Common events using this interface include click, dblclick, mouseup, mousedown.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent<br/>
    /// </summary>
    public class MouseEvent : UIEvent
    {
        /// <summary>
        /// The MouseEvent() constructor creates a new MouseEvent object.
        /// </summary>
        /// <param name="type">A string with the name of the event. It is case-sensitive and browsers set it to dblclick, mousedown, mouseenter, mouseleave, mousemove, mouseout, mouseover, or mouseup.</param>
        public MouseEvent(string type) : base(JS.New(nameof(MouseEvent), type)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MouseEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        #region Properties
        /// <summary>
        /// Returns a boolean value that is true if the Alt (Option or ⌥ on macOS) key was active when the key event was generated.
        /// </summary>
        public bool AltKey => JSRef!.Get<bool>("altKey");
        /// <summary>
        /// Returns a boolean value that is true if the Ctrl key was active when the key event was generated.
        /// </summary>
        public bool CtrlKey => JSRef!.Get<bool>("ctrlKey");
        /// <summary>
        /// Returns a boolean value that is true if the Meta key (on Mac keyboards, the ⌘ Command key; on Windows keyboards, the Windows key (⊞)) was active when the key event was generated.
        /// </summary>
        public bool MetaKey => JSRef!.Get<bool>("metaKey");
        /// <summary>
        /// Returns a boolean value that is true if the Shift key was active when the key event was generated.
        /// </summary>
        public bool ShiftKey => JSRef!.Get<bool>("shiftKey");
        /// <summary>
        /// The button number that was pressed (if applicable) when the mouse event was fired.
        /// </summary>
        public MouseButton Button => JSRef!.Get<MouseButton>("button");
        /// <summary>
        /// The buttons being pressed (if any) when the mouse event was fired.
        /// </summary>
        public MouseButtons Buttons => JSRef!.Get<MouseButtons>("buttons");
        /// <summary>
        /// The X coordinate of the mouse pointer in viewport coordinates.
        /// </summary>
        public double ClientX => JSRef!.Get<double>("clientX");
        /// <summary>
        /// The Y coordinate of the mouse pointer in viewport coordinates.
        /// </summary>
        public double ClientY => JSRef!.Get<double>("clientY");
        /// <summary>
        /// Returns the horizontal coordinate of the event relative to the current layer.
        /// </summary>
        public int? LayerX => JSRef!.Get<int?>("layerX");
        /// <summary>
        /// Returns the vertical coordinate of the event relative to the current layer.
        /// </summary>
        public int? LayerY => JSRef!.Get<int?>("layerY");
        /// <summary>
        /// The X coordinate of the mouse pointer relative to the position of the last mousemove event.
        /// </summary>
        public double MovementX => JSRef!.Get<double>("movementX");
        /// <summary>
        /// The Y coordinate of the mouse pointer relative to the position of the last mousemove event.
        /// </summary>
        public double MovementY => JSRef!.Get<double>("movementY");
        /// <summary>
        /// The X coordinate of the mouse pointer relative to the position of the padding edge of the target node.
        /// </summary>
        public double OffsetX => JSRef!.Get<double>("offsetX");
        /// <summary>
        /// The Y coordinate of the mouse pointer relative to the position of the padding edge of the target node.
        /// </summary>
        public double OffsetY => JSRef!.Get<double>("offsetY");
        /// <summary>
        /// The X coordinate of the mouse pointer relative to the whole document.
        /// </summary>
        public double PageX => JSRef!.Get<double>("pageX");
        /// <summary>
        /// The Y coordinate of the mouse pointer relative to the whole document.
        /// </summary>
        public double PageY => JSRef!.Get<double>("pageY");
        /// <summary>
        /// The secondary target for the event, if there is one.
        /// </summary>
        public EventTarget? RelatedTarget => JSRef!.Get<EventTarget?>("relatedTarget");
        /// <summary>
        /// The X coordinate of the mouse pointer in screen coordinates.
        /// </summary>
        public double ScreenX => JSRef!.Get<double>("screenX");
        /// <summary>
        /// The Y coordinate of the mouse pointer in screen coordinates.
        /// </summary>
        public double ScreenY => JSRef!.Get<double>("screenY");
        /// <summary>
        /// Alias for MouseEvent.clientX.
        /// </summary>
        public double X => JSRef!.Get<double>("x");
        /// <summary>
        /// Alias for MouseEvent.clientY.
        /// </summary>
        public double Y => JSRef!.Get<double>("y");
        #endregion
        #region Methods
        /// <summary>
        /// Returns the current state of the specified modifier key. See KeyboardEvent.getModifierState() for details.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool GetModifierState(string key) => JSRef!.Call<bool>("getModifierState", key);
        #endregion
    }
}
