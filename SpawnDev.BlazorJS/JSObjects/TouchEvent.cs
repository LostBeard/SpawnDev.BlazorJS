using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The TouchEvent interface represents an UIEvent which is sent when the state of contacts with a touch-sensitive surface changes. This surface can be a touch screen or trackpad, for example. The event can describe one or more points of contact with the screen and includes support for detecting movement, addition and removal of contact points, and so forth.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TouchEvent
    /// </summary>
    public class TouchEvent : UIEvent
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public TouchEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
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
        /// A TouchList of all the Touch objects representing individual points of contact whose states changed between the previous touch event and this one.
        /// </summary>
        public TouchList ChangedTouches => JSRef!.Get<TouchList>("changedTouches");
        /// <summary>
        /// A TouchList of all the Touch objects that are both currently in contact with the touch surface and were also started on the same element that is the target of the event.
        /// </summary>
        public TouchList TargetTouches => JSRef!.Get<TouchList>("targetTouches");
        /// <summary>
        /// A TouchList of all the Touch objects representing all current points of contact with the surface, regardless of target or changed status.
        /// </summary>
        public TouchList Touches => JSRef!.Get<TouchList>("touches");
    }
}
