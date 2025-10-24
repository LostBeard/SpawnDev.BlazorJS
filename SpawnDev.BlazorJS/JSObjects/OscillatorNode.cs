using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The OscillatorNode interface represents a periodic waveform, such as a sine wave. It is an AudioScheduledSourceNode audio-processing module that causes a specified frequency of a given wave to be created—in effect, a constant tone.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/OscillatorNode
    /// </summary>
    public class OscillatorNode : AudioScheduledSourceNode
    {
        /// <inheritdoc/>
        public OscillatorNode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance of the OscillatorNode interface.<br/>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        public OscillatorNode(AudioContext context, OscillatorNodeOptions? options = null) : base(options == null ? JS.New(nameof(OscillatorNode), context) : JS.New(nameof(OscillatorNode), context, options)) { }
        /// <summary>
        /// An a-rate AudioParam representing the frequency of oscillation in hertz (though the AudioParam returned is read-only, the value it represents is not). The default value is 440 Hz (a standard middle-A note).
        /// </summary>
        public AudioParam Frequency => JSRef!.Get<AudioParam>("frequency");
        /// <summary>
        /// An a-rate AudioParam representing detuning of oscillation in cents (though the AudioParam returned is read-only, the value it represents is not). The default value is 0.
        /// </summary>
        public AudioParam Detune => JSRef!.Get<AudioParam>("detune");
        /// <summary>
        /// A string which specifies the shape of waveform to play; this can be one of a number of standard values, or custom to use a PeriodicWave to describe a custom waveform. Different waves will produce different tones. Standard values are "sine", "square", "sawtooth", "triangle" and "custom". The default is "sine".
        /// </summary>
        public EnumString<OscillatorType> Type
        {
            get => JSRef!.Get<EnumString<OscillatorType>>("type");
            set => JSRef!.Set("type", value);
        }
        /// <summary>
        /// The setPeriodicWave() method of the OscillatorNode interface is used to point to a PeriodicWave defining a periodic waveform that can be used to shape the oscillator's output, when type is custom.
        /// </summary>
        /// <param name="periodicWave">A PeriodicWave object representing the waveform to use as the shape of the oscillator's output.</param>
        public void SetPeriodicWave(PeriodicWave periodicWave) => JSRef!.InvokeVoid("setPeriodicWave", periodicWave);


    }
}
