using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Node : EventTarget
    {
        public Node(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string NodeName => JSRef.Get<string>("nodeName");
        public string BaseURI => JSRef.Get<string>("baseURI");
        public bool IsConnected => JSRef.Get<bool>("isConnected");
        public void AppendChild(JSObject node) => JSRef.CallVoid("appendChild", node);
        public void AppendChild(IJSInProcessObjectReference node) => JSRef.CallVoid("appendChild", node);
        public void AppendChild(ElementReference node) => JSRef.CallVoid("appendChild", node);
        public void RemoveChild(JSObject node) => JSRef.CallVoid("removeChild", node);
        public void RemoveChild(IJSInProcessObjectReference node) => JSRef.CallVoid("removeChild", node);
        public void RemoveChild(ElementReference node) => JSRef.CallVoid("removeChild", node);
        public bool Contains(JSObject node) => JSRef.Call<bool>("contains");
        public Node ParentNode => JSRef.Get<Node>("parentNode");
        public Node CloneNode() => JSRef.Call<Node>("cloneNode");
        public Node CloneNode(bool deep) => JSRef.Call<Node>("cloneNode", deep);

        public JSEventCallback OnSelectStart { get => new JSEventCallback(o => AddEventListener("selectstart", o), o => RemoveEventListener("selectstart", o)); set { /** required **/ } }
    }
}
