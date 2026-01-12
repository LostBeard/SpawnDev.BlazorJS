using System.Text.Json.Serialization;
using SpawnDev.BlazorJS.JsonConverters;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A GPUStencilFaceState dictionary specifies the stencil state for a given face direction (front or back).
    /// https://www.w3.org/TR/webgpu/#dictdef-gpustencilfacestate
    /// </summary>
    public class GPUStencilFaceState
    {
        /// <summary>
        /// The exclusion operation to perform when the stencil test fails.
        /// </summary>
        [JsonPropertyName("compare")]
        public EnumString<GPUCompareFunction> Compare { get; init; } = GPUCompareFunction.Always;

        /// <summary>
        /// The exclusion operation to perform when the stencil test fails.
        /// </summary>
        [JsonPropertyName("failOp")]
        public EnumString<GPUStencilOperation> FailOp { get; init; } = GPUStencilOperation.Keep;

        /// <summary>
        /// The exclusion operation to perform when the stencil test passes but the depth test fails.
        /// </summary>
        [JsonPropertyName("depthFailOp")]
        public EnumString<GPUStencilOperation> DepthFailOp { get; init; } = GPUStencilOperation.Keep;

        /// <summary>
        /// The exclusion operation to perform when both the stencil test and the depth test pass.
        /// </summary>
        [JsonPropertyName("passOp")]
        public EnumString<GPUStencilOperation> PassOp { get; init; } = GPUStencilOperation.Keep;
    }
}
