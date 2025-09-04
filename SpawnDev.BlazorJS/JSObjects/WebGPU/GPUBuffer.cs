using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUBuffer interface of the WebGPU API represents a block of memory that can be used to store raw data to use in GPU operations.<br/>
    /// A GPUBuffer object instance is created using the GPUDevice.createBuffer() method.<br/>
    /// https://www.w3.org/TR/webgpu/#gpubuffer
    /// </summary>
    public class GPUBuffer : GPUObjectBase, IGPUBindingResource
    {
        /// <inheritdoc/>
        public GPUBuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An enumerated value representing the mapped state of the GPUBuffer.
        /// </summary>
        public EnumString<GPUBufferMapState>? MapState => JSRef!.Get<EnumString<GPUBufferMapState>?>("mapState");
        /// <summary>
        /// A number representing the length of the GPUBuffer's memory allocation, in bytes.
        /// </summary>
        public GPUSize64Out Size => JSRef!.Get<GPUSize64Out>("size");
        /// <summary>
        /// The usage read-only property of the GPUBuffer interface contains the bitwise flags representing the allowed usages of the GPUBuffer.<br/>
        /// usage is set via the usage property in the descriptor object passed into the originating GPUDevice.createBuffer() call.
        /// </summary>
        public GPUBufferUsage Usage => JSRef!.Get<GPUBufferUsage>("usage");
        /// <summary>
        /// Destroys the GPUBuffer
        /// </summary>
        public void Destroy() => JSRef!.CallVoid("destroy");
        /// <summary>
        /// The getMappedRange() method of the GPUBuffer interface returns an ArrayBuffer containing the mapped contents of the GPUBuffer in the specified range.<br/>
        /// This can only happen once the GPUBuffer has been successfully mapped with GPUBuffer.mapAsync() (this can be checked via GPUBuffer.mapState). While the GPUBuffer is mapped it cannot be used in any GPU commands.<br/>
        /// When you have finished working with the GPUBuffer values, call GPUBuffer.unmap() to unmap it, making it accessible to the GPU again.
        /// </summary>
        /// <returns>An ArrayBuffer.</returns>
        public ArrayBuffer GetMappedRange() => JSRef!.Call<ArrayBuffer>("getMappedRange");
        /// <summary>
        /// The getMappedRange() method of the GPUBuffer interface returns an ArrayBuffer containing the mapped contents of the GPUBuffer in the specified range.<br/>
        /// This can only happen once the GPUBuffer has been successfully mapped with GPUBuffer.mapAsync() (this can be checked via GPUBuffer.mapState). While the GPUBuffer is mapped it cannot be used in any GPU commands.<br/>
        /// When you have finished working with the GPUBuffer values, call GPUBuffer.unmap() to unmap it, making it accessible to the GPU again.
        /// </summary>
        /// <param name="offset">A number representing the offset, in bytes, from the start of the GPUBuffer's mapped range to the start of the range to be returned in the ArrayBuffer. If offset is omitted, it defaults to 0.</param>
        /// <returns>An ArrayBuffer.</returns>
        public ArrayBuffer GetMappedRange(long offset) => JSRef!.Call<ArrayBuffer>("getMappedRange", offset);
        /// <summary>
        /// The getMappedRange() method of the GPUBuffer interface returns an ArrayBuffer containing the mapped contents of the GPUBuffer in the specified range.<br/>
        /// This can only happen once the GPUBuffer has been successfully mapped with GPUBuffer.mapAsync() (this can be checked via GPUBuffer.mapState). While the GPUBuffer is mapped it cannot be used in any GPU commands.<br/>
        /// When you have finished working with the GPUBuffer values, call GPUBuffer.unmap() to unmap it, making it accessible to the GPU again.
        /// </summary>
        /// <param name="offset">A number representing the offset, in bytes, from the start of the GPUBuffer's mapped range to the start of the range to be returned in the ArrayBuffer. If offset is omitted, it defaults to 0.</param>
        /// <param name="size">A number representing the size, in bytes, of the ArrayBuffer to return. If size is omitted, the range extends to the end of the GPUBuffer's mapped range.</param>
        /// <returns>An ArrayBuffer.</returns>
        public ArrayBuffer GetMappedRange(long offset, long size) => JSRef!.Call<ArrayBuffer>("getMappedRange", offset, size);
        /// <summary>
        /// The mapAsync() method of the GPUBuffer interface maps the specified range of the GPUBuffer. It returns a Promise that resolves when the GPUBuffer's content is ready to be accessed. While the GPUBuffer is mapped it cannot be used in any GPU commands.<br/>
        /// Once the buffer is successfully mapped (which can be checked via GPUBuffer.mapState), calls to GPUBuffer.getMappedRange() will return an ArrayBuffer containing the GPUBuffer's current values, to be read and updated by JavaScript as required.<br/>
        /// When you have finished working with the GPUBuffer values, call GPUBuffer.unmap() to unmap it, making it accessible to the GPU again.
        /// </summary>
        /// <param name="mode">
        /// A bitwise flag that specifies whether the GPUBuffer is mapped for reading or writing. Possible values are:<br/>
        /// <br/>
        /// GPUMapMode.READ - The GPUBuffer is mapped for reading. Values can be read, but any changes made to the ArrayBuffer returned by GPUBuffer.getMappedRange() will be discarded once GPUBuffer.unmap() is called.<br/>
        /// Read-mode mapping can only be used on GPUBuffers that have a usage of GPUBufferUsage.MAP_READ set on them (i.e. when created with GPUDevice.createBuffer()).<br/>
        /// <br/>
        /// GPUMapMode.WRITE - The GPUBuffer is mapped for writing. Values can be read and updated — any changes made to the ArrayBuffer returned by GPUBuffer.getMappedRange() will be saved to the GPUBuffer once GPUBuffer.unmap() is called.<br/>
        /// Write-mode mapping can only be used on GPUBuffers that have a usage of GPUBufferUsage.MAP_WRITE set on them (i.e. when created with GPUDevice.createBuffer()).
        /// </param>
        /// <param name="offset">A number representing the offset, in bytes, from the start of the buffer to the start of the range to be mapped. If offset is omitted, it defaults to 0.</param>
        /// <param name="size">A number representing the size, in bytes, of the range to be mapped. If size is omitted, the range mapped extends to the end of the GPUBuffer.</param>
        /// <returns>A Promise that resolves to Undefined when the GPUBuffer's content is ready to be accessed.</returns>
        public Task MapAsync(GPUMapMode mode, long offset, long size) => JSRef!.CallVoidAsync("mapAsync", mode, offset, size);
        /// <summary>
        /// The mapAsync() method of the GPUBuffer interface maps the specified range of the GPUBuffer. It returns a Promise that resolves when the GPUBuffer's content is ready to be accessed. While the GPUBuffer is mapped it cannot be used in any GPU commands.<br/>
        /// Once the buffer is successfully mapped (which can be checked via GPUBuffer.mapState), calls to GPUBuffer.getMappedRange() will return an ArrayBuffer containing the GPUBuffer's current values, to be read and updated by JavaScript as required.<br/>
        /// When you have finished working with the GPUBuffer values, call GPUBuffer.unmap() to unmap it, making it accessible to the GPU again.
        /// </summary>
        /// <param name="mode">
        /// A bitwise flag that specifies whether the GPUBuffer is mapped for reading or writing. Possible values are:<br/>
        /// <br/>
        /// GPUMapMode.READ - The GPUBuffer is mapped for reading. Values can be read, but any changes made to the ArrayBuffer returned by GPUBuffer.getMappedRange() will be discarded once GPUBuffer.unmap() is called.<br/>
        /// Read-mode mapping can only be used on GPUBuffers that have a usage of GPUBufferUsage.MAP_READ set on them (i.e. when created with GPUDevice.createBuffer()).<br/>
        /// <br/>
        /// GPUMapMode.WRITE - The GPUBuffer is mapped for writing. Values can be read and updated — any changes made to the ArrayBuffer returned by GPUBuffer.getMappedRange() will be saved to the GPUBuffer once GPUBuffer.unmap() is called.<br/>
        /// Write-mode mapping can only be used on GPUBuffers that have a usage of GPUBufferUsage.MAP_WRITE set on them (i.e. when created with GPUDevice.createBuffer()).
        /// </param>
        /// <param name="offset">A number representing the offset, in bytes, from the start of the buffer to the start of the range to be mapped. If offset is omitted, it defaults to 0.</param>
        /// <returns>A Promise that resolves to Undefined when the GPUBuffer's content is ready to be accessed.</returns>
        public Task MapAsync(GPUMapMode mode, long offset = 0) => JSRef!.CallVoidAsync("mapAsync", mode, offset);
        /// <summary>
        /// The unmap() method of the GPUBuffer interface unmaps the mapped range of the GPUBuffer, making its contents available for use by the GPU again after it has previously been mapped with GPUBuffer.mapAsync() (the GPU cannot access a mapped GPUBuffer).<br/>
        /// When unmap() is called, any ArrayBuffers created via GPUBuffer.getMappedRange() are detached.
        /// </summary>
        public void Unmap() => JSRef!.CallVoid("unmap");
    }
}
