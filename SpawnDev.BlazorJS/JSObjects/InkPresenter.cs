using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The InkPresenter interface of the Ink API provides the ability to instruct the OS-level compositor to render ink strokes between pointer event dispatches.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/InkPresenter
    /// </summary>
    public class InkPresenter : JSObject
    {
        /// <summary>
        /// Creates a new instance of <see cref="InkPresenter"/>.
        /// </summary>
        /// <param name="_ref"></param>
        public InkPresenter(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a value, in milliseconds, indicating the latency improvement that can be expected using this presenter.
        /// </summary>
        public float ExpectedImprovement => JSRef!.Get<float>("expectedImprovement");
        /// <summary>
        /// Returns the Element inside which rendering of ink strokes is confined.
        /// </summary>
        public Element PresentationArea => JSRef!.Get<Element>("presentationArea");
        /// <summary>
        /// Passes the PointerEvent that was used as the last rendering point for the current frame, allowing the OS-level compositor to render a delegated ink trail ahead of the next pointer event being dispatched.
        /// </summary>
        /// <param name="pointerEvent"></param>
        /// <param name="style"></param>
        public void UpdateInkTrailStartPoint(PointerEvent pointerEvent, InkPresenterStyle style) => JSRef!.CallVoid("updateInkTrailStartPoint", pointerEvent, style);
    }
}
