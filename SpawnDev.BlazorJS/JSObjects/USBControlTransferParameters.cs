using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// 
    /// https://developer.mozilla.org/en-US/docs/Web/API/USBDevice/controlTransferOut#setup
    /// </summary>
    public class USBControlTransferParameters
    {
        /// <summary>
        /// Must be one of three values specifying whether the transfer is "standard" (common to all USB devices) "class" (common to an industry-standard class of devices) or "vendor".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RequestType { get; set; }
        /// <summary>
        /// Specifies the target of the transfer on the device, one of "device", "interface", "endpoint", or "other".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Recipient { get; set; }
        /// <summary>
        /// A vendor-specific command.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Request { get; set; }
        /// <summary>
        /// Vendor-specific request parameters.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Value { get; set; }
        /// <summary>
        /// The interface number of the recipient.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Index { get; set; }
    }
}
