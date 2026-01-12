using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PaymentAddress interface of the Payment Request API is used to store validity information about an address used for payment.
    /// https://developer.mozilla.org/en-US/docs/Web/API/PaymentAddress
    /// </summary>
    public class PaymentAddress : JSObject
    {
        /// <summary>
        /// Creates a new instance of <see cref="PaymentAddress"/>.
        /// </summary>
        /// <param name="_ref"></param>
        public PaymentAddress(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns the first line of the address.
        /// </summary>
        public Array<string> AddressLine => JSRef!.Get<Array<string>>("addressLine");

        /// <summary>
        /// Returns the city.
        /// </summary>
        public string City => JSRef!.Get<string>("city");

        /// <summary>
        /// Returns the country.
        /// </summary>
        public string Country => JSRef!.Get<string>("country");

        /// <summary>
        /// Returns the dependent locality.
        /// </summary>
        public string DependentLocality => JSRef!.Get<string>("dependentLocality");

        /// <summary>
        /// Returns the organization.
        /// </summary>
        public string Organization => JSRef!.Get<string>("organization");

        /// <summary>
        /// Returns the phone number.
        /// </summary>
        public string Phone => JSRef!.Get<string>("phone");

        /// <summary>
        /// Returns the postal code.
        /// </summary>
        public string PostalCode => JSRef!.Get<string>("postalCode");

        /// <summary>
        /// Returns the recipient.
        /// </summary>
        public string Recipient => JSRef!.Get<string>("recipient");

        /// <summary>
        /// Returns the region.
        /// </summary>
        public string Region => JSRef!.Get<string>("region");

        /// <summary>
        /// Returns the sorting code.
        /// </summary>
        public string SortingCode => JSRef!.Get<string>("sortingCode");

        /// <summary>
        /// Returns a JSON-serializable object that provides a address information using the PaymentAddress vocabulary.
        /// </summary>
        /// <returns></returns>
        public object ToJSON() => JSRef!.Call<object>("toJSON");
    }
}
