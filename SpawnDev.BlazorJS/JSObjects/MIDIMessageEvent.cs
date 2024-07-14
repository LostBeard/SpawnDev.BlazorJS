using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MIDIMessageEvent interface of the Web MIDI API represents the event passed to the midimessage event of the MIDIInput interface. A midimessage event is fired every time a MIDI message is sent from a device represented by a MIDIInput, for example when a MIDI keyboard key is pressed, a knob is tweaked, or a slider is moved.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MIDIMessageEvent
    /// </summary>
    public class MIDIMessageEvent : Event
    {
        public MIDIMessageEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A Uint8Array containing the data bytes of a single MIDI message. See the MIDI specification for more information on its form.
        /// </summary>
        public Uint8Array Data => JSRef!.Get<Uint8Array>("data");
    }
}
