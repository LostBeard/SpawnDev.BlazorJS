namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/total#value
    /// </summary>
    public class PaymentCurrencyAmount
    {
        /// <summary>
        /// A string containing a three-letter ISO 4217 standard currency code representing the currency of the payment. Examples include USD, CAN, and GBP.
        /// </summary>
        public string Currency {  get; set; }
        /// <summary>
        /// A string containing a decimal monetary value, e.g., 2.55.
        /// </summary>
        public string Value { get; set; }
    }
}
