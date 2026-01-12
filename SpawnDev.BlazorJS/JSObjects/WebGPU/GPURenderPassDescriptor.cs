using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents a descriptor for configuring a GPU render pass.
    /// https://www.w3.org/TR/webgpu/#dictdef-gpurenderpassdescriptor
    /// </summary>
    public class GPURenderPassDescriptor : GPUObjectDescriptorBase
    {
        /// <summary>
        /// An array of objects (see Color attachment object structure) defining the color attachments 
        /// that will be output to when executing this render pass.
        /// </summary>
        [JsonPropertyName("colorAttachments")]
        public GPURenderPassColorAttachment[] ColorAttachments { get; init; }

        /// <summary>
        /// The GPURenderPassDepthStencilAttachment value that defines the depth/stencil attachment that will be output to and tested against when executing this render pass.
        /// Due to usage compatibility, no writable depth/stencil attachment may alias another attachment or any resource used inside the render pass.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("depthStencilAttachment")]
        public GPURenderPassDepthStencilAttachment? DepthStencilAttachment { get; init; }

        /// <summary>
        /// The maximum number of draw calls that will be done in the render pass. 
        /// Used by some implementations to size work injected before the render pass. 
        /// Keeping the default value is a good default, unless it is known that more draw calls will be done.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("maxDrawCount")]
        public GPUSize64? MaxDrawCount { get; init; }
    }
}
