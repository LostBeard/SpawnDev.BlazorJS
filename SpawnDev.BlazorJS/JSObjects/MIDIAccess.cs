using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MIDIAccess interface of the Web MIDI API provides methods for listing MIDI input and output devices, and obtaining access to those devices.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/MIDIAccess
    /// </summary>
    public class MIDIAccess : EventTarget
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MIDIAccess(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns an instance of MIDIInputMap which provides access to any available MIDI input ports.
        /// </summary>
        public MIDIInputMap Inputs => JSRef.Get<MIDIInputMap>("inputs");
        /// <summary>
        /// Returns an instance of MIDIOutputMap which provides access to any available MIDI output ports.
        /// </summary>
        public MIDIOutputMap Outputs => JSRef.Get<MIDIOutputMap>("outputs");
        /// <summary>
        /// A boolean attribute indicating whether system exclusive support is enabled on the current MIDIAccess instance.
        /// </summary>
        public bool SysexEnabled => JSRef.Get<bool>("sysexEnabled");
        #endregion

        #region Methods
        #endregion

        #region Events
        /// <summary>
        /// Called whenever a new MIDI port is added or an existing port changes state.
        /// </summary>
        public JSEventCallback<MIDIConnectionEvent> OnStateChange { get => new JSEventCallback<MIDIConnectionEvent>("statechange", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
