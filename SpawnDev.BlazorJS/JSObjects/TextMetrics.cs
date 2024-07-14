using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The TextMetrics interface represents the dimensions of a piece of text in the canvas; a TextMetrics instance can be retrieved using the CanvasRenderingContext2D.measureText() method.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics<br/>
    /// TODO - finish
    /// </summary>
    public class TextMetrics : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public TextMetrics(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the width of a segment of inline text in CSS pixels. It takes into account the current font of the context.
        /// </summary>
        public double Width { get => JSRef!.Get<double>("width"); set => JSRef!.Set("width", value); }
    }
}
