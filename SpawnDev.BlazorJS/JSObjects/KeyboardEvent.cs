using Microsoft.JSInterop;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// KeyboardEvent objects describe a user interaction with the keyboard<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent
    /// </summary>
    public class KeyboardEvent : Event
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
        public KeyLocation Location => (KeyLocation)JSRef!.Get<int>("location");

        /// <summary>
        /// Returns a boolean value indicating if a modifier key such as Alt, Shift, Ctrl, or Meta, was pressed when the event was created.
        /// </summary>
        /// <returns></returns>
        public bool GetModifierState() => JSRef!.Call<bool>("getModifierState");
    }

    /// <summary>
    /// The following constants identify which part of the keyboard the key event originates from.
    /// </summary>
    public enum KeyLocation
    {
        /// <summary>
        /// The key described by the event is not identified as being located in a particular area of the keyboard.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent#constants
        /// </summary>
        DomKeyLocationStandard = 0x00,

        /// <summary>
        /// The key is one which may exist in multiple locations on the keyboard and, in this instance, is on the left side of the keyboard.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent#constants
        /// </summary>        
        DomKeyLocationLeft = 0x01,

        /// <summary>
        /// The key is one which may exist in multiple positions on the keyboard and, in this case, is located on the right side of the keyboard.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent#constants
        /// </summary>
        DomKeyLocationRight = 0x02,

        /// <summary>
        /// The key is located on the numeric keypad, or is a virtual key associated with the numeric keypad if there's more than one place the key could originate from.<br/>
        /// https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent#constants
        /// </summary>
        DomKeyLocationNumpad = 0x03,
    }
}
