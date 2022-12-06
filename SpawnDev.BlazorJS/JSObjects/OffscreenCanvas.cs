using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<OffscreenCanvas>))]
    public class OffscreenCanvas : JSObject
    {
        public OffscreenCanvas(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
