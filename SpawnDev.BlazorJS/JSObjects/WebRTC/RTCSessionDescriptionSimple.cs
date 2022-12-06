using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCSessionDescriptionSimple : IRTCSessionDescription
    {
        public string Type { get; set; }
        public string Sdp { get; set; }
        public RTCSessionDescriptionSimple(){}
        public RTCSessionDescriptionSimple(string type, string sdp) => (Type, Sdp) = (type, sdp);
    }
}
