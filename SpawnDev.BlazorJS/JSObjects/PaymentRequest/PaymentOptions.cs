using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PaymentOptions dictionary contains the options for the payment request.
    /// </summary>
    public class PaymentOptions
    {
        /// <summary>
        /// A boolean indicating whether the user agent should collect the payer's name.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RequestPayerName { get; set; }

        /// <summary>
        /// A boolean indicating whether the user agent should collect the payer's email.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RequestPayerEmail { get; set; }

        /// <summary>
        /// A boolean indicating whether the user agent should collect the payer's phone.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RequestPayerPhone { get; set; }

        /// <summary>
        /// A boolean indicating whether the user agent should collect the shipping address.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RequestShipping { get; set; }

        /// <summary>
        /// A string indicating the type of shipping.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ShippingType { get; set; }
    }
}
