using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Node>))]
    public class Node : EventTarget
    {
        public Node(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string NodeName => JSRef.Get<string>("nodeName");
        public string BaseURI => JSRef.Get<string>("baseURI");
        public bool IsConnected => JSRef.Get<bool>("isConnected");
        public void AppendChild(JSObject node) => JSRef.CallVoid("appendChild");
        public void AppendChild(IJSInProcessObjectReference node) => JSRef.CallVoid("appendChild");
        public void Contains(JSObject node) => JSRef.Call<bool>("contains");
    }
}
