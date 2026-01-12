using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MIDIOutputMap read-only interface of the Web MIDI API provides the set of MIDI output ports that are currently available.
    /// </summary>
    public class MIDIOutputMap : Map<string, MIDIOutput>
    {
        #region Constructors
        /// <summary>
        /// Creates a new instance of <see cref="MIDIOutputMap"/>.
        /// </summary>
        /// <param name="_ref"></param>
        public MIDIOutputMap(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
    }
}
