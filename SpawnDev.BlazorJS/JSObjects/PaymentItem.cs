namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/modifiers#total
    /// </summary>
    public class PaymentItem
    {
        /// <summary>
        /// A string containing a human-readable description of the item, which may be displayed to the user.
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// A PaymentCurrencyAmount object (see total > Value).
        /// </summary>
        public PaymentCurrencyAmount Amount { get; set; }
        /// <summary>
        /// A boolean. When set to true it means that the amount member is not final. This is commonly used to show items such as shipping or tax amounts that depend upon selection of shipping address or shipping option.
        /// </summary>
        public bool Pending { get; set; }
    }
}
