using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class BroadcastChannel : EventTarget {
        public BroadcastChannel(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Name => JSRef.Get<string>("name");
        public BroadcastChannel(string channelName) : base(JS.New("BroadcastChannel", channelName)) { }
        CallbackGroup _callbacks = new CallbackGroup();
        public delegate void ErrorDelete();
        public event ErrorDelete OnError;
        public delegate void MessageDelegate(MessageEvent msg);
        public event MessageDelegate OnMessage;
        protected override void FromReference(IJSInProcessObjectReference _ref) {
            base.FromReference(_ref);
            AddEventListener("message", Callback.Create<MessageEvent>((e) => {
                OnMessagePre(e);
                e.Dispose();
            }, _callbacks));
            AddEventListener("messageerror", Callback.Create<MessageEvent>((e) => {
                OnErrorPre();
                e.Dispose();
            }, _callbacks));
        }

        protected virtual void OnMessagePre(MessageEvent e) {
            OnMessage?.Invoke(e);
        }

        protected virtual void OnErrorPre() {
            OnError?.Invoke();
        }

        public void Close() => JSRef.CallVoid("close");
        public void PostMessaage(object message) {
            JSRef.CallVoid("postMessage", message);
        }
        protected override void LosingReference()
        {
            _callbacks.Dispose();
        }
    }
}
