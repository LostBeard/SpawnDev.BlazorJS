using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// KeyboardEvent objects describe a user interaction with the keyboard<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent
    /// </summary>
    public class KeyboardEvent : UIEvent
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public KeyboardEvent(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns a string with the code value of the physical key represented by the event.
        /// </summary>
        public string Code => JSRef!.Get<string>("code");

        /// <summary>
        /// Returns a string representing the key value of the key represented by the event.
        /// </summary>
        public string Key => JSRef!.Get<string>("key");

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
        /// Returns a boolean value that is true if the event is fired between after compositionstart and before compositionend.
        /// </summary>
        public bool IsComposing => JSRef!.Get<bool>("isComposing");

        /// <summary>
        /// Returns a boolean value that is true if the key is being held down such that it is automatically repeating.
        /// </summary>
        public bool Repeat => JSRef!.Get<bool>("repeat");

        /// <summary>
        /// Returns a number representing the location of the key on the keyboard or other input device.
        /// </summary>
        public KeyLocation Location => JSRef!.Get<KeyLocation>("location");

        /// <summary>
        /// Returns a boolean value indicating if a modifier key such as Alt, Shift, Ctrl, or Meta, was pressed when the event was created.
        /// </summary>
        /// <returns></returns>
        public bool GetModifierState() => JSRef!.Call<bool>("getModifierState");
    }
}
