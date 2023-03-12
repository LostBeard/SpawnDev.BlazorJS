using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<TransformStream>))]
    public class TransformStream : JSObject
    {
        public TransformStream(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }
    }
}
