namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOMPointInit dictionary of the Geometry Interfaces Module Level 1 specification is used to provide optional parameters when creating or initializing a DOMPoint or DOMPointReadOnly object.
    /// </summary>
    public class DOMPointInit
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
        public double Z { get; set; } = 0;

        /// <summary>
        /// The w coordinate of the point in space. Default is 1.
        /// </summary>
        public double W { get; set; } = 1;
    }
}
