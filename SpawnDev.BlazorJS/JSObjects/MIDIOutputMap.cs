using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MIDIOutputMap read-only interface of the Web MIDI API provides the set of MIDI output ports that are currently available.
    /// </summary>
    public class MIDIOutputMap : MapReadOnly<string, MIDIOutput>
    {
        #region Constructors
        public MIDIOutputMap(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
    }
}
