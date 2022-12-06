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
    [JsonConverter(typeof(JSObjectConverter<XMLHttpRequest>))]
    public class XMLHttpRequest : XMLHttpRequestEventTarget
    {
        public XMLHttpRequest() : base(JS.CreateNew("XMLHttpRequest")) { }
        public XMLHttpRequest(IJSInProcessObjectReference _ref) : base(_ref) { }
        public XMLHttpRequestUpload Upload => _ref.Get<XMLHttpRequestUpload>("upload");
        public int Status => _ref.Get<int>("status");
        public string ResponseText => _ref.Get<string>("responseText");
        public string StatusText => _ref.Get<string>("statusText");
        public Blob Response => _ref.Get<Blob>("response");
        public double Timeout { get => _ref.Get<double>("timeout"); set => _ref.Set("timeout", value); }
        public void Open(string method, string url, bool async) => _ref.CallVoid("open", method, url, async);
        public void Send(Blob blob) => _ref.CallVoid("send", blob);
        public void Send() => _ref.CallVoid("send");
        public bool WithCredentials { get => _ref.Get<bool>("withCredentials"); set => _ref.Set("withCredentials", value); }
        public void SetRequestHeader(string header, string value) => _ref.CallVoid("setRequestHeader", header, value);
        public void Abort() => _ref.CallVoid("abort");
        public string ResponseType { get => _ref.Get<string>("responseType"); set => _ref.Set("responseType", value); }
    }
}
