using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUCanvasContext interface of the WebGPU API represents the WebGPU rendering context of a canvas element, 
    /// returned via an HTMLCanvasElement.getContext() call with a contextType of "webgpu".
    /// https://www.w3.org/TR/webgpu/#gpucanvascontext
    /// </summary>
    public class GPUCanvasContext : JSObject
    {
        /// <inheritdoc/>
        public GPUCanvasContext(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Configures the context to use for rendering with a given GPUDevice.
        /// When called the canvas will initially be cleared to transparent black.
        /// </summary>
        /// <param name="configuration"></param>
        public void Configure(GPUCanvasConfiguration configuration) => JSRef!.CallVoid("configure", configuration);

        /// <summary>
        /// The getCurrentTexture() method of the GPUCanvasContext interface returns the next GPUTexture to
        /// be composited to the document by the canvas context.
        /// </summary>
        /// <returns></returns>
        public GPUTexture GetCurrentTexture() => JSRef!.Call<GPUTexture>("getCurrentTexture");

        /// <summary>
        /// Removes the context configuration. Destroys any textures produced while configured
        /// </summary>
        public void Unconfigure() => JSRef!.CallVoid("unconfigure");

        /// <summary>
        /// Returns the context configuration.
        /// </summary>
        /// <returns></returns>
        public GPUCanvasConfiguration? GetConfiguration() => JSRef!.Call<GPUCanvasConfiguration?>("getConfiguration");
    } 
}
