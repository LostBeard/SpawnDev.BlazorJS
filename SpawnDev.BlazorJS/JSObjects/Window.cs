using Microsoft.JSInterop;
//using SpawnDev.JS.Tools;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{

    [JsonConverter(typeof(JSObjectConverter<Window>))]
    public class Window : JSObject
    {
        public Window() : base(JS.Get<IJSInProcessObjectReference>("window")) { }
        public Window(IJSInProcessObjectReference _ref) : base(_ref) { }
        public WebStorage SessionStorage => _ref.Get<WebStorage>("sessionStorage");
        public WebStorage LocalStorage => _ref.Get<WebStorage>("localStorage");
        public Navigator Navigator => _ref.Get<Navigator>("navigator");
        public Screen Screen => _ref.Get<Screen>("screen");
        public long SetTimeout(Callback callback, double delay) => _ref.Call<long>("setTimeout", callback, delay);
        public void ClearTimeout(long requestId) => _ref.CallVoid("clearTimeout", requestId);
        public long RequestAnimationFrame(Callback callback) => _ref.Call<long>("requestAnimationFrame", callback);
        public void CancelAnimationFrame(long requestId) => _ref.CallVoid("cancelAnimationFrame", requestId);
        public double DevicePixelRatio { get { var tmp = _ref.Get<double>("devicePixelRatio"); return tmp > 0d ? tmp : 1d;  } }
        public int InnerWidth => _ref.Get<int>("innerWidth");
        public int InnerHeight => _ref.Get<int>("innerHeight");
        ///// <summary>
        ///// Experimental state. Not supported in most browsers. (Works in Chrome)
        ///// </summary>
        ///// <returns>ScreenDetails</returns>
        public async Task<ScreenDetails> GetScreenDetails() => await _ref.CallAsync<ScreenDetails>("getScreenDetails");
    }
}
