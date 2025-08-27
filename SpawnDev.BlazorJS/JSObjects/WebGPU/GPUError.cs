using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUError interface of the WebGPU API is the base interface for errors surfaced by GPUDevice.popErrorScope and the uncapturederror event.
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUError
    /// </summary>
    public class GPUError : JSObject
    {
        /// <inheritdoc/>
        public GPUError(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string providing a human-readable message that explains why the error occurred.
        /// </summary>
        public string Message => JSRef!.Get<string>("message");
        /// <summary>
        /// Returns the error type name
        /// </summary>
        public string ErrorType => JSRef!.ConstructorName()!;
    }
}
