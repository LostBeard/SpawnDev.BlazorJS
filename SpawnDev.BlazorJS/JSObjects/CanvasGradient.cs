using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class CanvasGradient : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CanvasGradient(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The CanvasGradient.addColorStop() method of the Canvas 2D API adds a new color stop, defined by an offset and a color, to a given canvas gradient.
        /// </summary>
        /// <param name="offset">A number between 0 and 1, inclusive, representing the position of the color stop. 0 represents the start of the gradient and 1 represents the end.</param>
        /// <param name="color">A CSS <color> value representing the color of the stop.</param>
        public void AddColorStop(double offset, string color) => JSRef!.CallVoid("addColorStop", offset, color);

    }
}
