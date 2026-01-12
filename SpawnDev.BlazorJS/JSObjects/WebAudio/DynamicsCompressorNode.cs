using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DynamicsCompressorNode interface provides a compression effect, which lowers the volume of the loudest parts of the signal in order to help prevent clipping and distortion that can occur when multiple sounds are played and mixed together at once.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DynamicsCompressorNode
    /// </summary>
    public class DynamicsCompressorNode : AudioNode
    {
        /// <inheritdoc/>
        public DynamicsCompressorNode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An k-rate AudioParam representing the decibel value above which the compression will start taking effect.
        /// </summary>
        public AudioParam Threshold => JSRef!.Get<AudioParam>("threshold");
        /// <summary>
        /// An k-rate AudioParam representing the amount of change, in dB, needed in the input for a 1 dB change in the output.
        /// </summary>
        public AudioParam Knee => JSRef!.Get<AudioParam>("knee");
        /// <summary>
        /// An k-rate AudioParam representing the amount of attenuation, in dB, that is being applied to the signal.
        /// </summary>
        public AudioParam Ratio => JSRef!.Get<AudioParam>("ratio");
        /// <summary>
        /// An k-rate AudioParam representing the amount of time, in seconds, required to reduce the gain by 10 dB.
        /// </summary>
        public AudioParam Attack => JSRef!.Get<AudioParam>("attack");
        /// <summary>
        /// An k-rate AudioParam representing the amount of time, in seconds, required to increase the gain by 10 dB.
        /// </summary>
        public AudioParam Release => JSRef!.Get<AudioParam>("release");
    }
}
