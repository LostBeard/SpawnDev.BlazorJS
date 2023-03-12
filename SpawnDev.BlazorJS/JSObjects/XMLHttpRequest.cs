using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;
using SpawnDev.BlazorJS.JsonConverters;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<XMLHttpRequest>))]
    public class XMLHttpRequest : XMLHttpRequestEventTarget
    {
        public XMLHttpRequest() : base(JS.New("XMLHttpRequest")) { }
        public XMLHttpRequest(IJSInProcessObjectReference _ref) : base(_ref) { }
        public XMLHttpRequestUpload Upload => JSRef.Get<XMLHttpRequestUpload>("upload");
        public int Status => JSRef.Get<int>("status");
        public string ResponseText => JSRef.Get<string>("responseText");
        public string StatusText => JSRef.Get<string>("statusText");
        public Blob Response => JSRef.Get<Blob>("response");
        public double Timeout { get => JSRef.Get<double>("timeout"); set => JSRef.Set("timeout", value); }
        public void Open(string method, string url, bool async) => JSRef.CallVoid("open", method, url, async);
        public void Send(Blob blob) => JSRef.CallVoid("send", blob);
        public void Send() => JSRef.CallVoid("send");
        public bool WithCredentials { get => JSRef.Get<bool>("withCredentials"); set => JSRef.Set("withCredentials", value); }
        public void SetRequestHeader(string header, string value) => JSRef.CallVoid("setRequestHeader", header, value);
        public void Abort() => JSRef.CallVoid("abort");
        public string ResponseType { get => JSRef.Get<string>("responseType"); set => JSRef.Set("responseType", value); }
    }
}
