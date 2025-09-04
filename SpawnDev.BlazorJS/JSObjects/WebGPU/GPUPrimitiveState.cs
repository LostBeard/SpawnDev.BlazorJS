using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object describing how a pipeline constructs and rasterizes primitives from its vertex inputs.
    /// https://www.w3.org/TR/webgpu/#primitive-state
    /// </summary>
    public class GPUPrimitiveState
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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<GPUPrimitiveTopology>? Topology { get; init; }

        /// <summary>
        /// The index format determines both the data type of index values in a buffer and, when used with strip primitive topologies 
        /// ("line-strip" or "triangle-strip") also specifies the primitive restart value. The primitive restart value indicates which 
        /// index value indicates that a new primitive should be started rather than continuing to construct the triangle strip with the prior indexed vertices. 
        /// GPUPrimitiveStates that specify a strip primitive topology must specify a stripIndexFormat if they are used for indexed draws 
        /// so that the primitive restart value that will be used is known at pipeline creation time.GPUPrimitiveStates that specify 
        /// a list primitive topology will use the index format passed to setIndexBuffer() when doing indexed rendering.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<GPUIndexFormat>? StripIndexFormat { get; init; }

        /// <summary>
        /// Defines which polygons are considered front-facing. The possible values are:
        /// "ccw" Polygons with vertices whose framebuffer coordinates are given in counter-clockwise order are considered front-facing.
        /// "cw" Polygons with vertices whose framebuffer coordinates are given in clockwise order are considered front-facing.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<GPUFrontFace>? FrontFace { get; init; }

        /// <summary>
        /// Defines which polygons will be culled by draw calls made with a GPURenderPipeline. The possible values are:
        /// "none" No polygons are discarded.
        /// "front" Front-facing polygons are discarded.
        /// "back" Back-facing polygons are discarded.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<GPUCullMode>? CullMode { get; init; }

        /// <summary>
        /// If true, indicates that depth clipping is disabled.
        /// Requires the "depth-clip-control" feature to be enabled.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? UnclippedDepth { get; init; }
    }
}