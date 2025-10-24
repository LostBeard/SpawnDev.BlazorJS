using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PeriodicWave interface defines a periodic waveform that can be used to shape the output of an OscillatorNode.<br/>
    /// PeriodicWave has no inputs or outputs; it is used to define custom oscillators when calling OscillatorNode.setPeriodicWave(). The PeriodicWave itself is created/returned by BaseAudioContext.createPeriodicWave.
    /// </summary>
    public class PeriodicWave : JSObject
    {
        /// <inheritdoc/>
        public PeriodicWave(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PeriodicWave"/> class, representing a periodic waveform that
        /// can be used as a source in an audio context.
        /// </summary>
        /// <param name="context">The <see cref="AudioContext"/> in which this periodic waveform will be used.</param>
        /// <param name="options">Optional configuration settings for the periodic waveform, such as the real and imaginary components of the
        /// waveform. If null, default options are used.</param>
        public PeriodicWave(AudioContext context, PeriodicWaveOptions? options = null) : base(options == null ? JS.New(nameof(PeriodicWave), context) : JS.New(nameof(PeriodicWave), context, options)) { }
    }
}
