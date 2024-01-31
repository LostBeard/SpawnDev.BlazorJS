using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AnalyserNode interface represents a node able to provide real-time frequency and time-domain analysis information. It is an AudioNode that passes the audio stream unchanged from the input to the output, but allows you to take the generated data, process it, and create audio visualizations.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/AnalyserNode
    /// </summary>
    public class AnalyserNode : AudioNode
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AnalyserNode(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// An unsigned long value representing the size of the FFT (Fast Fourier Transform) to be used to determine the frequency domain.
        /// </summary>
        public ulong FFTSize => JSRef.Get<ulong>("fftSize");

        /// <summary>
        /// Copies the current waveform, or time-domain, data into a Float32Array array passed into it.
        /// </summary>
        /// <param name="float32Array"></param>
        public void GetFloatTimeDomainData(Float32Array float32Array) => JSRef.CallVoid("getFloatTimeDomainData", float32Array);
    }
}
