using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GainNode interface represents a change in volume. It is an AudioNode audio-processing module that causes a given gain to be applied to the input data before its propagation to the output. A GainNode always has exactly one input and one output, both with the same number of channels.<br/>
    /// The gain is a unitless value, changing with time, that is multiplied to each corresponding sample of all input channels. If modified, the new gain is instantly applied, causing unaesthetic 'clicks' in the resulting audio. To prevent this from happening, never change the value directly but use the exponential interpolation methods on the AudioParam interface.
    /// https://developer.mozilla.org/en-US/docs/Web/API/GainNode
    /// </summary>
    public class GainNode : AudioNode
    {
        /// <inheritdoc/>
        public GainNode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The GainNode() constructor of the Web Audio API creates a new GainNode object which is an AudioNode that represents a change in volume.
        /// </summary>
        /// <param name="context">A reference to a BaseAudioContext, e.g., an AudioContext.</param>
        /// <param name="options"></param>
        public GainNode(BaseAudioContext context, GainNodeOptions? options = null) : base(options == null ? JS.New(nameof(GainNode), context) : JS.New(nameof(GainNode), context, options)) { }
        /// <summary>
        /// An a-rate AudioParam representing the amount of gain to apply. You have to set AudioParam.value or use the methods of AudioParam to change the effect of gain.
        /// </summary>
        public AudioParam Gain => JSRef!.Get<AudioParam>("gain");
    }
}
