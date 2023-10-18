using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class WindowClient : Client
    {
        public WindowClient(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Gives user input focus to the current client.
        /// </summary>
        /// <returns></returns>
        public Task<WindowClient> Focus() => JSRef.CallAsync<WindowClient>("focus");
        /// <summary>
        /// Loads a specified URL into a controlled client page.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<WindowClient> Navigate(string url) => JSRef.CallAsync<WindowClient>("navigate", url);
        /// <summary>
        /// A boolean that indicates whether the current client has focus.
        /// </summary>
        public bool Focused => JSRef.Get<bool>("focused");
        /// <summary>
        /// Indicates the visibility of the current client. This value can be one of "hidden", "visible", or "prerender".
        /// </summary>
        public string VisibilityState => JSRef.Get<string>("visibilityState");
    }
}
