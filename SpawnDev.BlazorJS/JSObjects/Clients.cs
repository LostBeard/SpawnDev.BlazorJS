using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Clients interface provides access to Client objects. Access it via self.clients within a service worker.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Clients
    /// </summary>
    public class Clients : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Clients(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Promise for a Client matching a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Client> Get(string id) => JSRef!.CallAsync<Client>("get", id);
        /// <summary>
        /// Returns a Promise for an array of Client objects. An options argument allows you to control the types of clients returned.
        /// </summary>
        /// <returns></returns>
        public Task<Array<Client>> MatchAll() => JSRef!.CallAsync<Array<Client>>("matchAll");
        /// <summary>
        /// Returns a Promise for an array of Client objects. An options argument allows you to control the types of clients returned.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Array<Client>> MatchAll(ClientsMatchAllOptions options) => JSRef!.CallAsync<Array<Client>>("matchAll", options);
        /// <summary>
        /// The openWindow() method of the Clients interface creates a new top level browsing context and loads a given URL. If the calling script doesn't have permission to show popups, openWindow() will throw an InvalidAccessError.<br/>
        /// In Firefox, the method is allowed to show popups only when called as the result of a notification click event.<br/>
        /// In Chrome for Android, the method may instead open the URL in an existing browsing context provided by a standalone web app previously added to the user's home screen. As of recently, this also works on Chrome for Windows.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<WindowClient> OpenWindow(string url) => JSRef!.CallAsync<WindowClient>("openWindow", url);
        /// <summary>
        /// Allows an active service worker to set itself as the controller for all clients within its scope.<br/>
        /// Usually called in the service worker 'activate' event
        /// </summary>
        /// <returns></returns>
        public Task Claim() => JSRef!.CallVoidAsync("claim");
    }
}
