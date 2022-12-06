using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Node>))]
    public class Node : EventTarget
    {
        public Node(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string NodeName => _ref.Get<string>("nodeName");
        public string BaseURI => _ref.Get<string>("baseURI");
        public bool IsConnected => _ref.Get<bool>("isConnected");
    }
}
