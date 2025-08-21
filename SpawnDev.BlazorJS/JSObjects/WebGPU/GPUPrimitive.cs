namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object describing how a pipeline constructs and rasterizes primitives from its vertex inputs.
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createRenderPipeline#primitive_object_structure
    /// </summary>
    public class GPUPrimitive
    {
        /// <summary>
        ///An enumerated value that defines the type of primitive to be constructed from the specified vertex inputs.Possible values are:
        ///"line-list": Each consecutive pair of two vertices defines a line primitive.
        ///"line-strip": Each vertex after the first defines a line primitive between it and the previous vertex.
        ///"point-list": Each vertex defines a point primitive.
        ///"triangle-list": Each consecutive triplet of three vertices defines a triangle primitive.
        ///"triangle-strip": Each vertex after the first two defines a triangle primitive between it and the previous two vertices.
        /// If omitted, topology defaults to "triangle-list".
        /// </summary>
        public string Topology { get; set; }
    }
}
