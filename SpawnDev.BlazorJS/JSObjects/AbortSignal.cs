using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<AbortSignal>))]
    public class AbortSignal : EventTarget
    {
        public AbortSignal(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Aborted => JSRef.Get<bool>("aborted");
        public void Abort() => JSRef.CallVoid("abort");
    }
}
