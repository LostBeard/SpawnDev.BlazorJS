using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRMesh interface of the WebXR Device API provides real-world geometry data such as meshes detected by the XR system.<br/>
    /// https://immersive-web.github.io/real-world-geometry/mesh-detection.html
    /// </summary>
    public class XRMesh : JSObject
    {
        /// <inheritdoc/>
        public XRMesh(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an XRSpace whose native origin tracks the mesh's position and orientation.
        /// </summary>
        public XRSpace MeshSpace => JSRef!.Get<XRSpace>("meshSpace");
        /// <summary>
        /// Returns a Float32Array containing the mesh vertex positions. Each vertex is 3 floats (x, y, z) in the coordinate system of meshSpace.
        /// </summary>
        public Float32Array Vertices => JSRef!.Get<Float32Array>("vertices");
        /// <summary>
        /// Returns a Uint32Array containing the mesh triangle indices. Each triangle is 3 indices into the vertices array.
        /// </summary>
        public Uint32Array Indices => JSRef!.Get<Uint32Array>("indices");
        /// <summary>
        /// Returns a DOMHighResTimeStamp indicating the last time the mesh data was updated.
        /// </summary>
        public double LastChangedTime => JSRef!.Get<double>("lastChangedTime");
        /// <summary>
        /// Returns a string indicating the semantic label of the mesh, or null if not available.
        /// </summary>
        public string? SemanticLabel => JSRef!.Get<string?>("semanticLabel");
    }
}
