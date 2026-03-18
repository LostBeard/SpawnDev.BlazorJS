using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Web Audio API's AudioParam interface represents an audio-related parameter, usually a parameter of an AudioNode (such as GainNode.gain).<br/>
    /// Each AudioParam has a list of events, initially empty, that define when and how values change. When this list is not empty, changes using the AudioParam.value attributes are ignored. This list of events allows us to schedule changes that have to happen at very precise times, using arbitrary timeline-based automation curves. The time used is the one defined in AudioContext.currentTime.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioParam
    /// </summary>
    public class AudioParam : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AudioParam(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Represents the initial value of the attribute as defined by the specific AudioNode creating the AudioParam.
        /// </summary>
        public float DefaultValue => JSRef!.Get<float>("defaultValue");
        /// <summary>
        /// Represents the maximum possible value for the parameter's nominal (effective) range.
        /// </summary>
        public float MaxValue => JSRef!.Get<float>("maxValue");
        /// <summary>
        /// Represents the minimum possible value for the parameter's nominal (effective) range.
        /// </summary>
        public float MinValue => JSRef!.Get<float>("minValue");
        /// <summary>
        /// Represents the parameter's current value as of the current time; initially set to the value of defaultValue.
        /// </summary>
        public float Value { get => JSRef!.Get<float>("value"); set => JSRef!.Set("value", value); }
        /// <summary>
        /// Schedules an instant change to the value at a precise time.
        /// </summary>
        public AudioParam SetValueAtTime(float value, double startTime) => JSRef!.Call<AudioParam>("setValueAtTime", value, startTime);
        /// <summary>
        /// Schedules a gradual linear change to the value.
        /// </summary>
        public AudioParam LinearRampToValueAtTime(float value, double endTime) => JSRef!.Call<AudioParam>("linearRampToValueAtTime", value, endTime);
        /// <summary>
        /// Schedules a gradual exponential change to the value. The value must be positive.
        /// </summary>
        public AudioParam ExponentialRampToValueAtTime(float value, double endTime) => JSRef!.Call<AudioParam>("exponentialRampToValueAtTime", value, endTime);
        /// <summary>
        /// Schedules the start of a change to the value, following an exponential approach to a target value at a given rate.
        /// </summary>
        public AudioParam SetTargetAtTime(float target, double startTime, float timeConstant) => JSRef!.Call<AudioParam>("setTargetAtTime", target, startTime, timeConstant);
        /// <summary>
        /// Schedules the values to follow a set of values defined by a Float32Array scaled to fit into a given interval.
        /// </summary>
        public AudioParam SetValueCurveAtTime(float[] values, double startTime, double duration) => JSRef!.Call<AudioParam>("setValueCurveAtTime", values, startTime, duration);
        /// <summary>
        /// Cancels all scheduled future changes to the AudioParam.
        /// </summary>
        public AudioParam CancelScheduledValues(double startTime) => JSRef!.Call<AudioParam>("cancelScheduledValues", startTime);
        /// <summary>
        /// Cancels all scheduled future changes to the AudioParam but holds its value at a given time.
        /// </summary>
        public AudioParam CancelAndHoldAtTime(double cancelTime) => JSRef!.Call<AudioParam>("cancelAndHoldAtTime", cancelTime);
    }
}
