using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Window : EventTarget {
        public Window() : base(JS.Get<IJSInProcessObjectReference>("window")) { }
        public Window(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string? Name { get => JSRef.Get<string>("name"); set => JSRef.Set("name", value); }
        public WebStorage SessionStorage => JSRef.Get<WebStorage>("sessionStorage");
        public WebStorage LocalStorage => JSRef.Get<WebStorage>("localStorage");
        public Navigator Navigator => JSRef.Get<Navigator>("navigator");
        public Screen Screen => JSRef.Get<Screen>("screen");
        public long SetTimeout(Callback callback, double delay) => JSRef.Call<long>("setTimeout", callback, delay);
        public void ClearTimeout(long requestId) => JSRef.CallVoid("clearTimeout", requestId);
        public long RequestAnimationFrame(Callback callback) => JSRef.Call<long>("requestAnimationFrame", callback);
        public void CancelAnimationFrame(long requestId) => JSRef.CallVoid("cancelAnimationFrame", requestId);
        public double DevicePixelRatio { get { var tmp = JSRef.Get<double>("devicePixelRatio"); return tmp > 0d ? tmp : 1d; } }
        public int InnerWidth => JSRef.Get<int>("innerWidth");
        public int InnerHeight => JSRef.Get<int>("innerHeight");
        ///// <summary>
        ///// Experimental state. Not supported in most browsers. (Works in Chrome)
        ///// </summary>
        ///// <returns>ScreenDetails</returns>
        public Task<ScreenDetails> GetScreenDetails() => JSRef.CallAsync<ScreenDetails>("getScreenDetails");

        // non-standard .Net extension
        CallbackGroup _callbacks = new CallbackGroup();
        public delegate void AnimationFrameDelegate(double timestamp);
        private Callback _OnAnimationFrameCallback;
        private long _OnAnimationFrameCallbackHandle = 0;
        private int _OnAnimationFrameCount = 0;
        private event AnimationFrameDelegate _OnAnimationFrame;
        public event AnimationFrameDelegate OnAnimationFrame {
            add {
                _OnAnimationFrame += value;
                _OnAnimationFrameCount = _OnAnimationFrame == null ? 0 : _OnAnimationFrame.GetInvocationList().Length;
                if (_OnAnimationFrameCount == 1) {
                    if (_OnAnimationFrameCallback == null) _OnAnimationFrameCallback = Callback.Create<double>(AnimationFrame, _callbacks);
                    _OnAnimationFrameCallbackHandle = RequestAnimationFrame(_OnAnimationFrameCallback);
                }
            }
            remove {
                _OnAnimationFrame -= value;
                _OnAnimationFrameCount = _OnAnimationFrame == null ? 0 : _OnAnimationFrame.GetInvocationList().Length;
                if (_OnAnimationFrameCount == 0) {
                    if (_OnAnimationFrameCallbackHandle != 0) {
                        CancelAnimationFrame(_OnAnimationFrameCallbackHandle);
                        _OnAnimationFrameCallbackHandle = 0;
                    }
                }
            }
        }
        void AnimationFrame(double timestaamp) {
            if (_OnAnimationFrameCount > 0)
                _OnAnimationFrameCallbackHandle = RequestAnimationFrame(_OnAnimationFrameCallback);
            _OnAnimationFrame?.Invoke(timestaamp);
        }
    }
}
