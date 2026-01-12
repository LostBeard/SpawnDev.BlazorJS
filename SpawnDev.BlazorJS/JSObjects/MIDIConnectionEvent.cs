using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MIDIConnectionEvent interface of the Web MIDI API is the event passed to the statechange event of the MIDIAccess interface and the statechange event of the MIDIPort interface. This occurs any time a new port becomes available, or when a previously available port becomes unavailable. For example, this event is fired whenever a MIDI device is either plugged in to or unplugged from a computer.
    /// </summary>
    public class MIDIConnectionEvent : Event
    {
        /// <summary>
        /// Creates a new instance of <see cref="MIDIConnectionEvent"/>.
        /// </summary>
        /// <param name="_ref"></param>
        public MIDIConnectionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a reference to a MIDIPort instance for a port that has been connected or disconnected.
        /// </summary>
        public MIDIPort Port => JSRef!.Get<MIDIPort>("port");
    }
}
