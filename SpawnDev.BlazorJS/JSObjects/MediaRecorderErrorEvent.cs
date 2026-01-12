using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaRecorderErrorEvent interface represents errors which occur during recording.
    /// </summary>
    public class MediaRecorderErrorEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MediaRecorderErrorEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
