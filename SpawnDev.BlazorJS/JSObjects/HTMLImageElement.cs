using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<HTMLImageElement>))]
    public class HTMLImageElement : HTMLElement
    {
        public int Width => _ref.Get<int>("width");
        public int Height => _ref.Get<int>("height");
        public int NaturalWidth => _ref.Get<int>("naturalWidth");
        public int NaturalHeight => _ref.Get<int>("naturalHeight");
        public bool Complete => _ref.Get<bool>("complete");

        public string Src { get => _ref.Get<string>("src"); set => _ref.Set("src", value); }

        public HTMLImageElement(IJSInProcessObjectReference _ref) : base(_ref) { }

        public HTMLImageElement() : base(JS.CreateNew("Image")) { }

        public static Task<HTMLImageElement> CreateFromImageAsync(string src)
        {
            var t = new TaskCompletionSource<HTMLImageElement>();
            CreateFromImage(src, t.SetResult);
            return t.Task;
        }

        //public static HTMLImageElement Create()
        //{
        //    return CreateNew<HTMLImageElement>("Image");
        //}

        public static void CreateFromImage(string src, Action<HTMLImageElement> callback)
        {
            var image = new HTMLImageElement();
            var imageCallbacks = new CallbackGroup();
            image.AddEventListener("load", Callback.Create(() =>
            {
                imageCallbacks.Dispose();
                callback(image);
            }, imageCallbacks));
            image.AddEventListener("error", Callback.Create(() =>
            {
                imageCallbacks.Dispose();
                image.Dispose();
                callback(null);
            }, imageCallbacks));
            image.Src = src;
        }

    }
}
