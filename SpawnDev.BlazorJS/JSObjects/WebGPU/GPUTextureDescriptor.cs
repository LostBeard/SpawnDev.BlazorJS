using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#gputexturedescriptor
    /// </summary>
    public class GPUTextureDescriptor : GPUObjectDescriptorBase
    {
        /// <summary>
        /// A GPUExtent3D dictionary defining the size of the texture. 
        /// </summary>
        public IEnumerable<int> Size { get; init; }
        /// <summary>
        /// A GPUTextureDescriptor specifying the format of the texture. 
        /// </summary>
        public string Format { get; init; }
        /// <summary>
        /// A GPUTextureUsageFlags describing how the texture will be used. 
        /// </summary>
        public GPUTextureUsage Usage { get; init; }

        /// <summary>
        /// The number of mipmap levels in the texture. 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MipLevelCount { get; init; }

        /// <summary>
        /// Whether the texture is one-dimensional, an array of two-dimensional layers, or three-dimensional.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Dimension { get; init; }
        
        /// <summary>
        /// The number of samples per pixel in the texture. 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SampleCount { get; init; }
        
        /// <summary>
        /// A GPUTextureViewDescriptor describing the default view to create for the texture. 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> ViewFormats { get; init; }
    }
}
