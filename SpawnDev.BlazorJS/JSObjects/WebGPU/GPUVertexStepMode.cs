using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The step mode configures how an address for vertex buffer data is computed, based on the current vertex or instance index:<br/>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpuvertexstepmode
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUVertexStepMode
    {
        /// <summary>
        /// The address is advanced by arrayStride for each vertex, and reset between instances.
        /// </summary>
        [JsonPropertyName("vertex")]
        Vertex,
        /// <summary>
        /// The address is advanced by arrayStride for each instance.
        /// </summary>
        [JsonPropertyName("instance")]
        Instance,
    }
}
