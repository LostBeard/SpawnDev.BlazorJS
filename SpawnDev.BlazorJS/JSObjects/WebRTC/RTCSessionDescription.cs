using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    [JsonConverter(typeof(JSObjectConverter<RTCSessionDescription>))]
    public class RTCSessionDescription : JSObject, IRTCSessionDescription
    {
        public RTCSessionDescription(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string ToJSON() => JSRef.Call<string>("toJSON");
        public string Type => JSRef.Get<string>("type");
        public string Sdp => JSRef.Get<string>("sdp");
    }
}
