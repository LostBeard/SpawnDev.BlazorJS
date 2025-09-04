using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// GPUErrorFilter defines the type of errors that should be caught when calling pushErrorScope():<br/>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpuerrorfilter
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUErrorFilter
    {
        /// <summary>
        /// Indicates that the error scope will catch a GPUValidationError.
        /// </summary>
        [JsonPropertyName("validation")]
        Validation,
        /// <summary>
        /// Indicates that the error scope will catch a GPUOutOfMemoryError.
        /// </summary>
        [JsonPropertyName("out-of-memory")]
        OutOfMemory,
        /// <summary>
        /// Indicates that the error scope will catch a GPUInternalError.
        /// </summary>
        [JsonPropertyName("internal")]
        Internal,
    }
}
