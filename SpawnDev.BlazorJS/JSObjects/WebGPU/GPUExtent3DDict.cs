using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpuextent3ddict
    /// </summary>
    public class GPUExtent3DDict
    {
        /// <summary>
        /// Width of the extent.
        /// </summary>
        public GPUIntegerCoordinate Width { get; set; }
        /// <summary>
        /// Height of the extent.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUIntegerCoordinate? Height { get; set; }
        /// <summary>
        /// Depth or array layers of the extent.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUIntegerCoordinate? DepthOrArrayLayers { get; set; }
    }
}
