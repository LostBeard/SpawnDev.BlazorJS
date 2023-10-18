using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Clients : JSObject
    {
        public Clients(IJSInProcessObjectReference _ref) : base(_ref) { }
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
        public Task Claim() => JSRef.CallAsync<WindowClient>("claim");
    }
}
