namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A GPUQuerySetDescriptor specifies the options to use in creating a GPUQuerySet.<br/>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpuquerysetdescriptor
    /// </summary>
    public class GPUQuerySetDescriptor : GPUObjectDescriptorBase
    {
        /// <summary>
        /// The type of queries managed by GPUQuerySet.
        /// </summary>
        public GPUQueryType Type { get; set; }
        /// <summary>
        /// The number of queries managed by GPUQuerySet.
        /// </summary>
        public GPUSize32 Count { get; set; }
    }
}
