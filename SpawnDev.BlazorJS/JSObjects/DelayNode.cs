using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BaseAudioContext/createDelay
    /// </summary>
    public class DelayNode : AudioNode
    {
        /// <inheritdoc/>
        public DelayNode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Crates a new instance
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        public DelayNode(BaseAudioContext context, DelayNodeOptions? options = null) : base(options == null ? JS.New(nameof(DelayNode), context) : JS.New(nameof(DelayNode), context, options)) { }
        /// <summary>
        /// An a-rate AudioParam representing the amount of delay to apply, specified in seconds.
        /// </summary>
        public AudioParam DelayTime => JSRef!.Get<AudioParam>("delayTime");
    }
}
