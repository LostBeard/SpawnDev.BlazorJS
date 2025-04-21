using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The canmakepayment event of the ServiceWorkerGlobalScope interface is fired on a payment app's service worker to check whether it is ready to handle a payment. Specifically, it is fired when the merchant website calls the PaymentRequest() constructor.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CanMakePaymentEvent
    /// </summary>
    public class CanMakePaymentEvent : ExtendableEvent
    {
        /// <inheritdoc/>
        public CanMakePaymentEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Enables the service worker to respond appropriately to signal whether it is ready to handle payments.
        /// </summary>
        /// <param name="response"></param>
        public void RespondWith(Task<bool> response) => JSRef!.CallVoid("respondWith", new Promise<bool>(response));
        /// <summary>
        /// Enables the service worker to respond appropriately to signal whether it is ready to handle payments.
        /// </summary>
        /// <param name="response"></param>
        public void RespondWith(Promise<bool> response) => JSRef!.CallVoid("respondWith", response);
    }
}
