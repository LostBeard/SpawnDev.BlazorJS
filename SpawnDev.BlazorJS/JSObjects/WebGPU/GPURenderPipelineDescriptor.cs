using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Create render pipeline descriptor<br/>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpurenderpipelinedescriptor
    /// </summary>
    public class GPURenderPipelineDescriptor : GPUPipelineDescriptorBase
    {
        /// <summary>
        /// An object describing the vertex shader entry point of the pipeline and its input buffer layouts.
        /// </summary>
        public GPUVertexState Vertex { get; init; }

        /// <summary>
        /// An object describing how a pipeline constructs and rasterizes primitives from its vertex inputs.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUPrimitiveState? Primitive { get; init; }

        /// <summary>
        /// An object describing depth-stencil properties including testing, operations, and bias.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUDepthStencilState? DepthStencil { get; init; }

        /// <summary>
        /// An object describing how the pipeline interacts with a render pass's multisampled attachments.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUMultisampleState? Multisample { get; init; }

        /// <summary>
        /// An object describing the fragment shader entry point of the pipeline and its output colors. 
        /// If no fragment shader entry point is defined, the pipeline will not produce any color attachment outputs, 
        /// but it still performs rasterization and produces depth values based on the vertex position output.
        /// Depth testing and stencil operations can still be used.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUFragmentState? Fragment { get; init; }
    }
}