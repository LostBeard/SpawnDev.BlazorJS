using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ResizeObserverSize
    {
        public double InlineSize { get; set; }
        public double BlockSize { get; set; }
    }

    [JsonConverter(typeof(JSObjectConverter<ResizeObserverEntry>))]
    public class ResizeObserverEntry : JSObject
    {
        public List<ResizeObserverSize> BorderBoxSize => _ref.Get<List<ResizeObserverSize>>("borderBoxSize");
        public List<ResizeObserverSize> ContentBoxSize => _ref.Get<List<ResizeObserverSize>>("contentBoxSize");
        public List<ResizeObserverSize> DevicePixelContentBoxSize => _ref.Get<List<ResizeObserverSize>>("devicePixelContentBoxSize");
        public DOMRect ContentRect => _ref.Get<DOMRect>("contentRect");
        public ResizeObserverEntry(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
