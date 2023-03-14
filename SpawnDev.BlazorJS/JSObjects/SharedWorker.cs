using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class SharedWorker : EventTarget
    {
        public MessagePort Port => JSRef.Get<MessagePort>("port");

        public SharedWorker(IJSInProcessObjectReference _ref) : base(_ref) { }
        public SharedWorker(string url) : base(JS.New(nameof(SharedWorker), url))
        { }
        public SharedWorker(string url, string name) : base(JS.New(nameof(SharedWorker), url, name))
        { }
    }
}
