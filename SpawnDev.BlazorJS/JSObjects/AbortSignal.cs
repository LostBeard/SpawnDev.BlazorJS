using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<AbortSignal>))]
    public class AbortSignal : EventTarget
    {
        public AbortSignal(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Aborted => _ref.Get<bool>("aborted");
        public void Abort() => _ref.CallVoid("abort");
    }
}
