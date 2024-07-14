using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ImageBitmap interface represents a bitmap image which can be drawn to a canvas without undue latency. It can be created from a variety of source objects using the createImageBitmap() factory method. ImageBitmap provides an asynchronous and resource efficient pathway to prepare textures for rendering in WebGL.<br/>
    /// ImageBitmap is a transferable object.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ImageBitmap
    /// </summary>
    public class ImageBitmap : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ImageBitmap(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An unsigned long representing the height, in CSS pixels, of the ImageData.
        /// </summary>
        public uint Height => JSRef!.Get<uint>("height");
        /// <summary>
        /// An unsigned long representing the width, in CSS pixels, of the ImageData.
        /// </summary>
        public uint Width => JSRef!.Get<uint>("width");
        /// <summary>
        /// Disposes of all graphical resources associated with an ImageBitmap.
        /// </summary>
        public void Close()=> JSRef!.CallVoid("close");
    }
}
