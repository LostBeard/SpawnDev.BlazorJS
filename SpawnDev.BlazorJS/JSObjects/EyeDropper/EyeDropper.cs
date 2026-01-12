using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The EyeDropper interface of the EyeDropper API provides a mechanism for creating an eyedropper tool. Using the eyedropper, users can select colors from their screens, including outside of the browser window.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/EyeDropper
    /// </summary>
    public class EyeDropper : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public EyeDropper(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new EyeDropper object.
        /// </summary>
        public EyeDropper() : base(JS.New(nameof(EyeDropper))) { }
        /// <summary>
        /// The open() method of the EyeDropper interface opens the eyedropper and waits for the user to select a color. It returns a Promise that resolves to a ColorSelectionResult object once the user has selected a color.
        /// </summary>
        /// <returns></returns>
        public Task<ColorSelectionResult> Open() => JSRef!.CallAsync<ColorSelectionResult>("open");
        /// <summary>
        /// The open() method of the EyeDropper interface opens the eyedropper and waits for the user to select a color. It returns a Promise that resolves to a ColorSelectionResult object once the user has selected a color.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<ColorSelectionResult> Open(EyeDropperOptions options) => JSRef!.CallAsync<ColorSelectionResult>("open", options);
    }
}
