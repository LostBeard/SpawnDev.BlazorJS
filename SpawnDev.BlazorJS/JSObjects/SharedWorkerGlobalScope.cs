using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<SharedWorkerGlobalScope>))]
    public class SharedWorkerGlobalScope : WorkerGlobalScope
    {
        public SharedWorkerGlobalScope(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void Close() => JSRef.CallVoid("close");
    }
}
