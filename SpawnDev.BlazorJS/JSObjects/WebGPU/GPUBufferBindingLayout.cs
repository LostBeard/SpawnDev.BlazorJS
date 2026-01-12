namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpubufferbindinglayout
    /// </summary>
    public class GPUBufferBindingLayout
    {
        /// <summary>
        /// Indicates the type required for buffers bound to this bindings.
        /// </summary>
        public string Type { get; init; } = "uniform";

        /// <summary>
        /// Indicates whether this binding requires a dynamic offset.
        /// </summary>
        public bool HasDynamicOffset { get; init; } = false;

        /// <summary>
        /// Indicates the minimum size of a buffer binding used with this bind point.
        /// Bindings are always validated against this size in createBindGroup().
        /// If this is not 0, pipeline creation additionally validates that this value ≥ the minimum buffer binding size of the variable.
        /// If this is 0, it is ignored by pipeline creation, and instead draw/dispatch commands validate that each binding in the GPUBindGroup satisfies the minimum buffer binding size of the variable.
        /// </summary>
        public GPUSize64 MinBindingSize { get; init; } = 0;
    }
}