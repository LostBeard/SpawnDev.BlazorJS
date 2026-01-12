using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DetectedText interface of the Text Detection API represents a text detected by the TextDetector.detect() method.
    /// </summary>
    public class DetectedText : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public DetectedText(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// A DOMRectReadOnly object indicating the dimensions and position of the detected text.
        /// </summary>
        public DOMRectReadOnly BoundingBox => JSRef!.Get<DOMRectReadOnly>("boundingBox");

        /// <summary>
        /// A string corresponding to the raw string detected in the image.
        /// </summary>
        public string RawValue => JSRef!.Get<string>("rawValue");

        /// <summary>
        /// An array of 4 Point2D objects representing the four corner points of the detected text.
        /// </summary>
        public List<DOMPointReadOnly>? CornerPoints => JSRef!.Get<List<DOMPointReadOnly>?>("cornerPoints");
    }
}
