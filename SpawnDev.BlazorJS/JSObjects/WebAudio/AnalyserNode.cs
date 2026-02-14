using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AnalyserNode interface represents a node able to provide real-time frequency and time-domain analysis information. It is an AudioNode that passes the audio stream unchanged from the input to the output, but allows you to take the generated data, process it, and create audio visualizations.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AnalyserNode
    /// </summary>
    public class AnalyserNode : AudioNode
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AnalyserNode(IJSInProcessObjectReference _ref) : base(_ref) { }

        #region Properties
        /// <summary>
        /// An unsigned long value representing the size of the FFT (Fast Fourier Transform) to be used to determine the frequency domain. Must be a power of 2 between 2^5 and 2^15 (32 to 32768). Defaults to 2048.
        /// </summary>
        public ulong FftSize { get => JSRef!.Get<ulong>("fftSize"); set => JSRef!.Set("fftSize", value); }

        /// <summary>
        /// An unsigned long value half that of the FFT size. This generally equates to the number of data values you will have to play with for the visualization.
        /// </summary>
        public ulong FrequencyBinCount => JSRef!.Get<ulong>("frequencyBinCount");

        /// <summary>
        /// A double value representing the minimum power value in the scaling range for the FFT analysis data, for conversion to unsigned byte values. Defaults to -100.
        /// </summary>
        public double MinDecibels { get => JSRef!.Get<double>("minDecibels"); set => JSRef!.Set("minDecibels", value); }

        /// <summary>
        /// A double value representing the maximum power value in the scaling range for the FFT analysis data, for conversion to unsigned byte values. Defaults to -30.
        /// </summary>
        public double MaxDecibels { get => JSRef!.Get<double>("maxDecibels"); set => JSRef!.Set("maxDecibels", value); }

        /// <summary>
        /// A double value representing the averaging constant with the last analysis frame. Defaults to 0.8.
        /// </summary>
        public double SmoothingTimeConstant { get => JSRef!.Get<double>("smoothingTimeConstant"); set => JSRef!.Set("smoothingTimeConstant", value); }
        #endregion

        #region Methods
        /// <summary>
        /// Copies the current frequency data into a Uint8Array (unsigned byte array) passed into it. Each item in the array represents the decibel value for a specific frequency.
        /// </summary>
        /// <param name="uint8Array"></param>
        public void GetByteFrequencyData(Uint8Array uint8Array) => JSRef!.CallVoid("getByteFrequencyData", uint8Array);

        /// <summary>
        /// Copies the current frequency data into a Float32Array passed into it. Each item in the array represents the decibel value for a specific frequency.
        /// </summary>
        /// <param name="float32Array"></param>
        public void GetFloatFrequencyData(Float32Array float32Array) => JSRef!.CallVoid("getFloatFrequencyData", float32Array);

        /// <summary>
        /// Copies the current waveform, or time-domain, data into a Uint8Array (unsigned byte array) passed into it.
        /// </summary>
        /// <param name="uint8Array"></param>
        public void GetByteTimeDomainData(Uint8Array uint8Array) => JSRef!.CallVoid("getByteTimeDomainData", uint8Array);

        /// <summary>
        /// Copies the current waveform, or time-domain, data into a Float32Array array passed into it.
        /// </summary>
        /// <param name="float32Array"></param>
        public void GetFloatTimeDomainData(Float32Array float32Array) => JSRef!.CallVoid("getFloatTimeDomainData", float32Array);
        #endregion
    }
}
