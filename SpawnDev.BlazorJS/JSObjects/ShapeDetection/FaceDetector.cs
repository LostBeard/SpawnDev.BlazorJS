using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The FaceDetector interface of the Face Detection API detects faces in images.
    /// </summary>
    public class FaceDetector : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public FaceDetector(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new FaceDetector object.
        /// </summary>
        public FaceDetector(FaceDetectorOptions? options = null) : base(JS.New(nameof(FaceDetector), options)) { }

        /// <summary>
        /// Detects faces in the specified image.
        /// </summary>
        /// <param name="imageBitmapSource">The image to detect faces in.</param>
        /// <returns>A Promise that returns an array of DetectedFace objects.</returns>
        public Task<List<DetectedFace>> Detect(Union<Blob, Element, ImageData, ImageBitmap, OffscreenCanvas> imageBitmapSource) => JSRef!.CallAsync<List<DetectedFace>>("detect", imageBitmapSource);
    }
}
