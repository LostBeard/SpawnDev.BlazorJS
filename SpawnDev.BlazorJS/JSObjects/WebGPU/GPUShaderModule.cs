using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUShaderModule interface of the WebGPU API represents an internal shader module object, 
    /// a container for WGSL shader code that can be submitted to the GPU for execution by a pipeline.
    /// A GPUShaderModule object instance is created using GPUDevice.createShaderModule().
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUShaderModule
    /// </summary>
    public class GPUShaderModule : JSObject
    {
        /// <inheritdoc/>
        public GPUShaderModule(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// A string providing a label that can be used to identify the object, for example in GPUError messages or console warnings.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }
    }
}
