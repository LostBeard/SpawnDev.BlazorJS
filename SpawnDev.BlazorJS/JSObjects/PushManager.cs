using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PushManager interface of the Push API provides a way to receive notifications from third-party servers as well as request URLs for push notifications.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/PushManager
    /// </summary>
    public class PushManager : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PushManager(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Subscribes to a push service. It returns a Promise that resolves to a PushSubscription object containing details of a push subscription. A new push subscription is created if the current service worker does not have an existing subscription.
        /// </summary>
        /// <returns></returns>
        public Task<PushSubscription> Subscribe() => JSRef!.CallAsync<PushSubscription>("subscribe");
        /// <summary>
        /// Subscribes to a push service. It returns a Promise that resolves to a PushSubscription object containing details of a push subscription. A new push subscription is created if the current service worker does not have an existing subscription.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<PushSubscription> Subscribe(PushManagerSubscribeOptions options) => JSRef!.CallAsync<PushSubscription>("subscribe", options);
        /// <summary>
        /// Retrieves an existing push subscription. It returns a Promise that resolves to a PushSubscription object containing details of an existing subscription. If no existing subscription exists, this resolves to a null value.
        /// </summary>
        /// <returns></returns>
        public Task<PushSubscription?> GetSubscription() => JSRef!.CallAsync<PushSubscription?>("getSubscription");
        /// <summary>
        /// Returns a Promise that resolves to the permission state of the current PushManager, which will be one of 'granted', 'denied', or 'prompt'.
        /// </summary>
        /// <returns></returns>
        public Task<string> PermissionState() => JSRef!.CallAsync<string>("permissionState");
    }
}
