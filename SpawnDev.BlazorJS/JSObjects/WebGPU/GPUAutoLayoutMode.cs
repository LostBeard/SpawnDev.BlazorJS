using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpuautolayoutmode
    /// </summary>
    [JsonConverter(typeof(JsonConverters.EnumStringConverterFactory))]
    public enum GPUAutoLayoutMode
    {
        /// <summary>
        /// Note: If "auto" is used the pipeline cannot share GPUBindGroups with any other pipelines.
        /// </summary>
        [JsonPropertyName("auto")]
        Auto,
    }
}
