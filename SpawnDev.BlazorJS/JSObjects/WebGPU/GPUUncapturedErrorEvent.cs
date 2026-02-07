using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUUncapturedErrorEvent interface of the WebGPU API is the event object type for the GPUDevice uncapturederror event, used for telemetry and to report unexpected errors.
    /// </summary>
    public class GPUUncapturedErrorEvent : Event
    {
        /// <inheritdoc/>
        public GPUUncapturedErrorEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A GPUError object instance providing access to the details of the error.
        /// </summary>
        public GPUError Error => JSRef!.Get<GPUError>("error");
    }
}
