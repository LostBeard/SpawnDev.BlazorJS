using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BackgroundFetchRecord interface of the Background Fetch API represents an individual request and response.<br/>
    /// A BackgroundFetchRecord is created by the BackgroundFetchRegistration.matchAll() method, therefore there is no constructor for this interface.<br/>
    /// There will be one BackgroundFetchRecord for each resource requested by fetch().<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchRecord
    /// </summary>
    public class BackgroundFetchRecord : JSObject
    {
        ///<inheritdoc/>
        public BackgroundFetchRecord(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Request.
        /// </summary>
        public Request Request => JSRef!.Get<Request>("request");
        /// <summary>
        /// Returns a promise that resolves with a Response.
        /// </summary>
        public Task<Response> ResponseReady => JSRef!.GetAsync<Response>("responseReady");
    }
}
