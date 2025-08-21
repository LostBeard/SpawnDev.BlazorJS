namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents a descriptor used to configure a GPU command encoder.
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createCommandEncoder#descriptor
    /// </summary>
    public class GPUCommandEncoderDescriptor
    {
        /// <summary>
        /// A string providing a label that can be used to identify the object, for example in GPUError messages or console warnings.
        /// </summary>
        public string Label { get; set; }
    }
}
