using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#gpucomputepassencoder
    /// </summary>
    public class GPUComputePassEncoder : GPUObjectBase
    {
        /// <inheritdoc/>
        public GPUComputePassEncoder(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pipeline"></param>
        public void SetPipeline(GPUComputePipeline pipeline) => JSRef!.CallVoid("setPipeline", pipeline);

        /// <summary>
        /// Dispatch work to be performed with the current GPUComputePipeline. See § 23.1 Computing for the detailed specification.
        /// </summary>
        /// <param name="workgroupCountX"></param>
        /// <param name="workgroupCountY"></param>
        /// <param name="workgroupCountZ"></param>
        public void DispatchWorkgroups(GPUSize32 workgroupCountX, GPUSize32 workgroupCountY = 1, GPUSize32 workgroupCountZ = 1) => JSRef!.CallVoid("dispatchWorkgroups", workgroupCountX, workgroupCountY, workgroupCountZ);

        /// <summary>
        /// Dispatch work to be performed with the current GPUComputePipeline using parameters read from a GPUBuffer. See § 23.1 Computing for the detailed specification.<br/>
        /// The indirect dispatch parameters encoded in the buffer must be a tightly packed block of three 32-bit unsigned integer values (12 bytes total), given in the same order as the arguments for dispatchWorkgroups().
        /// </summary>
        /// <param name="indirectBuffer"></param>
        /// <param name="indirectOffset"></param>
        public void DispatchWorkgroupsIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset) => JSRef!.CallVoid("dispatchWorkgroupsIndirect", indirectBuffer, indirectOffset);

        /// <summary>
        /// Completes recording of the compute pass commands sequence.
        /// </summary>
        public void End() => JSRef!.CallVoid("end");


        /// <summary>
        /// Sets the current GPUBindGroup for the given index, specifying dynamic offsets as a subset of a Uint32Array.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="bindGroup"></param>
        /// <param name="dynamicOffsetsData"></param>
        public void SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, IEnumerable<GPUBufferDynamicOffset>? dynamicOffsetsData = null)
        {
            if (dynamicOffsetsData == null)
                JSRef!.CallVoid("setBindGroup", index, bindGroup);
            else
                JSRef!.CallVoid("setBindGroup", index, bindGroup, dynamicOffsetsData);
        }


        /// <summary>
        /// Sets the current GPUBindGroup for the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="bindGroup"></param>
        /// <param name="dynamicOffsetsData"></param>
        /// <param name="dynamicOffsetsDataStart"></param>
        /// <param name="dynamicOffsetsDataLength"></param>
        public void SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, Uint32Array dynamicOffsetsData, GPUSize64 dynamicOffsetsDataStart, GPUSize32 dynamicOffsetsDataLength) =>
            JSRef!.CallVoid("setBindGroup", index, bindGroup, dynamicOffsetsData, dynamicOffsetsDataStart, dynamicOffsetsDataLength);

    }
}
