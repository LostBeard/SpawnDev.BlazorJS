namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOMMatrixInit dictionary of the Geometry Interfaces Module Level 1 specification is used to provide optional parameters when creating or initializing a DOMMatrix object.<br/>
    /// https://www.w3.org/TR/geometry-1/#dictdef-dommatrixinit
    /// </summary>
    public class DOMMatrixInit
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
        /// A double representing the m13 component of the matrix.
        /// </summary>
        public double M13 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m14 component of the matrix.
        /// </summary>
        public double M14 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m21 component of the matrix.
        /// </summary>
        public double M21 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m22 component of the matrix.
        /// </summary>
        public double M22 { get; set; } = 1.0;

        /// <summary>
        /// A double representing the m23 component of the matrix.
        /// </summary>
        public double M23 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m24 component of the matrix.
        /// </summary>
        public double M24 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m31 component of the matrix.
        /// </summary>
        public double M31 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m32 component of the matrix.
        /// </summary>
        public double M32 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m33 component of the matrix.
        /// </summary>
        public double M33 { get; set; } = 1.0;

        /// <summary>
        /// A double representing the m34 component of the matrix.
        /// </summary>
        public double M34 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m41 component of the matrix.
        /// </summary>
        public double M41 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m42 component of the matrix.
        /// </summary>
        public double M42 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m43 component of the matrix.
        /// </summary>
        public double M43 { get; set; } = 0.0;

        /// <summary>
        /// A double representing the m44 component of the matrix.
        /// </summary>
        public double M44 { get; set; } = 1.0;

        /// <summary>
        /// A boolean value indicating whether the matrix is 2D or 3D.
        /// </summary>
        public bool Is2D { get; set; } = true;
    }
}
