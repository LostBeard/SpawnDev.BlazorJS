namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpupipelinedescriptorbase
    /// </summary>
    public class GPUPipelineDescriptorBase  : GPUObjectDescriptorBase
    {
        /// <summary>
        /// The GPUPipelineLayout for this pipeline, or "auto" to generate the pipeline layout automatically.<br/>
        /// Note: If "auto" is used the pipeline cannot share GPUBindGroups with any other pipelines.
        /// </summary>
        public Union<GPUPipelineLayout, EnumString<GPUAutoLayoutMode>> Layout { get; set; }
    }
}
