using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class RequestFullscreenOptions
    {
        /// <summary>
        /// Options hide, show, auto (default)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NavigationUI { get; set; }
    }
    [JsonConverter(typeof(JSObjectConverter<Element>))]
    public class Element : Node
    {
        public Element(IJSInProcessObjectReference _ref) : base(_ref) { }
        public DOMRect GetBoundingClientRect() => JSRef.Call<DOMRect>("getBoundingClientRect");
        public async Task RequestFullscreen() => await JSRef.InvokeVoidAsync("requestFullscreen");
        public async Task RequestFullscreen(RequestFullscreenOptions options) => await JSRef.InvokeVoidAsync("requestFullscreen", options);
    }
}