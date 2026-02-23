using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUQueue interface of the WebGPU API controls execution of encoded commands on the GPU.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUQueue<br/>
    /// https://www.w3.org/TR/webgpu/#gpuqueue
    /// </summary>
    public class GPUQueue : GPUObjectBase
    {
        /// <inheritdoc/>
        public GPUQueue(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Schedules the execution of the command buffers by the GPU on this queue.<br/>
        /// Submitted command buffers cannot be used again.
        /// </summary>
        /// <param name="commandBuffers"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Submit(GPUCommandBuffer[] commandBuffers) => JSRef!.CallVoid("submit", commandBuffers);

        /// <summary>
        /// Returns a Promise that resolves when all the work submitted to the GPU via this GPUQueue at the point the method is called has been processed.
        /// </summary>
        /// <returns></returns>
        public Task OnSubmittedWorkDone() => JSRef!.CallVoidAsync("onSubmittedWorkDone");

        /// <summary>
        /// The writeBuffer() method of the GPUQueue interface writes a provided data source into a given GPUBuffer.
        /// This is a convenience function, which provides an alternative to setting buffer data via buffer mapping and buffer-to-buffer copies.
        /// It lets the user agent determine the most efficient way to copy the data over.
        /// </summary>
        /// <param name="gpuBuffer">A GPUBuffer object representing the buffer to write data to.</param>
        /// <param name="bufferOffset">A number representing the offset, in bytes, to start writing the data at inside the GPUBuffer.</param>
        /// <param name="data">An object representing the data source to write into the GPUBuffer. This can be an ArrayBuffer, TypedArray, or DataView.</param>
        /// <param name="dataOffset">A number representing the offset to start writing the data from inside the data source. 
        /// This value is a number of elements if data is a TypedArray, and a number of bytes if not. If omitted, dataOffset defaults to 0.</param>
        /// <param name="size">A number representing the size of the content to write from data to buffer. 
        /// This value is a number of elements if data is a TypedArray, and a number of bytes if not.
        /// If omitted, size will be equal to the overall size of data, minus dataOffset.</param>
        public void WriteBuffer(GPUBuffer gpuBuffer, GPUSize64 bufferOffset, AllowSharedBufferSource data, int? dataOffset = 0, GPUSize64? size = null)
        {
            if (size == null)
                JSRef!.CallVoid("writeBuffer", gpuBuffer, bufferOffset, data, dataOffset);
            else
                JSRef!.CallVoid("writeBuffer", gpuBuffer, bufferOffset, data, dataOffset, size);
        }
        /// <summary>
        /// The writeBuffer() method of the GPUQueue interface writes a provided data source into a given GPUBuffer.
        /// This is a convenience function, which provides an alternative to setting buffer data via buffer mapping and buffer-to-buffer copies.
        /// It lets the user agent determine the most efficient way to copy the data over.
        /// </summary>
        /// <param name="gpuBuffer">A GPUBuffer object representing the buffer to write data to.</param>
        /// <param name="bufferOffset">A number representing the offset, in bytes, to start writing the data at inside the GPUBuffer.</param>
        /// <param name="data">An object representing the data source to write into the GPUBuffer. This can be an ArrayBuffer, TypedArray, or DataView.</param>
        /// <param name="dataOffset">A number representing the offset to start writing the data from inside the data source. 
        /// This value is a number of elements if data is a TypedArray, and a number of bytes if not. If omitted, dataOffset defaults to 0.</param>
        /// <param name="size">A number representing the size of the content to write from data to buffer. 
        /// This value is a number of elements if data is a TypedArray, and a number of bytes if not.
        /// If omitted, size will be equal to the overall size of data, minus dataOffset.</param>
        public void WriteBuffer(GPUBuffer gpuBuffer, long bufferOffset, AllowSharedBufferSource data, int? dataOffset = 0, long? size = null)
        {
            if (size == null)
                JSRef!.CallVoid("writeBuffer", gpuBuffer, bufferOffset, data, dataOffset);
            else
                JSRef!.CallVoid("writeBuffer", gpuBuffer, bufferOffset, data, dataOffset, size);
        }

        /// <summary>
        /// Issues a write operation of the provided data into a GPUTexture.
        /// </summary>
        /// <param name="destination">The texture subresource and origin to write to.</param>
        /// <param name="data">Data to write into destination.</param>
        /// <param name="dataLayout">Layout of the content in data.</param>
        /// <param name="size">Extents of the content to write from data to destination.</param>
        public void WriteTexture(GPUTexelCopyTextureInfo destination, AllowSharedBufferSource data, GPUTexelCopyBufferLayout dataLayout, GPUExtent3D size) => JSRef!.CallVoid("writeTexture", destination, data, dataLayout, size);

        /// <summary>
        /// Issues a copy operation of the contents of a platform image/canvas into the destination texture.<br/>
        /// This operation performs color encoding into the destination encoding according to the parameters of GPUCopyExternalImageDestInfo.<br/>
        /// Copying into a -srgb texture results in the same texture bytes, not the same decoded values, as copying into the corresponding non--srgb format. Thus, after a copy operation, sampling the destination texture has different results depending on whether its format is -srgb, all else unchanged.<br/>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="copySize"></param>
        public void CopyExternalImageToTexture(GPUCopyExternalImageSourceInfo source, GPUCopyExternalImageDestInfo destination, GPUExtent3D copySize) => JSRef!.CallVoid("copyExternalImageToTexture", source, destination, copySize);
    }
}
