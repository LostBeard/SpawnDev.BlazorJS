using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class WakeLockSentinel : EventTarget
    {
        public WakeLockSentinel(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Released => JSRef.Get<bool>("released");
        public string Type => JSRef.Get<string>("type");
        /// <summary>
        /// release event
        /// </summary>
        public JSEventCallback OnRelease { get => new JSEventCallback((o) => AddEventListener("release", o), (o) => RemoveEventListener("release", o)); set { } }
    }
    public class WakeLock : JSObject
    {
        public WakeLock(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Task<WakeLockSentinel> Request(string type = "screen") => JSRef.CallAsync<WakeLockSentinel>("request", type);
    }
}
