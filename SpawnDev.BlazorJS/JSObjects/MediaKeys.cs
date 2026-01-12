using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaKeys
    /// </summary>
    public class MediaKeys : JSObject
    {
        /// <summary>
        /// Creates a new instance of <see cref="MediaKeys"/>.
        /// </summary>
        /// <param name="_ref"></param>
        public MediaKeys(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
