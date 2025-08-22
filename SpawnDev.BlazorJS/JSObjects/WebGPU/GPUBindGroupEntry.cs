namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A GPUBindGroupEntry describes a single resource to be bound in a GPUBindGroup
    /// https://www.w3.org/TR/webgpu/#dictdef-gpubindgroupentry
    /// </summary>
    public class GPUBindGroupEntry
    {
        /// <summary>
        /// A unique identifier for a resource binding within the GPUBindGroup, corresponding to a GPUBindGroupLayoutEntry.binding and a @binding attribute in the GPUShaderModule.
        /// </summary>
        public GPUIndex32 Binding { get; init; }

        /// <summary>
        /// The resource to bind, which may be a GPUSampler, GPUTexture, GPUTextureView, GPUBuffer, GPUBufferBinding, or GPUExternalTexture.
        /// </summary>
        public object Resource 
        { 
            get => _resource; 

            init
            {
                if(value is IGPUBindingResource)
                    _resource = value;
                else
                    throw new ArgumentException("Resource must be a GPUSampler, GPUTexture, GPUTextureView, GPUBuffer, GPUBufferBinding, or GPUExternalTexture");
            }
        }

        private object _resource;
    }
}
