namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An XRRayDirectionInit dictionary represents a direction vector to be passed to the XRRay(origin, direction) constructor.<br/>
    /// https://www.w3.org/TR/webxr-hit-test-1/#dictdef-xrraydirectioninit
    /// </summary>
    public class XRRayDirectionInit
    {
        /// <summary>
        /// The x coordinate of the point in space. Default is 0.
        /// </summary>
        public double X { get; set; } = 0;

        /// <summary>
        /// The y coordinate of the point in space. Default is 0.
        /// </summary>
        public double Y { get; set; } = 0;

        /// <summary>
        /// The z coordinate of the point in space. Default is 0.
        /// </summary>
        public double Z { get; set; } = -1;

        /// <summary>
        /// The w coordinate of the point in space. Default is 1.
        /// </summary>
        public double W { get; set; } = 0;
    }
}
