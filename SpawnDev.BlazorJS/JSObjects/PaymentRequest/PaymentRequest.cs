using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PaymentRequest interface of the Payment Request API is the primary entry point into the API. It allows the web page to create a payment request, to determine if the user has a way to make the payment, and to show the payment UI to the user.
    /// </summary>
    public class PaymentRequest : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public PaymentRequest(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new PaymentRequest.
        /// </summary>
        public PaymentRequest(IEnumerable<PaymentMethodData> methodData, PaymentDetailsInit details, PaymentOptions? options = null) : base(JS.New(nameof(PaymentRequest), methodData, details, options)) { }

        /// <summary>
        /// Shows the payment UI to the user.
        /// </summary>
        public Task<PaymentResponse> Show() => JSRef!.CallAsync<PaymentResponse>("show");

        /// <summary>
        /// Shows the payment UI to the user.
        /// </summary>
        public Task<PaymentResponse> Show(Task<PaymentDetailsInit> detailsPromise) => JSRef!.CallAsync<PaymentResponse>("show", detailsPromise);

        /// <summary>
        /// Aborts the payment request.
        /// </summary>
        public Task Abort() => JSRef!.CallVoidAsync("abort");

        /// <summary>
        /// Returns a boolean indicating whether the user has a way to make the payment.
        /// </summary>
        public Task<bool> CanMakePayment() => JSRef!.CallAsync<bool>("canMakePayment");

        /// <summary>
        /// Returns the ID of the payment request.
        /// </summary>
        public string Id => JSRef!.Get<string>("id");

        /// <summary>
        /// Returns the shipping address chosen by the user.
        /// </summary>
        public PaymentAddress? ShippingAddress => JSRef!.Get<PaymentAddress?>("shippingAddress");

        /// <summary>
        /// Returns the shipping option chosen by the user.
        /// </summary>
        public string? ShippingOption => JSRef!.Get<string?>("shippingOption");

        /// <summary>
        /// Returns the shipping type chosen by the user.
        /// </summary>
        public string? ShippingType => JSRef!.Get<string?>("shippingType");

        /// <summary>
        /// Fired when the user changes the payment method.
        /// </summary>
        public ActionEvent<Event> OnPaymentMethodChange { get => new ActionEvent<Event>("paymentmethodchange", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the user changes the shipping address.
        /// </summary>
        public ActionEvent<Event> OnShippingAddressChange { get => new ActionEvent<Event>("shippingaddresschange", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Fired when the user changes the shipping option.
        /// </summary>
        public ActionEvent<Event> OnShippingOptionChange { get => new ActionEvent<Event>("shippingoptionchange", AddEventListener, RemoveEventListener); set { } }
    }
}
