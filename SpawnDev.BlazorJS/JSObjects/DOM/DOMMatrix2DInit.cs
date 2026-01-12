namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOMMatrix2DInit dictionary of the Geometry Interfaces Module Level 1 specification is used to provide optional parameters when creating or initializing a 2D DOMMatrix object.<br/>
    /// https://www.w3.org/TR/geometry-1/#dictdef-dommatrix2dinit
    /// </summary>
    public class DOMMatrix2DInit
    {
        /// <summary>
        /// A double representing the m11 component of the matrix.
        /// </summary>
        public double M11 { get; set; } = 1.0;

        /// <summary>
        /// A double representing the m12 component of the matrix.
        /// </summary>
        public double M12 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m21 component of the matrix.
        /// </summary>
        public double M21 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m22 component of the matrix.
        /// </summary>
        public double M22 { get; set; } = 1.0;

        /// <summary>
        /// A double representing the m41 component of the matrix.
        /// </summary>
        public double M41 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m42 component of the matrix.
        /// </summary>
        public double M42 { get; set; } = 0.0;

        /// <summary>
        /// A boolean value indicating whether the matrix is 2D or 3D.
        /// </summary>
        public bool Is2D { get; set; } = true;
    }


}
