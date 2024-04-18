using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Touch interface represents a single contact point on a touch-sensitive device. The contact point is commonly a finger or stylus and the device may be a touchscreen or trackpad.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Touch
    /// </summary>
    public class Touch : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Touch(IJSInProcessObjectReference _ref) : base(_ref) { }

        // TODO
    }
}
