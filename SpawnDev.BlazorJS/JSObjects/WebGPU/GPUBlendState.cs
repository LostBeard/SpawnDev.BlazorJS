namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpublendstate
    /// </summary>
    public class GPUBlendState
    {
        /// <summary>
        /// Defines the blending behavior of the corresponding render target for color channels.
        /// </summary>
        public GPUBlendComponent Color { get; set; }
        /// <summary>
        /// Defines the blending behavior of the corresponding render target for the alpha channel.
        /// </summary>
        public GPUBlendComponent Alpha { get; set; }
    }
}
