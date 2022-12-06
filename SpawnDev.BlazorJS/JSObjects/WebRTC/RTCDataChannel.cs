using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    [JsonConverter(typeof(JSObjectConverter<RTCDataChannel>))]
    public class RTCDataChannel : EventTarget
    {
        public RTCDataChannel(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ushort Id => _ref.Get<ushort>("id");
        public string Label => _ref.Get<string>("label");
        public bool Ordered => _ref.Get<bool>("ordered");
        public ushort? MaxPacketLifeTime => _ref.Get<ushort?>("maxPacketLifeTime");
        public ushort? MaxRetransmits => _ref.Get<ushort?>("maxRetransmits");
        public string Protocol => _ref.Get<string>("protocol");
        public bool Negotiated => _ref.Get<bool>("negotiated");
        public string ReadyState => _ref.Get<string>("readyState");
        public void Close() => _ref.CallVoid("close");
        public void Open() => _ref.CallVoid("open");
        public void Send(string data) => _ref.CallVoid("send", data);
        public void Send(Blob data) => _ref.CallVoid("send", data);
        public void Send(ArrayBuffer data) => _ref.CallVoid("send", data);
    }
}
