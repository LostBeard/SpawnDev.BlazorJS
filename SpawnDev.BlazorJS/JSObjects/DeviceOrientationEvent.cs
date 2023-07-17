using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DeviceOrientationEvent object provides web developers with information from the physical orientation of the device running the web page.
    /// </summary>
    public class DeviceOrientationEvent : Event
    {
        public DeviceOrientationEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A boolean that indicates whether or not the device is providing orientation data absolutely.
        /// </summary>
        public bool Absolute => JSRef.Get<bool>("absolute");
        /// <summary>
        /// A number representing the motion of the device around the z axis, express in degrees with values ranging from 0 (inclusive) to 360 (exclusive).
        /// </summary>
        public double Alpha => JSRef.Get<double>("alpha");
        /// <summary>
        /// A number representing the motion of the device around the x axis, express in degrees with values ranging from -180 (inclusive) to 180 (exclusive). This represents a front to back motion of the device.
        /// </summary>
        public double Beta => JSRef.Get<double>("beta");
        /// <summary>
        /// A number representing the motion of the device around the y axis, express in degrees with values ranging from -90 (inclusive) to 90 (exclusive). This represents a left to right motion of the device.
        /// </summary>
        public double Gamma => JSRef.Get<double>("gamma");
    }
}
