using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpupipelinedescriptorbase
    /// </summary>
    public class GPUPipelineDescriptorBase : GPUObjectDescriptorBase
    {
        /// <summary>
        /// The GPUPipelineLayout for this pipeline, or "auto" to generate the pipeline layout automatically.<br/>
        /// Note: If "auto" is used the pipeline cannot share GPUBindGroups with any other pipelines.
        /// </summary>
        [JsonPropertyName("layout")]
        public Union<GPUPipelineLayout, GPUAutoLayoutMode, string> Layout { get; set; }
    }
}
