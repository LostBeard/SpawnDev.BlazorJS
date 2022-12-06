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
        public JSObject SrcObject 
        {
            get => _ref.Get<JSObject>("srcObject");
            set => _ref.Set("srcObject", value);
        }


        public async Task Play() => await _ref.CallVoidAsync("play");
        public void Pause() => _ref.CallVoid("pause");
    }
}
