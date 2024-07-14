using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// This is the event type for fetch events dispatched on the service worker global scope. It contains information about the fetch, including the request and how the receiver will treat the response. It provides the event.respondWith() method, which allows us to provide a response to this fetch.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/FetchEvent
    /// </summary>
    public class FetchEvent : ExtendableEvent
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public FetchEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The id of the same-origin client that initiated the fetch.
        /// </summary>
        public string ClientId => JSRef!.Get<string>("clientId");
        /// <summary>
        /// A promise that is pending while the event has not been handled, and fulfilled once it has.<br />
        /// </summary>
        public Promise Handled => JSRef!.Get<Promise>("handled");
        /// <summary>
        /// The Request the browser intends to make.
        /// </summary>
        public Task<Response> PreloadResponse => JSRef!.GetAsync<Response>("preloadResponse");
        /// <summary>
        /// The id of the client that is being replaced during a page navigation.
        /// </summary>
        public string ReplacesClientId => JSRef!.Get<string>("replacesClientId");
        /// <summary>
        /// The id of the client that replaces the previous client during a page navigation.
        /// </summary>
        public string ResultingClientId => JSRef!.Get<string>("resultingClientId");
        /// <summary>
        /// The Request the browser intends to make.
        /// </summary>
        public Request Request => JSRef!.Get<Request>("request");
        /// <summary>
        /// Prevent the browser's default fetch handling, and provide (a promise for) a response yourself.
        /// </summary>
        /// <param name="response"></param>
        public void RespondWith(Task<Response> response) => JSRef!.CallVoid("respondWith", new Promise<Response>(response));
        /// <summary>
        /// Prevent the browser's default fetch handling, and provide (a promise for) a response yourself.
        /// </summary>
        /// <param name="response"></param>
        public void RespondWith(Promise<Response> response) => JSRef!.CallVoid("respondWith", response);
        /// <summary>
        /// Prevent the browser's default fetch handling, and provide (a promise for) a response yourself.
        /// </summary>
        /// <param name="response"></param>
        public void RespondWith(Response response) => JSRef!.CallVoid("respondWith", response);
    }
}
