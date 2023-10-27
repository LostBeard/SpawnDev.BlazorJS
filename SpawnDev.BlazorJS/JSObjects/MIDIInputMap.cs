using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MIDIInputMap read-only interface of the Web MIDI API provides the set of MIDI input ports that are currently available.
    /// </summary>
    public class MIDIInputMap : MapReadOnly<string, MIDIInput>
    {
        #region Constructors
        public MIDIInputMap(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
    }
}
