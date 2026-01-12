using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object descriptor holds the information needed to create an object, which is typically done via one of the create* methods of GPUDevice.
    /// https://www.w3.org/TR/webgpu/#dictdef-gpuobjectdescriptorbase
    /// </summary>
    public abstract class GPUObjectDescriptorBase
    {
        /// <summary>
        /// A string providing a label that can be used to identify the object, for example in GPUError messages or console warnings.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("label")]
        public string Label { get; init; } = "";
    }
}