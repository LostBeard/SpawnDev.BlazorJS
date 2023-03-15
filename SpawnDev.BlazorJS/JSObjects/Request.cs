using Microsoft.JSInterop;
using System.Dynamic;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Request : JSObject {
        public Request(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool BodyUsed => JSRef.Get<bool>("bodyUsed");
        public string Url => JSRef.Get<string>("url");
        public string Method => JSRef.Get<string>("method");
        public string Credentials => JSRef.Get<string>("credentials");
        public Request(string url, ExpandoObject? options = null) : base(JS.New(nameof(Request), url, options)) { }
    }
}
