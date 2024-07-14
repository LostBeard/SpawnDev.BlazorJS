using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The OffscreenCanvasRenderingContext2D interface is a CanvasRenderingContext2D rendering context for drawing to the bitmap of an OffscreenCanvas object. It is similar to the CanvasRenderingContext2D object, with the following differences:<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/OffscreenCanvasRenderingContext2D
    /// </summary>
    public class OffscreenCanvasRenderingContext2D : CanvasRenderingContext2D
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public OffscreenCanvasRenderingContext2D(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Pushes the rendered image to the context's OffscreenCanvas object's placeholder canvas element.<br/>
        /// ⚠ Deprecated - Not for use in new websites
        /// </summary>
        public void Commit() => JSRef!.CallVoid("commit");
    }
}
