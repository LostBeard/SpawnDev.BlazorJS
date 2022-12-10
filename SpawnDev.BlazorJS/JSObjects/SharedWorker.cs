using Microsoft.JSInterop;
using SpawnDev.BlazorJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    //public class SharedWorkerMessageEvent
    //{
    //    public string Data { get; set; }
    //}

    [JsonConverter(typeof(JSObjectConverter<SharedWorker>))]
    public class SharedWorker : EventTarget
    {
        CallbackGroup _callbacks = new CallbackGroup();
        public delegate void MessageDelegate(MessageEvent msg);
        public event MessageDelegate OnMessage;

        public MessagePort Port => JSRef.Get<MessagePort>("port");

        public SharedWorker(IJSInProcessObjectReference _ref) : base(_ref) { }
        public SharedWorker(string url) : base(NullRef)
        {
            FromReference(JS.CreateNew("SharedWorker", url));
        }
        public SharedWorker(string url, string name) : base(NullRef)
        {
            FromReference(JS.CreateNew("SharedWorker", url, name));
        }
        protected override void FromReference(IJSInProcessObjectReference _ref)
        {
            base.FromReference(_ref);
            
        }

        public override void Dispose()
        {
            _callbacks.Dispose();
            base.Dispose();
        }
    }
}
