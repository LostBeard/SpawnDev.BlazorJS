using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PushSubscription interface of the Push API provides a subscription's URL endpoint and allows unsubscribing from a push service.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/PushSubscription
    /// </summary>
    public class PushSubscription : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PushSubscription(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string containing the endpoint associated with the push subscription.
        /// </summary>
        public string Endpoint => JSRef.Get<string>("endpoint");
        /// <summary>
        /// A DOMHighResTimeStamp of the subscription expiration time associated with the push subscription, if there is one, or null otherwise.
        /// </summary>
        public double? ExpirationTime => JSRef.Get<double?>("expirationTime");
        /// <summary>
        /// An object containing the options used to create the subscription.
        /// </summary>
        public PushManagerSubscribeOptions Options => JSRef.Get<PushManagerSubscribeOptions>("options");
        /// <summary>
        /// Starts the asynchronous process of unsubscribing from the push service, returning a Promise that resolves to a boolean value when the current subscription is successfully unregistered.
        /// </summary>
        /// <returns></returns>
        public Task<bool> Unsubscribe() => JSRef.CallAsync<bool>("unsubscribe");
        /// <summary>
        /// Returns an ArrayBuffer which contains the client's public key, which can then be sent to a server and used in encrypting push message data.
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public ArrayBuffer GetKey(string keyName) => JSRef.Call<ArrayBuffer>("getKey", keyName);
    }
}
