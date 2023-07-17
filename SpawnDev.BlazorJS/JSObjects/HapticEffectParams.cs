namespace SpawnDev.BlazorJS.JSObjects
{
    public class HapticEffectParams
    {
        /// <summary>
        /// The duration of the effect in milliseconds.
        /// </summary>
        public double Duration { get; set; }
        /// <summary>
        /// The delay in milliseconds before the effect is started.
        /// </summary>
        public double StartDelay { get; set; }
        /// <summary>
        /// Rumble intensity of the low-frequency (strong) rumble motors, normalized to the range between 0.0 and 1.0.
        /// </summary>
        public double StrongMagnitude { get; set; }
        /// <summary>
        /// Rumble intensity of the high-frequency (weak) rumble motors, normalized to the range between 0.0 and 1.0.
        /// </summary>
        public double WeakMagnitude { get; set; }
    }
}
