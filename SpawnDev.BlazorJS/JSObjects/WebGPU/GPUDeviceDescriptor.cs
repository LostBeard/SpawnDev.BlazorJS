using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// RequestDevice options<br/>
    /// https://www.w3.org/TR/webgpu/#gpudevicedescriptor
    /// </summary>
    public class GPUDeviceDescriptor
    {
        /// <summary>
        /// An object that provides information for the device's default GPUQueue (as returned by GPUDevice.queue). This object has a single property — label — which provides the default queue with a label value. If no value is provided, this defaults to an empty object, and the default queue's label will be an empty string.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUQueue? DefaultQueue { get; set; }
        /// <summary>
        /// A string providing a label that can be used to identify the GPUDevice, for example in GPUError messages or console warnings.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }
        /// <summary>
        /// An array of strings representing additional functionality that you want supported by the returned GPUDevice. The requestDevice() call will fail if the GPUAdapter cannot provide these features. See GPUSupportedFeatures for a full list of possible features. This defaults to an empty array if no value is provided.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? RequiredFeatures { get; set; }
        /// <summary>
        /// An object containing properties representing the limits that you want supported by the returned GPUDevice. The requestDevice() call will fail if the GPUAdapter cannot provide these limits. Each key must be the name of a member of GPUSupportedLimits. This defaults to an empty object if no value is provided.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? RequiredLimits { get; set; }
    }
}
