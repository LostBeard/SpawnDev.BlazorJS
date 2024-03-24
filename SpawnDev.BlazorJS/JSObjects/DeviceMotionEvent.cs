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
        /// <summary>
        /// An object giving the acceleration of the device on the three axis X, Y and Z. Acceleration is expressed in m/s².
        /// </summary>
        public DeviceMotionXYZ Acceleration => JSRef.Get<DeviceMotionXYZ>("acceleration");
        /// <summary>
        /// An object giving the acceleration of the device on the three axis X, Y and Z with the effect of gravity. Acceleration is expressed in m/s².
        /// </summary>
        public DeviceMotionXYZ AccelerationIncludingGravity => JSRef.Get<DeviceMotionXYZ>("accelerationIncludingGravity");
        /// <summary>
        /// An object giving the rate of change of the device's orientation on the three orientation axis alpha, beta and gamma. Rotation rate is expressed in degrees per seconds.
        /// </summary>
        public DeviceMotionAlphaBetaGamma RotationRate => JSRef.Get<DeviceMotionAlphaBetaGamma>("rotationRate");
        /// <summary>
        /// A number representing the interval of time, in milliseconds, at which data is obtained from the device.
        /// </summary>
        public double Interval => JSRef.Get<double>("interval");

    }
}
