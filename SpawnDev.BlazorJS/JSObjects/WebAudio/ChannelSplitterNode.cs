using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ChannelSplitterNode interface, often used in conjunction with its opposite, ChannelMergerNode, separates the different channels of an audio source into a set of mono outputs. This is useful for accessing each channel separately, e.g. for performing channel mixing where a separate gain must be controlled on each channel.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ChannelSplitterNode
    /// </summary>
    public class ChannelSplitterNode : AudioNode
    {
        public ChannelSplitterNode(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
