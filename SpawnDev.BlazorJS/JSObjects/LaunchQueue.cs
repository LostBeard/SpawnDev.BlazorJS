using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The LaunchQueue interface of the Launch Handler API is available via the Window.launchQueue property. When a progressive web app (PWA) is launched with a launch_handler client_mode value of focus-existing, navigate-new, or navigate-existing, LaunchQueue provides access to functionality that allows custom launch navigation handling to be implemented in the PWA. This functionality is controlled by the properties of the LaunchParams object passed into the setConsumer() callback function.
    /// </summary>
    public class LaunchQueue : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public LaunchQueue(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The setConsumer() method of the LaunchQueue interface is used to declare the callback that will handle custom launch navigation handling in a progressive web app (PWA). Such custom navigation is initiated via Window.launchQueue when a PWA has been launched with a launch_handler client_mode value of focus-existing, navigate-new, or navigate-existing
        /// </summary>
        /// <param name="callback">A callback function that handles custom navigation for the PWA. The callback is passed a LaunchParams object instance as a parameter.</param>
        public void SetConsumer(ActionCallback<LaunchParams> callback) => JSRef!.CallVoid("setConsumer", callback);
    }
}
