using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PointerEvent interface represents the state of a DOM event produced by a pointer such as the geometry of the contact point, the device type that generated the event, the amount of pressure that was applied on the contact surface, etc.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent
    /// </summary>
    public class PointerEvent : MouseEvent
    {
        /// <summary>
        /// The PointerEvent() constructor creates a new synthetic and untrusted PointerEvent object instance.
        /// </summary>
        /// <param name="type">A string representing the name of the event (see PointerEvent event types).</param>
        public PointerEvent(string type) : base(JS.New(nameof(PointerEvent), type)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PointerEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        #region Properties
        /// <summary>
        /// Represents the angle between a transducer (a pointer or stylus) axis and the X-Y plane of a device screen.
        /// </summary>
        public double AltitudeAngle => JSRef!.Get<double>("altitudeAngle");
        /// <summary>
        /// Represents the angle between the Y-Z plane and the plane containing both the transducer (a pointer or stylus) axis and the Y axis.
        /// </summary>
        public double AzimuthAngle => JSRef!.Get<double>("azimuthAngle");
        /// <summary>
        /// A unique identifier for the pointer causing the event.
        /// </summary>
        public int PointerId => JSRef!.Get<int>("pointerId");
        /// <summary>
        /// The width (magnitude on the X axis), in CSS pixels, of the contact geometry of the pointer.
        /// </summary>
        public int Width => JSRef!.Get<int>("width");
        /// <summary>
        /// The height (magnitude on the Y axis), in CSS pixels, of the contact geometry of the pointer.
        /// </summary>
        public int Height => JSRef!.Get<int>("height");
        /// <summary>
        /// The normalized pressure of the pointer input in the range 0 to 1, where 0 and 1 represent the minimum and maximum pressure the hardware is capable of detecting, respectively.
        /// </summary>
        public double Pressure => JSRef!.Get<double>("pressure");
        /// <summary>
        /// The normalized tangential pressure of the pointer input (also known as barrel pressure or cylinder stress) in the range -1 to 1, where 0 is the neutral position of the control.
        /// </summary>
        public double TangentialPressure => JSRef!.Get<double>("tangentialPressure");
        /// <summary>
        /// The plane angle (in degrees, in the range of -90 to 90) between the Y–Z plane and the plane containing both the pointer (e.g. pen stylus) axis and the Y axis.
        /// </summary>
        public double TiltX => JSRef!.Get<double>("tiltX");
        /// <summary>
        /// The plane angle (in degrees, in the range of -90 to 90) between the X–Z plane and the plane containing both the pointer (e.g. pen stylus) axis and the X axis.
        /// </summary>
        public double TiltY => JSRef!.Get<double>("tiltY");
        /// <summary>
        /// The clockwise rotation of the pointer (e.g. pen stylus) around its major axis in degrees, with a value in the range 0 to 359.
        /// </summary>
        public double Twist => JSRef!.Get<double>("twist");
        /// <summary>
        /// Indicates the device type that caused the event (mouse, pen, touch, etc.).
        /// </summary>
        public string PointerType => JSRef!.Get<string>("pointerType");
        /// <summary>
        /// Indicates if the pointer represents the primary pointer of this pointer type.
        /// </summary>
        public bool IsPrimary => JSRef!.Get<bool>("isPrimary");
        #endregion
        #region Methods
        /// <summary>
        /// Returns a sequence of all PointerEvent instances that were coalesced into the dispatched pointermove event.
        /// </summary>
        public Array<PointerEvent> GetCoalescedEvents => JSRef!.Call<Array<PointerEvent>>("getCoalescedEvents");
        /// <summary>
        /// Returns a sequence of PointerEvent instances that the browser predicts will follow the dispatched pointermove event's coalesced events.
        /// </summary>
        public Array<PointerEvent> GetPredictedEvents => JSRef!.Call<Array<PointerEvent>>("getPredictedEvents");
        #endregion
    }
}
