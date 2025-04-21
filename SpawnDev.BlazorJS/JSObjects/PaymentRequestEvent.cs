using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PaymentRequestEvent interface of the Payment Handler API is the object passed to a payment handler when a PaymentRequest is made.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent
    /// </summary>
    public class PaymentRequestEvent : ExtendableEvent
    {
        /// <inheritdoc/>
        public PaymentRequestEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an array of objects containing payment method identifiers for the payment methods that the website accepts and any associated payment method specific data.
        /// </summary>
        public PaymentMethodData[] MethodData => JSRef!.Get<PaymentMethodData[]>("methodData");
        /// <summary>
        /// Returns an array of objects containing changes to payment details.
        /// </summary>
        public PaymentModifier[] Modifiers => JSRef!.Get<PaymentModifier[]>("modifiers");
        /// <summary>
        /// Returns the ID of the PaymentRequest object.
        /// </summary>
        public string PaymentRequestId => JSRef!.Get<string>("paymentRequestId");
        /// <summary>
        /// Returns the origin where the PaymentRequest object was initialized.
        /// </summary>
        public string PaymentRequestOrigin => JSRef!.Get<string>("paymentRequestOrigin");
        /// <summary>
        /// Returns the top-level origin where the PaymentRequest object was initialized.
        /// </summary>
        public string TopOrigin => JSRef!.Get<string>("topOrigin");
        /// <summary>
        /// Returns the total amount being requested for payment.
        /// </summary>
        public PaymentCurrencyAmount Total => JSRef!.Get<PaymentCurrencyAmount>("total");
    }
}
