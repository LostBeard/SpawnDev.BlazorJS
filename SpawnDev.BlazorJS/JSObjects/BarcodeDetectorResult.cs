using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class BarcodeDetectorResult : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public BarcodeDetectorResult(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// boundingBox: A DOMRectReadOnly, which returns the dimensions of a rectangle representing the extent of a detected barcode, aligned with the image
        /// </summary>
        public DOMRectReadOnly BoundingBox => JSRef.Get<DOMRectReadOnly>("boundingBox");
        /// <summary>
        /// The x and y co-ordinates of the four corner points of the detected barcode relative to the image, starting with the top left and working clockwise. This may not be square due to perspective distortions within the image.
        /// </summary>
        public Point2D CornerPoints => JSRef.Get<Point2D>("cornerPoints");
        /// <summary>
        /// The detected barcode format. 
        /// </summary>
        public string Format => JSRef.Get<string>("format");
        /// <summary>
        /// A string decoded from the barcode data
        /// </summary>
        public string RawValue => JSRef.Get<string>("rawValue");

    }
}
