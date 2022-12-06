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
        public List<ResizeObserverSize> BorderBoxSize => JSRef.Get<List<ResizeObserverSize>>("borderBoxSize");
        public List<ResizeObserverSize> ContentBoxSize => JSRef.Get<List<ResizeObserverSize>>("contentBoxSize");
        public List<ResizeObserverSize> DevicePixelContentBoxSize => JSRef.Get<List<ResizeObserverSize>>("devicePixelContentBoxSize");
        public DOMRect ContentRect => JSRef.Get<DOMRect>("contentRect");
        public ResizeObserverEntry(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
