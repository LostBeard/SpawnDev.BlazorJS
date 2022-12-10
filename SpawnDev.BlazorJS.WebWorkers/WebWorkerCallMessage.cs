using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.WebWorkers
{
    internal class WebWorkerCallMessageBase
    {
        public string ServiceTypeFullName { get; set; } = "";
        public string MethodName { get; set; } = "";
        public string RequestId { get; set; } = "";
    }

    internal class WebWorkerCallMessageOutgoing : WebWorkerCallMessageBase
    {
        public object?[]? Args { get; set; } = null;
    }
}
