using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLImageElement interface represents an HTML &lt;img&gt; element, providing the properties and methods used to manipulate image elements.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLImageElement
    /// </summary>
    public class HTMLImageElement : HTMLElement
    {
        /// <summary>
        /// Explicit conversion from ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLImageElement?(ElementReference elementReference) => elementReference.Context == null || string.IsNullOrEmpty(elementReference.Id) ? null : new HTMLImageElement(elementReference);
        /// <summary>
        /// Explicit conversion from ElementReference?
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLImageElement?(ElementReference? elementReference) => elementReference == null || elementReference.Value.Context == null || string.IsNullOrEmpty(elementReference.Value.Id) ? null : new HTMLImageElement(elementReference.Value);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLImageElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLImageElement(ElementReference elementReference) : base(elementReference) { }
        /// <summary>
        /// The Image() constructor creates and returns a new HTMLImageElement object representing an HTML <img> element which is not attached to any DOM tree. It accepts optional width and height parameters. When called without parameters, new Image() is equivalent to calling document.createElement('img').
        /// </summary>
        public HTMLImageElement() : base(JS.New("Image")) { }
        public int Width => JSRef!.Get<int>("width");
        public int Height => JSRef!.Get<int>("height");
        public int NaturalWidth => JSRef!.Get<int>("naturalWidth");
        public int NaturalHeight => JSRef!.Get<int>("naturalHeight");
        public bool Complete => JSRef!.Get<bool>("complete");
        public string Src { get => JSRef!.Get<string>("src"); set => JSRef!.Set("src", value); }
        public string CrossOrigin { get => JSRef!.Get<string>("crossOrigin"); set => JSRef!.Set("crossOrigin", value); }

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
            var callbacks = new CallbackGroup();
            image.AddEventListener("load", callbacks.Add(Callback.Create(() =>
            {
                callbacks.Dispose();
                callback(image);
            })));
            image.AddEventListener("error", callbacks.Add(Callback.Create(() =>
            {
                callbacks.Dispose();
                image.Dispose();
                callback(null);
            })));
            if (crossOrigin != null) image.CrossOrigin = crossOrigin;
            image.Src = src;
        }

    }
}
