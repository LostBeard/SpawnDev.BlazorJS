using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AudioListener interface represents the position and orientation of the unique person listening to the audio scene, and is used in audio spatialization. All PannerNodes spatialize in relation to the AudioListener stored in the BaseAudioContext.listener attribute.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioListener
    /// </summary>
    public class AudioListener : JSObject
    {
        /// <inheritdoc/>
        public AudioListener(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Represents the horizontal position of the listener in a right-hand cartesian coordinate system. The default is 0.
        /// </summary>
        public AudioParam PositionX => JSRef!.Get<AudioParam>("positionX");
        /// <summary>
        /// Represents the vertical position of the listener in a right-hand cartesian coordinate system. The default is 0.
        /// </summary>
        public AudioParam PositionY => JSRef!.Get<AudioParam>("positionY");
        /// <summary>
        /// Represents the longitudinal (back and forth) position of the listener in a right-hand cartesian coordinate system. The default is 0.
        /// </summary>
        public AudioParam PositionZ => JSRef!.Get<AudioParam>("positionZ");
        /// <summary>
        /// Represents the horizontal position of the listener's forward direction in the same cartesian coordinate system as the position (positionX, positionY, and positionZ) values. The forward and up values are linearly independent of each other. The default is 0.
        /// </summary>
        public AudioParam ForwardX => JSRef!.Get<AudioParam>("forwardX");
        /// <summary>
        /// Represents the vertical position of the listener's forward direction in the same cartesian coordinate system as the position (positionX, positionY, and positionZ) values. The forward and up values are linearly independent of each other. The default is 0.
        /// </summary>
        public AudioParam ForwardY => JSRef!.Get<AudioParam>("forwardY");
        /// <summary>
        /// Represents the longitudinal (back and forth) position of the listener's forward direction in the same cartesian coordinate system as the position (positionX, positionY, and positionZ) values. The forward and up values are linearly independent of each other. The default is -1.
        /// </summary>
        public AudioParam ForwardZ => JSRef!.Get<AudioParam>("forwardZ");
        /// <summary>
        /// Represents the horizontal position of the top of the listener's head in the same cartesian coordinate system as the position (positionX, positionY, and positionZ) values. The forward and up values are linearly independent of each other. The default is 0.
        /// </summary>
        public AudioParam UpX => JSRef!.Get<AudioParam>("upX");
        /// <summary>
        /// Represents the vertical position of the top of the listener's head in the same cartesian coordinate system as the position (positionX, positionY, and positionZ) values. The forward and up values are linearly independent of each other. The default is 1.
        /// </summary>
        public AudioParam UpY => JSRef!.Get<AudioParam>("upY");
        /// <summary>
        /// Represents the longitudinal (back and forth) position of the top of the listener's head in the same cartesian coordinate system as the position (positionX, positionY, and positionZ) values. The forward and up values are linearly independent of each other. The default is 0.
        /// </summary>
        public AudioParam UpZ => JSRef!.Get<AudioParam>("upZ");
    }
}
