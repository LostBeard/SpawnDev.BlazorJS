using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUQueue interface of the WebGPU API controls execution of encoded commands on the GPU.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUQueue
    /// </summary>
    public class GPUQueue : JSObject
    {
        public GPUQueue(IJSInProcessObjectReference _ref) : base(_ref){ }
        public string Label => JSRef.Get<string>("label");

        // TODO finish
        //public void CopyExternalImageToTexture(source, destination, copySize) => JSRef.CallVoid("copyExternalImageToTexture");
        
    }
}
