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

    //[JsonConverter(typeof(IJSObjectConverter<SharedWorker>))]
    //public class SharedWorker : IJSObject
    //{
    //    public static bool Supported => IJSObject.TypeOf("window.SharedWorker") != "undefined";
    //    CallbackGroup callbacks = new CallbackGroup();
    //    dynamic port = null;

    //    public SharedWorker(IJSInProcessObjectReference _ref) : base(_ref) { }

    //    public SharedWorker(string workerUrl)
    //    {
    //        FromReference(CreateNew("SharedWorker", workerUrl));
    //        port = _this.port<IJSObject>();
    //        port.addEventListener("message", Callback.Create<SharedWorkerMessageEvent>(onMessage, callbacks), false);
    //        port.start();
    //    }

    //    public void PostMessage(string msg)
    //    {
    //        port.postMessage(msg);
    //    }

    //    void onMessage(SharedWorkerMessageEvent e)
    //    {
    //        Console.WriteLine("SharedWorkerMessageEvent: " + e.Data);
    //    }

    //    public override void Dispose()
    //    {
    //        if (IsWrapperDisposed) return;
    //        port?.Dispose();
    //        callbacks.Dispose();
    //        base.Dispose();
    //    }
    //}
}
