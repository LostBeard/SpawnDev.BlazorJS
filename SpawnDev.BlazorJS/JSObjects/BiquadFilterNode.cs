using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BiquadFilterNode
    /// </summary>
    public class BiquadFilterNode : AudioNode
    {
        /// <inheritdoc/>
        public BiquadFilterNode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The BiquadFilterNode() constructor of the Web Audio API creates a new BiquadFilterNode object, which represents a simple low-order filter.
        /// </summary>
        /// <param name="context">A reference to an AudioContext.</param>
        /// <param name="options"></param>
        public BiquadFilterNode(AudioContext context, BiquadFilterNodeOptions? options = null) : base(options == null ? JS.New(nameof(BiquadFilterNode), context) : JS.New(nameof(BiquadFilterNode), context, options)) { }
        /// <summary>
        /// The getFrequencyResponse() method of the BiquadFilterNode interface takes the current filtering algorithm's settings and calculates the frequency response for frequencies specified in a specified array of frequencies.<br/>
        /// The two output arrays, magResponseOutput and phaseResponseOutput, must be created before calling this method; they must be the same size as the array of input frequency values (frequencyArray).
        /// </summary>
        /// <param name="frequencyArray">A Float32Array containing an array of frequencies, specified in Hertz, which you want to filter.</param>
        /// <param name="magResponseOutput">A Float32Array to receive the computed magnitudes of the frequency response for each frequency value in the frequencyArray. For any frequency in frequencyArray whose value is outside the range 0.0 to sampleRate/2 (where sampleRate is the sample rate of the AudioContext), the corresponding value in this array is NaN. These are unitless values.</param>
        /// <param name="phaseResponseOutput">A Float32Array to receive the computed phase response values in radians for each frequency value in the input frequencyArray. For any frequency in frequencyArray whose value is outside the range 0.0 to sampleRate/2 (where sampleRate is the sample rate of the AudioContext), the corresponding value in this array is NaN.</param>
        public void GetFrequencyResponse(Float32Array frequencyArray, Float32Array magResponseOutput, Float32Array phaseResponseOutput) => JSRef!.CallVoid("getFrequencyResponse", frequencyArray, magResponseOutput, phaseResponseOutput);
        /// <summary>
        /// An a-rate AudioParam, a double representing a frequency in the current filtering algorithm measured in hertz (Hz).
        /// </summary>
        public float Frequency => JSRef!.Get<float>("frequency");
        /// <summary>
        /// An a-rate AudioParam representing detuning of the frequency in cents.
        /// </summary>
        public float Detune => JSRef!.Get<float>("detune");
        /// <summary>
        /// An a-rate AudioParam, a double representing a Q factor, or quality factor.
        /// </summary>
        public float Q => JSRef!.Get<float>("Q");
        /// <summary>
        /// An a-rate AudioParam, a double representing the gain used in the current filtering algorithm.
        /// </summary>
        public float Gain => JSRef!.Get<float>("gain");
        /// <summary>
        /// A string value defining the kind of filtering algorithm the node is implementing.
        /// </summary>
        public string Type => JSRef!.Get<string>("type");
    }
}
