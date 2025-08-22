using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Create render pipeline descriptor<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createRenderPipeline#descriptor
    /// </summary>
    public class GPURenderPipelineDescriptor
    {
        /// <summary>
        /// An object describing depth-stencil properties including testing, operations, and bias.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUDepthStencilState? DepthStencil { get; set; }

        /// <summary>
        /// An object describing the fragment shader entry point of the pipeline and its output colors. 
        /// If no fragment shader entry point is defined, the pipeline will not produce any color attachment outputs, 
        /// but it still performs rasterization and produces depth values based on the vertex position output.
        /// Depth testing and stencil operations can still be used.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUFragment? Fragment { get; set; }

        /// <summary>
        /// A string providing a label that can be used to identify the object, for example in GPUError messages or console warnings.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }

        /// <summary>
        /// Defines the layout (structure, purpose, and type) of all the GPU resources (buffers, textures, etc.) used during the execution of the pipeline.
        /// Layout can be a GPUPipelineLayout object or a string = "auto". 
        /// If set to "auto", the GPU will automatically create a pipeline layout based on the resources used in the pipeline.
        /// </summary>
        public object Layout { get; set; }

        /// <summary>
        /// An object describing how the pipeline interacts with a render pass's multisampled attachments.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUMultisample? Multisample { get; set; }

        /// <summary>
        /// An object describing how a pipeline constructs and rasterizes primitives from its vertex inputs.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUPrimitive? Primitive { get; set; }

        /// <summary>
        /// An object describing the vertex shader entry point of the pipeline and its input buffer layouts.
        /// </summary>
        public GPUVertex Vertex { get; set; }
    }
}
