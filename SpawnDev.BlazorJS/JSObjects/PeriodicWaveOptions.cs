using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PeriodicWave/PeriodicWave#options
    /// </summary>
    public class PeriodicWaveOptions : AudioNodeOptions
    {
        /// <summary>
        /// An array containing the cosine terms of the Fourier series defining the periodic waveform. The first element (index 0) represents the DC offset, the second element (index 1) represents the fundamental frequency, the third element (index 2) represents the second harmonic, and so on.
        /// </summary>
        public Float32Array Real { get; set; }
        /// <summary>
        /// An array containing the sine terms of the Fourier series defining the periodic waveform. The first element (index 0) is ignored, the second element (index 1) represents the fundamental frequency, the third element (index 2) represents the second harmonic, and so on.
        /// </summary>
        public Float32Array Imag { get; set; }
        /// <summary>
        /// A Boolean value which, if true, indicates that the values in the real and imaginary arrays represent normalized values. If false, the values represent unnormalized values. The default value is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DisableNormalization { get; set; }
    }
}
