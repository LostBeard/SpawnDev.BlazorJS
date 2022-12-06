using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Audio>))]
    public class Audio : JSObject
    {
        public Audio(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Audio(string url) : base("Audio", url) { }
        public void Play() => JSRef.CallVoid("play");
    }
}
