namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents the state of a color target in a GPU rendering pipeline, including its format.
    /// https://www.w3.org/TR/webgpu/#color-target-state
    /// </summary>
    public class GPUColorTargetState
    {
        /// <summary>
        /// Gets or sets the format string used to define the output representation.
        /// </summary>
        public string Format { get; set; }
    }
}
