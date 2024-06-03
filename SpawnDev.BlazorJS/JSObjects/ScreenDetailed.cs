using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ScreenDetailed interface of the Window Management API represents detailed information about one specific screen available to the user's device.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ScreenDetailed
    /// </summary>
    public class ScreenDetailed : Screen
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ScreenDetailed(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A number representing the screen's device pixel ratio.
        /// </summary>
        public double DevicePixelRatio => JSRef!.Get<double>("devicePixelRatio");
        /// <summary>
        /// A boolean indicating whether the screen is internal to the device or external.
        /// </summary>
        public bool IsInternal => JSRef!.Get<bool>("isInternal");
        /// <summary>
        /// A boolean indicating whether the screen is set as the operating system (OS) primary screen or not.
        /// </summary>
        public bool IsPrimary => JSRef!.Get<bool>("isPrimary");
        /// <summary>
        /// A string providing a descriptive label for the screen, for example "Built-in Retina Display".
        /// </summary>
        public string Label => JSRef!.Get<string>("label");
        /// <summary>
        /// A number representing the x-coordinate (left-hand edge) of the total screen area.
        /// </summary>
        public int Left => JSRef!.Get<int>("left");
        /// <summary>
        /// A number representing the y-coordinate (top edge) of the total screen area.
        /// </summary>
        public int Top => JSRef!.Get<int>("top");
    }
}
