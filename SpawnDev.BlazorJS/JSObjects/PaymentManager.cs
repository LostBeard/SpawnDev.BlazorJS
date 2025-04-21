using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PaymentManager interface of the Payment Handler API is used to manage various aspects of payment app functionality.<br/>
    /// It is accessed via the ServiceWorkerRegistration.paymentManager property.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PaymentManager
    /// </summary>
    public class PaymentManager : JSObject
    {
        ///<inheritdoc/>
        public PaymentManager(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Provides a hint for the browser to display along with the payment app's name and icon in the Payment Handler UI.
        /// </summary>
        public string UserHint { get => JSRef!.Get<string>("userHint"); set => JSRef!.Set("userHint", value); }
        /// <summary>
        /// Delegates responsibility for providing various parts of the required payment information to the payment app rather than collecting it from the browser (for example, via autofill).
        /// </summary>
        /// <param name="delegations">
        /// An array containing one or more enumerated values that specify the payment information you want to delegate to the payment app.<br/>
        /// Possible values can be:<br/>
        /// payerEmail - The payment app will provide the payer's email whenever it is needed.<br/>
        /// payerName - The payment app will provide the payer's name whenever it is needed.<br/>
        /// payerPhone - The payment app will provide the payer's phone number whenever it is needed.<br/>
        /// shippingAddress - The payment app will provide the shipping address whenever it is needed.<br/>
        /// </param>
        /// <returns></returns>
        public Task EnableDelegations(IEnumerable<string> delegations) => JSRef!.CallVoidAsync("enableDelegations", delegations);
    }
}
