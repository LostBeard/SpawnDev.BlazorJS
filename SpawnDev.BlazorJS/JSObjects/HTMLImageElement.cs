using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class HTMLImageElement : HTMLElement
    {
        public int Width => JSRef.Get<int>("width");
        public int Height => JSRef.Get<int>("height");
        public int NaturalWidth => JSRef.Get<int>("naturalWidth");
        public int NaturalHeight => JSRef.Get<int>("naturalHeight");
        public bool Complete => JSRef.Get<bool>("complete");
        public string Src { get => JSRef.Get<string>("src"); set => JSRef.Set("src", value); }
        public string CrossOrigin { get => JSRef.Get<string>("crossOrigin"); set => JSRef.Set("crossOrigin", value); }

        public HTMLImageElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        public HTMLImageElement(ElementReference elementReference) : base(JS.ToJSRef(elementReference)) { }
        public HTMLImageElement() : base(JS.New("Image")) { }

        public static Task<HTMLImageElement> CreateFromImageAsync(string src, string? crossOrigin = null)
        {
            var t = new TaskCompletionSource<HTMLImageElement>();
            CreateFromImage(src, (image) =>
            {
                if (image != null)
                {
                    t.SetResult(image);
                }
                else
                {
                    t.SetException(new Exception("Loading image failed"));
                }
            }, crossOrigin);
            return t.Task;
        }

        public static void CreateFromImage(string src, Action<HTMLImageElement?> callback, string? crossOrigin = null)
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
            if (crossOrigin != null) image.CrossOrigin = crossOrigin;
            image.Src = src;
        }

    }
}
