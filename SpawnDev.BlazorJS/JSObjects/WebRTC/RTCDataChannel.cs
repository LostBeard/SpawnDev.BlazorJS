using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    // https://developer.mozilla.org/en-US/docs/Web/API/RTCDataChannel
    // https://developer.mozilla.org/en-US/docs/Web/API/WebRTC_API/Simple_RTCDataChannel_sample
    [JsonConverter(typeof(JSObjectConverter<RTCDataChannel>))]
    public class RTCDataChannel : EventTarget
    {
        public RTCDataChannel(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ushort Id => JSRef.Get<ushort>("id");
        public string Label => JSRef.Get<string>("label");
        public bool Ordered => JSRef.Get<bool>("ordered");
        public ushort? MaxPacketLifeTime => JSRef.Get<ushort?>("maxPacketLifeTime");
        public ushort? MaxRetransmits => JSRef.Get<ushort?>("maxRetransmits");
        public string Protocol => JSRef.Get<string>("protocol");
        public bool Negotiated => JSRef.Get<bool>("negotiated");
        public string ReadyState => JSRef.Get<string>("readyState");
        public void Close() => JSRef.CallVoid("close");
        //public void Open() => JSRef.CallVoid("open");
        public void Send(string data) => JSRef.CallVoid("send", data);
        public void Send(Blob data) => JSRef.CallVoid("send", data);
        public void Send(ArrayBuffer data) => JSRef.CallVoid("send", data);
    }
}
