using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<HTMLElement>))]
    public class HTMLElement : Element
    {
        public HTMLElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int OffsetWidth => JSRef.Get<int>("offsetWidth");
        public int OffsetHeight => JSRef.Get<int>("offsetHeight");
    }
}