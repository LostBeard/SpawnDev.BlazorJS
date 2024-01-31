using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Audio : HTMLMediaElement
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Audio(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Audio(string url) : base(JS.New(nameof(Audio), url)) { }
    }
}
