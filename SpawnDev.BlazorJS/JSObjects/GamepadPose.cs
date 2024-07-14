using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GamepadPose interface of the Gamepad API represents the pose of a WebVR controller at a given timestamp (which includes orientation, position, velocity, and acceleration information).<br/>
    /// This interface is accessible through the Gamepad.pose property.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GamepadPose
    /// </summary>
    public class GamepadPose : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public GamepadPose(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a boolean indicating whether the gamepad is capable of returning orientation information (true) or not (false).
        /// </summary>
        public bool HasOrientation => JSRef!.Get<bool>("hasOrientation");
        /// <summary>
        /// Returns a boolean indicating whether the gamepad is capable of returning position information (true) or not (false).
        /// </summary>
        public bool HasPosition => JSRef!.Get<bool>("hasPosition");
        /// <summary>
        /// The position read-only property of the GamepadPose interface returns the position of the Gamepad as a 3D vector.<br/>
        /// The coordinate system is as follows:<br/>
        /// Positive X is to the user's right.<br/>
        /// Positive Y is up.<br/>
        /// Positive Z is behind the user.<br/>
        /// Positions are measured in meters from an origin point — this point is the position the sensor was first read at.<br/>
        /// </summary>
        public Float32Array? Position => JSRef!.Get<Float32Array?>("position");
        /// <summary>
        /// The linearVelocity read-only property of the GamepadPose interface returns an array representing the linear velocity vector of the Gamepad, in meters per second.
        /// In other words, the current velocity at which the sensor is moving along the x, y, and z axes.
        /// </summary>
        public Float32Array? LinearVelocity => JSRef!.Get<Float32Array?>("linearVelocity");
        /// <summary>
        /// The linearAcceleration read-only property of the GamepadPose interface returns an array representing the linear acceleration vector of the Gamepad, in meters per second per second.
        /// In other words, the current acceleration of the sensor, along the x, y, and z axes.
        /// </summary>
        public Float32Array? LinearAcceleration => JSRef!.Get<Float32Array?>("linearAcceleration");
        /// <summary>
        /// The orientation read-only property of the GamepadPose interface returns the orientation of the Gamepad, as a quarternion value.<br/>
        /// The value is a Float32Array, made up of the following values:<br/>
        /// pitch — rotation around the X axis.<br/>
        /// yaw — rotation around the Y axis.<br/>
        /// roll — rotation around the Z axis.<br/>
        /// w — the fourth dimension(usually 1).<br/>
        /// The orientation yaw(rotation around the y axis) is relative to the initial yaw of the sensor when it was first read.
        /// </summary>
        public Float32Array? Orientation => JSRef!.Get<Float32Array?>("orientation");
        /// <summary>
        /// The angularVelocity read-only property of the GamepadPose interface returns an array representing the angular velocity vector of the Gamepad, in radians per second.
        /// In other words, the current velocity at which the sensor is rotating around the x, y, and z axes.
        /// </summary>
        public Float32Array? AngularVelocity => JSRef!.Get<Float32Array?>("angularVelocity");
        /// <summary>
        /// The angularAcceleration read-only property of the GamepadPose interface returns an array representing the angular acceleration vector of the Gamepad, in meters per second per second.
        /// In other words, the current acceleration of the sensor's rotation around the x, y, and z axes.
        /// </summary>
        public Float32Array? AngularAcceleration => JSRef!.Get<Float32Array?>("angularAcceleration");
    }
}
