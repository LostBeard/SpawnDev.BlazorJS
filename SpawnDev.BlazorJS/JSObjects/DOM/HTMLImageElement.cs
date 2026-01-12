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
        /// <summary>
        /// A string that reflects the alt HTML attribute, thus indicating the alternate fallback content to be displayed if the image has not been loaded.
        /// </summary>
        public string Alt { get => JSRef!.Get<string>("alt"); set => JSRef!.Set("alt", value); }
        /// <summary>
        /// Returns a boolean value that is true if the browser has finished fetching the image, whether successful or not. That means this value is also true if the image has no src value indicating an image to load.
        /// </summary>
        public bool Complete => JSRef!.Get<bool>("complete");
        /// <summary>
        /// A string specifying the CORS setting for this image element. See CORS settings attributes for further details. This may be null if CORS is not used.
        /// </summary>
        public string? CrossOrigin { get => JSRef!.Get<string?>("crossOrigin"); set => JSRef!.Set("crossOrigin", value); }
        /// <summary>
        /// Returns a string representing the URL from which the currently displayed image was loaded. This may change as the image is adjusted due to changing conditions, as directed by any media queries which are in place.
        /// </summary>
        public string CurrentSrc => JSRef!.Get<string>("currentSrc");
        /// <summary>
        /// An optional string representing a hint given to the browser on how it should decode the image. If this value is provided, it must be one of the possible permitted values: sync to decode the image synchronously, async to decode it asynchronously, or auto to indicate no preference (which is the default). Read the decoding page for details on the implications of this property's values.
        /// </summary>
        public string? Decoding { get => JSRef!.Get<string?>("decoding"); set => JSRef!.Set("decoding", value); }
        /// <summary>
        /// An optional string representing a hint given to the browser on how it should prioritize fetching of the image relative to other images. If this value is provided, it must be one of the possible permitted values: high to fetch at a high priority, low to fetch at a low priority, or auto to indicate no preference (which is the default).
        /// </summary>
        public string? FetchPriority { get => JSRef!.Get<string?>("fetchPriority"); set => JSRef!.Set("fetchPriority", value); }
        /// <summary>
        /// An integer value that reflects the height HTML attribute, indicating the rendered height of the image in CSS pixels.
        /// </summary>
        public int Height => JSRef!.Get<int>("height");
        /// <summary>
        /// A boolean value that reflects the ismap HTML attribute, indicating that the image is part of a server-side image map. This is different from a client-side image map, specified using an &lt;image&gt; element and a corresponding &lt;map&gt; which contains &lt;area&gt; elements indicating the clickable areas in the image. The image must be contained within an &lt;a&gt; element; see the ismap page for details.
        /// </summary>
        public bool IsMap { get => JSRef!.Get<bool>("isMap"); set => JSRef!.Set("isMap", value); }
        /// <summary>
        /// A string providing a hint to the browser used to optimize loading the document by determining whether to load the image immediately (eager) or on an as-needed basis (lazy).
        /// </summary>
        public string? Loading { get => JSRef!.Get<string?>("loading"); set => JSRef!.Set("loading", value); }
        /// <summary>
        /// An integer value representing the intrinsic height of the image in CSS pixels, if it is available; else, it shows 0. This is the height the image would be if it were rendered at its natural full size.
        /// </summary>
        public int NaturalHeight => JSRef!.Get<int>("naturalHeight");
        /// <summary>
        /// An integer value representing the intrinsic width of the image in CSS pixels, if it is available; otherwise, it will show 0. This is the width the image would be if it were rendered at its natural full size.
        /// </summary>
        public int NaturalWidth => JSRef!.Get<int>("naturalWidth");
        /// <summary>
        /// A string that reflects the referrerpolicy HTML attribute, which tells the user agent how to decide which referrer to use in order to fetch the image. Read this article for details on the possible values of this string.
        /// </summary>
        public string? ReferrerPolicy { get => JSRef!.Get<string?>("referrerPolicy"); set => JSRef!.Set("referrerPolicy", value); }
        /// <summary>
        /// A string reflecting the sizes HTML attribute. This string specifies a list of comma-separated conditional sizes for the image; that is, for a given viewport size, a particular image size is to be used. Read the documentation on the sizes page for details on the format of this string.
        /// </summary>
        public string? Sizes { get => JSRef!.Get<string?>("sizes"); set => JSRef!.Set("sizes", value); }
        /// <summary>
        /// A string that reflects the src HTML attribute, which contains the full URL of the image including base URI. You can load a different image into the element by changing the URL in the src attribute.
        /// </summary>
        public string Src { get => JSRef!.Get<string>("src"); set => JSRef!.Set("src", value); }
        /// <summary>
        /// A string reflecting the srcset HTML attribute. This specifies a list of candidate images, separated by commas (',', U+002C COMMA). Each candidate image is a URL followed by a space, followed by a specially-formatted string indicating the size of the image. The size may be specified either the width or a size multiple. Read the srcset page for specifics on the format of the size substring.
        /// </summary>
        public string? SrcSet { get => JSRef!.Get<string?>("srcset"); set => JSRef!.Set("srcset", value); }
        /// <summary>
        /// A string reflecting the usemap HTML attribute, containing the page-local URL of the map element describing the image map to use. The page-local URL is a pound (hash) symbol (#) followed by the ID of the map element, such as #my-map-element. The map in turn contains area elements indicating the clickable areas in the image.
        /// </summary>
        public string? UseMap { get => JSRef!.Get<string?>("useMap"); set => JSRef!.Set("useMap", value); }
        /// <summary>
        /// An integer value that reflects the width HTML attribute, indicating the rendered width of the image in CSS pixels.
        /// </summary>
        public int Width => JSRef!.Get<int>("width");
        /// <summary>
        /// An integer indicating the horizontal offset of the left border edge of the image's CSS layout box relative to the origin of the html element's containing block.
        /// </summary>
        public int X => JSRef!.Get<int>("x");
        /// <summary>
        /// The integer vertical offset of the top border edge of the image's CSS layout box relative to the origin of the html element's containing block.
        /// </summary>
        public int Y => JSRef!.Get<int>("y");
        /// <summary>
        /// Returns a Promise that resolves when the image is decoded and it's safe to append the image to the DOM. This prevents rendering of the next frame from having to pause to decode the image, as would happen if an undecoded image were added to the DOM.
        /// </summary>
        public Task Decode() => JSRef!.CallVoidAsync("decode");
        /// <summary>
        /// Creates a new Image and returns it when it has completed loading src, or throws an exception if it fails
        /// </summary>
        /// <param name="src"></param>
        /// <param name="crossOrigin"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Creates a new Image and calls the callback when it has completed loading src or fails
        /// </summary>
        /// <param name="src"></param>
        /// <param name="callback"></param>
        /// <param name="crossOrigin"></param>
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
        /// <summary>
        /// Returns the Image as a Blob<br/>
        /// May throw an exception if the image is "tainted" by CORS issues.
        /// Non-standard method. 
        /// </summary>
        /// <param name="options">An object with the following properties: type and quality</param>
        /// <returns>A Promise returning a Blob object representing the image.</returns>
        public async Task<Blob> ConvertToBlob(ConvertToBlobOptions? options = null)
        {
            using var canvas = new OffscreenCanvas(Width, Height);
            using var ctx = canvas.Get2DContext();
            ctx.DrawImage(this);
            if (options == null)
                return await canvas.ConvertToBlob();
            else
                return await canvas.ConvertToBlob(options);
        }
    }
}
