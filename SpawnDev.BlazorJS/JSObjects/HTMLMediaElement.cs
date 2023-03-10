using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/HTMLMediaElement
    [JsonConverter(typeof(JSObjectConverter<HTMLMediaElement>))]
    public class HTMLMediaElement : HTMLElement
    {
        public HTMLMediaElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        // MediaStream, MediaSource, Blob, or File
        public JSObject? SrcObject 
        {
            get => JSRef.Get<JSObject>("srcObject");
            set => JSRef.Set("srcObject", value);
        }
        public string? Src
        {
            get => JSRef.Get<string>("src");
            set => JSRef.Set("src", value);
        }
        public double CurrentTime {
            get => JSRef.Get<double>("currentTime");
            set => JSRef.Set("currentTime", value);
        }
        public string? CurrentSrc
        {
            get => JSRef.Get<string>("currentSrc");
        }
        public T? GetSrcObject<T>() => JSRef.Get<T>("srcObject");

        public async Task Play() => await JSRef.CallVoidAsync("play");
        public void Pause() => JSRef.CallVoid("pause");
    }
}
