using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MIDIInput interface of the Web MIDI API receives messages from a MIDI input port.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/MIDIInput
    /// </summary>
    public class MIDIInput : MIDIPort
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MIDIInput(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        /// <summary>
        /// Fired when the current port receives a MIDI message.
        /// </summary>
        public JSEventCallback<MIDIMessageEvent> OnMIDIMessage { get => new JSEventCallback<MIDIMessageEvent>("midimessage", AddEventListener, RemoveEventListener); set { } }
    }
}
