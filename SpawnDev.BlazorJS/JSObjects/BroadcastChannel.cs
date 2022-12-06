using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<BroadcastChannel>))]
    public class BroadcastChannel : JSObject
    {
        public BroadcastChannel(IJSInProcessObjectReference _ref) :base(_ref){ }
        CallbackGroup callbacks = new CallbackGroup();
        public string Name => _ref.Get<string>("name");
        BroadcastChannel(string channelName) : base("BroadcastChannel", channelName) { }
        public void PostMessage<T>(T msg) => _ref.CallVoid("postMessage", msg);
        public void OnMessage(Callback callback) => callbacks.Add(callback);
        public void Close() => _ref.CallVoid("close");
        public override void Dispose()
        {
            if (IsWrapperDisposed) return;
            base.Dispose();
            callbacks.Dispose();
        }
    }
}
