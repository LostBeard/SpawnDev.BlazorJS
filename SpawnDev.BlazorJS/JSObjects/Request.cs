using Microsoft.JSInterop;
using System.Dynamic;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Request>))]
    public class Request : JSObject
    {
        public Request(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool BodyUsed => _ref.Get<bool>("bodyUsed");
        public string Url => _ref.Get<string>("url");
        public string Method => _ref.Get<string>("method");
        public string Credentials => _ref.Get<string>("credentials");
        public Request(string url, ExpandoObject options = null) : base("Request", url, options) { }
    }
}
