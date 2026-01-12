using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PaymentValidationErrors dictionary is a dictionary that indicates which fields in a PaymentResponse failed validation.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PaymentValidationErrors
    /// </summary>
    public class PaymentValidationErrors
    {
        /// <summary>
        /// A string containing an error message explaining why the selected payment method was invalid.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("error")]
        public string? Error { get; set; }

        /// <summary>
        /// A PayerErrors object containing validation errors for the payer details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("payer")]
        public PayerErrors? Payer { get; set; }

        /// <summary>
        /// An AddressErrors object containing validation errors for the shipping address.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("shippingAddress")]
        public AddressErrors? ShippingAddress { get; set; }
    }

    /// <summary>
    /// Validation errors for payer details.
    /// </summary>
    public class PayerErrors
    {
        /// <summary>
        /// Error for the payer's email.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Error for the payer's name.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Error for the payer's phone number.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }
    }

    /// <summary>
    /// Validation errors for the shipping address.
    /// </summary>
    public class AddressErrors
    {
        /// <summary>
        /// Error for the address line.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("addressLine")]
        public string? AddressLine { get; set; }

        /// <summary>
        /// Error for the city.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// Error for the country.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// Error for the dependent locality.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("dependentLocality")]
        public string? DependentLocality { get; set; }

        /// <summary>
        /// Error for the organization.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("organization")]
        public string? Organization { get; set; }

        /// <summary>
        /// Error for the phone number.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// Error for the postal code.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("postalCode")]
        public string? PostalCode { get; set; }

        /// <summary>
        /// Error for the recipient.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("recipient")]
        public string? Recipient { get; set; }

        /// <summary>
        /// Error for the region.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("region")]
        public string? Region { get; set; }

        /// <summary>
        /// Error for the sorting code.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("sortingCode")]
        public string? SortingCode { get; set; }
    }
}
