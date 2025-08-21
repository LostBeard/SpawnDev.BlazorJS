using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUQueue interface of the WebGPU API controls execution of encoded commands on the GPU.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUQueue
    /// </summary>
    public class GPUQueue : JSObject
    {
        /// <inheritdoc/>
        public GPUQueue(IJSInProcessObjectReference _ref) : base(_ref){ }

        /// <summary>
        /// A string providing a label that can be used to identify the object, for example in GPUError messages or console warnings.
        /// </summary>
        public string Label => JSRef!.Get<string>("label");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandBuffers"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Submit(GPUCommandBuffer[] commandBuffers) => JSRef!.CallVoid("submit", commandBuffers);
    }
}
