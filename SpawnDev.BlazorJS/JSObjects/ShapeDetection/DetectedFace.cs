using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DetectedFace interface of the Mask Detection API represents a face detected by the FaceDetector.detect() method.
    /// </summary>
    public class DetectedFace : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public DetectedFace(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// A DOMRectReadOnly object indicating the dimensions and position of the detected face.
        /// </summary>
        public DOMRectReadOnly BoundingBox => JSRef!.Get<DOMRectReadOnly>("boundingBox");

        /// <summary>
        /// An array of Landmark objects, each representing a detection of a particular landmark.
        /// </summary>
        public List<JSObject>? Landmarks => JSRef!.Get<List<JSObject>?>("landmarks");
    }
}
