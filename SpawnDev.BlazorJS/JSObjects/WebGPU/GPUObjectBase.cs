using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A WebGPU object consists of a WebGPU Interface and an internal object.
    /// The WebGPU interface defines the public interface and state of the WebGPU object. 
    /// It can be used on the content timeline where it was created, where it is a JavaScript-exposed WebIDL interface.
    /// Any interface which includes GPUObjectBase is a WebGPU interface.
    /// https://www.w3.org/TR/webgpu/#gpuobjectbase
    /// </summary>
    public abstract class GPUObjectBase : JSObject
    {
        /// <inheritdoc/>
        protected GPUObjectBase(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// A developer-provided label which is used in an implementation-defined way. 
        /// It can be used by the browser, OS, or other tools to help identify the underlying internal object to the developer. 
        /// Examples include displaying the label in GPUError messages, console warnings, browser developer tools, and platform debugging utilities.
        /// </summary>
        public string? Label => JSRef!.Get<string?>("label");
    }
}
