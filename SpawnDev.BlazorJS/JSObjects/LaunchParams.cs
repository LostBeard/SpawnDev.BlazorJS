using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The LaunchParams interface of the Launch Handler API is used when implementing custom launch navigation handling in a PWA. When window.launchQueue.setConsumer() is invoked to set up the launch navigation handling functionality, the callback function inside setConsumer() is passed a LaunchParams object instance.<br/>
    /// Such custom navigation handling is initiated via Window.launchQueue when a PWA has been launched with a launch_handler client_mode value of focus-existing, navigate-new, or navigate-existing
    /// </summary>
    public class LaunchParams : JSObject
    {
        public LaunchParams(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a read-only array of FileSystemHandle objects representing any files passed along with the launch navigation via the POST method
        /// </summary>
        public FileSystemHandle[] Files => JSRef!.Get<FileSystemHandle[]>("files");
        /// <summary>
        /// Returns the target URL of the launch.
        /// </summary>
        public string TargetURL => JSRef!.Get<string>("targetURL");
    }
}
