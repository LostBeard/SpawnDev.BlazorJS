namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpusamplerbindinglayout
    /// </summary>
    public class GPUSamplerBindingLayout
    {
        /// <summary>
        /// Indicates the required type of a sampler bound to this bindings.
        /// Options are "filtering", "non-filtering", "comparison"
        /// </summary>
        public string Type { get; init; }
    }
}