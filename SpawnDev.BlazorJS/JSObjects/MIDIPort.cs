using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MIDIPort interface of the Web MIDI API represents a MIDI input or output port.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/MIDIPort
    /// </summary>
    public class MIDIPort : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MIDIPort(IJSInProcessObjectReference _ref) : base(_ref) { }

        #region Properties;
        /// <summary>
        /// Returns a string containing the unique ID of the port.
        /// </summary>
        public string Id => JSRef!.Get<string>("id");
        /// <summary>
        /// Returns a string containing the manufacturer of the port.
        /// </summary>
        public string Manufacturer => JSRef!.Get<string>("manufacturer");
        /// <summary>
        /// Returns a string containing the system name of the port.
        /// </summary>
        public string Name => JSRef!.Get<string>("name");
        /// <summary>
        /// Returns a string containing the type of the port
        /// </summary>
        public string Type => JSRef!.Get<string>("type");
        /// <summary>
        /// Returns a string containing the version of the port.
        /// </summary>
        public string Version => JSRef!.Get<string>("version");
        /// <summary>
        /// Returns a string containing the state of the port
        /// </summary>
        public string State => JSRef!.Get<string>("state");
        /// <summary>
        /// Returns a string containing the connection state of the port
        /// </summary>
        public string Connection => JSRef!.Get<string>("connection");
        #endregion

        #region Methods
        /// <summary>
        /// Makes the MIDI device connected to this MIDIPort explicitly available, and returns a Promise which resolves once access to the port has been successful.
        /// </summary>
        public Task Open() => JSRef!.CallVoidAsync("open");
        /// <summary>
        /// Makes the MIDI device connected to this MIDIPort unavailable, changing the state from "open" to "closed". This returns a Promise which resolves once the port has been closed.
        /// </summary>
        public Task Close() => JSRef!.CallVoidAsync("close");
        #endregion

        #region Events
        /// <summary>
        /// Called when an existing port changes its state or connection.
        /// </summary>
        public JSEventCallback<MIDIConnectionEvent> OnStateChange { get => new JSEventCallback<MIDIConnectionEvent>("statechange", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
