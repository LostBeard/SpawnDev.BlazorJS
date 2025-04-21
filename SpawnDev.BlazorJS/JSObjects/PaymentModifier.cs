using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/modifiers#value
    /// </summary>
    public class PaymentModifier : JSObject
    {
        /// <inheritdoc/>
        public PaymentModifier(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public PaymentModifier() : base(JS.New("Object")) { }
        /// <summary>
        /// A payment method identifier. The members of the object only apply to the payment if the user selects this payment method.
        /// </summary>
        public string? SupportedMethods { get => JSRef!.Get<string?>("supportedMethods"); set => JSRef!.Set("supportedMethods", value); }
        /// <summary>
        /// A PaymentItem object
        /// </summary>
        public PaymentItem? Total { get => JSRef!.Get<PaymentItem?>("total"); set => JSRef!.Set("total", value); }
    }
}
