namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object describing the layout of a bind group, which is a collection of resources that can be bound to a pipeline.<br/>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpubindgrouplayoutdescriptor
    /// </summary>
    public class GPUBindGroupLayoutDescriptor : GPUObjectDescriptorBase
    {
        /// <summary>
        /// An array of entry objects, each one of which describes a single shader resource binding to be included in the GPUBindGroupLayout. 
        /// Each entry will correspond to an entry defined in a GPUBindGroup (created via a GPUDevice.createBindGroup() call) that uses 
        /// this GPUBindGroupLayout object as a template.
        /// </summary>
        public IEnumerable<GPUBindGroupLayoutEntry> Entries { get; init; }

    }
}