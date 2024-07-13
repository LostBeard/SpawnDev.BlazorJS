using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BarcodeDetector interface of the Barcode Detection API allows detection of linear and two dimensional barcodes in images.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/BarcodeDetector
    /// </summary>
    public class BarcodeDetector : JSObject
    {
        /// <summary>
        /// The BarcodeDetector() constructor creates a new BarcodeDetector object which detects linear and two-dimensional barcodes in images.
        /// </summary>
        public BarcodeDetector() : base(JS.New(nameof(BarcodeDetector))) { }
        /// <summary>
        /// The BarcodeDetector() constructor creates a new BarcodeDetector object which detects linear and two-dimensional barcodes in images.
        /// </summary>
        /// <param name="options"></param>
        public BarcodeDetector(BarcodeDetectorOptions options) : base(JS.New(nameof(BarcodeDetector), options)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public BarcodeDetector(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The getSupportedFormats() static method of the BarcodeDetector interface returns a Promise which fulfills with an Array of supported barcode format types.
        /// </summary>
        /// <returns></returns>
        public static Task<List<string>> GetSupportedFormats() => JS.CallAsync<List<string>>("BarcodeDetector.getSupportedFormats");
        /// <summary>
        /// Checks if BarcodeDetector is defined in the global scope
        /// </summary>
        /// <returns></returns>
        public static bool IsDefined() => !JS.IsUndefined("BarcodeDetector");
        /// <summary>
        /// The detect() method of the BarcodeDetector interface returns a Promise which fulfills with an Array of detected barcodes within an image.
        /// </summary>
        /// <param name="imageBitmapSource">Receives an ImageBitmapSource as a parameter. This can be an element, a Blob of type image or an ImageData object.</param>
        /// <returns></returns>
        public Task<Array<DetectedBarcode>> Detect(Union<Blob, Element, ImageData> imageBitmapSource) => JSRef!.CallAsync<Array<DetectedBarcode>>("detect", imageBitmapSource);
    }
}
