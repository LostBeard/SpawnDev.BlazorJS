using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Returned from AudioContext.GetOutputTimestamp()
    /// </summary>
    public class AudioTimestamp : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AudioTimestamp(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// contextTime: A point in the time coordinate system of the currentTime for the BaseAudioContext; the time after the audio context was first created.
        /// </summary>
        public double ContextTime => JSRef.Get<double>("contextTime");
        /// <summary>
        /// performanceTime: A point in the time coordinate system of a Performance interface; the time after the document containing the audio context was first rendered
        /// </summary>
        public double PerformanceTime => JSRef.Get<double>("performanceTime");
    }
}
