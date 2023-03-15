using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class HTMLImageElement : HTMLElement {
        public int Width => JSRef.Get<int>("width");
        public int Height => JSRef.Get<int>("height");
        public int NaturalWidth => JSRef.Get<int>("naturalWidth");
        public int NaturalHeight => JSRef.Get<int>("naturalHeight");
        public bool Complete => JSRef.Get<bool>("complete");

        public string Src { get => JSRef.Get<string>("src"); set => JSRef.Set("src", value); }

        public HTMLImageElement(IJSInProcessObjectReference _ref) : base(_ref) { }

        public HTMLImageElement() : base(JS.New("Image")) { }

        public static Task<HTMLImageElement> CreateFromImageAsync(string src) {
            var t = new TaskCompletionSource<HTMLImageElement>();
            CreateFromImage(src, t.SetResult);
            return t.Task;
        }

        //public static HTMLImageElement Create()
        //{
        //    return CreateNew<HTMLImageElement>("Image");
        //}

        public static void CreateFromImage(string src, Action<HTMLImageElement> callback) {
            var image = new HTMLImageElement();
            var imageCallbacks = new CallbackGroup();
            image.AddEventListener("load", Callback.Create(() => {
                imageCallbacks.Dispose();
                callback(image);
            }, imageCallbacks));
            image.AddEventListener("error", Callback.Create(() => {
                imageCallbacks.Dispose();
                image.Dispose();
                callback(null);
            }, imageCallbacks));
            image.Src = src;
        }

    }
}
