using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PaymentDetailsInit dictionary contains the details of the payment request.
    /// </summary>
    public class PaymentDetailsInit
    {
        /// <summary>
        /// A string containing a unique identifier for the payment request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }

        /// <summary>
        /// A PaymentItem dictionary containing the total amount of the payment request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PaymentItem? Total { get; set; }

        /// <summary>
        /// An array of PaymentItem dictionaries containing the line items of the payment request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<PaymentItem>? DisplayItems { get; set; }

        // TODO: ShippingOptions, Modifiers
    }
}
