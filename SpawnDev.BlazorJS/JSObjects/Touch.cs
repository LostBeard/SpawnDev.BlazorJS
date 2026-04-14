using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Touch interface represents a single contact point on a touch-sensitive device. The contact point is commonly a finger or stylus and the device may be a touchscreen or trackpad.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Touch
    /// </summary>
    public class Touch : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Touch(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// A unique identifier for this Touch object. A given touch point (say, by a finger)
        /// will have the same identifier for the duration of its movement around the surface.
        /// </summary>
        public long Identifier => JSRef!.Get<long>("identifier");

        /// <summary>
        /// The X coordinate of the touch point relative to the left edge of the browser viewport,
        /// not including any scroll offset.
        /// </summary>
        public double ClientX => JSRef!.Get<double>("clientX");

        /// <summary>
        /// The Y coordinate of the touch point relative to the top edge of the browser viewport,
        /// not including any scroll offset.
        /// </summary>
        public double ClientY => JSRef!.Get<double>("clientY");

        /// <summary>
        /// The X coordinate of the touch point relative to the left edge of the document.
        /// </summary>
        public double PageX => JSRef!.Get<double>("pageX");

        /// <summary>
        /// The Y coordinate of the touch point relative to the top edge of the document.
        /// </summary>
        public double PageY => JSRef!.Get<double>("pageY");

        /// <summary>
        /// The X coordinate of the touch point relative to the left edge of the screen.
        /// </summary>
        public double ScreenX => JSRef!.Get<double>("screenX");

        /// <summary>
        /// The Y coordinate of the touch point relative to the top edge of the screen.
        /// </summary>
        public double ScreenY => JSRef!.Get<double>("screenY");

        /// <summary>
        /// The Element on which the touch point started when it was first placed on the surface.
        /// </summary>
        public EventTarget? Target => JSRef!.Get<EventTarget?>("target");

        /// <summary>
        /// The X radius of the ellipse that most closely circumscribes the area of contact with the screen.
        /// </summary>
        public double RadiusX => JSRef!.Get<double>("radiusX");

        /// <summary>
        /// The Y radius of the ellipse that most closely circumscribes the area of contact with the screen.
        /// </summary>
        public double RadiusY => JSRef!.Get<double>("radiusY");

        /// <summary>
        /// The angle (in degrees) that the ellipse described by radiusX and radiusY must be rotated,
        /// clockwise, to most accurately cover the area of contact.
        /// </summary>
        public double RotationAngle => JSRef!.Get<double>("rotationAngle");

        /// <summary>
        /// The amount of pressure being applied to the surface by the user, as a float
        /// between 0.0 (no pressure) and 1.0 (maximum pressure).
        /// </summary>
        public double Force => JSRef!.Get<double>("force");
    }
}
