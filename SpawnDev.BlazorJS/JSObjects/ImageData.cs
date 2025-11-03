using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ImageData interface represents the underlying pixel data of an area of a canvas element.<br/>
    /// It is created using the ImageData() constructor or creator methods on the CanvasRenderingContext2D object associated with a canvas: createImageData() and getImageData(). It can also be used to set a part of the canvas by using putImageData().<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ImageData
    /// </summary>
    [Transferable]
    public class ImageData : JSObject
    {
        #region Constructors

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ImageData(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// The ImageData() constructor returns a newly instantiated ImageData object built from the typed array given and having the specified width and height.<br/>
        /// This constructor is the preferred way of creating such an object in a Worker.
        /// </summary>
        /// <param name="width">An unsigned long representing the width of the image.</param>
        /// <param name="height">An unsigned long representing the height of the image. This value is optional if an array is given: the height will be inferred from the array's size and the given width.</param>
        public ImageData(uint width, uint height) : base(JS.New(nameof(ImageData), width, height)) { }

        /// <summary>
        /// The ImageData() constructor returns a newly instantiated ImageData object built from the typed array given and having the specified width and height.<br/>
        /// This constructor is the preferred way of creating such an object in a Worker.
        /// </summary>
        /// <param name="width">An unsigned long representing the width of the image.</param>
        /// <param name="height">An unsigned long representing the height of the image. This value is optional if an array is given: the height will be inferred from the array's size and the given width.</param>
        /// <param name="settings">ImageDataSettings object</param>
        public ImageData(uint width, uint height, ImageDataSettings settings) : base(JS.New(nameof(ImageData), width, height, settings)) { }

        /// <summary>
        /// The ImageData() constructor returns a newly instantiated ImageData object built from the typed array given and having the specified width and height.<br/>
        /// This constructor is the preferred way of creating such an object in a Worker.
        /// </summary>
        /// <param name="dataArray">A Uint8ClampedArray containing the underlying pixel representation of the image. If no such array is given, an image with a transparent black rectangle of the specified width and height will be created.</param>
        /// <param name="width">An unsigned long representing the width of the image.</param>
        public ImageData(Uint8ClampedArray dataArray, uint width) : base(JS.New(nameof(ImageData), dataArray, width)) { }

        /// <summary>
        /// The ImageData() constructor returns a newly instantiated ImageData object built from the typed array given and having the specified width and height.<br/>
        /// This constructor is the preferred way of creating such an object in a Worker.
        /// </summary>
        /// <param name="dataArray">A Uint8ClampedArray containing the underlying pixel representation of the image. If no such array is given, an image with a transparent black rectangle of the specified width and height will be created.</param>
        /// <param name="width">An unsigned long representing the width of the image.</param>
        /// <param name="height">An unsigned long representing the height of the image. This value is optional if an array is given: the height will be inferred from the array's size and the given width.</param>
        public ImageData(Uint8ClampedArray dataArray, uint width, uint height) : base(JS.New(nameof(ImageData), dataArray, width, height)) { }

        /// <summary>
        /// The ImageData() constructor returns a newly instantiated ImageData object built from the typed array given and having the specified width and height.<br/>
        /// This constructor is the preferred way of creating such an object in a Worker.
        /// </summary>
        /// <param name="dataArray">A Uint8ClampedArray containing the underlying pixel representation of the image. If no such array is given, an image with a transparent black rectangle of the specified width and height will be created.</param>
        /// <param name="width">An unsigned long representing the width of the image.</param>
        /// <param name="height">An unsigned long representing the height of the image. This value is optional if an array is given: the height will be inferred from the array's size and the given width.</param>
        /// <param name="settings">ImageDataSettings object</param>
        public ImageData(Uint8ClampedArray dataArray, uint width, uint height, ImageDataSettings settings) : base(JS.New(nameof(ImageData), dataArray, width, height, settings)) { }

        #endregion

        #region Properties

        /// <summary>
        /// A Uint8ClampedArray representing a one-dimensional array containing the data in the RGBA order, with integer values between 0 and 255 (inclusive). The order goes by rows from the top-left pixel to the bottom-right.
        /// </summary>
        public Uint8ClampedArray Data => JSRef!.Get<Uint8ClampedArray>("data");

        /// <summary>
        /// A string indicating the color space of the image data.
        /// </summary>
        public string ColorSpace => JSRef!.Get<string>("colorSpace");

        /// <summary>
        /// A string indicating the format to use for the ImageData.
        /// </summary>
        public string PixelFormat => JSRef!.Get<string>("pixelFormat");

        /// <summary>
        /// An unsigned long representing the actual height, in pixels, of the ImageData.
        /// </summary>
        public int Height => JSRef!.Get<int>("height");

        /// <summary>
        /// An unsigned long representing the actual width, in pixels, of the ImageData.
        /// </summary>
        public int Width => JSRef!.Get<int>("width");

        #endregion

        /// <summary>
        /// Creates an ImageData from a Uint8Array's view on its underlying ArrayBuffer.<br/>
        /// This is a zero-copy operation. The ImageData.Data property, a Uint8ClampedArray, will point to the same section of the same ArrayBuffer as the source.
        /// </summary>
        /// <param name="rgbaUint8Array"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static ImageData FromUint8Array(Uint8Array rgbaUint8Array, uint width, uint height)
        {
            using var arrayBuffer = rgbaUint8Array.Buffer;
            using var rgbaUint8ClampedArray = new Uint8ClampedArray(arrayBuffer, rgbaUint8Array.ByteOffset, rgbaUint8Array.ByteLength);
            return new ImageData(rgbaUint8ClampedArray, width, height);
        }

        /// <summary>
        /// Creates an ImageData from a byte[]
        /// </summary>
        /// <param name="rgbaBytes"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static ImageData FromBytes(byte[] rgbaBytes, uint width, uint height)
        {
            using var rgbaBytesUint8Array = new Uint8Array(rgbaBytes);
            using var arrayBuffer = rgbaBytesUint8Array.Buffer;
            using var rgbaBytesUint8ClampedArray = new Uint8ClampedArray(arrayBuffer);
            return new ImageData(rgbaBytesUint8ClampedArray, width, height);
        }
    }
}
