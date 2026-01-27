using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DeviceOrientationEvent object provides web developers with information from the physical orientation of the device running the web page.<br/>
    /// https://www.w3.org/TR/orientation-event/#deviceorientation<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DeviceOrientationEvent
    /// </summary>
    public class DeviceOrientationEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DeviceOrientationEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A boolean that indicates whether or not the device is providing orientation data absolutely.
        /// </summary>
        public bool Absolute => JSRef!.Get<bool>("absolute");
        /// <summary>
        /// A number representing the motion of the device around the z axis, express in degrees with values ranging from 0 (inclusive) to 360 (exclusive).
        /// </summary>
        public double? Alpha => JSRef!.Get<double?>("alpha");
        /// <summary>
        /// A number representing the motion of the device around the x axis, express in degrees with values ranging from -180 (inclusive) to 180 (exclusive). This represents a front to back motion of the device.
        /// </summary>
        public double? Beta => JSRef!.Get<double?>("beta");
        /// <summary>
        /// A number representing the motion of the device around the y axis, express in degrees with values ranging from -90 (inclusive) to 90 (exclusive). This represents a left to right motion of the device.
        /// </summary>
        public double? Gamma => JSRef!.Get<double?>("gamma");
        /// <summary>
        /// Gets the compass heading in degrees as reported by the device's webkit-compatible orientation sensor.
        /// </summary>
        /// <remarks>This property is specific to browsers that implement the non-standard
        /// 'webkitCompassHeading' property, primarily on iOS devices. The value may be null if the sensor is
        /// unavailable or unsupported by the browser.</remarks>
        public double? WebkitCompassHeading => JSRef!.Get<double?>("webkitCompassHeading");
        /// <summary>
        /// The accuracy of the compass means that the deviation is positive or negative. It's usually 10.
        /// <remarks>This property is specific to browsers that implement the non-standard</remarks>
        /// </summary>
        public double? WebkitCompassAccuracy => JSRef!.Get<double?>("webkitCompassAccuracy");
        /// <summary>
        /// Requests permission from the user to access device orientation events.
        /// </summary>
        /// <remarks>This method is typically required on certain platforms, such as iOS, where explicit
        /// user permission is needed to access device orientation events. The returned permission status should be
        /// checked before attempting to use device orientation data.</remarks>
        /// <param name="absolute">A value indicating whether to request permission in absolute mode. If <see langword="true"/>, requests
        /// absolute orientation data; otherwise, requests relative orientation data.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a string indicating the
        /// permission status, such as "granted", "denied", or "prompt".</returns>
        public static Task<string> RequestPermission(bool absolute = false) => JS.CallAsync<string>("DeviceOrientationEvent.requestPermission", absolute);
        /// <summary>
        /// Returns true if the DeviceOrientationEvent.requestPermission method is supported in the current environment.
        /// </summary>
        public static bool RequestPermissionSupported => JS.IsUndefined("DeviceOrientationEvent?.requestPermission") == false;
    }
}
