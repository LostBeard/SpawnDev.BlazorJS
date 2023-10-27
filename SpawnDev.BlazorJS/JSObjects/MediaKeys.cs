using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaKeys
    /// </summary>
    public class MediaKeys : JSObject
    {
        public MediaKeys(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
