using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUQueue interface of the WebGPU API controls execution of encoded commands on the GPU.<br/>
    /// https://www.w3.org/TR/webgpu/#gpuqueue
    /// </summary>
    public class GPUQueue : GPUObjectBase
    {
        /// <inheritdoc/>
        public GPUQueue(IJSInProcessObjectReference _ref) : base(_ref){ }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandBuffers"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Submit(GPUCommandBuffer[] commandBuffers) => JSRef!.CallVoid("submit", commandBuffers);

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
        public void WriteBuffer(GPUBuffer gpuBuffer, long bufferOffset, ArrayBuffer data, int? dataOffset = 0, long? size = null) => 
            JSRef!.CallVoid("writeBuffer", gpuBuffer, bufferOffset, data, dataOffset, size);
    }
}
