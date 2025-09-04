using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUDevice interface of the WebGPU API represents a logical GPU device. This is the main interface through which the majority of WebGPU functionality is accessed.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice<br/>
    /// https://www.w3.org/TR/webgpu/#gpudevice
    /// </summary>
    public class GPUDevice : EventTarget
    {
        #region Constructors
        /// <inheritdoc/>
        public GPUDevice(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        /// <summary>
        /// The adapterInfo read-only property of the GPUDevice interface returns a GPUAdapterInfo object containing identifying information about the device's originating adapter.
        /// </summary>
        public GPUAdapterInfo AdapterInfo => JSRef!.Get<GPUAdapterInfo>("adapter");

        /// <summary>
        /// A GPUSupportedFeatures object that describes additional functionality supported by the device.
        /// </summary>
        public GPUSupportedFeatures Features => JSRef!.Get<GPUSupportedFeatures>("features");

        /// <summary>
        /// A string providing a label that can be used to identify the object, for example in GPUError messages or console warnings.
        /// </summary>
        public string? Label => JSRef!.Get<string?>("label");

        /// <summary>
        /// A GPUSupportedLimits object that describes the limits supported by the device.
        /// </summary>
        public GPUSupportedLimits Limits => JSRef!.Get<GPUSupportedLimits>("limits");

        /// <summary>
        /// Contains a Promise that remains pending throughout the device's lifetime and resolves with a GPUDeviceLostInfo object when the device is lost.
        /// </summary>
        public Task<GPUDeviceLostInfo> Lost => JSRef!.GetAsync<GPUDeviceLostInfo>("lost");

        /// <summary>
        /// Returns the primary GPUQueue for the device.
        /// </summary>
        public GPUQueue Queue => JSRef!.Get<GPUQueue>("queue");

        /// <summary>
        /// Destroys the GPUDevice.
        /// </summary>
        public void Destroy() => JSRef!.CallVoid("destroy");

        /// <summary>
        /// The pushErrorScope() method of the GPUDevice interface pushes a new GPU error scope onto the device's error scope stack, allowing you to capture errors of a particular type.<br/>
        /// Once you are done capturing errors, you can end capture by invoking GPUDevice.popErrorScope(). This pops the scope from the stack and returns a Promise that resolves to an object describing the first error captured in the scope, or null if no errors were captured.
        /// </summary>
        /// <param name="filter"></param>
        public void PushErrorScope(GPUErrorFilter filter) => JSRef!.CallVoid("pushErrorScope", filter);

        /// <summary>
        /// The popErrorScope() method of the GPUDevice interface pops an existing GPU error scope from the error scope stack (originally pushed using GPUDevice.pushErrorScope()) and returns a Promise that resolves to an object describing the first error captured in the scope, or null if no error occurred.
        /// </summary>
        /// <returns></returns>
        public Task<GPUError?> PopErrorScope() => JSRef!.CallAsync<GPUError?>("popErrorScope");

        /// <summary>
        /// The createBuffer() method of the GPUDevice interface creates a GPUBuffer in which to store raw data to use in GPU operations.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPUBuffer CreateBuffer(GPUBufferDescriptor descriptor) => JSRef!.Call<GPUBuffer>("createBuffer", descriptor);

        /// <summary>
        /// Creates a GPUSampler.
        /// </summary>
        /// <param name="descriptor">Description of the GPUSampler to create.</param>
        /// <returns></returns>
        public GPUSampler CreateSampler(GPUSamplerDescriptor? descriptor = null) => descriptor == null ? JSRef!.Call<GPUSampler>("createSampler") : JSRef!.Call<GPUSampler>("createSampler", descriptor);

        /// <summary>
        /// Creates a GPUExternalTexture wrapping the provided image source.
        /// </summary>
        /// <param name="descriptor">Provides the external image source object (and any creation options).</param>
        /// <returns></returns>
        public GPUExternalTexture ImportExternalTexture(GPUExternalTextureDescriptor descriptor) => JSRef!.Call<GPUExternalTexture>("importExternalTexture", descriptor);

        /// <summary>
        /// The createRenderPipeline() method of the GPUDevice interface creates a GPURenderPipeline object, 
        /// which represents a collection of GPU state and shader programs that can be used to render graphics.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPURenderPipeline CreateRenderPipeline(GPURenderPipelineDescriptor descriptor) => JSRef!.Call<GPURenderPipeline>("createRenderPipeline", descriptor);

        /// <summary>
        /// Creates a GPURenderPipeline using async pipeline creation. The returned Promise resolves when the created pipeline is ready to be used without additional delay.<br/>
        /// If pipeline creation fails, the returned Promise rejects with an GPUPipelineError. (A GPUError is not dispatched to the device.)<br/>
        /// Note: Use of this method is preferred whenever possible, as it prevents blocking the queue timeline work on pipeline compilation.
        /// </summary>
        /// <param name="descriptor">Description of the GPURenderPipeline to create.</param>
        /// <returns></returns>
        public Task<GPURenderPipeline> CreateRenderPipelineAsync(GPURenderPipelineDescriptor descriptor) => JSRef!.CallAsync<GPURenderPipeline>("createRenderPipelineAsync", descriptor);

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
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPUCommandEncoder CreateCommandEncoder(GPUCommandEncoderDescriptor? descriptor = null) => descriptor == null ? JSRef!.Call<GPUCommandEncoder>("createCommandEncoder") : JSRef!.Call<GPUCommandEncoder>("createCommandEncoder", descriptor);

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
        /// The createQuerySet() method of the GPUDevice interface creates a GPUQuerySet that can be used to record the results of queries on passes, such as occlusion or timestamp queries.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPUQuerySet CreateQuerySet(GPUQuerySetDescriptor descriptor) => JSRef!.Call<GPUQuerySet>("createQuerySet", descriptor);

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
        public Task<GPUComputePipeline> CreateComputePipelineAsync(GPUComputePipelineDescriptor descriptor) => JSRef!.CallAsync<GPUComputePipeline>("createComputePipelineAsync", descriptor);

        /// <summary>
        /// Creates a GPURenderBundleEncoder.
        /// </summary>
        /// <param name="descriptor">Description of the GPURenderBundleEncoder to create.</param>
        /// <returns></returns>
        public GPURenderBundleEncoder CreateRenderBundleEncoder(GPURenderBundleEncoderDescriptor descriptor) => JSRef!.Call<GPURenderBundleEncoder>("createRenderBundleEncoder", descriptor);
    }
}
