using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CookieStoreManager interface of the Cookie Store API allows service workers to subscribe to cookie change events. Call subscribe() on a particular service worker registration to receive change events.<br/>
    /// A CookieStoreManager has an associated ServiceWorkerRegistration. Each service worker registration has a cookie change subscription list, which is a list of cookie change subscriptions each containing a name and URL. The methods in this interface allow the service worker to add and remove subscriptions from this list, and to get a list of all subscriptions.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CookieStoreManager
    /// </summary>
    public class CookieStoreManager : JSObject
    {
        /// <inheritdoc/>
        public CookieStoreManager(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Promise which resolves to a list of the cookie change subscriptions for this service worker registration.
        /// </summary>
        /// <returns></returns>
        public Task<CookieSubscription[]> GetSubscriptions() => JSRef!.CallAsync<CookieSubscription[]>("getSubscriptions");
        /// <summary>
        /// Subscribes to changes to cookies. It returns a Promise which resolves when the subscription is successful.
        /// </summary>
        /// <param name="subscriptions"></param>
        /// <returns></returns>
        public Task Subscribe(IEnumerable<CookieSubscription> subscriptions) => JSRef!.CallVoidAsync("subscribe");
        /// <summary>
        /// Unsubscribes the registered service worker from changes to cookies. It returns a Promise which resolves when the operation is successful.
        /// </summary>
        /// <param name="subscriptions"></param>
        /// <returns></returns>
        public Task Unsubscribe(IEnumerable<CookieSubscription> subscriptions) => JSRef!.CallVoidAsync("unsubscribe");
    }
}
