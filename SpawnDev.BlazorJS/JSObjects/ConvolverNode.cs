using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ConvolverNode interface is an AudioNode that performs a Linear Convolution on a given AudioBuffer, often used to achieve a reverb effect. A ConvolverNode always has exactly one input and one output.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ConvolverNode
    /// </summary>
    public class ConvolverNode : AudioNode
    {
        /// <inheritdoc/>
        public ConvolverNode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Crates a new instance
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        public ConvolverNode(BaseAudioContext context, ConvolverNodeOptions? options = null) : base(options == null ? JS.New(nameof(ConvolverNode), context) : JS.New(nameof(ConvolverNode), context, options)) { }
        /// <summary>
        /// A mono, stereo, or 4-channel AudioBuffer containing the (possibly multichannel) impulse response used by the ConvolverNode to create the reverb effect.
        /// </summary>
        public AudioBuffer Buffer { get => JSRef!.Get<AudioBuffer>("buffer"); set => JSRef!.Set("buffer", value); }
        /// <summary>
        /// A boolean that controls whether the impulse response from the buffer will be scaled by an equal-power normalization when the buffer attribute is set, or not.
        /// </summary>
        public bool Normalize { get => JSRef!.Get<bool>("normalize"); set => JSRef!.Set("normalize", value); }
    }
}
