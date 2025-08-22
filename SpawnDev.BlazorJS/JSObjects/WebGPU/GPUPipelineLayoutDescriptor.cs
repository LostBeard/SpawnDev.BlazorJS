namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Describes the layout of a pipeline, which is used to create a GPUPipelineLayout object.<br/>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpupipelinelayoutdescriptor
    /// </summary>
    public class GPUPipelineLayoutDescriptor : GPUObjectDescriptorBase
    {
        /// <summary>
        /// An array of GPUBindGroupLayout objects (which are in turn created via calls to GPUDevice.createBindGroupLayout()). 
        /// Each one corresponds to a @group attribute in the shader code contained in the GPUShaderModule used in a related pipeline.
        /// </summary>
        public IEnumerable<GPUBindGroupLayout> BindGroupLayouts { get; init; }
    }
}
