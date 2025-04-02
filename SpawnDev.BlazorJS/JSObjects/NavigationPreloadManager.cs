using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The NavigationPreloadManager interface of the Service Worker API provides methods for managing the preloading of resources in parallel with service worker bootup.<br/>
    /// If supported, an object of this type is returned by ServiceWorkerRegistration.navigationPreload. The result of a preload fetch request is waited on using the promise returned by FetchEvent.preloadResponse.
    /// https://developer.mozilla.org/en-US/docs/Web/API/NavigationPreloadManager
    /// </summary>
    public class NavigationPreloadManager : JSObject
    {
        /// <inheritdoc/>
        public NavigationPreloadManager(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Enables navigation preloading, returning a Promise that resolves with undefined.
        /// </summary>
        /// <returns></returns>
        public Task Enable() => JSRef!.CallVoidAsync("enable");
        /// <summary>
        /// Sets the value of the Service-Worker-Navigation-Preload HTTP header sent in preloading requests and returns an empty Promise.
        /// </summary>
        /// <param name="value">An arbitrary string value, which the target server uses to determine what should returned for the requested resource.</param>
        /// <returns></returns>
        public Task SetHeaderValue(string value) => JSRef!.CallVoidAsync("setHeaderValue", value);
        /// <summary>
        /// Returns a Promise that resolves to an object with properties that indicate whether preloading is enabled, and what value will be sent in the Service-Worker-Navigation-Preload HTTP header in preloading requests.
        /// </summary>
        /// <returns></returns>
        public Task<NavigationPreloadState> GetState() => JSRef!.CallAsync<NavigationPreloadState>("getState");
        /// <summary>
        /// Disables navigation preloading, returning a Promise that resolves with undefined.
        /// </summary>
        /// <returns></returns>
        public Task Disable() => JSRef!.CallVoidAsync("disable");
    }
}
