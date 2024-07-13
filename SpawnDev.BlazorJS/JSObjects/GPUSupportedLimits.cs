using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUSupportedLimits interface of the WebGPU API describes the limits supported by a GPUAdapter.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUSupportedLimits
    /// </summary>
    public class GPUSupportedLimits : JSObject
    {
        public GPUSupportedLimits(IJSInProcessObjectReference _ref) : base(_ref){ }

        public int? MaxTextureDimension1D => JSRef!.Get<int?>("maxTextureDimension1D");
        public int? MaxTextureDimension2D => JSRef!.Get<int?>("maxTextureDimension2D");
        public int? MaxTextureDimension3D => JSRef!.Get<int?>("maxTextureDimension3D");
        public int? MaxTextureArrayLayers => JSRef!.Get<int?>("maxTextureArrayLayers");
        public int? MaxBindGroups => JSRef!.Get<int?>("maxBindGroups");
        public int? MaxBindingsPerBindGroup => JSRef!.Get<int?>("maxBindingsPerBindGroup");
        public int? MaxDynamicUniformBuffersPerPipelineLayout => JSRef!.Get<int?>("maxDynamicUniformBuffersPerPipelineLayout");
        public int? MaxDynamicStorageBuffersPerPipelineLayout => JSRef!.Get<int?>("maxDynamicStorageBuffersPerPipelineLayout");
        public int? MaxSampledTexturesPerShaderStage => JSRef!.Get<int?>("maxSampledTexturesPerShaderStage");
        public int? MaxSamplersPerShaderStage => JSRef!.Get<int?>("maxSamplersPerShaderStage");
        public int? MaxStorageBuffersPerShaderStage => JSRef!.Get<int?>("maxStorageBuffersPerShaderStage");
        public int? MaxStorageTexturesPerShaderStage => JSRef!.Get<int?>("maxStorageTexturesPerShaderStage");
        public int? MaxUniformBuffersPerShaderStage => JSRef!.Get<int?>("maxUniformBuffersPerShaderStage");
        public int? MaxUniformBufferBindingSize => JSRef!.Get<int?>("maxUniformBufferBindingSize");
        public int? MaxStorageBufferBindingSize => JSRef!.Get<int?>("maxStorageBufferBindingSize");
        public int? MinUniformBufferOffsetAlignment => JSRef!.Get<int?>("minUniformBufferOffsetAlignment");
        public int? MinStorageBufferOffsetAlignment => JSRef!.Get<int?>("minStorageBufferOffsetAlignment");
        public int? MaxVertexBuffers => JSRef!.Get<int?>("maxVertexBuffers");
        public int? MaxBufferSize => JSRef!.Get<int?>("maxBufferSize");
        public int? MaxVertexAttributes => JSRef!.Get<int?>("maxVertexAttributes");
        public int? MaxVertexBufferArrayStride => JSRef!.Get<int?>("maxVertexBufferArrayStride");
        public int? MaxInterStageShaderComponents => JSRef!.Get<int?>("maxInterStageShaderComponents");
        public int? MaxInterStageShaderVariables => JSRef!.Get<int?>("maxInterStageShaderVariables");
        public int? MaxColorAttachments => JSRef!.Get<int?>("maxColorAttachments");
        public int? MaxColorAttachmentBytesPerSample => JSRef!.Get<int?>("maxColorAttachmentBytesPerSample");
        public int? MaxComputeWorkgroupStorageSize => JSRef!.Get<int?>("maxComputeWorkgroupStorageSize");
        public int? MaxComputeInvocationsPerWorkgroup => JSRef!.Get<int?>("maxComputeInvocationsPerWorkgroup");
        public int? MaxComputeWorkgroupSizeX => JSRef!.Get<int?>("maxComputeWorkgroupSizeX");
        public int? MaxComputeWorkgroupSizeY => JSRef!.Get<int?>("maxComputeWorkgroupSizeY");
        public int? MaxComputeWorkgroupSizeZ => JSRef!.Get<int?>("maxComputeWorkgroupSizeZ");
        public int? MaxComputeWorkgroupsPerDimension => JSRef!.Get<int?>("maxComputeWorkgroupsPerDimension");
    }
}
