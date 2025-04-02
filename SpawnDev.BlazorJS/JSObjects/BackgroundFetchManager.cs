using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BackgroundFetchManager interface of the Background Fetch API is a map where the keys are background fetch IDs and the values are BackgroundFetchRegistration objects.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchManager
    /// </summary>
    public class BackgroundFetchManager : JSObject
    {
        ///<inheritdoc/>
        public BackgroundFetchManager(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Promise that resolves with a BackgroundFetchRegistration object for a supplied array of URLs and Request objects.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requests"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<BackgroundFetchRegistration> Fetch(string id, IEnumerable<Union<string, Request>> requests, BackgroundFetchOptions options) => JSRef!.CallAsync<BackgroundFetchRegistration>("fetch", id, requests, options);
        /// <summary>
        /// Returns a Promise that resolves with the BackgroundFetchRegistration associated with the provided id or undefined if the id is not found.
        /// </summary>
        /// <returns></returns>
        public Task<BackgroundFetchRegistration?> Get(string id) => JSRef!.CallAsync<BackgroundFetchRegistration?>("get", id);
        /// <summary>
        /// Returns the IDs of all registered background fetches.
        /// </summary>
        public string[] GetIds() => JSRef!.Call<string[]>("getIds");
    }
}
