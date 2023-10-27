namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GeolocationPositionError interface represents the reason of an error occurring when using the geolocating device.
    /// </summary>
    public class GeolocationPositionError
    {
        /// <summary>
        /// Returns an unsigned short representing the error code. The following values are possible:<br />
        /// 1 - PERMISSION_DENIED<br />
        /// 2 - POSITION_UNAVAILABLE<br />
        /// 3 - TIMEOUT<br />
        /// </summary>
        public ushort Code { get; set; }
    }
}
