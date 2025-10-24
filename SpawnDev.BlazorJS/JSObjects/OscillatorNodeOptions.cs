using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object whose properties specify the initial values for the oscillator node's properties. Any properties omitted from the object will take on the default value as documented.
    /// </summary>
    public class OscillatorNodeOptions : AudioNodeOptions
    {
        /// <summary>
        /// The shape of the wave produced by the node. 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<OscillatorType>? Type { get; set; }
        /// <summary>
        /// The frequency (in hertz) of the periodic waveform. Its default is 440.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Frequency { get; set; }
        /// <summary>
        /// A detuning value (in cents) which will offset the frequency by the given amount. Its default is 0.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Detune { get; set; }
        /// <summary>
        /// An arbitrary period waveform described by a PeriodicWave object.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PeriodicWave? PeriodicWave { get; set; }
    }
}
