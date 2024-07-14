using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The TextMetrics interface represents the dimensions of a piece of text in the canvas; a TextMetrics instance can be retrieved using the CanvasRenderingContext2D.measureText() method.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics
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
        public double Width => JSRef!.Get<double>("width");
        /// <summary>
        /// Distance parallel to the baseline from the alignment point given by the CanvasRenderingContext2D.textAlign property to the left side of the bounding rectangle of the given text, in CSS pixels; positive numbers indicating a distance going left from the given alignment point.
        /// </summary>
        public double ActualBoundingBoxLeft => JSRef!.Get<double>("actualBoundingBoxLeft");
        /// <summary>
        /// Returns the distance from the alignment point given by the CanvasRenderingContext2D.textAlign property to the right side of the bounding rectangle of the given text, in CSS pixels. The distance is measured parallel to the baseline.
        /// </summary>
        public double ActualBoundingBoxRight => JSRef!.Get<double>("actualBoundingBoxRight");
        /// <summary>
        /// Returns the distance from the horizontal line indicated by the CanvasRenderingContext2D.textBaseline attribute to the top of the highest bounding rectangle of all the fonts used to render the text, in CSS pixels.
        /// </summary>
        public double FontBoundingBoxAscent => JSRef!.Get<double>("fontBoundingBoxAscent");
        /// <summary>
        /// Returns the distance from the horizontal line indicated by the CanvasRenderingContext2D.textBaseline attribute to the bottom of the bounding rectangle of all the fonts used to render the text, in CSS pixels.
        /// </summary>
        public double FontBoundingBoxDescent => JSRef!.Get<double>("fontBoundingBoxDescent");
        /// <summary>
        /// Returns the distance from the horizontal line indicated by the CanvasRenderingContext2D.textBaseline attribute to the top of the bounding rectangle used to render the text, in CSS pixels.
        /// </summary>
        public double ActualBoundingBoxAscent => JSRef!.Get<double>("actualBoundingBoxAscent");
        /// <summary>
        /// Returns the distance from the horizontal line indicated by the CanvasRenderingContext2D.textBaseline attribute to the bottom of the bounding rectangle used to render the text, in CSS pixels.
        /// </summary>
        public double ActualBoundingBoxDescent => JSRef!.Get<double>("actualBoundingBoxDescent");
        /// <summary>
        /// Returns the distance from the horizontal line indicated by the CanvasRenderingContext2D.textBaseline property to the top of the em square in the line box, in CSS pixels.
        /// </summary>
        public double EMHeightAscent => JSRef!.Get<double>("emHeightAscent");
        /// <summary>
        /// Returns the distance from the horizontal line indicated by the CanvasRenderingContext2D.textBaseline property to the bottom of the em square in the line box, in CSS pixels.
        /// </summary>
        public double EMHeightDescent => JSRef!.Get<double>("emHeightDescent");
        /// <summary>
        /// Returns the distance from the horizontal line indicated by the CanvasRenderingContext2D.textBaseline property to the hanging baseline of the line box, in CSS pixels.
        /// </summary>
        public double HangingBaseline => JSRef!.Get<double>("hangingBaseline");
        /// <summary>
        /// Returns the distance from the horizontal line indicated by the CanvasRenderingContext2D.textBaseline property to the alphabetic baseline of the line box, in CSS pixels.
        /// </summary>
        public double AlphabeticBaseline => JSRef!.Get<double>("alphabeticBaseline");
        /// <summary>
        /// Returns the distance from the horizontal line indicated by the CanvasRenderingContext2D.textBaseline property to the ideographic baseline of the line box, in CSS pixels.
        /// </summary>
        public double IdeographicBaseline => JSRef!.Get<double>("ideographicBaseline");
    }
}
