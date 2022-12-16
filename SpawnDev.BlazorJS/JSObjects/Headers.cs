using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Headers>))]
    public class Headers : JSObject
    {
        public Headers() : base(JS.New(nameof(Headers))) { }
        public Headers(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void Append(string name, string value) => JSRef.CallVoid("append", name, value);
        public void Set(string name, string value) => JSRef.CallVoid("set", name, value);
        public string Get(string name) => JSRef.Call<string>("get", name);
        public void Delete(string name) => JSRef.CallVoid("delete", name);
    }
}
