using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUDevice interface of the WebGPU API represents a logical GPU device. This is the main interface through which the majority of WebGPU functionality is accessed.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice
    /// </summary>
    public class GPUDevice : EventTarget
    {
        #region Constructors
        /// <inheritdoc/>
        public GPUDevice(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        public void PushErrorScope(string filter) => JSRef!.CallVoid("pushErrorScope", filter);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<object?> PopErrorScopeAsync() => JSRef!.CallAsync<object?>("popErrorScope");

        /// <summary>
        /// The createBuffer() method of the GPUDevice interface creates a GPUBuffer in which to store raw data to use in GPU operations.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPUBuffer CreateBuffer(GPUBufferDescriptor descriptor) => JSRef!.Call<GPUBuffer>("createBuffer", descriptor);

        /// <summary>
        /// The createRenderPipeline() method of the GPUDevice interface creates a GPURenderPipeline object, 
        /// which represents a collection of GPU state and shader programs that can be used to render graphics.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPURenderPipeline CreateRenderPipeline(GPURenderPipelineDescriptor descriptor) => JSRef!.Call<GPURenderPipeline>("createRenderPipeline", descriptor);

        /// <summary>
        /// The createComputePipeline() method of the GPUDevice interface creates a GPUPipelineLayout that defines the GPUBindGroupLayouts used by a pipeline.
        /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createPipelineLayout
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPUPipelineLayout CreatePipelineLayout(GPUPipelineLayoutDescriptor descriptor) => JSRef!.Call<GPUPipelineLayout>("createPipelineLayout", descriptor);

        /// <summary>
        /// Creates a GPUBindGroupLayout that defines the structure and purpose of related GPU resources such as buffers that will be used in a pipeline, 
        /// and is used as a template when creating GPUBindGroups.
        /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createBindGroupLayout
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPUBindGroupLayout CreateBindGroupLayout(GPUBindGroupLayoutDescriptor descriptor) => JSRef!.Call<GPUBindGroupLayout>("createBindGroupLayout", descriptor);

        /// <summary>
        /// Creates a GPUShaderModule from a string of WGSL source code.
        /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createShaderModule
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPUShaderModule CreateShaderModule(GPUShaderModuleDescriptor descriptor) => JSRef!.Call<GPUShaderModule>("createShaderModule", descriptor);

        /// <summary>
        /// Creates a GPUCommandEncoder, which is used to encode commands to be issued to the GPU.
        /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createCommandEncoder
        /// </summary>
        /// <returns></returns>
        public GPUCommandEncoder CreateCommandEncoder() => JSRef!.Call<GPUCommandEncoder>("createCommandEncoder");

        /// <summary>
        /// Creates a GPUCommandEncoder, which is used to encode commands to be issued to the GPU.
        /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createCommandEncoder
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPUCommandEncoder CreateCommandEncoder(GPUCommandEncoderDescriptor descriptor) => JSRef!.Call<GPUCommandEncoder>("createCommandEncoder", descriptor);

        /// <summary>
        /// The createTexture() method of the GPUDevice interface creates a GPUTexture in which to store 1D, 2D, or 3D arrays of data, such as images, to use in GPU rendering operations.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPUTexture CreateTexture(GPUTextureDescriptor descriptor) => JSRef!.Call<GPUTexture>("createTexture", descriptor);

        /// <summary>
        /// The createBindGroup() method of the GPUDevice interface creates a GPUBindGroup based on a GPUBindGroupLayout that defines a set of resources to be bound together in 
        /// a group and how those resources are used in shader stages.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPUBindGroup CreateBindGroup(GPUBindGroupDescriptor descriptor) => JSRef!.Call<GPUBindGroup>("createBindGroup", descriptor);

        /// <summary>
        /// Returns the primary GPUQueue for the device.
        /// </summary>
        public GPUQueue Queue => JSRef!.Get<GPUQueue>("queue");

        /// <summary>
        /// The createQuerySet() method of the GPUDevice interface creates a GPUQuerySet that can be used to record the results of queries on passes, such as occlusion or timestamp queries.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPUQuerySet CreateQuerySet(GPUQuerySetDescriptor descriptor) => JSRef!.Call<GPUQuerySet>("createQuerySet", descriptor);

        /// <summary>
        /// Destroys the GPUDevice.
        /// </summary>
        public void Destroy() => JSRef!.CallVoid("destroy");

        /// <summary>
        /// Creates a GPUComputePipeline using immediate pipeline creation.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPUComputePipeline CreateComputePipeline(GPUComputePipelineDescriptor descriptor) => JSRef!.Call<GPUComputePipeline>("createComputePipeline", descriptor);

        /// <summary>
        /// Creates a GPUComputePipeline using async pipeline creation. The returned Promise resolves when the created pipeline is ready to be used without additional delay.<br/>
        /// If pipeline creation fails, the returned Promise rejects with an GPUPipelineError. (A GPUError is not dispatched to the device.)<br/>
        /// Note: Use of this method is preferred whenever possible, as it prevents blocking the queue timeline work on pipeline compilation.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public Task<GPUComputePipeline> CreateComputePipelineAsync(GPUComputePipelineDescriptor descriptor) => JSRef!.CallAsync<GPUComputePipeline>("createComputePipeline", descriptor);
    }
}
