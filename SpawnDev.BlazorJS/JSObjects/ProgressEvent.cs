using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<ProgressEvent>))]
    public class ProgressEvent : JSObject
    {
        public ProgressEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public long? Loaded => JSRef.Get<long?>("loaded");
        public long? Total => JSRef.Get<long?>("total");
    }
}
