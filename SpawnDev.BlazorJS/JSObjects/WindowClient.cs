using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WindowClient interface of the ServiceWorker API represents the scope of a service worker client that is a document in a browsing context, controlled by an active worker. The service worker client independently selects and uses a service worker for its own loading and sub-resources.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/WindowClient
    /// </summary>
    public class WindowClient : Client
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WindowClient(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Gives user input focus to the current client.
        /// </summary>
        /// <returns></returns>
        public Task<WindowClient> Focus() => JSRef!.CallAsync<WindowClient>("focus");
        /// <summary>
        /// Loads a specified URL into a controlled client page.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<WindowClient> Navigate(string url) => JSRef!.CallAsync<WindowClient>("navigate", url);
        /// <summary>
        /// A boolean that indicates whether the current client has focus.
        /// </summary>
        public bool Focused => JSRef!.Get<bool>("focused");
        /// <summary>
        /// Indicates the visibility of the current client. This value can be one of "hidden", "visible", or "prerender".
        /// </summary>
        public string VisibilityState => JSRef!.Get<string>("visibilityState");
    }
}
