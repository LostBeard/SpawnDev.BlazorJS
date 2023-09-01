using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/FormData
    public class FormData : JSObject
    {
        public FormData(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
