using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DeviceMotionEvent interface provides web developers with information about the speed of changes for the device's position and orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/API/DeviceMotionEvent
    /// </summary>
    public class DeviceMotionEvent : Event
    {
        /// <summary>
        /// Default deserialize constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DeviceMotionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public DeviceMotionXYZ Acceleration => JSRef.Get<DeviceMotionXYZ>("acceleration");
        public DeviceMotionXYZ AccelerationIncludingGravity => JSRef.Get<DeviceMotionXYZ>("accelerationIncludingGravity");
        public DeviceMotionAlphaBetaGamma RotationRate => JSRef.Get<DeviceMotionAlphaBetaGamma>("rotationRate");
        public double Interval => JSRef.Get<double>("interval");

    }
}
