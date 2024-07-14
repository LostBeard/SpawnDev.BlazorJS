using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/InputDeviceCapabilities<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/InputDeviceCapabilities
    /// </summary>
    public class InputDeviceCapabilities : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public InputDeviceCapabilities(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A Boolean that indicates whether the device dispatches touch events.
        /// </summary>
        public bool FiresTouchEvents => JSRef!.Get<bool>("firesTouchEvents");
    }
}
