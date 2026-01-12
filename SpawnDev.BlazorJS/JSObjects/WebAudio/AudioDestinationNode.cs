using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioDestinationNode
    /// </summary>
    public class AudioDestinationNode : AudioNode
    {
        /// <inheritdoc/>
        public AudioDestinationNode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An unsigned long defining the maximum number of channels that the physical device can handle.
        /// </summary>
        public long MaxChannelCount => JSRef!.Get<long>("maxChannelCount");
    }
}
