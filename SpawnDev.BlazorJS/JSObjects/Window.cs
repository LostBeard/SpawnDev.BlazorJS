using Microsoft.JSInterop;
//using SpawnDev.JS.Tools;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{

    [JsonConverter(typeof(JSObjectConverter<Window>))]
    public class Window : EventTarget
    {
        public Window() : base(JS.Get<IJSInProcessObjectReference>("window")) { }
        public Window(IJSInProcessObjectReference _ref) : base(_ref) { }
        public WebStorage SessionStorage => JSRef.Get<WebStorage>("sessionStorage");
        public WebStorage LocalStorage => JSRef.Get<WebStorage>("localStorage");
        public Navigator Navigator => JSRef.Get<Navigator>("navigator");
        public Screen Screen => JSRef.Get<Screen>("screen");
        public long SetTimeout(Callback callback, double delay) => JSRef.Call<long>("setTimeout", callback, delay);
        public void ClearTimeout(long requestId) => JSRef.CallVoid("clearTimeout", requestId);
        public long RequestAnimationFrame(Callback callback) => JSRef.Call<long>("requestAnimationFrame", callback);
        public void CancelAnimationFrame(long requestId) => JSRef.CallVoid("cancelAnimationFrame", requestId);
        public double DevicePixelRatio { get { var tmp = JSRef.Get<double>("devicePixelRatio"); return tmp > 0d ? tmp : 1d;  } }
        public int InnerWidth => JSRef.Get<int>("innerWidth");
        public int InnerHeight => JSRef.Get<int>("innerHeight");
        ///// <summary>
        ///// Experimental state. Not supported in most browsers. (Works in Chrome)
        ///// </summary>
        ///// <returns>ScreenDetails</returns>
        public async Task<ScreenDetails> GetScreenDetails() => await JSRef.CallAsync<ScreenDetails>("getScreenDetails");
    }
}
