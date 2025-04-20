namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GeolocationPosition interface represents the position of the concerned device at a given time. The position, represented by a GeolocationCoordinates object, comprehends the 2D position of the device, on a spheroid representing the Earth, but also its altitude and its speed.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GeolocationPosition
    /// </summary>
    public class GeolocationPosition
    {
        /// <summary>
        /// Returns a GeolocationCoordinates object defining the current location.
        /// </summary>
        public GeolocationCoordinates Coords { get; set; }
        /// <summary>
        /// Returns a timestamp, given as Unix time in milliseconds, representing the time at which the location was retrieved.
        /// </summary>
        public EpochDateTime Timestamp { get; set; }
    }
    ///// <summary>
    ///// The GeolocationPosition interface represents the position of the concerned device at a given time. The position, represented by a GeolocationCoordinates object, comprehends the 2D position of the device, on a spheroid representing the Earth, but also its altitude and its speed.<br/>
    ///// https://developer.mozilla.org/en-US/docs/Web/API/GeolocationPosition
    ///// </summary>
    //public class GeolocationPosition : JSObject
    //{
    //    ///<inheritdoc/>
    //    public GeolocationPosition(IJSInProcessObjectReference _ref) : base(_ref) { }
    //    /// <summary>
    //    /// Returns a GeolocationCoordinates object defining the current location.
    //    /// </summary>
    //    public GeolocationCoordinates Coords => JSRef!.Get<GeolocationCoordinates>("coords");
    //    /// <summary>
    //    /// Returns a timestamp, given as Unix time in milliseconds, representing the time at which the location was retrieved.
    //    /// </summary>
    //    public EpochDateTime Timestamp => JSRef!.Get<EpochDateTime>("timestamp");
    //}
}
