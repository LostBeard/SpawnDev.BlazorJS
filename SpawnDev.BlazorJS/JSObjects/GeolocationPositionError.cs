namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GeolocationPositionError interface represents the reason of an error occurring when using the geolocating device.
    /// </summary>
    public class GeolocationPositionError
    {
        /// <summary>
        /// Returns an unsigned short representing the error code. The following values are possible:<br/>
        /// 1 - PERMISSION_DENIED<br/>
        /// 2 - POSITION_UNAVAILABLE<br/>
        /// 3 - TIMEOUT<br/>
        /// </summary>
        public ushort Code { get; set; }
        /// <summary>
        /// Returns a human-readable string describing the details of the error. Specifications note that this is primarily intended for debugging use and not to be shown directly in a user interface.
        /// </summary>
        public string? Message { get; set; }
    }
}
