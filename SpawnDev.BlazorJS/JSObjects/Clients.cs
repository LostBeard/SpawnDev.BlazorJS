using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Clients interface provides access to Client objects. Access it via self.clients within a service worker.<br />
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
        public Task<Client> Get(string id) => JSRef.CallAsync<Client>("get", id);
        /// <summary>
        /// Returns a Promise for an array of Client objects. An options argument allows you to control the types of clients returned.
        /// </summary>
        /// <returns></returns>
        public Task<Array<Client>> MatchAll() => JSRef.CallAsync<Array<Client>>("matchAll");
        /// <summary>
        /// Returns a Promise for an array of Client objects. An options argument allows you to control the types of clients returned.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Array<Client>> MatchAll(ClientsMatchAllOptions options) => JSRef.CallAsync<Array<Client>>("matchAll", options);
        /// <summary>
        /// Opens a new browser window for a given URL and returns a Promise for the new WindowClient.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<WindowClient> OpenWindow(string url) => JSRef.CallAsync<WindowClient>("openWindow", url);
        /// <summary>
        /// Allows an active service worker to set itself as the controller for all clients within its scope.
        /// </summary>
        /// <returns></returns>
        public Task Claim() => JSRef.CallVoidAsync("claim");
    }
}
