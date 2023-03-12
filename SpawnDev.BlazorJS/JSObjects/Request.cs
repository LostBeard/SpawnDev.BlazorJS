using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Dynamic;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Request>))]
    public class Request : JSObject
    {
        public Request(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool BodyUsed => JSRef.Get<bool>("bodyUsed");
        public string Url => JSRef.Get<string>("url");
        public string Method => JSRef.Get<string>("method");
        public string Credentials => JSRef.Get<string>("credentials");
        public Request(string url, ExpandoObject? options = null) : base(JS.New(nameof(Request), url, options)) { }
    }
}
